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
            //线程1:串口从控制台读数据然后自动回复
            tasks.Add(Task.Run(() =>
            {
                _commInstance.Read(output);
            }));
            //线程2: 如果收到控制台传入的指令，将指令格式化以后写入串口及控制台
            tasks.Add(Task.Run(() =>
            {
                _commInstance.Write(input);
            }));
            //线程3: 让地宝一直保持心跳
            tasks.Add(Task.Run(() =>
            {
                _commInstance.Heartbeat(output);
            }));
            //线程4: 开启udp通信
            tasks.Add(Task.Run(() =>
            {
                _udpInstance.Run(output);
            }));
            Task.WaitAll(tasks.ToArray());
        }
    }
}
