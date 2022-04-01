using Server;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class LogServer : ServerBase
    {
        /// <summary>
        /// log文件夹
        /// </summary>
        public readonly string LogFloder;
        
        internal LogServer(IPAddress listenIp, int port, string logPath) : base(listenIp, port)
        {
            LogFloder = logPath;
        }

        internal override void Service(object? obj)
        {
            using Socket socket = (Socket)obj!;
            
            //接受包头文件编号
            byte[] indexByte = new byte[sizeof(int)];
            int byteRead = 0;
            do{
                byteRead += socket.Receive(indexByte, byteRead, indexByte.Length - byteRead, SocketFlags.Peek);
            } while (byteRead < indexByte.Length);
            int index = BitConverter.ToInt32(indexByte);
            
            //接收文件
            using var output = File.Create(Path.Combine(LogFloder,$"log_{index}.log"));
            var buffer = new byte[1500];
            while ((byteRead = socket.Receive(buffer)) > 0)
            {
                output.Write(buffer, 0, byteRead);
            }

            socket.Shutdown(SocketShutdown.Both);
        }
    }
}
