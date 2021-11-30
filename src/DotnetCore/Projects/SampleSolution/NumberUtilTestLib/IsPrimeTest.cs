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
    [Author("Abdülkadir Karadağ")]
    public class IsPrimeTest
    {        
        public static IEnumerable<Tuple<long>> Data 
        {
            get {                
                using var sr = new StreamReader(@"isPrime_test.txt");

                string line;

                while ((line = sr.ReadLine()) != null)
                    yield return new Tuple<long>(long.Parse(line));                
            }
        }

        [Test, TestCaseSource("Data")]
        public void TestIsPrime(Tuple<long> dataInfo)
        {
            IsTrue(NumberUtil.IsPrime(dataInfo.Item1));            
        }        
    }
}
