using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler18
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
                int N = int.Parse(input.ReadLine());

                int[,] inputTriangle = new int[N, N];
                int[,] resultTriangle = new int[N, N];
                int maxPath = 0;

                for (int i = 0; i < N; ++i)
                {
                    string[] elements = input.ReadLine().Split();
                    for (int j = 0; j < elements.Length; ++j)
                    {
                        inputTriangle[i, j] = int.Parse(elements[j]);
                    }
                }

                resultTriangle[0, 0] = inputTriangle[0, 0];
                maxPath = resultTriangle[0, 0];
                
                for (int i = 1; i < N; ++i)
                {
                    int elementsInRow = i + 1;
                    for (int j = 0; j < elementsInRow; ++j)
                    {
                        if (j == 0)
                        {
                            resultTriangle[i, j] = inputTriangle[i, j] + resultTriangle[i - 1, j];
                        }
                        else if (j == elementsInRow - 1)
                        {
                            resultTriangle[i, j] = inputTriangle[i, j] + resultTriangle[i - 1, j - 1];
                        }
                        else
                        {
                            resultTriangle[i, j] = inputTriangle[i, j] + Math.Max(resultTriangle[i - 1, j - 1], resultTriangle[i - 1, j]);
                        }

                        if (resultTriangle[i, j] > maxPath)
                        {
                            maxPath = resultTriangle[i, j];
                        }
                    }
                }

                output.WriteLine(maxPath);
            }
        }

        public static void Test()
        {
            string inputData = @"1
4
3
7 4
2 4 6
8 5 9 3";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
