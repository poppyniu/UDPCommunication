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
            try
            {
                doc.LoadXml(message);
            }
            catch (Exception)
            {
                return RcpRequestType.NotDefined;
            }
            var node = doc.SelectSingleNode("//ctl[@td]");
            var node1 = doc.SelectSingleNode("//clean[@type]");
            if (node == null )
            {
                return RcpRequestType.NotDefined;
            }
            var td = node.Attributes[0].Value;
            var cleanType = "";
            if (node1!=null)
            {
                cleanType= node1.Attributes[0].Value; 
            }
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
            if (td == "GetLog")
            {
                return RcpRequestType.GetLog;
            }
            if (td == "Clean" && cleanType == "auto")
            {
                return RcpRequestType.CleanAuto;
            }
            if (td == "Clean" && cleanType == "singleRoom")
            {
                return RcpRequestType.CleanSingleRoom;
            }
            if (td == "Clean" && cleanType == "border")
            {
                return RcpRequestType.CleanBorder;
            }
            if (td == "Clean" && cleanType == "spot")
            {
                return RcpRequestType.CleanSpot;
            }
            if (td == "Clean" && cleanType == "stop")
            {
                return RcpRequestType.CleanStop;
            }
            if (td == "GetLifeSpan")
            {
                return RcpRequestType.GetLifeSpan;
            }
            if (td == "AddSched")
            {
                return RcpRequestType.AddSched;
            }
            if (td == "GetSched")
            {
                return RcpRequestType.GetSched;
            }
            if (td == "ModSched")
            {
                return RcpRequestType.ModSched;
            }
            if (td == "DelSched")
            {
                return RcpRequestType.DelSched;
            }
            return RcpRequestType.NotDefined;
        }
    }
}
