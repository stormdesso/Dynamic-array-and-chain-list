using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    abstract class BaseList<T>: IComparable<BaseList<T>> where T : IComparable<T>
    {
        public int count;
        public int Count
        {
            get { return count; }
        }
        public abstract void Add(T a);
        public abstract void Del(int pos);
        public abstract void Insert(int pos, T a);               
        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < Count; i++)            
                Console.Write(" "+this[i]+";");//this - ссылка на текущий экземпляр класса
                        
            Console.WriteLine();
        }

        public abstract void Clear();
        public abstract BaseList<T> Clone();
        public abstract T this[int i] { get; set; }
         
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
                    while ( (j >= 0) && (this[j].CompareTo(this[j + step]) == 1 ))//this[j] > this[j + step]
                    {
                        T tmp = this[j];
                        this[j] = this[j + step];
                        this[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
             }            
        }
       
        public void Assign(BaseList<T> originalObject)
        {
            //originalObject - объект из которого берутся данные, this - куда вставляются
            int j = 0;
            while (j != originalObject.Count)
            {
                this.Add(originalObject[j]);//this - ссылка на текущий экземпляр класса            
                j++;
            }            
        }
               
        public void AssignTo(BaseList<T> tmp)
        {
            tmp.Assign(this);
        }
        
        public void Save(string fileName)
        {
            StreamWriter fileWriter = new StreamWriter(fileName);
            for (int i = 0; i < Count; i++)            
                fileWriter.WriteLine(this[i]);//построчная запись в файл
            
            fileWriter.Close();
        }

        public void Load(string fileName)
        {
            try
            {
                StreamReader fileReader = new StreamReader(fileName);
                while (fileReader.EndOfStream == false)//читаем, пока не будет достигнут конец файла
                {
                    String textFromFile = fileReader.ReadLine();//считываем построчно данные из файла
                    this.Add((T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(textFromFile));                    
                }
                fileReader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл отсутствует :{0}",fileName );
                throw new EFileError(fileName);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка конвертирования в файле:{0}", fileName);//некорректные данные в файле
                throw new EFileError(fileName);
            }
        }

        public int CompareTo(BaseList<T> other)
        {
            int state = 0;

            if (this.Count < other.Count)
            {   
                Console.WriteLine("Мы здесь!");
                state = -1;               
            }

            if (this.Count > other.Count)
                state = 1;

            if (this.Count == other.Count)
                for (int i = 0; i < other.Count; i++)
                    state += this[i].CompareTo(other[i]);

            return state;
        }

        public static bool operator == (BaseList<T> list1, BaseList<T> list2)
        {
            if (list1.CompareTo(list2) == 0)
                return true;
            else
                return false;
        }

        public static bool operator != (BaseList<T> list1, BaseList<T> list2)
        {
            if (list1.CompareTo(list2) == 0)
                return false;
            else
                return true;          
        }

        public static BaseList<T> operator + (BaseList<T> list1, BaseList<T> list2)
        {
            BaseList<T> sum = list1.Clone();
            for (int i = 0; i < list2.Count; i++)            
                sum.Add(list2[i]);            

            return sum;
        }
    }
}
