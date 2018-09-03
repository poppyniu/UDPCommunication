using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiModules.DataModel
{
    class RcpDataFlow
    {
        public string BundleId { get; private set; }
        public string RcpMessage { get; private set; }

        public RcpDataFlow(string input)
        {
            var subInput = input.Split('\0');
            var channel = subInput[0].Substring(0, 3);
            if (channel == "`FC")
            {
                RcpMessage = subInput[0].Replace("`FC", "");
            }
            else if (channel == "`FA")
            {
                BundleId = subInput[1];
                RcpMessage = subInput[2];
            }
        }
    }
}
