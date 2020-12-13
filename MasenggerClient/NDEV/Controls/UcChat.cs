using MasenggerModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MasenggerClient.NDEV.Controls
{
    public partial class UcChat : UserControl
    {
        public int IdGrupo = -1;
        public string NickUsuarioRemitente = string.Empty;

        string Mensajes = string.Empty;

        ServerConnection conn = ServerConnection.GetConnection();

        public UcChat()
        {
            InitializeComponent();
        }

        private void UcChat_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(ParentForm, ex);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al dar click al botón de enviar, este envia un mensaje al grupo publico general
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e">Evento</param>
        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                btnEnviar.Enabled = false;

                if (!ValidarGrupo())
                {
                    btnEnviar.Enabled = true;
                    return;
                }

                if (string.IsNullOrEmpty(txtMensaje.Text))
                {
                    Fun.MsgWarning(ParentForm, "Ingresa un mensaje antes de enviarlo");
                    btnEnviar.Enabled = true;
                    return;
                }

                Mensaje mensaje = new Mensaje()
                {
                    Id = 0,
                    IdUsuario = conn.Usuario.Id,
                    IdGrupo = 0,
                    IdUsuarioRemitente = 0,
                    NickUsuarioRemitente = NickUsuarioRemitente,
                    RutaContenido = string.Empty,
                    Binario = (byte[])null,
                    Contenido = txtMensaje.Text,
                    FechaAlta = DateTime.Now
                };

                conn.Send("mensaje_nuevo", mensaje);
                txtMensaje.Clear();
                txtMensaje.Focus();
                btnEnviar.Enabled = true;
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(ParentForm, ex);
                btnEnviar.Enabled = true;
            }
        }

        /// <summary>
        /// Evento al dar click en el botón
        /// </summary>
        /// <param name="sender">Botón</param>
        /// <param name="e">Evento</param>
        private void btnEnviarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                btnEnviarArchivo.Enabled = false;

                if (!ValidarGrupo())
                {
                    btnEnviarArchivo.Enabled = true;
                    return;
                }

                DialogResult result = openFileDialog.ShowDialog(this);

                if (result != DialogResult.OK)
                {
                    btnEnviarArchivo.Enabled = true;
                    return;
                }
                
                string nombre = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string extension = Path.GetExtension(openFileDialog.FileName);

                Mensaje mensaje = new Mensaje()
                {
                    Id = 0,
                    IdUsuario = conn.Usuario.Id,
                    IdGrupo = 0,
                    IdUsuarioRemitente = 0,
                    NickUsuarioRemitente = NickUsuarioRemitente,
                    RutaContenido = openFileDialog.FileName,
                    Binario = File.ReadAllBytes(openFileDialog.FileName),
                    Contenido = $"#file:{nombre}{extension}",
                    FechaAlta = DateTime.Now
                };

                conn.Send("mensaje_archivo_nuevo", mensaje);

                btnEnviarArchivo.Enabled = true;
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(ParentForm, ex);
                btnEnviarArchivo.Enabled = true;
            }
        }

        #region "EVENTOS ASINCRONOS"

        /// <summary>
        /// Se ejecuta al momento de dar click a un archivo de la caja de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rTxtMensajes_LinkClickedAsync(object sender, LinkClickedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.LinkText))
                {
                    return;
                }

                string[] parts = e.LinkText.Split('/');

                if (parts.Length != 4)
                {
                    return;
                }

                int idMensaje = Convert.ToInt32(parts[2]);
                conn.Send("file_get", Convert.ToString(idMensaje), false);
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(ParentForm, ex);
            }
        }

        #endregion

        #region "METODOS ASINCRONOS"

        private delegate void FillMessagesDelegate(Response res);

        /// <summary>
        /// Hace una petición al servidor con la lista de los mensajes dependiendo de los filtros
        /// </summary>
        /// <param name="idGrupo">Id del grupo (0 si es el grupal)</param>
        /// <param name="idUsuario">Id del usuario emisor (0 si es grupal)</param>
        /// <param name="idUsuarioRemitente">Id usuario remitente (0 si es grupal)</param>
        public void FillMessages(Response res)
        {
            if (rTxtMensajes.InvokeRequired)
            {
                _ = Invoke(new FillMessagesDelegate(FillMessages), res);
            }
            else
            {
                try
                {
                    string mensajesNuevos = string.Empty;
                    List<Mensaje> mensajes = JsonConvert.DeserializeObject<List<Mensaje>>(Convert.ToString(res.Value));

                    foreach (Mensaje mensaje in mensajes)
                    {
                        mensajesNuevos += $"{mensaje.Contenido}\n";
                    }

                    // si los mensajes obtenidos son iguales a los mensajes anteriores
                    // no se hace nada (para que)
                    if (Mensajes != mensajesNuevos)
                    {
                        ClearMessages();
                        rTxtMensajes.Visible = false;

                        Mensajes = mensajesNuevos;
                        rTxtMensajes.Text = Mensajes;
                        Fun.ConvertTextToFileLinks(rTxtMensajes);
                        Fun.ConvertTextToEmojis(rTxtMensajes);

                        ScrollMessagesToEnd();

                        rTxtMensajes.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Fun.MsgErrorException(ParentForm, ex);
                    rTxtMensajes.Visible = true;
                }
            }
        }

        private delegate void AddMessageDelegate(string text);

        /// <summary>
        /// Agrega un mensaje a la caja de texto de los mensajes
        /// </summary>
        /// <param name="text">Texto del mensaje</param>
        public void AddMessage(string text)
        {
            if (rTxtMensajes.InvokeRequired)
            {
                _ = Invoke(new AddMessageDelegate(AddMessage), text);
            }
            else
            {
                Mensajes += $"{text}\n";
                rTxtMensajes.Text = Mensajes;

                Fun.ConvertTextToFileLinks(rTxtMensajes);
                Fun.ConvertTextToEmojis(rTxtMensajes);
            }
        }

        private delegate void ClearMessagesDelegate();

        /// <summary>
        /// Limpia la caja de los mensajes
        /// </summary>
        public void ClearMessages()
        {
            if (rTxtMensajes.InvokeRequired)
            {
                _ = Invoke(new ClearMessagesDelegate(ClearMessages));
            }
            else
            {
                rTxtMensajes.Clear();
                rTxtMensajes.Controls.Clear();
                Mensajes = string.Empty;
            }
        }

        #endregion

        #region "METODOS"

        /// <summary>
        /// Indica si el grupo asignado o usuario emisor y remitente (privado) este establecido
        /// </summary>
        /// <returns></returns>
        private bool ValidarGrupo()
        {
            if (IdGrupo == -1 && string.IsNullOrEmpty(NickUsuarioRemitente))
            {
                Fun.MsgWarning(ParentForm, "No se ha seleccionado un grupo o un usuario para enviar el mensaje");
                return false;
            }

            if (IdGrupo == 0)
            {
                return true;
            }

            return true;
        }

        /// <summary>
        /// Evento que se ejecuta al dar click a un emoji, inserta el formato del emoji en la caja de texto de mensaje
        /// </summary>
        /// <param name="sender">PictureBox</param>
        /// <param name="e">Evento</param>
        private void InsertarEmoji(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            txtMensaje.Text += $"#emoji:{pb.Tag}#";
            txtMensaje.SelectionStart = txtMensaje.Text.Length;
            txtMensaje.ScrollToCaret();
        }

        /// <summary>
        /// Scrolea la caja de texto de los mensajes hasta el final
        /// </summary>
        private void ScrollMessagesToEnd()
        {
            rTxtMensajes.SelectionStart = rTxtMensajes.Text.Length;
            rTxtMensajes.ScrollToCaret();
        }

        #endregion
    }
}
