using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageWarehouse
{
    public class XianBo : CommonDevice
    {
        public string DeviceId = "E07324e9d7e2487fcaf4@101.ecorobot.net/atom";

        public string GetDeviceCapResp
        {
            get
            {
                var raw = @"<ctl td='DeviceCap' c='s'>
	                        <MID>{DeviceId}</MID>
	                        <key>123456</key>
	                        <class>101</class>
	                        <acs v='setting,userman,clean'/>
	                        <acms>
		                        <acm ac='userman' td='GetUserInfo,AddUser,DelUser,SetAC,GetAccessControl,SetAccessControl'/>
		                        <acm ac='clean' td='PushRobotNotify,Move,GetChargeState,ChargeState,Clean,GetCleanState,GetBatteryInfo,CleanReport,GetLog,Log'/>
		                        <acm ac='setting' td='SetTime,AddSched,ModSched,DelSched,Sched2,EmptyLog'/>
		                        <acm ac='' td='BatteryInfo,LifeSpan,error'/>
	                        </acms>
                        </ctl>";
                return raw.Replace("{DeviceId}", DeviceId);
            }
        }

        public string GetChargeStateResp
        {
            get
            {
                return "<ctl td='ChargeState'><charge type='SlotCharging'/></ctl>";
            }
        }
    }
}
