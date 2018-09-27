using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new UdpServer();
            var task = new List<Task>();
                server.Receiver();
            //task.Add(new Task(() =>
            //{
            //    server.Receiver();
            //}));
            while (true)
            {
                var input = Console.ReadLine();
                server.SendMessage();
            }
        }
    }
}
