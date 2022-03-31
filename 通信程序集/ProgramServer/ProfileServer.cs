using System.Net;
using System.Net.Sockets;

namespace MyServer
{
    internal class ProfileServer : ServerBase
    {
        private int Index;
        private readonly string FileName;
        internal ProfileServer(IPAddress listenIp, int port, string fileName) : base(listenIp, port)
        {
            Index = 0;
            this.FileName = fileName;
        }

        internal override void Service(object? obj)
        {
            int myIndex;
            lock (this)
            {
                myIndex = Index++;
            }

            using Socket socket = (Socket)obj!;
            socket.SendFile(FileName, BitConverter.GetBytes(myIndex), null, TransmitFileOptions.UseSystemThread);
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}
