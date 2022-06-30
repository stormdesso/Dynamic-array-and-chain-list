using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class ChainList<T> : BaseList<T> where T: IComparable<T>
    {
        class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; } //объект типа данных Node, который хранит в себе ссылку на следующий объект           
        }
        private Node head = null;               
        public override T this[int i]
        {
            set
            {
                if (i >= 0 && i < count)
                    Find(i).Data = value;
                else
                {                    
                    throw new EIndexError(count, i);
                }
            }

            get
            {
                if (i >= 0 && i < count)
                    return Find(i).Data;
                else
                {
                    throw new EIndexError(count, i);
                }
            }
        }
        private Node Find(int i)
        {
            if (i < 0 || i > Count)
            {
                throw new EIndexError(count, i);
            }
            Node searchElement = head;
            int n = 0;
            while (searchElement.Next != null && n < i)
            {
                searchElement = searchElement.Next;
                n++;
            }
            return searchElement;
        }
        public override void Add(T a)
        {
            Node newTail = new Node();
            newTail.Data = a;//поле Next по дефолту null
            if (Count == 0)
                head = newTail;
            else
            {
                Node oldTail = Find(Count - 1);// находим последний элемент в последовательности
                oldTail.Next = newTail;//присваиваем полю Next ссылку на новый последний элемент(newTail)
            }
            count++;
        }
        public override void Del(int pos)
        {
            if (pos >= Count || pos < 0)
                throw new EIndexError(count, pos);
            else
            {
                if (pos == 0)
                    head = Find(pos + 1);
                if (pos > 0 && (Find(pos).Next != null))
                {
                    Node previusElement = Find(pos - 1);
                    previusElement.Next = Find(pos + 1);
                }
                else if (pos > 0 && (Find(pos).Next == null))
                {
                    Node previusElement = Find(pos - 1);
                    previusElement.Next = null;
                }
                count--;
            }
        }
        public override void Insert(int pos, T a)
        {
            Node newNode = new Node();
            newNode.Data = a;

            if (pos < 0 || pos > count - 1)
                throw new EIndexError(count, pos);
            else
            {
                if (pos == 0)
                {
                    newNode.Next = head;
                    head = newNode;
                }
                else
                {
                    Node temp = new Node();
                    temp = Find(pos);
                    Find(pos - 1).Next = newNode;
                    newNode.Next = temp;
                }
                count++;
            }
        }

        public override void Clear()
        {
            head = null;
            count = 0;
        }
        //сортировка Пузырьком       
        public override void Sort()
        {            
            Node currentNode = head;                    
            bool check = true;
            while (check == true)
            {
                check = false;
                currentNode = head;
                while (check == false && currentNode.Next != null)
                {
                    if (currentNode.Data.CompareTo(currentNode.Next.Data) <= 0)                     
                        currentNode = currentNode.Next;                    
                    else
                    {    
                        T temp;
                        temp = currentNode.Data;
                        currentNode.Data = currentNode.Next.Data;
                        currentNode.Next.Data = temp;
                        check = true;
                    }
                }
            }
        }
        
        public override BaseList<T> Clone()
        {            
            ChainList<T> cloneElement = new ChainList<T>();            
            cloneElement.Assign(this);//this - текущий экземпляр класса ChainList            
            return cloneElement;
        }
        
    }
}
