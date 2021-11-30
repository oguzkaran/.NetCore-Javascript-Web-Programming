using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberUtilUnitTest
{
    [TestFixture]
    [Author("A. Burak Gökbayrak")]
    public class IsPrimeTest
    {
        [Test]
        public void TestIsPrime()
        {
            var a = 10;
            var b = 20;
            var result = 40;

            Assert.AreEqual(result, a + b);
        }
    }
}
