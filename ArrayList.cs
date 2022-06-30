using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class ArrayList<T> : BaseList<T> where T : IComparable<T>
    {
        private T[] a = new T[3];

        public override T this[int i]
        {
            set
            {
                if (i < Count && i >= 0)
                {
                    a[i] = value;
                }
                else
                    throw new EIndexError(count, i);
            }
            get
            {
                if (i < Count && i >= 0)
                    return a[i];
                else
                    {
                        throw new EIndexError(count, i);
                    }
            }
        }

        public void Resize()
        {
            T[] tmp = new T[a.Length * 2];
            for (int j = 0; j < a.Length; j++)
            {
                tmp[j] = a[j];
            }
            a = tmp;
        }

        public override void Add(T a)
        {
            if (Count >= this.a.Length)
            {
                Resize();
            }
            this.a[Count] = a;
            count++;

        }
        public override void Del(int pos)
        {
            if ( a[a.Length-1] != null )
                Resize();

            if (pos >= Count || pos < 0)
                throw new EIndexError(count, pos);
            else
            {
                if (a.Length > 1)
                {
                    for (int j = pos; j < count-1; j++)
                    {                        
                        a[j] = a[j + 1];//когда полный массив, нужно делать ресайз
                    }
                    count--;
                    if (count < 0)
                    {
                        count = 0;
                    }

                }
            }

           

        }
        public override void Insert(int pos, T a)
        {
            if (count == pos)
                Resize();
            if (pos >= 0 && pos < Count)
            {                               
                T tmp, tmp2;
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
                throw new EIndexError(count, pos);
        }
        public override void Clear()
        {
            a = null;
            /*
            for (int i = 0; i < a.Length; i++)
            {
               a[i] = 0;                
            }
            */
            count = 0;
        }
                      
        public override BaseList<T> Clone()
        {
            ArrayList<T> cloneElement = new ArrayList<T>();
            cloneElement.Assign(this);//this - текущий экземпляр класса ArrayList            
            return cloneElement;
        }
    }
}
