using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler5
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
                long N = long.Parse(input.ReadLine());

                int[] arr = Enumerable.Range(1, (int)N).ToArray();
                int result = 1;
                for (int act = 0; act < arr.Length; ++act)
                {
                    result *= arr[act];
                    for (int i = act + 1; i < arr.Length; ++i)
                    {
                        if (arr[i] % arr[act] == 0)
                            arr[i] /= arr[act];
                    }
                }
                output.WriteLine(result);
            }
        }

        public static void Test()
        {
            string inputData = @"2
                                    3
                                    10";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
