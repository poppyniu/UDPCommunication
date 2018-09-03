using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestMessage
    {
        [Test]
        public void TestPackingPayload()
        {
            var device = new WifiModules.DW700();
            var message = device.GetChargeStateResp("UnitTest");
            Console.WriteLine(message);
        }
    }
}
