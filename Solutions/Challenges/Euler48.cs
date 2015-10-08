using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler48
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
            ulong N = ulong.Parse(input.ReadLine());
            ulong mod = 10000000000;
            ulong result = 0;
            for (ulong i = 1; i <= N; ++i)
            {
                result += PowMod(i, i, mod);
                result %= mod;
            }
            Console.WriteLine(result.ToString().TrimStart('0'));
        }

        private static ulong MulMod(ulong a, ulong b, ulong m)
        {
            if (a == 0 || b == 0) return 0;
            a %= m;
            b %= m;
            ulong maxB = ulong.MaxValue / a;
            if (maxB >= b) return (a * b) % m;
            return (((a * maxB) % m) * ((b / maxB) % m) + (a * (b % maxB)) % m) % m;
        }

        private static ulong PowMod(ulong b, ulong e, ulong m)
        {
            ulong result = 1;
            b = b % m;
            while (e > 0)
            {
                if (e % 2 == 1)
                {
                    result = MulMod(result, b, m);
                }
                e = e >> 1;
                b = MulMod(b, b, m);
            }
            return result;
        }

        public static void Test()
        {
            string inputData = @"10";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }


    }

}
