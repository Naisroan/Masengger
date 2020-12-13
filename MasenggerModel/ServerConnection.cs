using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MasenggerModel
{
    /// <summary>
    /// Clase con los atributos y metodos para la comunicación SERVIDOR -> CLIENTE y viceversa
    /// </summary>
    public class ServerConnection
    {
        #region "ATRIBUTOS"

        /// <summary>
        /// Indicamos que la conexión será unica aplicando Singleton
        /// </summary>
        private readonly static ServerConnection Instance = new ServerConnection();

        /// <summary>
        /// Id única de la conexión
        /// </summary>
        public Guid Id;

        /// <summary>
        /// TcpCliente donde esta la conexión del cliente
        /// </summary>
        public TcpClient TcpClient;

        /// <summary>
        /// Stream del cliente
        /// </summary>
        public NetworkStream TcpStream;

        /// <summary>
        /// StreamWritter del cliente para mandarle datos
        /// </summary>
        public StreamWriter TcpWritter;

        /// <summary>
        /// StreamReader del cliente para obtener datos
        /// </summary>
        public StreamReader TcpReader;

        /// <summary>
        /// Usuario relacionado con el cliente
        /// </summary>
        public Usuario Usuario;

        #endregion

        #region "METODOS"

        /// <summary>
        /// Obtiene la instancia única de la conexión
        /// </summary>
        /// <returns>Objeto de la conexión con el servidor</returns>
        public static ServerConnection GetConnection()
        {
            return Instance;
        }

        /// <summary>
        /// Establece conexión con el servidor
        /// </summary>
        /// <param name="mensaje">Buffer para un mensaje si algo salió mal</param>
        /// <returns>Retorna verdadero si la conexión fue exitosa</returns>
        public bool Connect(ref string mensaje, string ip, int puerto)
        {
            try
            {
                if (TcpClient != null && TcpClient.Connected)
                {
                    return true;
                }

                TcpClient = new TcpClient();
                TcpClient.Connect(ip, puerto);

                if (!TcpClient.Connected)
                {
                    return false;
                }

                TcpStream = TcpClient.GetStream();
                TcpWritter = new StreamWriter(TcpStream);
                TcpReader = new StreamReader(TcpStream);

                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Limpia las instancias de la conexion y manda petición al servidor para
        /// la desconexión
        /// </summary>
        public async void CloseAsync()
        {
            if (TcpClient == null || !TcpClient.Connected)
            {
                return;
            }

            Response res = await SendWait("disconnect", string.Empty, false);

            if (TcpReader != null)
            {
                TcpReader.Close();
                TcpReader = null;
            }

            if (TcpWritter != null)
            {
                TcpWritter.Close();
                TcpWritter = null;
            }

            if (TcpStream != null)
            {
                TcpStream.Close();
                TcpStream = null;
            }

            if (TcpClient != null)
            {
                TcpClient.Close();
                TcpClient = null;
            }

            if (Usuario != null)
            {
                Usuario = null;
            }
        }

        /// <summary>
        /// Envia una petición al servidor y NO espera una respuesta
        /// </summary>
        /// <typeparam name="T">Tipo de valor a enviar</typeparam>
        /// <param name="key">Comando</param>
        /// <param name="value">Valor que se desea enviar junto al comando</param>
        /// <param name="applyFormatJsonToValue">Indica si al valor se formateara a json</param>
        public void Send<T>(string key, T value, bool applyFormatJsonToValue = true, bool isEncripted = true)
        {
            try
            {
                if (TcpClient == null || !TcpClient.Connected)
                {
                    return;
                }

                Request req = new Request();
                req.Key = key;
                req.IsValueJson = applyFormatJsonToValue;
                req.IsEncripted = isEncripted;

                if (applyFormatJsonToValue)
                {
                    req.Value = JsonConvert.SerializeObject(value);
                }
                else
                {
                    req.Value = value;
                }

                string encryptedValue = string.Empty;

                if (isEncripted)
                {
                    encryptedValue = Encriptado.Encrypt(Convert.ToString(req.Value), true);
                }
                else
                {
                    encryptedValue = Convert.ToString(req.Value);
                }

                req.Value = encryptedValue;

                string reqJson = JsonConvert.SerializeObject(req);

                TcpWritter.WriteLine(reqJson);
                TcpWritter.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Envia una petición al servidor y SI espera una respuesta
        /// </summary>
        /// <typeparam name="T">Tipo de valor a enviar</typeparam>
        /// <param name="key">Comando</param>
        /// <param name="value">Valor que se desea enviar junto al comando</param>
        /// <param name="applyFormatJsonToValue">Indica si al valor se formateara a json</param>
        /// <returns>Retorna una instancia tipo Response con los datos recibidos del servidor</returns>
        public async Task<Response> SendWait<T>(string key, T value, bool applyFormatJsonToValue = true)
        {
            try
            {
                if (TcpClient == null || !TcpClient.Connected)
                {
                    return new Response()
                    {
                        Key = "error",
                        Value = "No hay conexión disponible con el servidor",
                        IsValueJson = false
                    };
                }

                Request req = new Request();
                req.Key = key;
                req.IsValueJson = applyFormatJsonToValue;
                req.IsEncripted = true;

                if (applyFormatJsonToValue)
                {
                    req.Value = JsonConvert.SerializeObject(value);
                }
                else
                {
                    req.Value = value;
                }

                string encryptedValue = Encriptado.Encrypt(Convert.ToString(req.Value), true);
                req.Value = encryptedValue;

                string reqJson = JsonConvert.SerializeObject(req);

                await TcpWritter.WriteLineAsync(reqJson);
                await TcpWritter.FlushAsync();

                string strRes = string.Empty;
                string decryptedValue = string.Empty;
                Response res = null;

                int intentos = 3;
                int intentosRealizados = 0;

                do
                {
                    strRes = await TcpReader.ReadLineAsync();
                    res = JsonConvert.DeserializeObject<Response>(strRes);

                    if (res.IsEncripted)
                    {
                        decryptedValue = Encriptado.Decrypt(Convert.ToString(res.Value), true);
                    }
                    else
                    {
                        decryptedValue = Convert.ToString(res.Value);
                    }

                    res.Value = decryptedValue;

                    intentosRealizados++;

                } while (res.Key != key && intentosRealizados < intentos);

                return res;
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Key = "error",
                    Value = ex.Message,
                    IsValueJson = false
                };
            }
        }

        /// <summary>
        /// No envia ninguna petición, solo espera la siguiente respuesta del servidor
        /// </summary>
        /// <returns>Alguna respuesta del servidor</returns>
        public async Task<Response> Wait()
        {
            try
            {
                if (TcpClient == null || !TcpClient.Connected)
                {
                    return new Response()
                    {
                        Key = "error",
                        Value = "No hay conexión disponible con el servidor",
                        IsValueJson = false
                    };
                }

                string strRes = string.Empty;
                string decryptedValue = string.Empty;
                Response res = null;

                strRes = await TcpReader.ReadLineAsync();
                res = JsonConvert.DeserializeObject<Response>(strRes);

                if (res.IsEncripted)
                {
                    decryptedValue = Encriptado.Decrypt(Convert.ToString(res.Value), true);
                }
                else
                {
                    decryptedValue = Convert.ToString(res.Value);
                }

                res.Value = decryptedValue;

                return res;
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Key = "error",
                    Value = ex.Message,
                    IsValueJson = false
                };
            }
        }

        #endregion
    }
}
