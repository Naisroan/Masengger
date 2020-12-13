using Emgu.CV;
using Emgu.CV.Structure;
using MasenggerModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasenggerClient
{
    public partial class FrmMasengger : Form
    {
        #region "ATRIBUTOS"

        FrmLogin FrmLogin;
        ServerConnection conn = ServerConnection.GetConnection();

        Task tkSendRequests;
        Task tkListenResponses;
        CancellationTokenSource canceltknSrcListenResponses = new CancellationTokenSource();
        CancellationTokenSource canceltknSrcSendRequests = new CancellationTokenSource();

        List<Usuario> UsuariosRegistrados = new List<Usuario>();
        List<Usuario> UsuariosConectados = new List<Usuario>();

        #endregion

        public FrmMasengger(FrmLogin frmLogin)
        {
            InitializeComponent();
            FrmLogin = frmLogin;
        }

        private void FrmMasengger_Load(object sender, EventArgs e)
        {
            try
            {
                lblCbTitulo.Text = $"Masengger - {conn.Usuario.Nick}";
                conn.Send("user_list", string.Empty, false);
                StartSendRequets();
                StartListenResponses();
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(this, ex);
            }
        }

        #region "INICIO"

        /// <summary>
        /// Se inicia la tarea que envia constantemente las peticiones al servidor
        /// </summary>
        public void StartSendRequets()
        {
            if (canceltknSrcSendRequests == null || canceltknSrcSendRequests.IsCancellationRequested)
            {
                canceltknSrcSendRequests = new CancellationTokenSource();
            }

            tkSendRequests = Task.Run(() =>
            {
                while (!canceltknSrcSendRequests.IsCancellationRequested)
                {
                    try
                    {
                        if (conn.TcpClient.Connected)
                        {
                            // enviamos peticiones para obtener usuarios conectados
                            conn.Send("user_connected_list", string.Empty, false);

                            // enviamos peticion para obtener los mensajes del grupo o privado
                            if (ucChat.IdGrupo != -1 || !string.IsNullOrEmpty(ucChat.NickUsuarioRemitente))
                            {
                                conn.Send("mensajes_lista", new FiltroLista()
                                {
                                    IdGrupo = ucChat.IdGrupo,
                                    NickRemitente = ucChat.NickUsuarioRemitente,
                                    IdUsuario = conn.Usuario.Id,
                                    IdUsuarioRemitente = 0,
                                });
                            }

                            conn.Send("video_get", string.Empty, false);
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    Thread.Sleep(500);
                }

                return;

            }, canceltknSrcSendRequests.Token);
        }

        /// <summary>
        /// Se inicia la tarea que constantemente recibe las respuestas de las peticiones del servidor que envian
        /// de por la funcion StartSendRequets()
        /// </summary>
        public void StartListenResponses()
        {
            if (canceltknSrcListenResponses == null || canceltknSrcListenResponses.IsCancellationRequested)
            {
                canceltknSrcListenResponses = new CancellationTokenSource();
            }

            tkListenResponses = Task.Run(async () =>
            {
                while (!canceltknSrcListenResponses.IsCancellationRequested)
                {
                    try
                    {
                        if (conn.TcpClient.Connected)
                        {
                            Response res = await conn.Wait();

                            if (!Fun.IsValid(this, res))
                            {
                                continue;
                            }

                            switch (res.Key)
                            {
                                case "user_list":
                                    {
                                        FillUsers(res);
                                        break;
                                    }

                                case "user_connected_list":
                                    {
                                        SetUsersConnected(res);
                                        break;
                                    }

                                case "mensaje_nuevo":
                                    {
                                        break;
                                    }

                                case "mensaje_archivo_nuevo":
                                    {
                                        break;
                                    }

                                case "file_get":
                                    {
                                        GetFile(res);
                                        break;
                                    }

                                case "mensajes_lista":
                                    {
                                        ucChat.FillMessages(res);
                                        break;
                                    }

                                case "video_get":
                                    {
                                        SetFrame(res);
                                        break;
                                    }

                                default:
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                return;

            }, canceltknSrcListenResponses.Token);
        }

        /// <summary>
        /// Se detiene la tarea que lee constantemente las respuestas del servidor
        /// </summary>
        public void StopListenResponses()
        {
            try
            {
                if (tkListenResponses != null && !canceltknSrcListenResponses.IsCancellationRequested)
                {
                    canceltknSrcListenResponses.Cancel(false);
                    tkListenResponses.Wait(3000);
                    canceltknSrcListenResponses.Dispose();
                    tkListenResponses = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Se detiene la tarea que envia constantemente las peticiones al servidor
        /// </summary>
        public void StopSendRequests()
        {
            try
            {
                if (tkSendRequests != null && !canceltknSrcSendRequests.IsCancellationRequested)
                {
                    canceltknSrcSendRequests.Cancel(true);
                    tkSendRequests.Wait();
                    canceltknSrcSendRequests.Dispose();
                    tkSendRequests = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "METODOS"

        private delegate void FillUsersDelegate(Response res);

        private delegate void SetUsersConnectedDelegate(Response res);

        private delegate void SetFrameDelegate(Response res);

        /// <summary>
        /// Recorre la lista de usuarios y establece si estan conectados o no
        /// </summary>
        /// <param name="res"></param>
        private void SetUsersConnected(Response res)
        {
            if (lbUsuarios.InvokeRequired)
            {
                _ = lbUsuarios.Invoke(new SetUsersConnectedDelegate(SetUsersConnected), res);
            }
            else
            {
                List<Usuario> usuariosConectados = JsonConvert.DeserializeObject<List<Usuario>>(Convert.ToString(res.Value));

                if (UsuariosConectados.Count == usuariosConectados.Count)
                {
                    return;
                }

                UsuariosConectados = usuariosConectados;

                for (int i = 0; i < lbUsuarios.Items.Count; i++)
                {
                    string item = (string)lbUsuarios.Items[i];
                    string[] parts = item.Split('-');
                    string nick = string.Empty;

                    if (parts.Length > 1)
                    {
                        nick = parts[0].Replace(" ", "");
                    }
                    else
                    {
                        nick = item;
                    }

                    if (nick == "Chat Grupal")
                    {
                        continue;
                    }

                    Usuario usuario = UsuariosConectados.FirstOrDefault(n => n.Nick == nick);

                    // si no esta en la lista no esta conectado
                    if (usuario == null)
                    {
                        if (item.Contains("activo"))
                        {
                            lbUsuarios.Items[i] = item.Replace(" - activo", "");
                        }
                    }
                    else
                    {
                        if (!item.Contains("activo"))
                        {
                            lbUsuarios.Items[i] = nick + " - activo";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Consulta los usuarios registrados y los llena en el ListBox lbUsuarios
        /// </summary>
        private void FillUsers(Response res)
        {
            try
            {
                if (lbUsuarios.InvokeRequired)
                {
                    _ = lbUsuarios.Invoke(new FillUsersDelegate(FillUsers), res);
                }
                else
                {
                    lbUsuarios.Visible = false;

                    lbUsuarios.Items.Clear();
                    lbUsuarios.Items.Add("Chat Grupal");

                    UsuariosRegistrados = JsonConvert.DeserializeObject<List<Usuario>>(Convert.ToString(res.Value));

                    foreach (Usuario usuario in UsuariosRegistrados)
                    {
                        if (usuario.Nick == conn.Usuario.Nick)
                        {
                            continue;
                        }

                        lbUsuarios.Items.Add(usuario.Nick);
                    }

                    lbUsuarios.Visible = true;
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Esta funcion convierte un mat en bytes para posteriormente hacer un bitmap y 
        /// pinntarlo en el picturebox
        /// </summary>
        /// <param name="frame"></param>
        private void SetFrame(Response res)
        {
            if (pbVideoFrame.InvokeRequired)
            {
                pbVideoFrame.Invoke(new SetFrameDelegate(SetFrame), res);
            }
            else
            {
                try
                {
                    Mat frame = JsonConvert.DeserializeObject<Mat>(Convert.ToString(res.Value));
                    byte[] imageBytes = frame.ToImage<Bgr, byte>().ToJpegData();

                    using (Stream sr = new MemoryStream(imageBytes))
                    {
                        pbVideoFrame.Image = new Bitmap(sr);
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        /// <summary>
        /// Cuando hay una respuesta de una petición de archivo se ejecuta esta función que recibe
        /// los bytes, crea un archivo y lo abre
        /// </summary>
        /// <param name="res"></param>
        private void GetFile(Response res)
        {
            Mensaje mensaje = JsonConvert.DeserializeObject<Mensaje>(Convert.ToString(res.Value));

            if (mensaje != null && !string.IsNullOrEmpty(mensaje.RutaContenido) && mensaje.Binario != null)
            {
                string nombre = Path.GetFileName(mensaje.RutaContenido);
                string ruta = $@"{Fun.PATH_DIR_TEMP_FILES}/{nombre}";

                if (!Directory.Exists(Fun.PATH_DIR_TEMP_FILES))
                {
                    Directory.CreateDirectory(Fun.PATH_DIR_TEMP_FILES);
                }

                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }

                using (var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(mensaje.Binario, 0, mensaje.Binario.Length);
                    Process.Start(ruta);
                }
            }
        }

        #endregion

        #region "EVENTOS"

        /// <summary>
        /// Evento que se ejecuta al cerrar el formulario con la función Close()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StopSendRequests(); // detiene el envio de peticiones
                StopListenResponses(); // detiene la escucha de respuestas
                FrmLogin.Close();
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(this, ex);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al seleccionar un usuario de la lista
        /// y carga los mensajes en el chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ucChat.ClearMessages();

                if (lbUsuarios.SelectedIndex < 0)
                {
                    ucChat.NickUsuarioRemitente = string.Empty;
                    ucChat.IdGrupo = -1;
                    return;
                }

                FiltroLista filtroLista = new FiltroLista();

                if (lbUsuarios.SelectedIndex == 0)
                {
                    filtroLista.IdGrupo = 0;
                    filtroLista.IdUsuario = 0;
                    filtroLista.IdUsuarioRemitente = 0;
                    filtroLista.NickRemitente = string.Empty;
                    ucChat.NickUsuarioRemitente = string.Empty;
                    ucChat.IdGrupo = 0;
                }
                else
                {
                    string strSelectedItem = Convert.ToString(lbUsuarios.SelectedItem);
                    string[] parts = strSelectedItem.Split('-');
                    string strUsuarioRemitente = string.Empty;

                    if (parts.Length > 1)
                    {
                        strUsuarioRemitente = parts[0].Replace(" ", "");
                    }
                    else
                    {
                        strUsuarioRemitente = strSelectedItem;
                    }

                    ucChat.NickUsuarioRemitente = strUsuarioRemitente;
                    ucChat.IdGrupo = 0;

                    filtroLista.NickRemitente = strUsuarioRemitente;
                    filtroLista.IdUsuario = conn.Usuario.Id;
                    filtroLista.IdGrupo = 0;
                    filtroLista.IdUsuarioRemitente = 0;
                }

                conn.Send("mensajes_lista", filtroLista);
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(this, ex);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al pasar el mouse por el botón de cerrar
        /// </summary>
        /// <param name="sender">Label</param>
        /// <param name="e">Evento</param>
        private void lblCbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento que se ejecuta al dar click con el mouse por el botón de minimizar
        /// </summary>
        /// <param name="sender">Label</param>
        /// <param name="e">Evento</param>
        private void lblCbMinimizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// Evento que se ejecuta al pasar el mouse por el Label
        /// </summary>
        /// <param name="sender">Label</param>
        /// <param name="e">Evento</param>
        private void lblCb_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Name == lblCbCerrar.Name)
            {
                lbl.BackColor = Color.IndianRed;
                lbl.ForeColor = Color.White;
            }
            else if (lbl.Name == lblCbMinimizar.Name)
            {
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Evento que se ejecuta al dejar de pasar el mouse por el Label
        /// </summary>
        /// <param name="sender">Label</param>
        /// <param name="e">Evento</param>
        private void lblCb_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Name == lblCbCerrar.Name)
            {
                lbl.BackColor = lbl.Parent.BackColor;
                lbl.ForeColor = Color.White;
            }
            else if (lbl.Name == lblCbMinimizar.Name)
            {
                lbl.BackColor = lbl.Parent.BackColor;
                lbl.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Evento que se ejecuta dar click a la barra superior con la finalidad
        /// de poder mover el formuario sin necesidad de bordes
        /// </summary>
        /// <param name="sender">Label</param>
        /// <param name="e">Evento</param>
        private void pnlControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            Fun.ReleaseCapture();
            Fun.SendMessage(Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
