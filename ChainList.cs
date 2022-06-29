﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ChainList
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; } //объект типа данных Node, который хранит в себе ссылку на следующий объект           
        }
        private Node head = null;
        private int count = 0;
        public int Count
        {
            get { return count; }
        }

        public int this[int i]
        {

            set
            {
                if (i >= 0 && i < count)
                    Find(i).Data = value;
                else
                    Console.WriteLine("Некорректный индекс для обращения");
            }

            get
            {
                if (i >= 0 && i < count)
                    return Find(i).Data;
                else
                {
                    Console.WriteLine("Некорректный индекс для обращения");
                    return -1;
                }
            }

        }

        private Node Find(int i)
        {
            if (i < 0 || i > Count)
            {
                Console.WriteLine("Некорректный индекс для поиска элемента");
                return null;
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
        public void Add(int a)
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

        public void Del(int pos)
        {
            if (pos >= Count || pos < 0)
                Console.WriteLine("Недопустимый индекс, при удалении элемента");
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

        public void Insert(int pos, int a)
        {
            Node newNode = new Node();
            newNode.Data = a;

            if (pos < 0 || pos > count - 1)
                Console.WriteLine("Некорректный индекс для вставки");
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

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void Print()
        {
            Node tmp = head;
            while (tmp != null)
            {
                Console.WriteLine(tmp.Data);
                tmp = tmp.Next;
            }
            Console.Write("\n");
        }

    }
}
