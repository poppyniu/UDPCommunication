using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageWarehouse
{
    public enum RcpRequestType
    {
        NotDefined,
        GetDeviceCap,
        WIFIStat,
        GetChargeState,
        GetVersion,
        GetBatteryInfo,
        GetCleanState,
        GetSched,
        CleanReport,
        CleanAuto,
        CleanSingleRoom,
        CleanBorder,
        CleanSpot,
        CleanStop,
        GetLog,
        GetLifeSpan,
        AddSched,
        ModSched,
        DelSched

    }
}
