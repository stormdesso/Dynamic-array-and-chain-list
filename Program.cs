using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Class4
    {
        static void Main(string[] args)
        {
            
            ArrayList<string> Array = new();
            ChainList<string> Chain = new();
           
            int arrayError = 0;
            int chainError = 0;
            Random randomGenerator = new Random();
            String alphabet = "abcdefghijklmnopqrstuvwxyz"; 
            for (int i = 0; i < 1000; i++)
            {                
                int n = randomGenerator.Next(1, 7);                  
                String value = "";               
                for (int j = 0; j < randomGenerator.Next(1, 5); j++)
                {
                    int index = randomGenerator.Next(1, 26);
                    value += alphabet[index];
                } 
                int pos = randomGenerator.Next(0, 1000);                              
                try
                {                                       
                    switch (n)
                    {
                        case 1:
                            Chain.Add(value);
                            
                            break;

                        case 2:

                            Chain[pos] = value;
                           

                            break;

                        case 3:

                            Chain.Del(pos);
                            
                            break;
                        case 4:

                            Chain.Insert(pos, value);// Insert
                            
                            break;

                        default:
                            break;
                    }
                }
                catch (EIndexError) { chainError++; }
                try
                {
                    switch (n)
                    {
                        case 1:
                            
                            Array.Add(value);
                            break;

                        case 2:

                            
                            Array[pos] = value;

                            break;

                        case 3:

                           
                            Array.Del(pos);
                            break;
                        case 4:
                            
                            Array.Insert(pos, value);
                            break;

                        default:
                            break;
                    }
                }
                catch (EIndexError) { arrayError++; }

                
            }
            
            Console.WriteLine("\n");
            Console.WriteLine("Array Error: {0}", arrayError);
            Console.WriteLine("Chain Error: {0}", chainError);
            
            Console.WriteLine($"Списки совпадают: {Array == Chain}");
            
            BaseList<string> Base_Chain = Chain.Clone();
            BaseList<string> Base_Array = Array.Clone();
            
            Console.WriteLine($"Списки равны: Base_Chain == Chain?: {Base_Chain == Chain}");
            Console.WriteLine($"Base_Chain типа: {Base_Chain.GetType()}");

            Console.WriteLine($"Списки равны: Base_Array == Array?: {Base_Array == Array}");
            Console.WriteLine($"Base_Array типа: {Base_Array.GetType()}");
                       
            Console.WriteLine("Base_Chain сортировка...");
            Base_Chain.Sort();
            //Base_Chain.Print();
            
            Console.WriteLine("Base_Array сортировка...");
            Base_Array.Sort();
            //Base_Array.Print();
            
            Console.WriteLine("Сортировка верная? {0}", Base_Chain== Base_Array);

            BaseList<string> array = new ArrayList<string>();
            Console.WriteLine("Выполнение array.Assign(Base_chain)...");            
            array.Assign(Base_Chain);

            Console.WriteLine("Base_Chain == array? {0}", Base_Chain == array);
            Console.WriteLine("Тип списка array :{0}",array.GetType());

            //1
            ArrayList<BaseList<string>> listOfList = new ArrayList<BaseList<string>>();
            listOfList.Add(Base_Chain);//Base_Chain
            listOfList.Add(Base_Array);

            Console.WriteLine("1) Cписок списков");           
            for (int i = 0; i < listOfList.Count; i++)            
                listOfList[i].Print();
            
            Console.WriteLine("Print newList:");
            listOfList.Print();
            //2
            Console.WriteLine("2) Cписок списков");
            ChainList<BaseList<string>> listOfList2 = new ChainList<BaseList<string>>();
            listOfList2.Add(array);
            listOfList2.Add(Base_Array);
            
            for (int i = 0; i < listOfList2.Count; i++)            
                listOfList2[i].Print();
                        
            listOfList2.Print();
            Console.WriteLine(" listOfList2 == listOfList? {0}",listOfList2 == listOfList );

            BaseList<string> sum = array + Base_Array;
            Console.WriteLine("\nСписок array + список Base_Array = ");
            sum.Print();


            Console.WriteLine();
            Console.WriteLine("Список,загружающийся в файл");
            array.Print();
            array.Save("temp.txt");

            BaseList<string> loadFromFileList = new ChainList<string>();
            try
            {
                loadFromFileList.Load("temp.txt");
            }
            catch (EFileError exeption)
            {
                Console.WriteLine("Исключение '{0}', в файле '{1}'",exeption.Message, exeption.FileName);
            }
            
            Console.WriteLine("\nСписок, загруженный из файла");
            loadFromFileList.Print();

            Console.ReadKey();
        }      
    }
}
