using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Emgu.CV;

namespace Masengger
{
    class Program
    {
        #region "ATRIBUTOS"

        /// <summary>
        /// TcpListener que escuchará las nuevas conexiones de los clientes
        /// </summary>
        static TcpListener Tcp;

        #endregion

        static void Main(string[] args)
        {
            try
            {
                Fun.PrintLog(Fun.Log.Server, "Obteniendo información del servidor");

                AppSettingsReader appSettings = new AppSettingsReader();
                int puerto = (int)appSettings.GetValue("SERVER_PUERTO", typeof(int));
                string rutaVideo = (string)appSettings.GetValue("RUTA_VIDEO", typeof(string));

                Fun.PrintLog(Fun.Log.Server, "Creando instancias necesarias");

                if (!File.Exists(rutaVideo))
                {
                    Fun.PrintLog(Fun.Log.Error, $"El vídeo de la ruta {rutaVideo} no existe", "Main{Task.Run}");
                    Thread.Sleep(2000);
                    return;
                }

                VideoCapture video = new VideoCapture(rutaVideo);
                Client.VideoFrames = new List<Mat>();

                while(true)
                {
                    Mat frame = new Mat();
                    video.Read(frame);

                    if (frame.Height != 0)
                    {
                        Client.VideoFrames.Add(frame);

                        continue;
                    }

                    break;
                }

                Tcp = new TcpListener(IPAddress.Any, puerto);
                Client.Clientes = new List<Client>();

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationTokenSource cancellationTokenSourceVideo = new CancellationTokenSource();

                Fun.PrintLog(Fun.Log.Server, "Iniciando escucha de clientes");

                Tcp.Start();

                // iniciamos el hilo en donde escuchará constantemente nuevos clientes
                _ = Task.Run(async () =>
                {
                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        TcpClient tcpClient;

                        try
                        {
                            Fun.PrintLog(Fun.Log.Server, "Esperando cliente...");

                            tcpClient = await Tcp.AcceptTcpClientAsync();
                            Client clienteNuevo = new Client(tcpClient);
                            clienteNuevo.StartListening();

                            Fun.PrintLog(Fun.Log.Connect, $"Cliente #{clienteNuevo.Id} conectado, escucha de peticiones iniciada");
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("Cannot access a disposed object."))
                            {
                                return;
                            }

                            Fun.PrintLog(Fun.Log.Error, ex.Message, "Main{Task.Run}");
                        }
                    }
                }, cancellationTokenSource.Token);

                // iniciamos el hilo en donde constantemente cambiará de frame del video
                _ = Task.Run(() =>
                {
                    while (!cancellationTokenSourceVideo.IsCancellationRequested)
                    {
                        try
                        {
                            if (Client.IndexFrame < Client.VideoFrames.Count - 1)
                            {
                                Client.IndexFrame++;
                            }
                            else
                            {
                                Client.IndexFrame = 0;
                            }

                            Thread.Sleep(100);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }, cancellationTokenSourceVideo.Token);

                Fun.PrintLog(Fun.Log.Server, "Servidor iniciado con exito, presione una tecla para detenerlo");

                // tiene que presionar una tecla para romper el ciclo
                while (!Console.KeyAvailable)
                {
                }

                Fun.PrintLog(Fun.Log.Server, "Deteniendo escucha de clientes");

                cancellationTokenSource.Cancel();
                cancellationTokenSourceVideo.Cancel();
                Thread.Sleep(3000);

                Fun.PrintLog(Fun.Log.Server, "Deteniendo escucha de peticiones de clientes");

                Client.StopListeningAllClients();

                Fun.PrintLog(Fun.Log.Server, "Deteniendo servidor");

                Tcp.Stop();
                Thread.Sleep(1000);

                Fun.PrintLog(Fun.Log.Server, "Servidor detenido con éxito :) hasta pronto");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Fun.PrintLog(Fun.Log.Error, ex.Message, "Main");
                Thread.Sleep(2000);
            }
        }
    }
}
