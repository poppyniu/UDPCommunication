using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageWarehouse
{
    public class D700
    {
        public static string GetDeviceCapResp
        {
            get
            {
                return "<ctl td='DeviceCap' c='s'><MID>E07324e9d7e2487fcaf4@101.ecorobot.net/atom</MID><key>123456</key><class>101</class><acs v='setting,userman,clean'/><acms><acm ac='userman' td='GetUserInfo,AddUser,DelUser,SetAC,GetAccessControl,SetAccessControl'/><acm ac='clean' td='PushRobotNotify,Move,GetChargeState,ChargeState,Clean,GetCleanState,GetBatteryInfo,CleanReport,GetLog,Log'/><acm ac='setting' td='SetTime,AddSched,ModSched,DelSched,Sched2,EmptyLog'/><acm ac='' td='BatteryInfo,LifeSpan,error'/></acms></ctl>";
            }
        }

        public static string GetChargeStateResp
        {
            get
            {
                //return @"710475@ecouser.net/171f6975\0\0<ctl td='ChargeState'><charge type='SlotCharging'/></ctl>";
                return "710475@ecouser.net/democ2531404\0\0<ctl td='ChargeState'><charge type='SlotCharging'/></ctl>";
            }
        }

        public static string GetChargeStateReq
        {
            get
            {
                //return "`FA 710475@ecouser.net/171f6975 <ctl td='GetChargeState'/>\0\u0019";//"`FA\0710475@ecouser.net/171f6975\0<ctl td='GetChargeState'/>\0?"
                //  return "`FA\0710475@ecouser.net/171f6975\0<ctl td='GetChargeState'/>\0?";
                return "`FA\0710475@ecouser.net/democ2531404\0<ctl td='GetChargeState'/>\0?";
            }
        }

        public static string GetBatteryInfoReq
        {
            get
            {
                return "`FA\0710475@ecouser.net/171f6975\0<ctl td='GetBatteryInfo'/>\0\\\u0001";//"`FA\0710475@ecouser.net/171f6975\0<ctl td='GetBatteryInfo'/>\0\\\u0001"
            }
        }

        public static string GetBatteryInfoResp
        {
            get
            {
                return @"710475@ecouser.net/171f6975\0\0<ctl td='BatteryInfo'><battery power='100'/></ctl>";
                //`FAtest@domain/atom[\0][\0]<ctl id="random_string" td="BatteryInfo"><battery power="100"/><ctl/>[\0][CRC8][\n]
            }
        }

        public static string GetCleanStateReq
        {
            get
            {
                return "`FA\0710475@ecouser.net/171f6975\0<ctl td='GetCleanState'/>\0?";
            }
        }

        public static string GetCleanStateResp
        {
            get
            {
                return @"710475@ecouser.net/171f6975\0\0<ctl td='CleanReport'><clean type='spot'/></ctl>";
            }
        }

        public static string GetSchedReq
        {
            get
            {
                return "`FA\0710475@ecouser.net/171f6975\0<ctl td='GetSched' id='1508336030' class='CoC'/>\0i";
            }
        }

        public static string GetVersionReq
        {
            get
            {
                return "`FA\0710475@ecouser.net/171f6975\0<ctl td='GetVersion' name='FW'/>\0J";
            }
        }

        public static string SetTimeReq
        {
            get
            {
                return "`FA\0710475@ecouser.net/171f6975\0<ctl id='713' td='SetTime'><time year='2018' month='08' date='29' hour='17' minute='22' second='27' tz='+8'/></ctl>\0*";
            }
        }

        public static string GetDeviceCapReq
        {
            get
            {
                return "`FC<ctl td='GetDeviceCap'/>\0\u0019";
            }
        }
        
        //恢复出厂配网
        public static string ResetResp
        {
            get
            {
                return @"<ctl id='123' td='FactoryRest'/>";
            }
        }
    }


}
