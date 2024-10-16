using System.Runtime.Remoting.Messaging;

namespace Spojove_listy;

class Program
{
    static void Main(string[] args)
    {
        Node uzlik = new Node(8);
    }
}
class Node
{
    public Node(int value)
    {
        Value = value;
    }
    public int Value { get; }
    public Node Next {  get; set; }
}
class LinkedList
{
    public Node Head { get; set; }

    public void Add(int value)
    {
        if (Head == null)
            Head = new Node(value);
        else
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
        }
    }
    public bool Find(int value)
    {
        if (Head == null)
            return false;
        Node node = Head;
        while (node.Next != null)
        {
            if(node.Value == value)
                return true;
            node = node.Next;
        }
    }   return false;
}