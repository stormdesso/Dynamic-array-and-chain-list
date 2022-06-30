using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class EIndexError : Exception
    {
        public int Length { get; private set; }
        public int Index { get; private set; }

        public EIndexError(int length, int index)
        {
            Length = length;
            Index = index;
            Console.WriteLine("Попытка обратиться к индексу {0}, при длине списка {1}", Index, Length);
        }
    }
}
