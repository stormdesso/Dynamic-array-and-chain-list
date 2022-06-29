using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    abstract class BaseList
    {
        public int count;
        public int Count
        {
            get { return count; }
        }
        public abstract void Add(int a);
        public abstract void Del(int pos);
        public abstract void Insert(int pos, int a);               
        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < Count; i++)            
                Console.Write(" "+this[i]+";");//this - ссылка на текущий экземпляр класса
                        
            Console.WriteLine();
        }

        public abstract void Clear();
        public abstract BaseList Clone();
        public abstract int this[int i] { get; set; }
         
        //сортировка Шелла
        public virtual void Sort() 
        {                          
            int j;
            int step = Count / 2;
            while (step > 0)
            {
                for (int i = 0; i < (Count - step); i++)
                {
                    j = i;
                    while ( (j >= 0) && ( this[j] > this[j + step] ) )
                    {
                        int tmp = this[j];
                        this[j] = this[j + step];
                        this[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
             }            
        }
       
        public void Assign(BaseList originalObject)
        {
            //originalObject - объект из которого берутся данные, this - куда вставляются
            int j = 0;
            while (j != originalObject.Count)
            {
                this.Add(originalObject[j]);//this - ссылка на текущий экземпляр класса            
                j++;
            }            
        }
               
        public void AssignTo(BaseList tmp)
        {
            tmp.Assign(this);
        }


    }
}
