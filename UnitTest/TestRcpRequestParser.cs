using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    class TestRcpRequestParser
    {
        [Test]
        public void ParserType()
        {
            var request = @"<ctl td='AddSched' id='req_resp_id'>
                                <sched time='09:45' repeat='0000001'>
                                    <ctl td='Clean'><clean type='auto'/></ctl>
                                </sched>
                            </ctl>";
            var parser = new MessageWarehouse.RcpRequestParser();
            parser.GetRequestType(request);
        }
    }
}
