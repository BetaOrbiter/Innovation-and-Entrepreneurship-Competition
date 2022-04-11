using System.Net;
using System.Net.Sockets;
using Profile;
using Newtonsoft.Json;

namespace Server
{
    internal class ProfileServer : ServerBase
    {
        /// <summary>
        /// 被测机id,每接受一次请求自增一
        /// </summary>
        private int Index;
        
        /// <summary>
        /// 配置类，由配置文件映射得到
        /// </summary>
        private readonly Configuration profile;

        internal ProfileServer(IPAddress listenIp, int port, string fileName) 
            : base(listenIp, port)
        {
            Index = 0;
            profile = Configuration.GetInstance(fileName)!;
        }

        internal override void Service(object? obj)
        {
            int myIndex;
            string buffer;
            //保证不同链接编号不同
            lock (this)
            {
                myIndex = Index++;
                profile.Id = myIndex;
                buffer = JsonConvert.SerializeObject(profile);
            }
            using Socket socket = (Socket)obj!;
            socket.Send(System.Text.Encoding.UTF8.GetBytes(buffer));
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}
