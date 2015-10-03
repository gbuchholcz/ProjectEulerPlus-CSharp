using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler28
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
                BigInteger mod = new BigInteger(1000000007);
                BigInteger i = new BigInteger((N - 1) >> 1);
                BigInteger i2 = BigInteger.Pow(i, 2);
                BigInteger i3 = BigInteger.Pow(i, 3);
                BigInteger sum_i = BigInteger.Divide(BigInteger.Add(i2, i), 2);
                BigInteger sum_i2 = BigInteger.Divide(BigInteger.Add(BigInteger.Add(BigInteger.Multiply(i3, 2), BigInteger.Multiply(i2, 3)), i), 6);

                BigInteger result = BigInteger.Remainder(
                                        BigInteger.Add(
                                            BigInteger.Add(
                                                BigInteger.Add(BigInteger.Multiply(i, 4), BigInteger.Multiply(sum_i, 4))
                                                , BigInteger.Multiply(sum_i2, 16))
                                            , 1)
                                        , mod);

                output.WriteLine(result.ToString());

            }
        }


        public static void Test()
        {
            string inputData = @"2
3
5";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
