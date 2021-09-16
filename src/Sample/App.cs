/*---------------------------------------------------------------------------------------------------------------------
    TODO: Parametresi ile aldığı iki yazının anagram olup olmadığını test eden isAnagram isimli metodu yazınız ve 
    test ediniz.

    Tanım: Bir yazının karakterlerinin yerlerinin değiştirilmesiyle ikinici bir yazı elde edilebiliyorsa bu yazılara
    anagram denir.
    Örnek: 
    brat -> bart
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using CSD.Util.Collections;

namespace CSD
{
    class App
    {
        public static void Main()
        {            
            var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var list2 = new List<int> { 1, 2, 3, 4, 5, 3, 6, 7 };

            Console.WriteLine(list1.AreAllDistinct());
            Console.WriteLine(list2.AreAllDistinct());
        }
    }
}