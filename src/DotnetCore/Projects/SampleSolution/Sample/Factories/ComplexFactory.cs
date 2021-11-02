using CSD.Util.Mathematics;
using System;

namespace Sample.Factories
{
    public class ComplexFactory
    {
        private Random m_random;        

        public ComplexFactory(Random random)
        {
            m_random = random;
        }

        public Complex [] GetRandomNumberAsArray(int count, double min, double max)
        {
            var numbers = new Complex[count];

            for (var i = 0; i < count; ++i)
                numbers[i] = new Complex {Real = m_random.NextDouble() * (max - min) + min, Imag = m_random.NextDouble() * (max - min) + 1};

            return numbers;
        }
    }
}
