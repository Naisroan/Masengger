using MasenggerClient.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Configuration;
using MasenggerModel;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace MasenggerClient
{
    public static class Fun
    {
        public static readonly string SERVER_IP = Convert.ToString(ConfigurationManager.AppSettings["SERVER_IP"]);

        public static readonly int SERVER_PUERTO = Convert.ToInt32(ConfigurationManager.AppSettings["SERVER_PUERTO"]);

        public static readonly string CORREO_CLIENTE = Convert.ToString(ConfigurationManager.AppSettings["CORREO_CLIENTE"]);

        public static readonly int CORREO_PUERTO = Convert.ToInt32(ConfigurationManager.AppSettings["CORREO_PUERTO"]);

        public static readonly string CORREO_EMISOR = Convert.ToString(ConfigurationManager.AppSettings["CORREO_EMISOR"]);

        public static readonly string CORREO_PASSWORD = Convert.ToString(ConfigurationManager.AppSettings["CORREO_PASSWORD"]);

        public static readonly string PATH_DIR_TEMP_FILES = Convert.ToString(ConfigurationManager.AppSettings["PATH_DIR_TEMP_FILES"]);

        /// <summary>
        /// Diccionario de emojis registrados en la aplicacion
        /// </summary>
        private static IDictionary<string, Image> Emoticones = new Dictionary<string, Image>()
        {
            { "xD", Resources.face_with_tears_of_joy_1f602 },
            { ":D", Resources.grinning_face_1f600 },
            { ">:c", Resources.pouting_face_1f621 },
            { "<3.<3", Resources.smiling_face_with_heart_shaped_eyes_1f60d },
            { "n.n", Resources.smiling_face_with_open_mouth_and_smiling_eyes_1f604 },
            { "(y)", Resources.victory_hand_emoji_modifier_fitzpatrick_type_3_270c_1f3fc_1f3fc },
        };

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static DialogResult MsgInfo(Form frmParent, string texto)
        {
            return MessageBox.Show(frmParent, texto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult MsgErrorException(Form frmParent, Exception ex)
        {
            return MessageBox.Show(frmParent, ex.Message, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult MsgError(Form frmParent, string texto)
        {
            return MessageBox.Show(frmParent, texto, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult MsgWarning(Form frmParent, string texto)
        {
            return MessageBox.Show(frmParent, texto, "¡Espere!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult MsgWarningYesNo(Form frmParent, string texto)
        {
            return MessageBox.Show(frmParent, texto, "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Metodo que recorre el texto de la caja de texto y reemplaza el formato de archivo por un link para poder descargarlo
        /// </summary>
        /// <param name="textbox">RichTextBox de los mensajes</param>
        /// <param name="onClickLink">Evento que se ejecutará al hacer click al link del archivo</param>
        public static void ConvertTextToFileLinks(RichTextBox textbox)
        {
            textbox.ReadOnly = false;

            while (textbox.Text.ToLower().Contains("#file:"))
            {
                int initIdx = textbox.Text.ToLower().IndexOf("#file:");

                int idxAux = initIdx + 1;
                int cantidad = 2;

                while (textbox.Text[idxAux] != '#')
                {
                    cantidad++;
                    idxAux++;
                }

                string filePattern = textbox.Text.Substring(initIdx, cantidad);
                string[] parts = filePattern.Replace("#", "").Split(':');
                string nombre = parts[1];
                string id = parts[2];

                textbox.Text = textbox.Text.Replace(filePattern, $"file://{id}/{nombre.Replace(" ", "")}");
            }

            textbox.ReadOnly = true;
        }

        /// <summary>
        /// Metodo que recorre la caja de texto que contiene los mensajes, busca el formato emoji y lo reemplaza por una imagen que corresponde al emoji
        /// </summary>
        /// <param name="textbox">RichTextBox de los mensajes</param>
        public static void ConvertTextToEmojis(RichTextBox textbox)
        {
            textbox.ReadOnly = false;

            foreach (string emoji in Emoticones.Keys)
            {
                string match = $"#emoji:{emoji.ToLower()}#";

                while (textbox.Text.ToLower().Contains(match))
                {
                    int initIdx = textbox.Text.ToLower().IndexOf(match);
                    int cantidad = "#emoji:".Length + emoji.Length + 1;

                    textbox.Select(initIdx, cantidad);
                    Clipboard.SetImage(Emoticones[emoji]);
                    textbox.Paste();
                }
            }

            textbox.ReadOnly = true;
        }

        /// <summary>
        /// Valida la respuesta del servidor
        /// </summary>
        /// <param name="frmParent">Form desde donde esta llamando la función</param>
        /// <param name="response">Respuesta del servidor</param>
        /// <returns>Verdadero si todo es correcto, falso si hay errores o avisos</returns>
        public static bool IsValid(Form frmParent, Response response)
        {
            if (response == null)
            {
                return false;
            }

            if (response.Key == "error" || response.Key == "aviso")
            {
                string strValue = Convert.ToString(response.Value);

                if (strValue == "Cannot access a disposed object.")
                {
                    MsgWarning(frmParent, "Es posible que la conexión se haya desconectado");
                    return false;
                }

                if (strValue == "The stream is currently in use by a previous operation on the stream.")
                {
                    return false;
                }

                MsgError(frmParent, $"Mensaje del servidor:\n\n{response.Value}");
                return false;
            }

            if (response.Key == "disconnect")
            {
                MsgWarning(frmParent, "Se ha desconectado del servidor");
                return false;
            }

            if (response.Status == 404)
            {
                MsgWarning(frmParent, Convert.ToString(response.Value));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Envía un mail a un correo
        /// </summary>
        /// <param name="correoDestinatario">Correo al que se desea mandar el mail</param>
        /// <param name="asunto">Asunto del correo</param>
        /// <param name="body">Contenido del correo</param>
        public static void SendMail(string correoDestinatario, string asunto, string body)
        {
            MailMessage mm = new MailMessage(CORREO_EMISOR, correoDestinatario);
            mm.Subject = asunto;
            mm.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = CORREO_CLIENTE;
            smtp.Port = CORREO_PUERTO;

            NetworkCredential nc = new NetworkCredential(CORREO_EMISOR, CORREO_PASSWORD);
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
            smtp.Send(mm);
        }
    }
}
