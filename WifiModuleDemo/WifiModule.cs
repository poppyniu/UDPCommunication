using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfiModuleDemo
{
    class WifiModule
    {
        private char[] StartChar
        {
            get
            {
                return new[] { '`', 'F' };
            }
        }

        private char[] EndChar
        {
            get
            {
                return new[] { '\n' };
            }
        }

        public string SetDeviceCap()
        {

        }

        private string PackingMessage(Channel c, string message)
        {
            var tmp = StartChar;
            tmp.Concat(SlipBuilder.BuildMessage(message));
            tmp.Concat(EndChar);
            return tmp.ToString();
        }

        private char ChannelChar(Channel c)
        {
            switch (c)
            {
                case Channel.A:
                    return 'A';
                case Channel.B:
                    return 'B';
                case Channel.C:
                    return 'C';
                case Channel.D:
                    return 'D';
                default:
                    throw new ArgumentOutOfRangeException("Channel not available");
            }
        }
    }

    enum Channel
    {
        A,
        B,
        C,
        D
    }
}
