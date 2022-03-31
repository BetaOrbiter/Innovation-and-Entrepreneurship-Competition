using System.Net;
using System.Net.Sockets;

namespace MyServer
{
    internal abstract class ServerBase
    {
        private readonly int port;
        private readonly IPAddress listenIp;

        internal ServerBase(IPAddress listenIp, int port)
        {
            this.port = port;
            this.listenIp = listenIp;
        }
        internal void Listen()
        {
            TcpListener tcpListener = new(listenIp, port);
            tcpListener.Start();
            while (true)
                ThreadPool.QueueUserWorkItem(Service, tcpListener.AcceptSocket());
        }
        internal abstract void Service(object? obj);
    }
}