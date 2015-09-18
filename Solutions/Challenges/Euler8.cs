using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler8
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                string[] inputSegments = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int N = int.Parse(inputSegments[0]);
                int K = int.Parse(inputSegments[1]);
                string number = input.ReadLine();
                int[] digits = ConvertBase(number);
                long maxProduct = 0;
                for (int i = 0; i < N - K + 1; ++i)
                {
                    long product = 1;
                    for (int j = i; j < i + K; ++j)
                    {
                        product *= digits[j];
                    }
                    if (product > maxProduct) maxProduct = product;
                }
                output.WriteLine(maxProduct);
            }
        }

        static int[] ConvertBase(string number)
        {
            number = number.Trim();
            int[] digits = new int[number.Length];
            for (int i = number.Length - 1; i >= 0; --i)
            {
                digits[number.Length - i - 1] = int.Parse(number[i].ToString());
            }
            return digits;
        }

        public static void Test()
        {
            string inputData = @"2
                                    10 5
                                    3675356291
                                    10 5
                                    2709360626";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
