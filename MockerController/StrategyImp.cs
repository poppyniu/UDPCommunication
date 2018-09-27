using MockerController.Communicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MockerController
{
    public class StrategyImp
    {
        private SerialPortCommunicator _commInstance;
        private UdpServices.UdpServer _udpInstance;

        public StrategyImp(string portName)
        {
            _commInstance = new SerialPortCommunicator(portName);
            _udpInstance = new UdpServices.UdpServer(_commInstance);
        }

        public void Run(Action<string> output, Func<string> input)
        {
            _commInstance.Start();
            var tasks = new List<Task>();
            tasks.Add(Task.Run(() =>
            {
                _commInstance.Read(output);
            }));
            tasks.Add(Task.Run(() =>
            {
                _commInstance.Write(input);
            }));
            tasks.Add(Task.Run(() =>
            {
                _udpInstance.Run();
            }));
            Task.WaitAll(tasks.ToArray());
        }
    }
}
