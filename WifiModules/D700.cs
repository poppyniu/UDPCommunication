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

        public void AutoResponse(string req, Action<string> writer)
        {
            if (req == MessageWarehouse.D700.GetDeviceCapReq)
            {
                writer?.Invoke(GetDeviceCapRespContent());
            }
        }
    }
}
