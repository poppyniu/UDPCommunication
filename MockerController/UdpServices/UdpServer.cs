using MockerController.Communicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockerController.UdpServices
{
    class UdpServer
    {
        private Socket server;
        private readonly SerialPortCommunicator _spc;

        public UdpServer(SerialPortCommunicator spc)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6001));
            _spc = spc;
        }

        private void WriteLine(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Run(Action<string> output)
        {
            while (_spc.IsRunning)
            {
                try
                {
                    if (server == null)
                    {
                        server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6001));
                    }
                    EndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
                    var buffer = new byte[1024];
                    //output?.Invoke("Info: Wait for client.");
                    var length = server.ReceiveFrom(buffer, ref point);
                    var message = Encoding.UTF8.GetString(buffer, 0, length);
                    //output?.Invoke(message);
                    HandleRequest(message);
                }
                catch (Exception e)
                {
                    server.Close();
                    server = null;
                }
            }
        }

        private void HandleRequest(string data)
        {
            var subs = data.Split(' ');
            var module = new WifiModules.DW700();
            if (subs[0].ToLower() == "error")
            {
                var message = module.NotifyError(Convert.ToInt32(subs[1]));
                _spc.Write(message);
            }
            else if (subs[0].ToLower() == "clean")
            {
                var message = module.StartClean(subs[1]);
                _spc.Write(message);
            }
            else
            {
                return;
            }
            ResponseToSender();
        }

        private void ResponseToSender()
        {
            EndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);
            var msg = "OK";
            server.SendTo(Encoding.UTF8.GetBytes(msg), point);
            //Console.WriteLine("Info: Udp action is finished.");
        }
    }
}
