using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class RtcServer : ServerBase
    {
        internal RtcServer(IPAddress listenIp, int port) : base(listenIp, port)
        {
        }

        /// <summary>
        /// 发送UnixEpoch到现在的秒数
        /// </summary>
        internal override void Service(object? socketObj)
        {
            using Socket socket = (Socket)socketObj!;
            TimeSpan diff = DateTime.UtcNow - DateTime.UnixEpoch;
            byte[] packet = BitConverter.GetBytes(diff.TotalSeconds);
            socket.Send(packet);
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}
