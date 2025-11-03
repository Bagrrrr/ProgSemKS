using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Topo_usp_Abeceda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graf = new Graph();
        }

    }

    class Graph
    {
        private Dictionary<char, Node> nodes { get; set; }

        public Graph()
        {
            nodes = new Dictionary<char, Node>()
                {
                    {'a',new Node('a') },
                    {'b',new Node('b') },
                    {'c',new Node('c') },
                    {'d',new Node('d') }
                };

            //	pro: b<c c<d a<d c<a
            nodes['b'].Succesors.Add(nodes['c']);
            nodes['c'].Predecesors.Add(nodes['b']);

            nodes['c'].Succesors.Add(nodes['d']);
            nodes['d'].Predecesors.Add(nodes['c']);

            nodes['a'].Succesors.Add(nodes['d']);
            nodes['d'].Predecesors.Add(nodes['a']);

            nodes['c'].Succesors.Add(nodes['a']);
            nodes['a'].Predecesors.Add(nodes['c']);

            Node stok = DFS(nodes['a']);

            List<char> poradi = GetOrder(nodes, stok);
            poradi.Reverse();
            Console.WriteLine("Poradi: ");
             foreach (char letter in poradi)
             {
                 Console.Write(letter + " ");
             }


            Console.ReadLine();
        }
        private List<char> GetOrder(Dictionary<char, Node> nodes, Node startNode)
        {

                Node stok = startNode;
                if (stok == null)
                {
                    Console.WriteLine("Stok nebyl nalezen");
                    return null;
                }
                else
                {
                    Node current = stok;
                    List<char> serazeno = new List<char>();
                    serazeno.Add(stok.Name);
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        foreach (Node predecessor in current.Predecesors)
                        {
                            predecessor.Succesors.Remove(current);
                            if (predecessor.Succesors.Count == 0)
                            {
                                current = predecessor;
                                serazeno.Add(current.Name);
                            }
                        }
                    }
                    return serazeno;
            }
        }

        private Node DFS(Node initialNode) // vrací buď stok nebo null
        {
            initialNode.NodeState = Node.State.Open;
            Node stok = null;
            DFS2(initialNode);
            return stok;

            void DFS2(Node node)
            {
                node.NodeState = Node.State.Open;
                if (node.Succesors.Count > 0) // je kam pokračovat
                {
                    foreach (Node successor in node.Succesors)
                    {
                        if (successor.NodeState == Node.State.Unvisited)
                        {
                            DFS2(successor);
                            if (stok != null) // pokud se našel stok
                                return;
                        }
                    }
                    node.NodeState = Node.State.Closed;

                }
                else // našli jsme stok
                {
                    stok = node;
                    return;
                }
            }
        }
    }
}


class Node
{
    public Node(char letter)
    {
        Name = letter;

        Succesors = new List<Node>();
        Predecesors = new List<Node>();

        NodeState = State.Unvisited;
        InTime = null;
        OutTime = null;
    }
    public char Name { get; }

    public List<Node> Succesors { get; set; }
    public List<Node> Predecesors { get; set; }

    public enum State { Open, Unvisited, Closed }
    public State NodeState { get; set; }

    public int? InTime { get; set; }
    public int? OutTime { get; set; }

    public override string ToString()
    {
        return Name.ToString();
    }
}

// Poradi nebude jednoznačné, když v grafu bude více stoků, nebo začátků.
// Pokud chcete mít jednoznačné pořadí, musíte mít v grafu jen jeden stok a jeden začátek.

// Seřazení nebude existovat u těžšího příkadu, když bude vstup vypadat nějak takhle:
// a a a ab ab ab abc abc abc abcd abcd abcd
// V tomto případě je vstup nejednoznačný a výstup bude také nejednoznačný.