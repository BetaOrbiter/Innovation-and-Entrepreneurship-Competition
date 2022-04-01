using System.Net;
using System.Net.Sockets;

namespace Server
{
    /// <summary>
    /// 在<see cref="listenIp"/>:<see cref="port"/>处监听<br/>
    /// 向线程池逐一发送<see cref="Service(object?)"/>服务函数<br/>
    /// </summary>
    internal abstract class ServerBase
    {
        private readonly int port;
        private readonly IPAddress listenIp;

        internal ServerBase(IPAddress listenIp, int port)
        {
            this.port = port;
            this.listenIp = listenIp;
        }

        /// <summary>
        /// 监听,发送每个链接<see cref="Socket"/>给<see cref="Service(object?)"/>,并传入线程池
        /// </summary>
        internal void Listen()
        {
            TcpListener tcpListener = new(listenIp, port);
            tcpListener.Start();
            while (true)
                ThreadPool.QueueUserWorkItem(Service, tcpListener.AcceptSocket());
        }

        /// <summary>
        /// 实现类使用<paramref name="obj"/>传入的<see cref="Socket"/>服务客户
        /// </summary>
        /// <param name="obj"><see cref="TcpListener.AcceptSocket"/>返回的<see cref="Socket"/></param>
        internal abstract void Service(object? obj);
    }
}