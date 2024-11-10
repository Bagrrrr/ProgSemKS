using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spojovy_seznam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node uzlik = new Node(8);
            LinkedList list = new LinkedList();
            list.PrintList();

            list.BubbleSort(list);
            list.PrintList();
            Console.ReadLine();
        }
    }
    class Node
    {
        public Node(int value)  
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
    }
    class LinkedList
    {
        public Node Head { get; set; }
        public void Add(int value)  
        {
            if (Head == null)   
            {
                Head = new Node(value); 
            }
            else
            {
                Node newNode = new Node(value);
                newNode.Next = Head;
                Head = newNode;
            }
        }


        public bool Find(int value) 
        {
            Node node = Head;
            while (node != null)   
            {
                if (node.Value == value)
                    return true;
                node = node.Next;
            }
            return false;
        }


        public int Min()    // UKOL 1 - MIN O(n)
        {
            int min = Head.Next.Value;
            Node node = Head;
            while (node != null)
            {
                if (node.Value < min)
                    min = node.Value;
                node = node.Next;
            }
            return min;
        }


        public void PrintList()     // UKOL 2 - PRINT
        {
            Node current = Head;
            while (current != null)
            {
                Console.Write(current.Value);
                Console.Write(' ');
                current = current.Next;
            }
            Console.WriteLine();
        }


        public int Len(LinkedList list)     // POMOCNY LEN
        {
            Node node = Head;
            int len = 0;
            while (node != null)
            {
                len++;
                node = node.Next;
            }
            return len;
        }


        public LinkedList BubbleSort(LinkedList list)
        {
            Node current = Head;
            Node previous = null;
            int len = list.Len(list);
            for (int i = 0; i < len; i++)
            {
                current = Head;
                previous = null;
                while (current.Next != null)
                {
                    if (current.Value > current.Next.Value)
                    {
                        previous.Next = current.Next;
                        current.Next = current.Next.Next;
                        previous.Next.Next = previous.Next;
                    }
                    previous = current;
                    current = current.Next;
                }
            }

            return list;
        }
    }
}