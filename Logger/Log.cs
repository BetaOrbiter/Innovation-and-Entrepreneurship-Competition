using Profile;
using System.Net.Sockets;

namespace MyTool
{
    public sealed class Log
    {
        private static readonly Lazy<Log> uniqueInstance = new(() => new Log());

        public string RemoteIp { get; set; }
        public int Port { get; set; }
        public string FileName;
        public Action<LogType, string> Record;

        private readonly int Index;

        public static Log GetInstance() => uniqueInstance.Value;

        private Log()
        {
            var profile = Configuration.GetInstance();

            RemoteIp = profile.RemoteIP;
            Port = profile.LogPort;
            FileName = profile.LogFileName;
            Index = profile.Id;

            Record = WriteToFile;
            using var useless = File.CreateText(FileName);
        }

        private void WriteToFile(LogType type, string message)
        {
            var line = $"[{Environment.MachineName}]:<{DateTime.Now:yyyy:MM:dd:HH:mm:ss}>[{type}]:{message}{Environment.NewLine}";
            lock (uniqueInstance.Value)
            {
                File.AppendAllText(FileName, line);
            }
        }

        public void SendToRemote()
        {
            lock (uniqueInstance.Value)
            {
                using Socket socket = new(SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(RemoteIp, Port);
                socket.Send(BitConverter.GetBytes(Index));
                socket.SendFile(FileName);
                socket.Shutdown(SocketShutdown.Both);
            }
        }
    }
}