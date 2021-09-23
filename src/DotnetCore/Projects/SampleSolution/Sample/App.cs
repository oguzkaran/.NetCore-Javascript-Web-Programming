/*---------------------------------------------------------------------------------------------------------------------
    Single Responbility Principle
    Open Closed Principle
    Liskov Substitution Principle
    Interface Segregation Principle
    Dependency Inverse Principle 

    Dependency Injection (Inversion Of Control)
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using CSD.Util.Collections;

namespace CSD
{
    interface ISource {
        int NextChar();
    }

    class StringSource : ISource {
        private readonly string m_str;
        private int m_idx;

        public StringSource(string str)
        {
            m_str = str;
        }

        public int NextChar()
        {
            return m_idx == m_str.Length ? -1 : m_str[m_idx++];
        }
    }

    class Parser {
        public ISource Source { get; set; }

        public Parser(ISource source)
        {
            Source = source;
        }

        public int CountWhitespaces()
        {
            int count = 0;

            int c;

            while ((c = Source.NextChar()) != -1)
                if (char.IsWhiteSpace((char)c))
                    ++count;

            return count;
        }
    }


    class App
    {
        public static void Main()
        {
            StringSource ss = new("Bugün hava \t\nyağmurlu");
            Parser p = new(ss);


            Console.WriteLine($"Count:{p.CountWhitespaces()}");
        }
    }
}