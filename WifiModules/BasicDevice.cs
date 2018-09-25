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

        public abstract string GetChargeStateResp(string id);

        public abstract string GetVersionResp(string id);

        public abstract string GetBatteryInfoResp(string id);

        public abstract string GetCleanReportResp(string id);

        public abstract string GetSchedResp(string id);

        public abstract string NotifyError(int errorNumber);

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
                return "\n";
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
                writer?.Invoke(GetSchedResp(dataFlow.BundleId));
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
