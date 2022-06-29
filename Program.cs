using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
   
    class Test
    {
        public static void Main()
        {      
            Random randomGenerator = new Random();
            int n = 0;
            
            //ArrayList test
            
            ArrayList Array = new ArrayList();
            Console.WriteLine("BEGIN");
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("№ {0}",(i+1));
                n = randomGenerator.Next(1, 7);
                testArray(Array, n);
            }            
            Console.WriteLine("END");
            

            //ChainList test
            Console.WriteLine("BEGIN");            
            ChainList Chain = new ChainList();
            n = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("№ {0}", (i + 1));
                n = randomGenerator.Next(1, 7);
                testChain(Chain, n);
            }
            Console.WriteLine("END");

        }
        
        public static void testArray(ArrayList arrayList, int n)
        {
            Random randomGenerator = new Random();
            int pos = randomGenerator.Next(0, 10000);
            int value = randomGenerator.Next(-1000000, 1000001);
            Console.WriteLine("-----------");           
            
            switch (n)
            {
                case 1: 
                    Console.WriteLine("add: " + value + " count = " + arrayList.Count);// Add
                    arrayList.Add(value);
                    break;

                case 2: 
                    Console.WriteLine("count: " + arrayList.Count);// count
                    break;

                case 3: 
                    Console.WriteLine("clear: ");// clear
                    arrayList.Clear();
                    break;

                case 4: 
                    Console.WriteLine("ArrayList["+pos+"]"+" = " + value);// this
                    arrayList[pos] = value;
                    Console.WriteLine(arrayList[pos]);
                    break;
                case 5: 
                    Console.WriteLine("del: " + pos);// del
                    arrayList.Del(pos);
                    break;
                
                case 6: 
                    Console.WriteLine("insert number: " + value + " position:" + pos);// insert
                    arrayList.Insert(pos, value);
                    break;                

                default:
                    
                    break;
            }
            Console.Write("Массив:");
            arrayList.Print();
            Console.WriteLine("\n-----------");
            Console.WriteLine("\n");
        }
        
        public static void testChain(ChainList Chain, int n)
        {            
            Random randomGenerator = new Random();
            int pos = randomGenerator.Next(0, 10000);
            int value = randomGenerator.Next(-1000000, 1000001);
            Console.WriteLine("-----------");
            switch (n)
            {
                case 1: 
                    Console.WriteLine("add: " + value + " сount = " + Chain.Count);// Add
                    Chain.Add(value);
                    break;
                
                case 2: 
                    Console.WriteLine("clear: ");// Clear
                    Chain.Clear();
                    break;

                case 3: 
                    Console.WriteLine("сount: " + Chain.Count);// Count
                    break;

                case 4:
                    Console.WriteLine("ChainList[" + pos + "]" + " = " + value);// This
                    Chain[pos] = value;
                    Console.WriteLine(Chain[pos]);
                    break;

                case 5: 
                    Console.WriteLine("del: " + pos);// Del
                    Chain.Del(pos);
                    break;
                case 6: 
                    Console.WriteLine("insert number: " + value + " position:" + pos);
                    Chain.Insert(pos, value);// Insert
                    break;

                default:
                    
                    break;
            }                        
            Console.Write("Список:");
            Chain.Print();
            Console.WriteLine("\n-----------");
            Console.WriteLine("\n");

        }

    }
}
