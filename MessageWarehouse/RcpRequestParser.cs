using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MessageWarehouse
{
    public class RcpRequestParser
    {
        public RcpRequestType GetRequestType(string message)
        {
            var doc = new XmlDocument();
            doc.LoadXml(message);
            var node = doc.SelectSingleNode("//ctl[@td]");
            if (node == null)
            {
                return RcpRequestType.NotDefined;
            }
            var td = node.Attributes[0].Value;
            if (td == "GetDeviceCap")
            {
                return RcpRequestType.GetDeviceCap;
            }
            if (td == "WIFIStat")
            {
                return RcpRequestType.WIFIStat;
            }
            if (td== "GetChargeState")
            {
                return RcpRequestType.GetChargeState;
            }
            Debug.WriteLine($"{td} is not defined");
            return RcpRequestType.NotDefined;
        }
    }
}
