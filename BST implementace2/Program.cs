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

            Node<string> node1 = new Node<string>(1, "Čau");
            Node<string> node2 = new Node<string>(2, "Zdravim");
            Node<string> node3 = new Node<string>(3, "Ahoj");
            Node<string> node4 = new Node<string>(4, "Ahojda");
            Node<string> node5 = new Node<string>(5, "Ahojdadad");

            node1.LeftSon = node2;
            node1.RightSon = node3;

            node3.LeftSon = node4;
            node3.RightSon = node5;

            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Root = node1;

            Console.WriteLine(tree.Show());
            Console.WriteLine(tree.Find(57));
        }
    }

    class Node<T>
    {
        public T Value { get; set; }
        public int Key { get; set; }

        public Node<T> LeftSon { get; set; }
        public Node<T> RightSon { get; set; }

        // konstruktor
        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }
    }

    class BinarySearchTree<T>
    {
        public Node<T> Root { get; set; }

        public string Show()
        {
            // vrací string, abychom použít Console.WriteLine()
            string output = "";

            void _show(Node<T> node)
            {
                if (node == null)
                    return;
                // pokračování
                _show(node.LeftSon);

                // výpis
                output += node.Key.ToString() + " ";

                _show(node.RightSon);
            }

            if (Root == null)
                return "Strom je prázdný";
            _show(Root);
            return output;
        }

        public T Find(int key)
        {
            Node<T> _find(Node<T> node, int key2)
            {
                if (node == null)
                    return null;

                if (node.Key == key2)
                    return node;

                if (key2 < node.Key)
                    return _find(node.LeftSon, key2);
                else
                    return _find(node.RightSon, key2);
            }

            Node<T> output = _find(Root, key);
            if (output == null)
                return default(T);
            return _find(Root, key).Value;
        }
    }

}