using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler14
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private const int maxInput = 5000000;
        private const int maxCachedElement = 10000000;
        private static long[] chainLengths = new long[maxCachedElement + 1];

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            chainLengths[1] = 1;
            List<long> chain = new List<long>(500);
            long[] maxLengths = new long[maxInput + 1];
            Tuple<long, long> result = Tuple.Create<long, long>(1, 1);

            for (long elem = 2; elem <= maxInput; ++elem)
            {
                long nextElem = elem;
                while (nextElem != 1)
                {
                    if (nextElem <= maxCachedElement && chainLengths[nextElem] != 0)
                    {
                        break;
                    }
                    chain.Add(nextElem);
                    nextElem = nextElem % 2 == 0 ? nextElem / 2 : 3 * nextElem + 1;
                }
                long tailLength = chainLengths[nextElem];
                long totalChainLength = chain.Count + tailLength;
                if (result.Item2 <= totalChainLength)
                {
                    result = Tuple.Create<long, long>(elem, totalChainLength);
                    maxLengths[elem] = elem;
                }
                else
                {
                    maxLengths[elem] = result.Item1;
                }
                for (int j = 0; j < chain.Count; ++j)
                {
                    if (chain[j] <= maxCachedElement)
                    {
                        chainLengths[chain[j]] = totalChainLength - j;
                    }
                }
                chain.Clear();
            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                output.WriteLine(maxLengths[N]);
            }
        }       


        public static void Test()
        {
            string inputData = @" 3
10 
15
20";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
