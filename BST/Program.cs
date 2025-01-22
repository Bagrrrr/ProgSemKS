using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<Person> node = new Node<Person>();
            Node<int> id = new Node<int>();
        }
    }

    class Node<T>
    {
        public int Key { get; }
        public T Value { get; }
    }
}
