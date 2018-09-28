using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModules
   {//TODO： Parse Control Message Here
    public class DW700 : BasicDevice
    {
        MessageWarehouse.DW700 _responsHelper = new MessageWarehouse.DW700();

        public override string GetBatteryInfoResp(string id)
        {
            return BuildChanneAResponse(id, _responsHelper.GetBatteryInfoResp);
        }

        public override string GetChargeStateResp(string id)
        {
            return BuildChanneAResponse(id, _responsHelper.GetChargeStateResp);
        }

        public override string GetCleanReportResp(string id)
        {
            return BuildChanneAResponse(id, _responsHelper.GetCleanReportResp);
        }

        public override string GetDeviceCapResp()
        {
            return BuildChanneCResponse(_responsHelper.GetDeviceCapResp);
        }

        public override string GetSchedResp(string id)
        {
            return BuildChanneAResponse(id, _responsHelper.GetSchedResp);
        }

        public override string GetVersionResp(string id)
        {
            return BuildChanneAResponse(id, _responsHelper.GetVersionResp);
        }

        public override string NotifyError(int errorNumber)
        {
            return BuildChanneBResponse(_responsHelper.GetErrorNumberResp(errorNumber));
        }

        public override string ResetCommand()
        {
            return BuildChanneCResponse(_responsHelper.ResetResp);
        }

        public override string GetWifiStat()
        {
            return BuildChanneCResponse(_responsHelper.GetWifiStat);
        }
    }
}
