using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModules
{
    public class Xianbo : BasicDevice
    {
        MessageWarehouse.XianBo _responsHelper = new MessageWarehouse.XianBo();

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
