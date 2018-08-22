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

        public StrategyImp(string portName)
        {
            _commInstance = new SerialPortCommunicator(portName);
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
            Task.WaitAll(tasks.ToArray());
        }
    }
}
