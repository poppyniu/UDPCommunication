using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModules.Util
{
    public class SlipPacketBuilder
    {
        public static string PacketMessage(string message)
        {
            var resp = new StringBuilder();
            resp.Append(message);
            //resp.Replace("\r\n", "\0");
            //resp.Replace("\\", "\\\0x01");
            //resp.Replace("`", "\\\0x02");
            //resp.Replace("\n", "\\\0x03");
            resp.Append('\0');
            resp.Append(CrcCalculator.CRC_8(Encoding.UTF8.GetBytes(resp.ToString())));
            return resp.ToString();
        }

        public static string UnpacketMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
