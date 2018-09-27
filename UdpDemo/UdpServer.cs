using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UdpDemo
{
    class UdpServer
    {
        private Socket server;

        public UdpServer()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000));
        }

        private void WriteLine(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Receiver()
        {
            while (true)
            {
                EndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
                var buffer = new byte[1024];
                var length = server.ReceiveFrom(buffer, ref point);
                var message = Encoding.UTF8.GetString(buffer, 0, length);
                Console.WriteLine(message);
            }
        }

        public void SendMessage()
        {
            EndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6001);
            var resp = new Model.RequestModel { Type = "error", ExpectResponse = "101" };
            var msg = JsonConvert.SerializeObject(resp);
            server.SendTo(Encoding.UTF8.GetBytes(msg), point);
            Console.WriteLine("Info: Udp is sent.");
        }
    }
}
