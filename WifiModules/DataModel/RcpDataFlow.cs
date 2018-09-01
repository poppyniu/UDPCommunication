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
            BundleId = subInput[1];
            RcpMessage = subInput[2];
        }
    }
}
