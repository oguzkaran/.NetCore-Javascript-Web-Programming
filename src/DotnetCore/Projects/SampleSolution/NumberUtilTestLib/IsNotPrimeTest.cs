using CSD.Util.Number;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static NUnit.Framework.Assert;

namespace NumberUtilUnitTest
{
    [TestFixture]
    [Author("Batuhan Koru")]
    public class IsNotPrimeTest
    {        
        public static IEnumerable<Tuple<long>> Data 
        {
            get {                
                using var sr = new StreamReader(@"isNotPrime_test.txt");

                string line;

                while ((line = sr.ReadLine()) != null)
                    yield return new Tuple<long>(long.Parse(line));                
            }
        }

        [Test, TestCaseSource("Data")]
        public void TestIsNotPrime(Tuple<long> dataInfo)
        {
            IsFalse(NumberUtil.IsPrime(dataInfo.Item1));            
        }

        [Test, TestCase(10), TestCase(12), TestCase(22)]
        public void TestNotIsPrime2(long val)
        {
            IsFalse(NumberUtil.IsPrime(val));
        }
    }
}
