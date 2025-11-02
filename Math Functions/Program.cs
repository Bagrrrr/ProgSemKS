using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Math_Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MathFunction> functions = new List<MathFunction>();
            functions.Add(new Linear(2, 3));
            functions.Add(new LinearAbsolute(-1, 4));
            functions.Add(new LinearUhhNvm(1, 2, 3, 4));
            functions.Add(new Quadratic(1, -4, 4));
            foreach (var func in functions)
            {
                func.FuncInfo();
                Console.WriteLine($"Pro x = 5 je y = {func.Calculate(5)}");
                Console.WriteLine();
            }
        }
    }
    public abstract class MathFunction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Interval Domain { get; set; }
        public Interval Range { get; set; }

        public string Prubeh { get; set; }

        public MathFunction()
        {
            Domain = new Interval();
            
        }

        public abstract double Calculate(double x);
        public virtual void FuncInfo()
        {
            Console.WriteLine($"{Name} ma rovnici {Description}, definicni obor {Domain} a obor hodnot {Range} s {Prubeh}");
        }

    }
    public struct Interval
    {
        public string UpperValue { get; set; }
        public string LowerValue    { get; set; }
        public string UpperBrackets { get; set; }
        public string LowerBrackets { get; set; }
        public string IntervalException { get; set; }

        public Interval(string lowbra, string lowval, string upval, string upbra, string exception)
        {
            UpperValue = upval;
            LowerValue = lowval;
            UpperBrackets = upbra;
            LowerBrackets = lowbra;
            IntervalException = exception;
        }

        public void PrintInterval()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            var lb = string.IsNullOrEmpty(LowerBrackets) ? "" : LowerBrackets;
            var ub = string.IsNullOrEmpty(UpperBrackets) ? "" : UpperBrackets;
            var lv = string.IsNullOrEmpty(LowerValue) ? "?" : LowerValue;
            var uv = string.IsNullOrEmpty(UpperValue) ? "?" : UpperValue;
            var ex = string.IsNullOrEmpty(IntervalException) ? "" : IntervalException;
            return $"{lb}{lv}, {uv}{ub}{ex}";
        }

    }
    public class Linear : MathFunction
    {
        public double A {  get; set; }
        public double B { get; set; }
        public Linear(double a, double b)
        {
            Name = "Linearni funkce";
            Description = string.Format("y = {0}x + {1}",a,b);
            A = a;
            B = b;
            Domain = new Interval("(","minus infinity","infinity",")", "");
            if (a == 0)
            {
                Range = new Interval("[", b.ToString(), b.ToString(), "]", "");
                Prubeh = "rovnym prubehem";
            }
            else
                Range = new Interval("(","minus infinity","infinity",")", "");
                Prubeh = "linearnim prubehem";

        }
        public override double Calculate(double x)
        {
            return A * x + B;
        }

    }
    public class LinearAbsolute : MathFunction
    {
        public double A { get; set; }
        public double B { get; set; }
        public LinearAbsolute(double a, double b)
        {
            Name = "Linearni funkce s absolutni hodnotou";
            Description = string.Format("y = |{0}x + {1}|", a, b);
            A = a;
            B = b;
            Domain = new Interval("(", "minus infinity", "infinity", ")", "");
            
            if (a == 0)
            {
                Range = new Interval("[", Math.Abs(b).ToString(), Math.Abs(b).ToString(), "]", "");
                Prubeh = "rovnym prubehem";
            }
            else
                Range = new Interval("[", "0", "infinity", ")", "");
                Prubeh = "linearnim prubehem se zrcadlovym zobrazenim negativnich hodnot: v";

        }
        public override double Calculate(double x)
        {
            return Math.Abs(A * x + B);
        }

    }
    public class LinearUhhNvm: MathFunction
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public LinearUhhNvm(double a, double b, double c, double d)
        {
            Name = "Linearni lomena funkce";
            Description = string.Format("y = ({0}x + {1})/({2}x + {3})", a, b, c , d);
            A = a;
            B = b;
            C = c;
            D = d;
            Domain = new Interval("(", "minus infinity", "infinity", ")", "/(-d/c)");
            
            if (a == 0 && c == 0)
            {
                Range = new Interval("[", (b/d).ToString(), (b/d).ToString(), "]", "");
                Prubeh = "rovnym prubehem";
            }
            else if (c == 0)
            {
                Range = new Interval("(", "minus infinity", "infinity", ")", "");
                Prubeh = "linearnim prubehem";
            }
            else
                Range = new Interval("(", "minus infinity", "infinity", ")", "/(a/c)");
                Prubeh = "hyperbolickym prubehem";

        }
        public override double Calculate(double x)
        {
            return (A * x + B)/(C * x + D);
        }

    }
    public class Quadratic : MathFunction
    {
        public double A { get; set; }
        public double B { get; set; }

        public double C { get; set; }
        public Quadratic(double a, double b, double c)
        {
            Name = "Kvadraticka funkce";
            Description = string.Format("y = {0}x^2 + {1}x + {2}", a, b, c);
            A = a;
            B = b;
            C = c;
            Domain = new Interval("(", "minus infinity", "infinity", ")", "");
            
            if (a == 0 && b == 0)
            {
                Range = new Interval("[", c.ToString(), c.ToString(), "]", "");
                Prubeh = "rovnym prubehem";
            }
            else if (a > 0)
            {
                double vertexY = C - (B * B) / (4 * A);
                Range = new Interval("[", vertexY.ToString(), "infinity", ")", "");
                Prubeh = "parabolickym prubehem";
            }
            else if (a < 0)
            {
                double vertexY = C - (B * B) / (4 * A);
                Range = new Interval("(", "minus infinity", vertexY.ToString(), "]", "");
                Prubeh = "parabolickym prubehem";
            }
            else
                Range = new Interval("(", "minus infinity", "infinity", ")", "");
                Prubeh = "parabolickym prubehem";

        }
        public override double Calculate(double x)
        {
            if (B*B - 4*A*C < 0)
            {
                Console.WriteLine("Kvadraticka funkce nema realne koreny.");
                return double.NaN;
            }
            else 
                return A * x * x + B * x + C;
        }

    }
}
