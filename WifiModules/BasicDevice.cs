using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageWarehouse;

namespace WifiModules
{
    public abstract class BasicDevice
    {
        private Util.RcpBuilder _rcpBuilder = new Util.RcpBuilder();
        private RcpRequestParser _rcpRequestParser = new RcpRequestParser();
        protected static string _bundleId = null;

        public abstract string GetDeviceCapResp();

        public abstract string ResetCommand();

        public abstract string GetWifiStat();

        public abstract string GetChargeStateResp(string id);

        public abstract string GetVersionResp(string id);

        public abstract string GetBatteryInfoResp(string id);

        public abstract string GetCleanReportResp(string id);

        public abstract string GetCleanReportResp1(string id,string cleanType);

        public abstract string CleanResp(string id);

        public abstract string GetLogResp(string id);

        public abstract string GetLifeSpan(string id);
        
        public abstract string AddSched(string id);
        
        public abstract string ModSched(string id);

        public abstract string DelSched(string id);

        public abstract string GetSchedResp(string id);

        public abstract string NotifyError(int errorNumber);

        public abstract string StartClean(string cleanType);

        protected string BuildChanneCResponse(string message)
        {
            return _rcpBuilder.BuildChannleC(message);
        }

        protected string BuildChanneRResponse(string id, string message)
        {
            return _rcpBuilder.BuildChannelR(id, message);
        }

        protected string BuildChanneBResponse(string message)
        {
            return _rcpBuilder.BuildChannelB(message);
        }

        protected string BuildChanneAResponse(string id, string message)
        {
            return _rcpBuilder.BuildChannelA(id, message);
        }

        protected string BuildChanneDResponse(string message)
        {
            return _rcpBuilder.BuildChannelD(message);
        }

        //TODO: Add Auto Response Logic Here
        public void AutoResponse(string req, Action<string> writer)
        {
            var dataFlow = new DataModel.RcpDataFlow(req);
            var type = _rcpRequestParser.GetRequestType(dataFlow.RcpMessage);
            if (!String.IsNullOrEmpty(dataFlow.BundleId))
            {
                _bundleId = dataFlow.BundleId;
            }
            if (type == RcpRequestType.GetDeviceCap)
            {
                writer?.Invoke(GetDeviceCapResp());
            }
            else if (type == RcpRequestType.GetVersion)
            {
                writer?.Invoke(GetVersionResp(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.GetBatteryInfo)
            {
                writer?.Invoke(GetBatteryInfoResp(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.GetCleanState)
            {
                writer?.Invoke(GetCleanReportResp(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.GetSched)
            {
               // writer?.Invoke(GetSchedResp(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.CleanAuto)
            {
                writer?.Invoke(GetCleanReportResp1(dataFlow.BundleId,"auto"));
            }
            else if (type == RcpRequestType.CleanSingleRoom)
            {
                writer?.Invoke(GetCleanReportResp1(dataFlow.BundleId, "singleRoom"));
            }
            else if (type == RcpRequestType.CleanBorder)
            {
                writer?.Invoke(GetCleanReportResp1(dataFlow.BundleId, "border"));
            }
            else if (type == RcpRequestType.CleanSpot)
            {
                writer?.Invoke(GetCleanReportResp1(dataFlow.BundleId, "spot"));
            }
            else if (type == RcpRequestType.CleanStop)
            {
                writer?.Invoke(GetCleanReportResp1(dataFlow.BundleId, "stop"));
            }
            else if (type == RcpRequestType.GetLog)
            {
                writer?.Invoke(GetLogResp(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.GetLifeSpan)
            {
                writer?.Invoke(GetLifeSpan(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.GetLifeSpan)
            {
                writer?.Invoke(GetLifeSpan(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.AddSched)
            {
                writer?.Invoke(AddSched(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.ModSched)
            {
                writer?.Invoke(ModSched(dataFlow.BundleId));
            }
            else if (type == RcpRequestType.DelSched)
            {
                writer?.Invoke(DelSched(dataFlow.BundleId));
            }
        }
    }
}
