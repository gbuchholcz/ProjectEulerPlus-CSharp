using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler17
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private const string separator = " ";
        private static Dictionary<long, string> dict = new Dictionary<long, string>()
        {
            {0, "Zero"}
            ,{ 1, "One" }
            ,{ 2, "Two"}
            ,{ 3, "Three"}
            ,{ 4, "Four"}
            ,{ 5, "Five"}
            ,{ 6, "Six"}
            ,{ 7, "Seven"}
            ,{ 8, "Eight"}
            ,{ 9, "Nine"}
            ,{ 10, "Ten"}
            ,{ 11, "Eleven"}
            ,{ 12, "Twelve"}
            ,{ 13, "Thirteen"}
            ,{ 14, "Fourteen"}
            ,{ 15, "Fifteen"}
            ,{ 16, "Sixteen"}
            ,{ 17, "Seventeen"}
            ,{ 18, "Eighteen"}
            ,{ 19, "Nineteen"}
            ,{ 20, "Twenty"}
            ,{ 30, "Thirty"}
            ,{ 40, "Forty"}
            ,{ 50, "Fifty"}
            ,{ 60, "Sixty"}
            ,{ 70, "Seventy"}
            ,{ 80, "Eighty"}
            ,{ 90, "Ninety"}
            ,{ 100, "Hundred"}
            ,{ 1000, "Thousand"}
            ,{ 1000000, "Million"}
            ,{ 1000000000, "Billion"}
            ,{ 1000000000000, "Trillion"}
        };

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                long N = long.Parse(input.ReadLine());

                if (N == 0)
                {
                    output.WriteLine(dict[0]);
                    continue;
                }


                long order = 1;
                StringBuilder result = new StringBuilder(40);

                while (N != 0)
                {
                    string p = ConvertToText(N % 1000) + (order != 1 && N % 1000 != 0 ? separator + dict[order] : string.Empty);
                    if (!String.IsNullOrEmpty(p))
                    {
                        if (result.Length > 0 && char.IsLetter(result[0]))
                        {
                            result.Insert(0, p + separator);
                        }
                        else
                        {
                            result.Insert(0, p);
                        }
                    }
                    N /= 1000;
                    order *= 1000;
                }
                output.WriteLine(result.ToString());

            }
        }

        private static string ConvertToText(long p)
        {
            StringBuilder result = new StringBuilder(20);

            if (p > 999 || p < 0)
            {
                throw new ArgumentException("p");
            }

            if (p == 0)
            {
                return string.Empty;
            }

            if (p >= 100)
            {
                result.Append(dict[p / 100]);
                result.Append(separator);
                result.Append(dict[100]);
                if (p % 100 != 0)
                {
                    result.Append(separator);
                }
            }

            p %= 100;
            if (p > 20)
            {
                result.Append(dict[10 * (p / 10)]);
                if (p % 10 != 0)
                {
                    result.Append(separator);
                    result.Append(dict[p % 10]);
                }
            }
            else if (p > 0)
            {
                result.Append(dict[p]);
            }
            return result.ToString();
        }    

        public static void Test()
        {
            string inputData = @"2
10
17";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
