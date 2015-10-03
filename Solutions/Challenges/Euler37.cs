using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler37
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
            long N = long.Parse(input.ReadLine());

            var primeGenerator = new PrimeGenerator(N);

            long result = 0;
            bool isTruncatablePrime;

            foreach (long p in primeGenerator.Where(p => p > 7))
            {
                long[] digits = ChangeBase(p, 10);
                isTruncatablePrime = true;
                for (int len = 1; len < digits.Length; ++len)
                {
                    long candidate = 0;
                    for (int i = len - 1; i >= 0; --i)
                    {
                        candidate *= 10;
                        candidate += digits[i];
                    }
                    if (!primeGenerator.IsPrime(candidate)) { isTruncatablePrime = false; break; }
                    candidate = 0;
                    for (int i = digits.Length - 1; i >= digits.Length - len; --i)
                    {
                        candidate *= 10;
                        candidate += digits[i];
                    }
                    if (!primeGenerator.IsPrime(candidate)) { isTruncatablePrime = false; break; }
                }
                if (isTruncatablePrime) result += p;
            }

            output.WriteLine(result.ToString());

        }

        public static long[] ChangeBase(long n, long b)
        {
            long[] result = new long[ArrLength(n, b)];
            for(int i = 0; n > 0; result[i++] = n % b, n /= b);
            return result;
        }

        public static long ArrLength(long n, long b)
        {
            int result = 0;
            while (n > 0)
            {
                ++result;
                n /= b;
            }; 
            return result;

        }

        public static void Test()
        {
            string inputData = @"100";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }

    //Sieve ot Atkin
    public class PrimeGenerator : IEnumerable<long>
    {

        private readonly bool[] isPrime;
        private long limit;

        public PrimeGenerator(long limit)
        {
            isPrime = new bool[limit];
            this.limit = limit;
            GeneratePrimes();
        }

        public bool IsPrime(long n)
        {
            return isPrime[n];
        }

        private void GeneratePrimes()
        {
            isPrime[0] = false;
            isPrime[1] = false;
            isPrime[2] = true;
            isPrime[3] = true;

            long limitSqrt = (int)Math.Sqrt(limit);

            for (int x = 1; x <= limitSqrt; x++) {
                for (int y = 1; y <= limitSqrt; y++) {
                    int n = (4 * x * x) + (y * y);
                    if (n < limit && (n % 12 == 1 || n % 12 == 5)) {
                        isPrime[n] = !isPrime[n];
                    }
                    n = (3 * x * x) + (y * y);
                    if (n < limit && (n % 12 == 7)) {
                        isPrime[n] = !isPrime[n];
                    }
                    n = (3 * x * x) - (y * y);
                    if (x > y && n < limit && (n % 12 == 11)) {
                        isPrime[n] = !isPrime[n];
                    }
                }
            }
            for (int n = 5; n <= limitSqrt; n++) {
                if (isPrime[n]) {
                    int x = n * n;
                    for (int i = x; i < limit; i += x) {
                        isPrime[i] = false;
                    }
                }
            }

        }
    

        public IEnumerator<long> GetEnumerator()
        {
            for(int i = 2; i < limit; ++i)
            {
                if (isPrime[i])
                    yield return i;
            }
            yield break;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
 
}
