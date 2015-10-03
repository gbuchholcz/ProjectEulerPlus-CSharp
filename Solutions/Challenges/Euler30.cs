
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler30
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static int[] powTable = new int[10];

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            int N = int.Parse(input.ReadLine());

            for (int i = 0; i < 10; ++i)
            {
                powTable[i] = (int)Math.Pow(i, N);
            }

            int result = 0;
            int maxExp = (int)Math.Pow(9, N);
            int maxNumberLength = 2;
            for (; Math.Pow(10, maxNumberLength) <= maxExp; ++maxNumberLength) ;
            int maxNumber = (int)Math.Pow(10, maxNumberLength + 1);

            for (int i = 10; i < maxNumber; ++i)
            {
                if (isNumberSpecial(i, N)) result += i;
            }

            output.WriteLine(result);
        }

        private static bool isNumberSpecial(int n, int exp)
        {
            int origN = n;
            int sum = 0;
            while (n != 0)
            {
                sum += powTable[n % 10];
                n /= 10;
            }
            if (sum == origN) return true;
            return false;
        }

        public static void Test()
        {
            string inputData = @"4";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
