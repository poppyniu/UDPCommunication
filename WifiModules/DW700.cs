using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModules
{
    public class DW700 : BasicDevice
    {
        MessageWarehouse.DW700 _responsHelper = new MessageWarehouse.DW700();

        public override string GetChargeStateResp(string id)
        {
            return BuildChanneAResponse(id, _responsHelper.GetChargeStateResp);
        }

        public override string GetDeviceCapResp()
        {
            return BuildChanneCResponse(_responsHelper.GetDeviceCapResp);
        }

        public override string ResetCommand()
        {
            return BuildChanneCResponse(_responsHelper.ResetResp);
        }
    }
}
