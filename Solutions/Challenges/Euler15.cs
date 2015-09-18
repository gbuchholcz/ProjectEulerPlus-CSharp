using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler15
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
                String[] str = input.ReadLine().Split();
                int N = int.Parse(str[0]);
                int  M = int.Parse(str[1]);
                long r = NcrModP(N + M, N > M ? M : N, 1000000007);
                output.WriteLine(r);
            }
        }

        static long NcrModP(long n, long k, long mod)
        {
            long result = 1;
            for (long i = n; i >= n - k + 1; --i)
            {
                result = (result * i) % mod;
            }
            for (long i = k; i >= 2; --i)
            {
                result = (result * InverseMod(i, mod)) % mod;
            }
            return result;
        }

        public static long InverseMod(long n, long m)
        {
            long t = 0;
            long newt = 1;
            long r = m;
            long newr = n;
            long tmp;
            while (newr != 0)
            {
                long quotient = r / newr;
                tmp = newt;
                newt = t - quotient * newt;
                t = tmp;
                tmp = newr;
                newr = r - quotient * newr;
                r = tmp;
            }
            if (r > 1) { new InvalidOperationException("n is not invertible"); }
            if (t < 0) { t += m; }
            return t;
        }


        public static void Test()
        {
            string inputData = @"2
2 2
3 2";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
