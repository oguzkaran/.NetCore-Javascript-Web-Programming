using System;
using System.Collections;

namespace CSD.Util.Collections
{
    public class IntRange : IEnumerable
    {
        private class IntRangeEnumerator : IEnumerator
        {
            private IntRange m_range;
            private int m_curentValue;
            private int m_idx;

            public IntRangeEnumerator(IntRange range)
            {
                m_range = range;
                m_idx = -1;                
            }

            public object Current => m_curentValue;

            public bool MoveNext()
            {                
                m_curentValue = m_range.Min + ++m_idx * m_range.Inc;

                return m_range.Min + m_idx * m_range.Inc <= m_range.Max;
            }

            public void Reset()
            {
                m_idx = -1;                
            }
        }
        public int Min { get; set; }
        public int Max { get; set; }

        public int Inc { get; set; }

        //TODO: public Func<int, int> Func { get; set; };

        public IEnumerator GetEnumerator()
        {
            return new IntRangeEnumerator(this);
        }        
    }
}
