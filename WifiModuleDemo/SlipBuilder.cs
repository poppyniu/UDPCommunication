using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfiModuleDemo
{
    class SlipBuilder
    {
        public static string BuildMessage(string message)
        {
            var tmp = message.Replace('\n', '\0');
            return tmp;
        }
    }
}
