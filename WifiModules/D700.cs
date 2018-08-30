using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageWarehouse;

namespace WifiModules
{
    public class D700 : BasicDevice
    {
        public override string GetDeviceCapRespContent()
        {
            return PackingMessage("C", MessageWarehouse.D700.GetDeviceCapResp);
        }

        public string ResetCommand()
        {
            return PackingMessage("C", MessageWarehouse.D700.ResetResp);
        }

        public string GetChargeStateResp()
        {
            return PackingMessage("A", MessageWarehouse.D700.GetChargeStateResp);
        }

        public string GetBatteryInfoResp()
        {
            return PackingMessage("A", MessageWarehouse.D700.GetBatteryInfoResp);
        }

        public string GetCleanStateResp()
        {
            return PackingMessage("A", MessageWarehouse.D700.GetCleanStateResp);
        }

        public void AutoResponse(string req, Action<string> writer)
        {
            if (req == MessageWarehouse.D700.GetDeviceCapReq)
            {
                writer?.Invoke(GetDeviceCapRespContent());
            }
            else if (req == MessageWarehouse.D700.GetChargeStateReq)
            {
                writer?.Invoke(GetChargeStateResp());
            }
            else if (req == MessageWarehouse.D700.GetBatteryInfoReq)
            {
                writer?.Invoke(GetBatteryInfoResp());
            }
            else if (req == MessageWarehouse.D700.GetCleanStateReq)
            {
                writer?.Invoke(GetCleanStateResp());
            }
        }
    }
}
