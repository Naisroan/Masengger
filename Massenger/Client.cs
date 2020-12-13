using Emgu.CV;
using Masengger.NDEV;
using MasenggerModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Masengger
{
    /// <summary>
    /// Cliente o conexión que se recibe a través del TcpListener
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Lista de las conexiones
        /// </summary>
        public static List<Client> Clientes;

        /// <summary>
        /// Frames del video para transmitir a todos los usuarios conectados
        /// </summary>
        public static List<Mat> VideoFrames;

        public static int IndexFrame = 0;

        /// <summary>
        /// Id unico del cliente
        /// </summary>
        public Guid Id;

        /// <summary>
        /// Stream del cliente
        /// </summary>
        public NetworkStream Stream;

        /// <summary>
        /// StreamWritter del cliente para mandarle datos
        /// </summary>
        public StreamWriter Writter;

        /// <summary>
        /// StreamReader del cliente para obtener datos
        /// </summary>
        public StreamReader Reader;

        /// <summary>
        /// Hilo del cliente para recibir peticiones
        /// </summary>
        public Thread Thread;

        /// <summary>
        /// Usuario relacionado con el cliente
        /// </summary>
        public Usuario Usuario;

        /// <summary>
        /// Constructor del cliente, inicia la instancias de los objetos necesarios para la comunicación
        /// entre servidor y dicho cliente
        /// </summary>
        /// <param name="client">Cliente con el que habrá comunicación</param>
        public Client(TcpClient client)
        {
            Id = Guid.NewGuid();
            Stream = client.GetStream();
            Reader = new StreamReader(Stream);
            Writter = new StreamWriter(Stream);
            Thread = new Thread(() => ListenRequests(this));

            if (Clientes == null)
            {
                Clientes = new List<Client>();
            }

            Clientes.Add(this);
        }

        /// <summary>
        /// Inicia el hilo donde ejecutará el método ListenRequests donde se tiene un ciclo
        /// para escuchar peticiones del cliente
        /// </summary>
        public void StartListening()
        {
            Thread.Start();
        }

        /// <summary>
        /// Detiene el hilo de escucha de peticiones del cliente y libera las demas instancias
        /// </summary>
        public void Stop()
        {
            if (Thread != null && Thread.IsAlive && !Thread.Join(1000))
            {
                Thread.Abort();
                Thread = null;
            }

            if (Writter != null)
            {
                Writter.Close();
            }

            if (Reader != null)
            {
                Reader.Close();
            }

            if (Stream != null)
            {
                Stream.Close();
            }

            Client clientToRemove = Clientes.FirstOrDefault(n => n.Id == Id);

            if (clientToRemove != null)
            {
                Clientes.Remove(clientToRemove);
                Fun.PrintLog(Fun.Log.Disconnect, $"El cliente con el Id {clientToRemove.Id} se ha desconectado");
            }
        }

        /// <summary>
        /// Método que contiene una estructura ciclica para escuchar peticiones del cliente
        /// </summary>
        /// <param name="client"></param>
        public async void ListenRequests(Client client)
        {
            while (true)
            {
                try
                {
                    bool isEmptyValue = false;
                    string mensaje = string.Empty;
                    Request request = null;
                    string strRequest = await Reader.ReadLineAsync();

                    if (!DebugRequest(ref request, ref mensaje, ref isEmptyValue, strRequest))
                    {
                        if (!string.IsNullOrEmpty(mensaje))
                        {
                            Fun.PrintLog(Fun.Log.Warning, mensaje, "Masengger.Client.ListenRequests.DebugRequest");
                        }

                        Stop();
                        break;
                    }

                    if (request == null)
                    {
                        continue;
                    }

                    switch (request.Key)
                    {
                        case "login_validuser":
                            {
                                ep_Login_ValidUser(request);
                                break;
                            }

                        case "register_create":
                            {
                                ep_Register_Create(request);
                                break;
                            }

                        case "user_getByNick":
                            {
                                ep_User_GetByNick(request);
                                break;
                            }

                        case "user_list":
                            {
                                ep_User_List(request);
                                break;
                            }

                        case "user_connected_list":
                            {
                                ep_User_Connected_List(request);
                                break;
                            }

                        case "file_get":
                            {
                                ep_File_Get(request);
                                break;
                            }

                        case "mensaje_nuevo":
                            {
                                ep_Mensaje_Nuevo(request);
                                break;
                            }

                        case "mensaje_archivo_nuevo":
                            {
                                ep_Mensaje_Archivo_Nuevo(request);
                                break;
                            }

                        case "mensajes_lista":
                            {
                                ep_Mensajes_Lista(request);
                                break;
                            }

                        case "video_get":
                            {
                                ep_Video_Get(request);
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    // se ignora este error porque al ocurre de parar el hilo, es decir, es un error controlado
                    if (ex.Message == "Thread was being aborted.")
                    {
                        break;
                    }

                    // errores que pasan cuando se pierde la conexión con el cliente de forma inesperada
                    if (ex.Message == "Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host."
                        || ex.Message == "Cannot read from a closed TextReader."
                        || ex.Message.Contains("Cannot access a disposed object.")
                        || ex.Message == "The stream is currently in use by a previous operation on the stream.")
                    {
                        Stop();
                        break;
                    }

                    Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ListenClient");
                }
            }
        }

        /// <summary>
        /// Depura la petición del cliente
        /// </summary>
        /// <param name="request">Es donde se almacena la petición si todo sale bien</param>
        /// <param name="mensaje">Si regresa false, el buffer de mensaje por si hay algún error</param>
        /// <param name="isEmptyValue">Indica que la petición viene con un valor vacio</param>
        /// <param name="request">Es la petición recibida (encriptada)</param>
        /// <returns>Verdadero si no hay anomalias, falso si hay algún error o se desconecta</returns>
        public bool DebugRequest(ref Request request, ref string mensaje, ref bool isEmptyValue, string requestEncrypted)
        {
            try
            {
                if (string.IsNullOrEmpty(requestEncrypted))
                {
                    isEmptyValue = true;
                }
                else
                {
                    request = JsonConvert.DeserializeObject<Request>(requestEncrypted);
                    isEmptyValue = false;

                    string decryptedValue = string.Empty;

                    if (request.IsEncripted)
                    {
                        decryptedValue = Encriptado.Decrypt(Convert.ToString(request.Value), true);
                    }
                    else
                    {
                        decryptedValue = Convert.ToString(request.Value);
                    }

                    request.Value = decryptedValue;

                    if (string.IsNullOrEmpty(request.Key))
                    {
                        return false;
                    }

                    if (request.Key == "disconnect")
                    {
                        Send("disconnect", string.Empty, false);
                        return false;
                    }

                    return true;
                }

                request = null;

                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Envía un respuesta al cliente
        /// </summary>
        /// <typeparam name="T">Cualquier tipo de objeto como valor</typeparam>
        /// <param name="key">Comando de la respuesta</param>
        /// <param name="value">Valor</param>
        /// <param name="applyFormatJsonToValue">Indica si el valor será formateado a json</param>
        public void Send<T>(string key, T value, bool applyFormatJsonToValue = true, int status = 204, bool isEncripted = true)
        {
            try
            {
                Response res = new Response();
                res.Key = key;
                res.IsValueJson = applyFormatJsonToValue;
                res.Status = status;
                res.IsEncripted = isEncripted;

                if (applyFormatJsonToValue)
                {
                    res.Value = JsonConvert.SerializeObject(value);
                }
                else
                {
                    res.Value = value;
                }

                string encryptedValue = string.Empty;

                if (isEncripted)
                {
                    encryptedValue = Encriptado.Encrypt(Convert.ToString(res.Value), true);
                }
                else
                {
                    encryptedValue = Convert.ToString(res.Value);
                }

                res.Value = encryptedValue;

                string resJson = JsonConvert.SerializeObject(res);

                Writter.WriteLine(resJson);
                Writter.Flush();
            }
            catch (Exception ex)
            {
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.Send");
            }
        }

        /// <summary>
        /// Recorre la lista de clientes conectados y libera cada uno de estos
        /// </summary>
        public static void StopListeningAllClients()
        {
            foreach (Client client in Clientes)
            {
                client.Stop();
                Thread.Sleep(1000);
            }
        }

        #region "ENDPOINTS (METODOS PARA INTERACCION DE SERVIDOR - CLIENTE)"

        /// <summary>
        /// Enpoint que se utiliza para validar la existencia de un usuario
        /// </summary>
        /// <param name="request">Recibe una petición con un valor de tipo Usuario</param>
        private void ep_Login_ValidUser(Request request)
        {
            try
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Convert.ToString(request.Value));

                bool isEmpty = false;
                DataSet result = BD.sp_Usuarios_Select(ref isEmpty, usuario.Correo);

                if (isEmpty)
                {
                    Send(request.Key, "Correo y/o contraseña no coinciden", false, 404);
                    return;
                }

                if (usuario.Password != Convert.ToString(result.Tables[0].Rows[0]["Password"]))
                {
                    Send(request.Key, "Correo y/o contraseña no coinciden", false, 404);
                    return;
                }

                usuario.Id = Convert.ToInt32(result.Tables[0].Rows[0]["Id"]);
                usuario.Correo = Convert.ToString(result.Tables[0].Rows[0]["Correo"]);
                usuario.Nick = string.IsNullOrEmpty(Convert.ToString(result.Tables[0].Rows[0]["Nick"])) ? Convert.ToString(result.Tables[0].Rows[0]["Correo"]) : Convert.ToString(result.Tables[0].Rows[0]["Nick"]);
                usuario.Password = Convert.ToString(result.Tables[0].Rows[0]["Password"]);

                Usuario = usuario;

                Send(request.Key, usuario, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_Login_ValidUser");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para el registro de un usuario
        /// </summary>
        /// <param name="request">Recibe una petición con un valor de tipo Usuario</param>
        private void ep_Register_Create(Request request)
        {
            try
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Convert.ToString(request.Value));

                if (BD.sp_Usuarios_Exists(usuario.Nick, string.Empty))
                {
                    Send(request.Key, "El nombre de usuario ya esta en uso", false, 404);
                    return;
                }

                if (BD.sp_Usuarios_Exists(string.Empty, usuario.Correo))
                {
                    Send(request.Key, "El correo ya esta en uso", false, 404);
                    return;
                }

                BD.sp_Usuarios_Insert(usuario);

                Send(request.Key, usuario, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_Register_Create");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para obtener un usuario por su nick
        /// </summary>
        /// <param name="request">Recibe una petición con un valor de tipo string</param>
        private void ep_User_GetByNick(Request request)
        {
            try
            {
                string nick = Convert.ToString(request.Value);

                bool isEmpty = false;
                DataSet result = BD.sp_Usuarios_Select(ref isEmpty, nick);

                if (isEmpty)
                {
                    Send(request.Key, "No se encontró al usuario", false, 404);
                    return;
                }

                Usuario usuario = new Usuario()
                {
                    Id = Convert.ToInt32(result.Tables[0].Rows[0]["Id"]),
                    Correo = Convert.ToString(result.Tables[0].Rows[0]["Correo"]),
                    Nick = string.IsNullOrEmpty(Convert.ToString(result.Tables[0].Rows[0]["Nick"])) ? Convert.ToString(result.Tables[0].Rows[0]["Correo"]) : Convert.ToString(result.Tables[0].Rows[0]["Nick"]),
                    Password = Convert.ToString(result.Tables[0].Rows[0]["Password"])
                };

                Send(request.Key, usuario, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_User_GetByNick");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para obtener un archivo por su Id
        /// </summary>
        /// <param name="request">Recibe una petición con un valor de tipo Mensaje</param>
        private void ep_File_Get(Request request)
        {
            try
            {
                bool isEmpty = false;
                int idMensaje = Convert.ToInt32(Convert.ToString(request.Value));
                DataSet result = BD.sp_Mensajes_Select(ref isEmpty, idMensaje);

                if (isEmpty)
                {
                    Send(request.Key, "No se encontro el mensaje solicitado", false, 404);
                    return;
                }

                DataTable dt = result.Tables[0];

                Mensaje mensaje = new Mensaje()
                {
                    Id = idMensaje,
                    IdGrupo = !Convert.IsDBNull(dt.Rows[0]["IdGrupo"]) ? Convert.ToInt32(Convert.ToString(dt.Rows[0]["IdGrupo"])) : 0,
                    IdUsuario = !Convert.IsDBNull(dt.Rows[0]["IdUsuario"]) ? Convert.ToInt32(Convert.ToString(dt.Rows[0]["IdUsuario"])) : 0,
                    Contenido = !Convert.IsDBNull(dt.Rows[0]["Contenido"]) ? Convert.ToString(dt.Rows[0]["Contenido"]) : string.Empty,
                    RutaContenido = !Convert.IsDBNull(dt.Rows[0]["RutaContenido"]) ? Convert.ToString(dt.Rows[0]["RutaContenido"]) : string.Empty,
                    Binario = !Convert.IsDBNull(dt.Rows[0]["Binario"]) ? (byte[])dt.Rows[0]["Binario"] : null,
                    FechaAlta = !Convert.IsDBNull(dt.Rows[0]["FechaAlta"]) ? Convert.ToDateTime(dt.Rows[0]["FechaAlta"]) : DateTime.Now
                };

                Send(request.Key, mensaje, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_File_Get");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para obtener una lista de mensajes
        /// </summary>
        /// <param name="request">Recibe una petición con un valor de tipo FiltroLista</param>
        private void ep_Mensajes_Lista(Request request)
        {
            try
            {
                FiltroLista filtro = JsonConvert.DeserializeObject<FiltroLista>(Convert.ToString(request.Value));

                bool isEmpty = false;
                DataSet result = BD.sp_Usuarios_Select(ref isEmpty, filtro.NickRemitente);

                Usuario usuarioRemitente = null;

                if (!isEmpty)
                {
                    usuarioRemitente = new Usuario()
                    {
                        Id = Convert.ToInt32(result.Tables[0].Rows[0]["Id"]),
                        Correo = Convert.ToString(result.Tables[0].Rows[0]["Correo"]),
                        Nick = string.IsNullOrEmpty(Convert.ToString(result.Tables[0].Rows[0]["Nick"])) ? Convert.ToString(result.Tables[0].Rows[0]["Correo"]) : Convert.ToString(result.Tables[0].Rows[0]["Nick"]),
                        Password = Convert.ToString(result.Tables[0].Rows[0]["Password"])
                    };
                }

                result = BD.sp_Mensajes_SelectAll(ref isEmpty, filtro.IdUsuario, filtro.IdGrupo, usuarioRemitente != null ? usuarioRemitente.Id : 0);
                List<Mensaje> mensajes = isEmpty ? new List<Mensaje>() : BD.ConvertDataTableToList<Mensaje>(result.Tables[0]);

                Send(request.Key, mensajes, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_Mensajes_Lista");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para insertar un mensaje nuevo
        /// </summary>
        /// <param name="request">Recibe una petición con un valor de tipo Mensaje</param>
        private void ep_Mensaje_Nuevo(Request request)
        {
            try
            {
                if (Usuario == null)
                {
                    Send("error", "El usuario no ha iniciado sesión", false, 404);
                    return;
                }

                Mensaje mensajeRecibido = JsonConvert.DeserializeObject<Mensaje>(Convert.ToString(request.Value));

                if (mensajeRecibido == null)
                {
                    Send("error", "No se ha podido obtener el mensaje recibido", false, 404);
                    return;
                }

                if (string.IsNullOrEmpty(mensajeRecibido.NickUsuarioRemitente) && mensajeRecibido.IdGrupo != 0)
                {
                    // Send("error", "Se requiere un grupo o un usuario remitente", false, 404);
                    return;
                }

                Usuario usuarioRemitente = null;
                Mensaje mensaje = null;

                if (mensajeRecibido.IdGrupo == 0 && string.IsNullOrEmpty(mensajeRecibido.NickUsuarioRemitente))
                {
                    mensaje = new Mensaje()
                    {
                        IdGrupo = 0,
                        IdUsuarioRemitente = 0,
                        IdUsuario = mensajeRecibido.IdUsuario,
                        Contenido = mensajeRecibido.Contenido,
                        RutaContenido = mensajeRecibido.RutaContenido,
                        Binario = mensajeRecibido.Binario,
                        FechaAlta = DateTime.Now
                    };
                }
                else
                {
                    bool isEmpty = false;
                    DataSet result = BD.sp_Usuarios_Select(ref isEmpty, mensajeRecibido.NickUsuarioRemitente);

                    if (isEmpty)
                    {
                        Send("error", "El usuario remitente no existe", false, 404);
                        return;
                    }

                    usuarioRemitente = new Usuario()
                    {
                        Id = Convert.ToInt32(result.Tables[0].Rows[0]["Id"]),
                        Correo = Convert.ToString(result.Tables[0].Rows[0]["Correo"]),
                        Nick = string.IsNullOrEmpty(Convert.ToString(result.Tables[0].Rows[0]["Nick"])) ? Convert.ToString(result.Tables[0].Rows[0]["Correo"]) : Convert.ToString(result.Tables[0].Rows[0]["Nick"]),
                        Password = Convert.ToString(result.Tables[0].Rows[0]["Password"])
                    };

                    mensaje = new Mensaje()
                    {
                        IdGrupo = 0,
                        IdUsuarioRemitente = usuarioRemitente.Id,
                        IdUsuario = mensajeRecibido.IdUsuario,
                        Contenido = mensajeRecibido.Contenido,
                        RutaContenido = mensajeRecibido.RutaContenido,
                        Binario = mensajeRecibido.Binario,
                        FechaAlta = DateTime.Now
                    };
                }

                if (!BD.sp_Mensajes_Insert(mensaje))
                {
                    Send("error", "No se pudo enviar el mensaje", false, 404);
                    return;
                }

                mensaje.Contenido = $"{Usuario.Nick}: {mensaje.Contenido}";
                Send(request.Key, mensaje, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_Mensaje_Nuevo");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para insertar un mensaje nuevo con un archivo
        /// </summary>
        /// <param name="request">Recibe una petición con un valor de tipo Mensaje</param>
        private void ep_Mensaje_Archivo_Nuevo(Request request)
        {
            try
            {
                if (Usuario == null)
                {
                    Send("error", "El usuario no ha iniciado sesión", false, 404);
                    return;
                }

                Mensaje mensajeRecibido = JsonConvert.DeserializeObject<Mensaje>(Convert.ToString(request.Value));

                if (mensajeRecibido == null)
                {
                    Send("error", "No se ha podido obtener el mensaje recibido", false, 404);
                    return;
                }

                if (string.IsNullOrEmpty(mensajeRecibido.NickUsuarioRemitente) && mensajeRecibido.IdGrupo != 0)
                {
                    // Send("error", "Se requiere un grupo o un usuario remitente", false, 404);
                    return;
                }

                Usuario usuarioRemitente = null;
                Mensaje mensaje = null;

                bool isEmpty = false;
                DataSet result = null;

                if (mensajeRecibido.IdGrupo == 0 && string.IsNullOrEmpty(mensajeRecibido.NickUsuarioRemitente))
                {
                    mensaje = new Mensaje()
                    {
                        IdGrupo = 0,
                        IdUsuarioRemitente = 0,
                        IdUsuario = mensajeRecibido.IdUsuario,
                        Contenido = mensajeRecibido.Contenido,
                        RutaContenido = mensajeRecibido.RutaContenido,
                        Binario = mensajeRecibido.Binario,
                        FechaAlta = DateTime.Now
                    };
                }
                else
                {
                    isEmpty = false;
                    result = BD.sp_Usuarios_Select(ref isEmpty, mensajeRecibido.NickUsuarioRemitente);

                    if (isEmpty)
                    {
                        Send("error", "El usuario remitente no existe", false, 404);
                        return;
                    }

                    usuarioRemitente = new Usuario()
                    {
                        Id = Convert.ToInt32(result.Tables[0].Rows[0]["Id"]),
                        Correo = Convert.ToString(result.Tables[0].Rows[0]["Correo"]),
                        Nick = string.IsNullOrEmpty(Convert.ToString(result.Tables[0].Rows[0]["Nick"])) ? Convert.ToString(result.Tables[0].Rows[0]["Correo"]) : Convert.ToString(result.Tables[0].Rows[0]["Nick"]),
                        Password = Convert.ToString(result.Tables[0].Rows[0]["Password"])
                    };

                    mensaje = new Mensaje()
                    {
                        IdGrupo = 0,
                        IdUsuarioRemitente = usuarioRemitente.Id,
                        IdUsuario = mensajeRecibido.IdUsuario,
                        Contenido = mensajeRecibido.Contenido,
                        RutaContenido = mensajeRecibido.RutaContenido,
                        Binario = mensajeRecibido.Binario,
                        FechaAlta = DateTime.Now
                    };
                }

                if (!BD.sp_Mensajes_Insert(mensaje))
                {
                    Send("error", "No se pudo enviar el mensaje", false, 404);
                    return;
                }

                isEmpty = false;
                int? idMensaje = BD.sp_Mensajes_SelectMaxIdentity();

                if (!idMensaje.HasValue)
                {
                    Send(request.Key, "No se encontro el mensaje solicitado", false, 404);
                    return;
                }

                result = BD.sp_Mensajes_Select(ref isEmpty, idMensaje.Value);

                if (isEmpty)
                {
                    Send(request.Key, "No se encontro el mensaje solicitado", false, 404);
                    return;
                }

                DataTable dt = result.Tables[0];

                Mensaje mensajeInsertado = new Mensaje()
                {
                    Id = idMensaje.Value,
                    IdGrupo = !Convert.IsDBNull(dt.Rows[0]["IdGrupo"]) ? Convert.ToInt32(Convert.ToString(dt.Rows[0]["IdGrupo"])) : 0,
                    IdUsuario = !Convert.IsDBNull(dt.Rows[0]["IdUsuario"]) ? Convert.ToInt32(Convert.ToString(dt.Rows[0]["IdUsuario"])) : 0,
                    Contenido = !Convert.IsDBNull(dt.Rows[0]["Contenido"]) ? Convert.ToString(dt.Rows[0]["Contenido"]) : string.Empty,
                    RutaContenido = !Convert.IsDBNull(dt.Rows[0]["RutaContenido"]) ? Convert.ToString(dt.Rows[0]["RutaContenido"]) : string.Empty,
                    Binario = !Convert.IsDBNull(dt.Rows[0]["Binario"]) ? (byte[])dt.Rows[0]["Binario"] : null,
                    FechaAlta = !Convert.IsDBNull(dt.Rows[0]["FechaAlta"]) ? Convert.ToDateTime(dt.Rows[0]["FechaAlta"]) : DateTime.Now
                };

                Send(request.Key, mensajeInsertado, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_Mensaje_Archivo_Nuevo");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para para obtener una lista de los usuarios registrados
        /// </summary>
        /// <param name="request">Recibe una petición que no tiene ningún valor</param>
        private void ep_User_List(Request request)
        {
            try
            {
                bool isEmpty = false;
                DataSet result = BD.sp_Usuarios_SelectAll(ref isEmpty);
                List<Usuario> usuarios = isEmpty ? new List<Usuario>() : BD.ConvertDataTableToList<Usuario>(result.Tables[0]);

                Send(request.Key, usuarios, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_User_List");
            }
        }

        /// <summary>
        /// Endpoint que se utiliza para obtener una lista con los usuarios conectados
        /// </summary>
        /// <param name="request">Recibe una petición que no tiene ningún valor</param>
        private void ep_User_Connected_List(Request request)
        {
            try
            {
                List<Usuario> usuariosConectados = new List<Usuario>();

                foreach (Client client in Clientes)
                {
                    if (client.Usuario == null)
                    {
                        continue;
                    }

                    usuariosConectados.Add(client.Usuario);
                }

                Send(request.Key, usuariosConectados, status: 200);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_User_Connected_List");
            }
        }

        private void ep_Video_Get(Request request)
        {
            try
            {
                Mat frame = VideoFrames[IndexFrame];
                Send(request.Key, frame, status: 200, isEncripted: false);
            }
            catch (Exception ex)
            {
                Send("error", ex.Message, status: 200);
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Client.ep_Video_Get");
            }
        }

        #endregion
    }
}
