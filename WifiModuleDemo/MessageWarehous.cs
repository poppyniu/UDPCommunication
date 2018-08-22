using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfiModuleDemo
{
    class MessageWarehous
    {
        public string SetDeviceCapMessage()
        {
            return @"<ctl td='DeviceCap'>
                    <MID>xxx@xb.ecorobot.net/atom</MID>
                    <class>XianBao</class>
                    <acs v='setting,userman,clean'/>
                    <acms>
                    <acm ac='userman' td='GetUserInfo,AddUser,DelUser,SetAC,GetAccessControl,SetAccessControl'/>
                    <acm ac='clean' td='Move,ChargeState,Clean,CleanReport,GetChargeState,GetCleanState'/>
                    <acm ac='setting' td='SetSched'/>
                    <acm ac='' td=''/>
                    </acms>
                    </ctl>";
        }
    }
}
