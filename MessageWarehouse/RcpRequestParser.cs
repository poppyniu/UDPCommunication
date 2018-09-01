using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
