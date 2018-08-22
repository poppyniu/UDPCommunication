using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfiModuleDemo
{
    class SerialPortCommunicator
    {
        private SerialPort _serialPort;
        private bool _continueFlag = true;

        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public SerialPortCommunicator(string serialPortName)
        {
            _serialPort = new SerialPort
            {
                BaudRate = 115200,
                PortName = serialPortName,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
        }

        public void Start()
        {
            _serialPort.Open();
        }

        public void Stop()
        {
            _continueFlag = false;
        }

        public void Write(string text)
        {
            _serialPort.WriteLine(text);
        }

        public void Read()
        {
            while (_continueFlag)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
            _serialPort.Close();
        }
    }
}
