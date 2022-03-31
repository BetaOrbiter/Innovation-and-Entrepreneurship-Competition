using System.Net;
using System.Net.Sockets;

namespace MyServer
{
    internal class RtcServer : ServerBase
    {
        internal RtcServer(IPAddress listenIp, int port) : base(listenIp, port)
        {
        }

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
