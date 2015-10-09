using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler49
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
            var pars = input.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            int N = pars[0];
            int K = pars[1];
            Dictionary<long, int[]> primeStore = new Dictionary<long, int[]>();
            var results = new List<Tuple<long, long>>();

            for(int i = 1000; i < 1000000; ++i)
            {
                if (IsPrime(i))
                {
                    long hash = CalculateHash(i);
                    if (!primeStore.ContainsKey(hash)) primeStore[hash] = new int[722];
                    primeStore[hash][1 + primeStore[hash][0]++] = i;
                }
            }
            foreach(int i in primeStore.Keys)
            {
                
                int[] primePermutations = primeStore[i];
                int sLen = primePermutations[0];
                if (sLen < K) continue;
                int maxSeq = primePermutations[sLen];
                for(int sstart = 1; sstart <= sLen - K + 1 ; ++sstart)
                {
                    if (primePermutations[sstart] >= N) break;
                    for (int sNext = sstart + 1; sNext <= sLen - K + 2; ++sNext)
                    {
                        int d = primePermutations[sNext] - primePermutations[sstart];
                        if (primePermutations[sNext] + (K - 2) * d > maxSeq) break;
                        int s3 = Array.IndexOf(primePermutations, primePermutations[sNext] + d, sNext + 1);
                        if (s3 != -1)
                        {
                            if (K == 3)
                            {
                                results.Add(new Tuple<long, long>(primePermutations[sstart], long.Parse((primePermutations[sstart] + d) + "" + (primePermutations[sstart] + 2 * d))));
                                continue;
                            }
                            else
                            {
                                int s4 = Array.IndexOf(primePermutations, primePermutations[sNext] + 2 * d, s3 + 1, primePermutations[0] - s3);
                                if (s4 > s3)
                                {
                                    results.Add(new Tuple<long, long>(primePermutations[sstart],
                                        long.Parse(
                                        "" + (primePermutations[sstart] + d)
                                        + "" + (primePermutations[sstart] + 2 * d)
                                        + "" + (primePermutations[sstart] + 3 * d))));
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            output.WriteLine(results.OrderBy(e => e.Item1).ThenBy(e => e.Item2).Select(e => e.Item1 + "" + e.Item2).Aggregate("", (acc, e) => acc + e + Environment.NewLine));

        }

        private static long CalculateHash(int i)
        {
            int result = 0;
            int[] digitCount = new int[10];
            while(i>0)
            {
                digitCount[i % 10]++;
                i /= 10;
            }
            for (int j = 0; j < 10; ++j )
            {
                result |= digitCount[j] << (j * 3);
            }
            return result;
        }

        public static void Test()
        {
            string inputData = @"1000000 4";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        public static int[] _primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113
                    , 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293
                    , 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491
                    , 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701
                    , 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929
                    , 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009};

        public static IEnumerable<int> Primes(int max)
        {
            int len = _primes.Length;
            for (int i = 0; i < len && _primes[i] < max; ++i) yield return _primes[i];
            for (int n = _primes[len - 1] + 2; n < max; n += 2)
            {
                if (IsPrime(n)) yield return n;
            }
        }

        public static bool IsPrime(int n)
        {
            if ((n | 0x00) == 0x01) return false;

            int len = _primes.Length;
            if (n <= _primes[len - 1])
            {
                int pos = Array.BinarySearch(_primes, n);
                if (pos >= 0) return true;
                return false;
            }

            int maxDivisor = (int)Math.Sqrt(n) + 1;
            for (int i = 0; i < len && _primes[i] < maxDivisor; ++i)
            {
                if (n % _primes[i] == 0) return false;
            }
            for (int i = _primes[len - 1]; i < maxDivisor; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

    }
}
