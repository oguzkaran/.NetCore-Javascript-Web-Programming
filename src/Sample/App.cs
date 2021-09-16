/*---------------------------------------------------------------------------------------------------------------------
    obejct sınıfının ReferenceEquals isimli static metodu ile referans karşılaştırması yapılabilir
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace CSD
{
    class Value<T> {
        public T Val { get; set; }

        public static bool operator ==(Value<T> v1, Value<T> v2)
        {
            return v1.Val.Equals(v2.Val);
        }

        public static bool operator !=(Value<T> v1, Value<T> v2)
        {
            return !(v1 == v2);
        }

        //...
    }

    class App
    {
        public static void Main()
        {
            Value<int> v1 = new() { Val = 10 };
            Value<int> v2 = new() { Val = 10 };

            Console.WriteLine(object.ReferenceEquals(v1, v2));            
        }
    }
}