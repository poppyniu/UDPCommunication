using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModuleServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var portName = GetPortName();
            var controller = new MockerController.StrategyImp(portName);
            controller.Run(Console.WriteLine, Console.ReadLine);
            Console.WriteLine("exit with code 0");
            Console.ReadLine();
        }

        public static string GetPortName()
        {
            var defaultPortName = "COM3";
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in MockerController.Communicator.SerialPortCommunicator.GetPortNames())
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
