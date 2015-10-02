using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler32
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            int N = int.Parse(input.ReadLine());
            int result = 0;
            HashSet<int> products = new HashSet<int>();
            for(int multiplicandLength = 1; multiplicandLength <= 1 + N / 2; ++multiplicandLength)
            {
                for (int multiplierLength = multiplicandLength; multiplierLength <= 1 + N / 2; ++multiplierLength)
                {
                    int productLength = N - multiplicandLength - multiplierLength;
                    if (productLength < 0 || productLength < multiplicandLength + multiplierLength - 1 || productLength > multiplicandLength + multiplierLength) continue;
                    foreach(var iteration in new PermutationGenerator<int>(Enumerable.Range(1, N)))
                    {
                        int multiplicand = 0;
                        int multiplier = 0;
                        int product = 0;
                        int ii = 0;
                        for(int i = 0; i < multiplicandLength; ++i)
                        {
                            multiplicand *= 10;
                            multiplicand += iteration[ii++];
                        }
                        for (int i = 0; i < multiplierLength; ++i)
                        {
                            multiplier *= 10;
                            multiplier += iteration[ii++];
                        }
                        for (int i = 0; i < productLength; ++i)
                        {
                            product *= 10;
                            product += iteration[ii++];
                        }
                        if (multiplicand * multiplier == product && !products.Contains(product))
                        {
                            products.Add(product);
                            result += product;
                        }
                    }
                }

            }
            output.WriteLine(result);
        }

        public class PermutationGenerator<T> : IEnumerable<T[]>
        {
            public PermutationGenerator(IEnumerable<T> inputSequence)
            {
                originalSequence = inputSequence.ToArray();
                permutation = Enumerable.Range(0, inputSequence.Count()).ToArray();
                valuePositionInPermutation = Enumerable.Range(0, inputSequence.Count()).ToArray();
                valueDirections = Enumerable.Repeat(false, inputSequence.Count()).ToArray();
            }

            T[] originalSequence;
            int[] permutation;
            int[] valuePositionInPermutation;
            bool[] valueDirections;

            private int LargestMobileNumber()
            {
                int result = -1;
                for (int val = permutation.Length - 1; val >= 0; --val)
                {
                    int targetLocation = valuePositionInPermutation[val] + (valueDirections[val] ? 1 : -1);
                    if (targetLocation >= 0 && targetLocation < permutation.Length && permutation[targetLocation] < val)
                    {
                        return val;
                    }
                }
                return result;
            }

            public IEnumerator<T[]> GetEnumerator()
            {
                if (originalSequence.Length == 0) yield break;

                yield return GenerateResult();

                while (LargestMobileNumber() != -1)
                {
                    int mobileValue = LargestMobileNumber();
                    int mobileLocation = valuePositionInPermutation[mobileValue];
                    int targetLocation = mobileLocation + (valueDirections[mobileValue] ? 1 : -1);
                    int targetValue = permutation[targetLocation];
                    Swap(ref permutation[mobileLocation], ref permutation[targetLocation]);
                    Swap(ref valuePositionInPermutation[mobileValue], ref valuePositionInPermutation[targetValue]);
                    for (int i = mobileValue + 1; i < valueDirections.Length; ++i)
                    {
                        valueDirections[i] = !valueDirections[i];
                    }

                    yield return GenerateResult();
                }
                yield break;

            }

            private T[] GenerateResult()
            {
                T[] result = new T[originalSequence.Length];
                for (int i = 0; i < originalSequence.Length; result[i] = originalSequence[permutation[i++]]) ;
                return result;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

        }

        public static void Swap<T>(ref T left, ref T right)
        {
            T tmp = left;
            left = right;
            right = tmp;
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
