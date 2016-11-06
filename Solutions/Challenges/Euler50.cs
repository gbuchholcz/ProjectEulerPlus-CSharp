using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler50
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static PrimeGenerator pg = new PrimeGenerator(10000000);

        static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {

            long maxN = 1000000000000;
            Sequence[] primeSum = new Sequence[1000000];
            long[] primeSumIndex = new long[1000000];
            int primeSumLength = 1;

            long sum = 0;

            foreach (var prime in pg)
            {
                sum += prime;

                primeSum[primeSumLength].Sum = sum;
                primeSum[primeSumLength].LastPrime = prime;
                primeSumIndex[primeSumLength] = primeSum[primeSumLength].Sum;
                ++primeSumLength;

                if (sum > maxN)
                {
                    break;
                }
            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {

                long N = long.Parse(input.ReadLine());
                int index = Array.BinarySearch(primeSumIndex, 0, primeSumLength, N);
                if (index > 0)
                {
                    if (pg.IsPrime(primeSum[index].Sum))
                    {
                        Console.WriteLine(primeSum[index].Sum + " " + index);
                        continue;
                    }
                    else
                    {
                        while (!pg.IsPrime(primeSum[--index].Sum)) ;
                    }
                }
                else
                {

                    index = ~index;
                    while (!pg.IsPrime(primeSum[--index].Sum)) ;
                }


                long startPrime = primeSum[index].LastPrime;
                long startSum = primeSum[index].Sum;
                int startLength = index;
                long stopSum = N;

                long resultSum = startSum;
                int resultLength = startLength;

                long actualSum = startSum;

                int actualLength = startLength;
                long totalIncrement = 0;
                foreach (long addendPrime in pg.GetPrimeEnumerator(startPrime + 1, long.MaxValue))
                {
                    totalIncrement += addendPrime;
                    if (totalIncrement > stopSum)
                    {
                        break;
                    }
                    actualSum += addendPrime;
                    ++actualLength;

                    var shortend = ShortenSequence(actualSum, actualLength, resultLength, stopSum);
                    if (shortend == null)
                    {
                        break;
                    }
                    else if (shortend.Item1 != 0)
                    {
                        resultLength = shortend.Item1;
                        resultSum = shortend.Item2;
                    }
                }

                Console.WriteLine(resultSum + " " + resultLength);

            }

        }

        private static Tuple<int, long> ShortenSequence(long actualSum, int actualLength, int minLength, long maxSum)
        {
            bool iscalled = false;
            foreach (long prime in pg)
            {
                --actualLength;
                if (actualLength <= minLength) break;
                actualSum -= prime;
                if (actualSum > maxSum) continue;
                iscalled = true;
                if (pg.IsPrime(actualSum))
                {
                    return Tuple.Create(actualLength, actualSum);
                }
            }
            if (!iscalled && actualSum > maxSum) return null;
            return Tuple.Create(0, 0L);
        }

        public struct Sequence
        {
            public long LastPrime { get; set; }
            public long Sum { get; set; }
        }

        public static void Test()
        {
            string inputData = @"2
                                    100
                                    1000";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        /// <summary>
        /// A class that support prime related functionalities like enumerating primes or checking whether a number is prime or not. The class is backed by sieve of Atkin.
        /// </summary> 
        public class PrimeGenerator : IEnumerable<long>
        {

            /// <summary>
            /// An array that stores for each number [0, max] if they are primes.
            /// </summary>
            private readonly bool[] isPrime;
            public bool[] PrimeSieve { get { return isPrime; } }

            private int[] primes;
            public int[] Primes { get { return primes; } }

            private long max;


            /// <summary>
            /// Initializes a new instance of the <see cref="PrimeGenerator"/> class. To optimize performance all numbers from 0 to max (inclusive) are evaluated if they are prime.
            /// </summary>
            /// <param name="max">The highest number (inclusive) that is preevaluated.</param>
            public PrimeGenerator(long max)
            {
                this.max = max;
                this.isPrime = new bool[max + 1];
                GeneratePrimes();
            }

            public bool IsPrime(long n)
            {
                if (n > max)
                {
                    if (n % 2 == 0) return false;
                    long sqrt = (int)(Math.Sqrt(n) + 0.1);
                    int primeCount = primes.Length;
                    int i;
                    for (i = 1; i < primeCount && primes[i] <= sqrt; ++i)
                    {
                        if (n % primes[i] == 0) return false;
                    }
                    if (i == primeCount)
                    {
                        for (long p = primes[primeCount - 1] + 2; p <= sqrt; p += 2)
                        {
                            if (n % p == 0) return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return isPrime[n];
                }
            }

            private void GeneratePrimes()
            {
                isPrime[0] = false;
                isPrime[1] = false;
                isPrime[2] = true;
                isPrime[3] = true;
                long limitSqrt = (int)(Math.Sqrt(max) + 0.1);

                for (int x = 1; x <= limitSqrt; x++)
                {
                    for (int y = 1; y <= limitSqrt; y++)
                    {
                        int n = (4 * x * x) + (y * y);
                        if (n <= max && (n % 12 == 1 || n % 12 == 5))
                        {
                            isPrime[n] = !isPrime[n];
                        }
                        n = (3 * x * x) + (y * y);
                        if (n <= max && (n % 12 == 7))
                        {
                            isPrime[n] = !isPrime[n];
                        }
                        n = (3 * x * x) - (y * y);
                        if (x > y && n <= max && (n % 12 == 11))
                        {
                            isPrime[n] = !isPrime[n];
                        }
                    }
                }
                for (int n = 5; n <= limitSqrt; n++)
                {
                    if (isPrime[n])
                    {
                        int x = n * n;
                        for (int i = x; i <= max; i += x)
                        {
                            isPrime[i] = false;
                        }
                    }
                }
                var primeList = new List<int>((int)max);
                for (int i = 2; i <= max; ++i)
                {
                    if (isPrime[i]) primeList.Add(i);
                }
                primes = primeList.ToArray();
            }

            public IEnumerable<long> GetPrimeEnumerator(long from, long to)
            {
                if (from % 2 == 0) from++;
                if (from <= max && from < to)
                {
                    for (int i = (int)from; i <= max && i < to; ++i)
                    {
                        if (isPrime[i])
                            yield return i;
                    }
                }
                for (long i = primes[primes.Length - 1] + 2; i < to; i += 2)
                {
                    if (IsPrime(i))
                        yield return i;
                }
            }

            public IEnumerator<long> GetEnumerator()
            {
                for (int i = 2; i <= max; ++i)
                {
                    if (isPrime[i])
                        yield return i;
                }
                for (long i = primes[primes.Length - 1] + 2; ; i += 2)
                {
                    if (IsPrime(i))
                        yield return i;
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

    }
}
