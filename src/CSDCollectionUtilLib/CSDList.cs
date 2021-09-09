//#define TEST

using System;
using System.Collections;

namespace CSD.Util.Collections
{
    #region CSDList class
    public class CSDList<E> : IEnumerable
    {
        private class CSDListEnumerator<T> : IEnumerator
        {
            public CSDList<T> m_list;
            public int m_idx = -1;

            public CSDListEnumerator(CSDList<T> list)
            {
                m_list = list;    
            }

            public object Current => m_list[m_idx];

            public bool MoveNext()
            {
                ++m_idx;
                return m_idx != m_list.m_idx;                    
            }

            public void Reset()
            {
                m_idx = -1;
            }
        }

        private const int ms_defaultCapacity = 10;
        private E[] m_elems;
        private int m_idx;

#pragma warning restore
        private void allocateCapacity(int capacity)
        {
#if TEST
#if !DEBUG
#warning You must be in Debug configuration
#endif
            Console.WriteLine($"Capacity:{capacity}");
            Console.WriteLine($"Count:{m_idx}");
            if (capacity < m_idx)
                throw new ArgumentException("Argument error while testing");

#endif
            E[] temp = new E[capacity];

            Array.Copy(m_elems, temp, m_idx);
            m_elems = temp;
        }

        #region CSDList default ctor
        public CSDList() : this(ms_defaultCapacity)
        {
                            
        }
        #endregion

        public CSDList(int initialCapacity)
        {
            if (initialCapacity < 0)
                throw new ArgumentOutOfRangeException("capacity value can not be negative");

            m_elems = new E[initialCapacity];
        }

        public void Add(E elem)
        {
            if (m_idx == m_elems.Length)
                allocateCapacity(m_elems.Length == 0 ? 1 : m_elems.Length * 2);

            m_elems[m_idx++] = elem;                        
        }

        public E this[int idx]
        {
            set => m_elems[idx] = value;
            get => m_elems[idx];
        }

        public int Count => m_idx;
        public int Capacity => m_elems.Length;

        //...

        public void Clear()
        {
            Array.Fill(m_elems, default);
            m_idx = 0;
        }

        public void TrimToSize()
        {
            allocateCapacity(m_idx);
        }
       

        public IEnumerator GetEnumerator()
        {
            return new CSDListEnumerator<E>(this);                
        }
    }

    #endregion
}
