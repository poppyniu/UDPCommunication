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
        //TODO： Parse Control Message Here
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
            if (td == "GetChargeState")
            {
                return RcpRequestType.GetChargeState;
            }
            if (td == "GetVersion")
            {
                return RcpRequestType.GetVersion;
            }
            if (td == "GetBatteryInfo")
            {
                return RcpRequestType.GetBatteryInfo;
            }
            if (td == "GetCleanState")
            {
                return RcpRequestType.GetCleanState;
            }
            if (td == "GetSched")
            {
                return RcpRequestType.GetSched;
            }
            return RcpRequestType.NotDefined;
        }
    }
}
