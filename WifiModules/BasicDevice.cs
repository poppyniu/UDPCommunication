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

        public abstract string GetDeviceCapResp();

        public abstract string ResetCommand();

        public abstract string GetChargeStateResp(string id);

        protected string BuildChanneCResponse(string message)
        {
            return _rcpBuilder.BuildChannleC(message);
        }

        protected string BuildChanneAResponse(string id, string message)
        {
            return _rcpBuilder.BuildChannelA(id, message);
        }

        public void AutoResponse(string req, Action<string> writer)
        {
            var dataFlow = new DataModel.RcpDataFlow(req);
            var type = _rcpRequestParser.GetRequestType(dataFlow.RcpMessage);
            if (type == RcpRequestType.GetDeviceCap)
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
