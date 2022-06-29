using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ArrayList
    {
        private int[] a = new int[3];

        private int count;
        public int Count
        {
            get { return count; }
        }

        public int this[int i]
        {
            set
            {
                if (i < Count && i >= 0)
                {
                    a[i] = value;
                }
                else
                    Console.WriteLine("Некорректный индекс, при присвоении");
            }
            get
            {
                if (i < Count && i >= 0)
                    return a[i];
                else
                    Console.WriteLine("Некорректный индекес, при получении значения элемента");
                return 0;
            }
        }

        public void Resize()
        {
            int[] tmp = new int[a.Length * 2];
            for (int j = 0; j < a.Length; j++)
            {
                tmp[j] = a[j];
            }
            a = tmp;
        }

        public void Add(int a)
        {
            if (Count >= this.a.Length)
            {
                Resize();
            }
            this.a[Count] = a;
            count++;

        }

        public void Del(int pos)
        {
            if (pos >= Count || pos < 0)
                Console.WriteLine("Недопустимый индекс, при удалении");
            else
            {
                if (a.Length > 1)
                {
                    for (int j = pos; j < count; j++)
                    {
                        a[j] = a[j + 1];
                    }
                    count--;
                    if (count < 0)
                    {
                        count = 0;
                    }
                        
                }
            }
        }

        public void Insert(int pos, int a)
        {
            if (count == pos)
                Resize();
            if (pos >= 0 && pos < Count)
            {
                int tmp, tmp2;
                tmp = this.a[pos];
                for (int j = pos + 1; j <= count; j++)
                {
                    tmp2 = this.a[j];
                    this.a[j] = tmp;
                    tmp = tmp2;
                }
                this.a[pos] = a;
                count++;
            }
            else
                Console.WriteLine("Некорректный индекс, при вставке в массив");
        }

        public void Clear()
        {
              
            for ( int i = 0; i < a.Length; i++)
            {
                this.a[i] = 0;  
            }
            count = 0;
        }

        public void Print()
        {
            Console.WriteLine();
            if ( count >= 0)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    Console.Write(a[j] + " ");
                }
            }
        }
    }
}
