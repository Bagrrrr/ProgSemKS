using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> Zavory = new Stack<char>();;
            string Zavorky = Console.ReadLine();
            bool ne = false;
            for (int i = 0; i < Zavorky.Length; i++)
            {
                if (Zavorky[i] == '(')
                {

                     Zavory.Push(Zavorky[i]);
  
                }
                else if (Zavorky[i] == '[')
                {

                     Zavory.Push(Zavorky[i]);

                }
                else if (Zavorky[i] == '{')
                {

                     Zavory.Push(Zavorky[i]);
    
                }
                else if (Zavorky[i] == ')')
                {
                    if (Zavory.Count > 0 && Zavory.Peek() == '(')
                    {
                        Zavory.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Nespravne");
                        ne = true;
                    }
                }
                else if (Zavorky[i] == ']')
                {
                    if (Zavory.Count > 0 && Zavory.Peek() == '[')
                    {
                        Zavory.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Nespravne");
                        ne = true;
                    }
                }
                else if (Zavorky[i] == '}')
                {
                    if (Zavory.Count > 0 && Zavory.Peek() == '{')
                    {
                        Zavory.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Nespravne");
                        ne = true;
                    }
                }
            }
            if (Zavory.Count != 0)
            {
                Console.WriteLine("Nespravne");
                ne = true;
            }
            if (ne == false)
            {
                Console.WriteLine("Spravne");
            }

            Console.ReadLine();
        }
    }
}
