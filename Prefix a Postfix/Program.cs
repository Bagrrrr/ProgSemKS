using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Prefix_a_Postfix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string priklad = Console.ReadLine();
            PrefixOrPostfix prefixOrPostfix = new PrefixOrPostfix();    
            Console.WriteLine(prefixOrPostfix.Vysledek(priklad));
        }
    }

    public class PrefixOrPostfix
    {

        public float? Vysledek(string priklad)
        {
            bool typ = PrefixCheck(priklad);
            if (typ == true)
            {
                return Prefix(priklad);
            }
            else
            {
                return Postfix(priklad);
            }
        }
        float? Prefix(string priklad)
        {
            string[] kousky = priklad.Split(' ');
            Stack<string> stack = new Stack<string>();
            int x = 0;
            int y = 0;
            while (1>0)
            {
                if (stack.Count > 2)
                {
                    string top1 = stack.Pop();
                    string top2 = stack.Pop();

                    if (float.TryParse(top2, out float float1) && float.TryParse(top1, out float float2))
                    {
                        string operace = stack.Pop();
                        float vysledek = 0;
                        switch (operace)
                        {
                            case "+":
                                vysledek = float1 + float2;
                                break;
                            case "-":
                                vysledek = float1 - float2;
                                break;
                            case "*":
                                vysledek = float1 * float2;
                                break;
                            case "/":
                                if (float2 != 0)
                                {
                                    vysledek = float1 / float2;
                                    break;
                                }
                                else
                                    Console.WriteLine("Dělení nulou");
                                    return null;
                            default:
                                Console.WriteLine("Neznámá operace");
                                return null;
                        }
                        stack.Push(vysledek.ToString());
                    }
                    else
                    {
                        stack.Push(top2);
                        stack.Push(top1);
                    }
                }
                if (stack.Count == 1)
                {
                    string vysledek = stack.Pop();
                    if (float.TryParse(vysledek, out float vysl))
                    {
                        return vysl;
                    }
                    else
                    {
                        stack.Push(vysledek);
                    }
                }
                if (y % 2 == 0)
                {
                    try
                    {
                        stack.Push(kousky[x]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Nedostatek");
                        return null;
                    }
                    x += 1;
                }
                y += 1;
            }
        }



        float? Postfix(string priklad)
        {
            string[] kousky = priklad.Split(' ');
            Stack<float> stack = new Stack<float>();
            for (int i = 0; i < kousky.Length; i++)
            {
                string momentalnik = kousky[i];
                if (float.TryParse(momentalnik, out float cislo))
                {
                    stack.Push(cislo);
                }
                else
                {
                    if (stack.Count < 2)
                    {
                        Console.WriteLine("Nedostatek");
                        return null;
                    }
                    float top1 = stack.Pop();
                    float top2 = stack.Pop();
                    float vysledek = 0;
                    switch (momentalnik)
                    {
                        case "+":
                            vysledek = top2 + top1;
                            break;
                        case "-":
                            vysledek = top2 - top1;
                            break;
                        case "*":
                            vysledek = top2 * top1;
                            break;
                        case "/":
                            if (top1 != 0)
                            {
                                vysledek = top2 / top1;
                                break;
                            }
                            else
                                Console.WriteLine("Dělení nulou");
                            return null;
                        default:
                            Console.WriteLine("Neznámá operace");
                            return null;
                    }
                    stack.Push(vysledek);


                }
            }
            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                Console.WriteLine("Nedostatek");
                return null;
            }



        }
        bool PrefixCheck(string prefix)
        {
            if (Char.IsDigit(prefix[0]) == true)
            {
                return false;
            }
            return true;
        }
    }
}


