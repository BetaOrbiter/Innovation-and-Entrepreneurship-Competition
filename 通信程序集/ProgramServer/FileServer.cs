using System.Net;
using System.Net.Sockets;
namespace Server
{
    internal class FileServer : ServerBase
    {
        
        /// <summary>
        /// 待发送文件路径
        /// </summary>
        public readonly string FileName;

        internal FileServer(IPAddress listenIp, int port, string fileName)
            : base(listenIp, port)
        {
            FileName = fileName;
        }

        internal override void Service(object? socketObj)
        {
            using Socket socket = (Socket)socketObj!;
            socket.SendFile(FileName);
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}