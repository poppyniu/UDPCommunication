using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WfiModuleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var communicator = new SerialPortCommunicator(GetPortName());
            var readThread = new Thread(communicator.Read);
            communicator.Start();
            readThread.Start();
            WriteAsMainThread();
            readThread.Join();
            communicator.Stop();
        }

        public static void WriteAsMainThread()
        {
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            string command;
            bool _continue = true;
            while (_continue)
            {
                command = Console.ReadLine();

                if (command == "1")
                {
                    var message = GetConstant();
                    _serialPort.WriteLine(constant);
                    Console.WriteLine(constant);
                }
                if (stringComparer.Equals("q", command))
                {
                    _continue = false;
                }
            }
        }

        public static string GetPortName()
        {
            var defaultPortName = "COM1";
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPortCommunicator.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter COM port value (Default: {0}): ", defaultPortName);
            portName = Console.ReadLine();

            if (portName == "" || !(portName.ToLower()).StartsWith("com"))
            {
                portName = defaultPortName;
            }
            return portName;
        }
    }
}
