using System.Net;
using System.Net.Sockets;

namespace MyServer
{
    internal class LogServer : ServerBase
    {
        internal LogServer(IPAddress listenIp, int port, string LogName) : base(listenIp, port)
        {
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
            using var output = File.Create($"log_{index}.log");
            var buffer = new byte[4096];
            while ((byteRead = socket.Receive(buffer)) > 0)
            {
                output.Write(buffer, 0, byteRead);
            }

            socket.Shutdown(SocketShutdown.Both);
            output.Close();
        }
    }
}
