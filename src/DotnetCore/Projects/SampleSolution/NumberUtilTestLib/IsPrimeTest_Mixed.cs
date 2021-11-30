using CSD.Util.Number;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberUtilUnitTest
{
    [TestFixture]
    [Author("A. Burak Gökbayrak")]
    public class IsPrimeTest_Mixed
    {        
        public static IEnumerable<Tuple<long, bool>> Data 
        {
            get {                
                using var sr = new StreamReader(@"isPrime_test_mixed.txt");

                string line;

                while ((line = sr.ReadLine()) != null) {
                    var dataInfoStr = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    yield return new Tuple<long, bool>(long.Parse(dataInfoStr[0]), bool.Parse(dataInfoStr[1]));
                }
            }
        }

        [Test, TestCaseSource("Data")]
        public void TestIsPrime(Tuple<long, bool> dataInfo)
        {
            Assert.AreEqual(dataInfo.Item2, NumberUtil.IsPrime(dataInfo.Item1));           
        }

        [Test, TestCase(11, true), TestCase(13, true), TestCase(1, false)]
        public void TestIsPrimeTestCases(long val, bool expected)
        {
            Assert.AreEqual(expected, NumberUtil.IsPrime(val));
        }        
    }
}
