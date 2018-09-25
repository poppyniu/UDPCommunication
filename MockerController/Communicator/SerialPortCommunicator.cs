﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockerController.Communicator
{
    public class SerialPortCommunicator
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

        public void Write(Func<string> input)
        {
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            string command;
            var module = new WifiModules.DW700();
            while (_continueFlag)
            {
                var args = input().Split(' ');
                if (args.Length == 0)
                {
                    continue;
                }
                command = args[0];
                if (stringComparer.Equals("q", command))
                {
                    Stop();
                }
                else if (command == "0")
                {
                    var message = module.ResetCommand();
                    Write(message);
                }
                else if (command == "e")
                {
                    if (args.Length < 2)
                    {
                        continue;
                    }
                    var message = module.NotifyError(int.Parse(args[1]));
                    Write(message);
                }
            }
        }

        public void Write(string message)
        {
            _serialPort.WriteLine(message);
            Console.WriteLine(message);
        }

        public void Read(Action<string> messageReadedAction)
        {
            var module = new WifiModules.DW700();
            while (_continueFlag)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    messageReadedAction?.Invoke(message);
                    module.AutoResponse(message, Write);
                }
                catch (TimeoutException) { }
            }
            _serialPort.Close();
        }
    }
}
