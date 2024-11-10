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
        public int Min()    
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
        public void PrintList()
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
        public int Len(LinkedList list)
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
        public LinkedList Sort2(LinkedList list)
        {
            LinkedList result = new LinkedList();
            int previous = 0;
            Node current = Head;
            int min = 0;
            while (current != null)
            {
                while (current != null)
                {
                    if (previous < current.Value & current.Value < min)
                    {
                        min = current.Value;
                    }
                    current = current.Next;
                }
                result.Add(min);
                previous = min;

            }
            return result;
        }
        public LinkedList BubbleSort(LinkedList list)
        {
            Node current = Head;
            Node previous = Head;
            int bigger = 0;
            int smaller = 0;
            int len = list.Len(list);
            for (int i = 0; i < len; i++)
            {
                while (current.Next != null)
                {
                    if (current.Value > current.Next.Value)
                    {
                        bigger = current.Value;
                        smaller = current.Next.Value;
                        current.Next.Value = bigger;
                        current.Value = smaller;
                    }
                    previous = current;
                    current = current.Next;
                }
            }

            return list;
        }
    }
}