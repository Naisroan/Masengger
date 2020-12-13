using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.Linq;

namespace Masengger
{
    public static class Fun
    {
        public enum Log
        {
            Default,
            Server,
            Error,
            Success,
            Warning,
            Disconnect,
            Connect
        }

        private static string GetLogString(Log log)
        {
            switch (log)
            {
                case Log.Error:
                    return "ERROR";
                case Log.Server:
                    return "MASENGGER";
                case Log.Success:
                    return "SUCCESS";
                case Log.Warning:
                    return "WARNING";
                case Log.Connect:
                    return "CONNECT";
                case Log.Disconnect:
                    return "DISCONNECT";
                default:
                    return "LOG";
            }
        }

        public static void PrintLog(Log tipo, string texto)
        {
            Console.WriteLine($"[{DateTime.Now}] - [{GetLogString(tipo)}]: {texto}");
        }

        public static void PrintLog(Log tipo, string texto, string functionName)
        {
            Console.WriteLine($"[{DateTime.Now}] - [{GetLogString(tipo)}]: {functionName}, {texto}");
        }

        public static void PrintLog(string texto)
        {
            Console.WriteLine($"[{DateTime.Now}] - [{GetLogString(Log.Default)}]: {texto}");
        }
    }
}
