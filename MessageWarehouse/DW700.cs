using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageWarehouse
{//TODO： Parse Control Message Here
    public class DW700 : CommonDevice
    {
        public string DeviceId = "Ezhuangyan2018092509@101.ecorobot.net/atom";

        public string GetDeviceCapResp
        {
            get
            {
                var raw = @"<ctl td='DeviceCap' c='s'><MID>{DeviceId}</MID><key>123456</key><class>101</class><acs v='setting,userman,clean'/><acms><acm ac='userman' td='GetUserInfo,AddUser,DelUser,SetAC,GetAccessControl,SetAccessControl'/><acm ac='clean' td='PushRobotNotify,Move,GetChargeState,ChargeState,Clean,GetCleanState,GetBatteryInfo,CleanReport,GetLog,Log'/><acm ac='setting' td='SetTime,AddSched,ModSched,DelSched,Sched2,EmptyLog'/><acm ac='' td='BatteryInfo,LifeSpan,error'/></acms></ctl>";
                return raw.Replace("{DeviceId}", DeviceId);
            }
        }

        /// <summary>
        /// *type: 
        // Going - 返回途中, 
        // SlotCharging - 在充电座上充电,  
        // WireCharging - 线充, 
        // Idle - 正常状态
        /// </summary>
        public string GetChargeStateResp
        {
            get
            {
                return "<ctl td='ChargeState'><charge type='Idle'/></ctl>";
            }
        }

        public string GetVersionResp
        {
            get
            {
                return "<ctl td='version'><ver name='FW'>0.16.1</ver></ctl>";
            }
        }

        public string GetBatteryInfoResp
        {
            get
            {
                return "<ctl td='BatteryInfo'><battery power='10'/></ctl>";
            }
        }

        /// <summary>
        /// * type:
        //* auto-自动, 
        //* spot-定点, 
        //* border-沿边, 
        //* singleRoom-单间,
        //* stop - 清扫停止
        /// </summary>
        public string GetCleanReportResp
        {
            get
            {
                return "<ctl td='CleanReport'><clean type='stop'/></ctl>";
            }
        }

        public string GetLogResp
        {
            get
            {
                return "<ctl td='Log' time='2018 - 11 - 11 11:11' evt='1'/>";
            }
        }

        public string GetLifeSpanResp
        {
            get
            {
                return "<ctl ret='ok' errno='' type='SideBrush' left='50' total='100'/>";
            }
        }

        public string AddSchedResp
        {
            get
            {
                return "<ctl id='req_resp_id' ret='ok'/>";
            }
        }

        public string ModSchedResp
        {
            get
            {
                return "<ctl id='req_resp_id' ret='ok'/>";
            }
        }

        public string DelSchedResp
        {
            get
            {
                return "<ctl id='req_resp_id' ret='ok'/>";
            }
        }


        public string GetCleanReportResp1(string cleanType)
        {
            {
                return $"<ctl td='CleanReport'><clean type='{cleanType}' speed='20'/></ctl>";
            }

        }

        public string CleanResp
        {
            get
            {
                return "< ctl td = 'Clean'>< clean type = 'auto'/></ ctl >";
            }

        }

        public string GetSchedResp
        {
            get
            {
                return "<ctl td='Sched2' id='req_resp_id'><s n='15390502766071' o='1' t='12:10' r='0000001'><ctl td='clean' type='auto'/></s></ctl>";
            }
        }

        public string GetErrorNumberResp(int number)
        {
            return $"<ctl td='error' errno='{number}'/>";
        }


        /// <summary>
        //* type:
        //* auto-自动, 
        //* spot-定点, 
        //* border-沿边, 
        //* singleRoom-单间,
        //* stop - 清扫停止
        /// </summary>
        public string GetStartCleanResp(string type)
        {
            return $"< ctl td = 'Clean'>< clean type = '{type}'/></ ctl >";
        }
    }
}
