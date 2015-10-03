using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler38
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
            string[] parameters = input.ReadLine().Split();
            int N = int.Parse(parameters[0]);
            int K = int.Parse(parameters[1]);

            for(int n = 2; n < N; ++n)
            {
                int[] digitCounter = new int[K];
                bool isPandigital = true;
                int ctr = 0;
                for(int i = 1; i <= K; ++i)
                {
                    string str = (n * i).ToString();
                    bool canBePandigital = true;
                    
                    for(int j = 0; j < str.Length; ++j)
                    {
                        int d = str[j] - '0' - 1;
                        if (d < 0 || d > K - 1 || digitCounter[d]++ > 0)
                        {
                            canBePandigital = false;
                            break;
                        }
                        ++ctr;
                    }
                    if (!canBePandigital)
                    {
                        isPandigital = false;
                        break;
                    }
                    else
                    {
                        if (ctr == K)
                        {
                            isPandigital = true;
                            break;
                        }
                    }
                }
                if (isPandigital)
                {
                    output.WriteLine(n);
                }
            }

        }

        public static void Test()
        {
            string inputData = @"100 8";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
