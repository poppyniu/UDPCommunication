﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModules.Util
{
    public class RcpBuilder
    {
        private readonly string StartChar = "`F";
        private readonly string EndChar = "\n";

        private string PackSlipMessage(string message)
        {
            var resp = new StringBuilder();
            resp.Append(message);
            resp.Replace("\r\n", "\0");
            resp.Replace("\\", "\0x01");
            resp.Replace("`", "\0x02");
            resp.Replace("\n", "\0x03");
            resp.Append('\0');
            resp.Append(CrcCalculator.CRC_8(Encoding.UTF8.GetBytes(resp.ToString())));
            //Console.WriteLine("Pack message is:----------{0}",resp);
            return resp.ToString();
        }

        public string BuildChannleC(string message)
        {
            var resp = StartChar;
            resp += "C";
            resp += PackSlipMessage(message);
            resp += EndChar;
            return resp;
        }

        public string BuildChannelA(string id, string message)
        {
            var resp = new StringBuilder();
            resp.Append(StartChar);
            resp.Append("A");
            resp.Append(id);
            resp.Append('\0');
            resp.Append('\0');
            resp.Append(PackSlipMessage(message));
            resp.Append(EndChar);
            return resp.ToString();
        }

        internal string BuildChannelB(string message)
        {
            var resp = new StringBuilder();
            resp.Append(StartChar);
            resp.Append("B");
            resp.Append('\0');
            resp.Append('\0');
            resp.Append(PackSlipMessage(message));
            resp.Append(EndChar);
            return resp.ToString();
        }

        internal string BuildChannelR(string id, string message)
        {
            var resp = new StringBuilder();
            resp.Append(StartChar);
            resp.Append("R");
            resp.Append(id);
            resp.Append('\0');
            resp.Append("x");
            resp.Append(PackSlipMessage(message));
            resp.Append(EndChar);
            return resp.ToString();
        }

        private string PackSlipMessage_temp(string message)
        {
            var resp = new StringBuilder();
            resp.Append(message);
            //resp.Replace("\r\n", "\0");
            //resp.Replace("\\", "\0x01");
            //resp.Replace("`", "\0x02");
            //resp.Replace("\n", "\0x03");
            //resp.Append('\0');
            resp.Append(CrcCalculator.CRC_8(Encoding.UTF8.GetBytes(resp.ToString())));
            return resp.ToString();
        }

        internal string BuildChannelD(string message)
        {
            var resp = new StringBuilder();
            resp.Append(StartChar);
            resp.Append("D");
            resp.Append('\0');
            resp.Append('\0');
            resp.Append(PackSlipMessage(message));
            resp.Append(EndChar);
            return resp.ToString();
        }
    }
}
