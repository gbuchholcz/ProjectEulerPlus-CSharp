using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler13
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
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            
            int T = int.Parse(input.ReadLine());
            string[] numbers = new string[T];
            for (int i = 0; i < T; ++i)
            {
                numbers[i] = input.ReadLine();
            }

            int remainder = 0;
            int sum = 0;
            for (int i = numbers[0].Length - 1; i >= 0; --i)
            {
                sum = remainder;
                for (int j = 0; j < T; ++j)
                {
                    sum += int.Parse(numbers[j][i].ToString());
                }
                result.Insert(0, sum % 10);
                remainder = (sum - sum % 10) / 10;
            }
            result.Insert(0, remainder.ToString());
            output.WriteLine(result.ToString(0, 10));
        }


        public static void Test()
        {
            string inputData = @"5
37107287533902102798797998220837590246510135740250
46376937677490009712648124896970078050417018260538
74324986199524741059474233309513058123726617309629
91942213363574161572522430563301811072406154908250
23067588207539346171171980310421047513778063246676";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
