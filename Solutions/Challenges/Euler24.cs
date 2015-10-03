using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler24
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
                long N = long.Parse(input.ReadLine()) - 1;
                List<char> chars = new List<char>("abcdefghijklm");
                StringBuilder result = new StringBuilder(chars.Count);
                long lowerLimit = 0;
                while (chars.Count > 1)
                {
                    long interval = Faktorial(chars.Count - 1);
                    long segment = (N - lowerLimit) / interval;
                    result.Append(chars[(int)segment]);
                    chars.Remove(chars[(int)segment]);
                    lowerLimit += interval * segment;
                }
                result.Append(chars[0]);
                output.WriteLine(result.ToString());
            }

        }

        private static long Faktorial(long n)
        {
            for (long i = n - 1; i > 0; n *= i--) ;
            return n;
        }


        public static void Test()
        {
            string inputData = @"2
1
2";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }

}
