/*---------------------------------------------------------------------------------------------------------------------
    .. operatörü ile bir Range oluşturulabilir ve bir diziye indek aralığı olarak verilebilir
----------------------------------------------------------------------------------------------------------------------*/
using System;

namespace CSD
{
    class App
    {
        public static void Main()
        {
            var names = new string[] { "ali", "veli", "selami", "ayşe", "fatma" };

            var range = 1..3;

            foreach (var name in names[range]) //[1, 3)
                Console.WriteLine(name);
        }
    }    
}


