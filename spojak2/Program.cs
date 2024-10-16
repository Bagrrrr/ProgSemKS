using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spojak2
{
    class Program
    {
        static void Main(string[] args)
        {
            Uzel uzlik = new Uzel(8);
            LinkedList Seznam = new LinkedList();
            Seznam.Add(9);
            Seznam.Add(5);
            Seznam.Add(1);
        }
    }
    class Uzel
    {
        public Uzel(int value)
        {
            Value = value;
        }
        public int Value { get; }
        public Uzel Next { get; set; }
    }
    class LinkedList
    {
        public Uzel Head { get; set; }

        public void Add(int value)
        {
            if (Head == null)
                Head = new Uzel(value);
            else
            {
                Uzel newNode = new Uzel(value);
                newNode.Next = Head;
                Head = newNode;
            }
        }
        public bool Find(int value)
        {
            if (Head == null)
                return false;
            Uzel node = Head;
            while (node.Next != null)
            {
                if (node.Value == value)
                    return true;
                node = node.Next;
            }
            return false;
        }
    }
}
