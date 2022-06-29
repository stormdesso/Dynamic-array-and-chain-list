using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Class4
    {
        static void Main(string[] args)
        {
            
            Random randomGenerator = new Random();
            int n = 0;
            ArrayList Array = new ArrayList();
            ChainList Chain = new ChainList();
                                
            for (int i = 0; i < 10; i++)
            {                
                n = randomGenerator.Next(1, 5);
                test( Chain, Array, n );
            }

            Console.WriteLine("\n");
            

            bool check = true;
            for (int i = 0; i < Array.Count; i++)
            {
                if ( Array[i] != Chain[i] )
                    check = false;
            }
            Console.WriteLine("Списки: ");
            Array.Print();
            Chain.Print();

            Console.WriteLine("Списки совпадают:{0} ",check);
            
            BaseList Base_Chain = Chain.Clone();
            BaseList Base_Array = Array.Clone();

            Console.WriteLine("Клон связанного списка");
            Base_Chain.Print();
            Console.WriteLine("Клон массива");
            Base_Array.Print();
                       
            Console.WriteLine("Скопированный список типа данных: {0}", Base_Chain.GetType());
            Console.WriteLine("Скопированный массив типа данных: {0}", Base_Array.GetType());
            
            Console.WriteLine("Base_Chain до сортировки");
            Base_Chain.Print();            
            Console.WriteLine("Base_Chain после сортировки");
            Base_Chain.Sort();
            Base_Chain.Print();

            Console.WriteLine("Base_Array до сортировки");
            Base_Array.Print();
            Console.WriteLine("Base_Array после сортировки");
            Base_Array.Sort();
            Base_Array.Print();

            check = true;
            for (int i = 0; i < Array.Count; i++)
            {
                if (Base_Array[i] != Base_Chain[i])
                    check = false;
            }
            Console.WriteLine("\nСортировка верная? ");
            Console.WriteLine(check);


            Console.WriteLine("результат выполнения array.Assign(Base_chain) :"); 
            BaseList array = new ArrayList();
            array.Assign(Base_Chain);            
            array.Print();
            Console.WriteLine("Тип списка array :{0}",array.GetType());

            Console.WriteLine("Исходник(Base_Chain) :");
            Base_Chain.Print();

            Console.ReadKey();

        }

        public static void test(ChainList Chain, ArrayList Array, int n)
        {
            Random randomGenerator = new Random();
            int pos = randomGenerator.Next(0, 10000);
            int value = randomGenerator.Next(-1000000, 1000001);            
            switch (n)
            {
                case 1:                    
                    Chain.Add(value);
                    Array.Add(value);
                    break;                
                
                case 2:
                    
                    Chain[pos] = value;
                    Array[pos] = value;
                    
                    break;

                case 3:
                    
                    Chain.Del(pos);
                    Array.Del(pos);
                    break;
                case 4:
                    
                    Chain.Insert(pos, value);// Insert
                    Array.Insert(pos, value);
                    break;

                default:
                    break;
            }                       

        }

        
    }
}
