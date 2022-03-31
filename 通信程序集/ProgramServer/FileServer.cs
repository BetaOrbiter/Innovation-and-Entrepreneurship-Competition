using System.Net;
using System.Net.Sockets;
namespace MyServer
{
    internal class FileServer : ServerBase
    {
        public readonly string? FileName;

        internal FileServer(IPAddress listenIp, int port, string fileName)
            : base(listenIp, port)
        {
            FileName = fileName;
        }

        internal override void Service(object? socketObj)
        {
            using Socket socket = (Socket)socketObj!;
            socket.SendFile(FileName);
        }
    }
}