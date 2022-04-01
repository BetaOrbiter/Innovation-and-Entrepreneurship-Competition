using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class ProfileServer : ServerBase
    {
        /// <summary>
        /// 被测机id,每接受一次请求自增一,在文件内容前发送
        /// </summary>
        private int Index;
        
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private readonly string FileName;
        
        internal ProfileServer(IPAddress listenIp, int port, string fileName) 
            : base(listenIp, port)
        {
            Index = 0;
            this.FileName = fileName;
        }

        internal override void Service(object? obj)
        {
            int myIndex;
            //保证不同链接编号不同
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
