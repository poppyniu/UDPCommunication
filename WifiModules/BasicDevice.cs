using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModules
{
    public abstract class BasicDevice
    {
        private string StartChar
        {
            get
            {
                return "`F";
            }
        }

        private string EndChar
        {
            get
            {
                return "\n";
            }
        }

        public abstract string GetDeviceCapRespContent();

        protected string PackingMessage(string channel, string message)
        {
            var resp = StartChar;
            resp += channel.ToUpper();
            resp += Util.SlipPacketBuilder.BuildMessage(message);
            resp += EndChar;
            return resp;
        }
    }
}
