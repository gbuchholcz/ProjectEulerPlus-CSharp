using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler33
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
            string[] parameters = input.ReadLine().Split();
            int N = int.Parse(parameters[0]);
            int K = int.Parse(parameters[1]);

            int maxSimplifiedNumerator = MathToolbelt.Pow10[N - K];
            int maxNumerator = MathToolbelt.Pow10[N];
            int minNumerator = MathToolbelt.Pow10[N - 1];
            int numeratorSum = 0;
            int denominatorSum = 0;

            int[][] canceledDigitLocationCombinations = MathToolbelt.Combinate(N, K).ToArray();
            int[][] canceledDigitsPermutations = MathToolbelt.PermuteWithRepetition(1, 9, K).ToArray();
            bool[,] resultLookup = new bool[maxNumerator, maxNumerator];

            for (int simplifiedNominator = 1; simplifiedNominator < maxSimplifiedNumerator; ++simplifiedNominator)
            {
                int[] simplifiedNominatorDigits = simplifiedNominator.ToArray(N - K);

                for (int simplifiedDenominator = simplifiedNominator + 1; simplifiedDenominator < maxSimplifiedNumerator; ++simplifiedDenominator)
                {

                    foreach (int[] canceledDigits in canceledDigitsPermutations)
                    {

                        foreach (int[] canceledDigitLocations in canceledDigitLocationCombinations)
                        {
                            int[] nominatorDigits = new int[N];

                            for (int i = 0; i < K; ++i)
                            {
                                nominatorDigits[canceledDigitLocations[i]] = canceledDigits[i];
                            }
                            int j = 0;
                            for (int i = 0; i < N; ++i)
                            {
                                if (nominatorDigits[i] == 0)
                                {
                                    nominatorDigits[i] = simplifiedNominatorDigits[j++];
                                }
                            }

                            int numerator = nominatorDigits.ToInt();

                            //output.WriteLine(simplifiedNominator + "-" + numerator);

                            if (numerator >= minNumerator && (numerator * simplifiedDenominator % simplifiedNominator) == 0)
                            {
                                int denominator = numerator * simplifiedDenominator / simplifiedNominator;
                                if (numerator < denominator && denominator < maxNumerator && !resultLookup[numerator, denominator])
                                {
                                    int[] simplifiedDenominatorDigits = simplifiedDenominator.ToArray(N - K);
                                    if (ContainsAllDigits(denominator, simplifiedDenominatorDigits, canceledDigits))
                                    {
                                        //output.WriteLine(numerator +"/"+ denominator + " -  " + simplifiedNominator + "/" + simplifiedDenominator);
                                        resultLookup[numerator, denominator] = true;
                                        numeratorSum += numerator;
                                        denominatorSum += denominator;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }

                        }
                    }
                }
            }
            output.WriteLine(numeratorSum.ToString() + " " + denominatorSum.ToString());
        }

        public static void Test()
        {
            string inputData = @"3 1";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static bool ContainsAllDigits(int n, int[] orderedDigits, int[] unorderedDigits)
        {
            int[] number = n.ToArray();
            long[] digits = new long[10];
            long digitsSum = 0;
            int orderedDigitsLength = orderedDigits.Length;
            int d1p = 0;

            for (int i = 0; i < unorderedDigits.Length; digits[unorderedDigits[i++]]++, digitsSum++) ;

            for (int i = 0; i < number.Length; ++i)
            {
                if (d1p < orderedDigitsLength && orderedDigits[d1p] == number[i])
                {
                    d1p++;
                }
                else if (digits[number[i]] > 0)
                {
                    digits[number[i]]--;
                    digitsSum--;
                }
                else
                {
                    return false;
                }
            }
            if (digitsSum != 0 || d1p != orderedDigitsLength)
            {
                return false;
            }
            return true;
        }

    }

    public static class MathToolbelt
    {

        public static readonly int[] Pow10 = new int[] { 1, 10, 100, 1000, 10000, 100000, 1000000 };

        public static int[] ToArray(this int n, int padding = 0)
        {
            int len = ArrLength(n);
            int[] result = new int[len > padding ? len : padding];
            for (int i = result.Length - 1; i >= 0; result[i--] = n % 10, n /= 10) ;
            return result;
        }

        public static int ToInt(this int[] ns)
        {
            int result = 0;
            for (int i = 0; i < ns.Length; ++i)
            {
                result *= 10;
                result += ns[i];
            }
            return result;
        }

        private static int ArrLength(int n)
        {
            if (n < 10) return 1;
            if (n < 100) return 2;
            if (n < 1000) return 3;
            if (n < 10000) return 4;
            if (n < 100000) return 5;
            if (n < 1000000) return 6;
            if (n < 10000000) return 7;
            return 8;
        }


        public static IEnumerable<int[]> PermuteWithRepetition(int min, int max, int selectionLength)
        {
            int[] sourceArray = Enumerable.Range(min, max - min + 1).ToArray();
            int sourceLength = sourceArray.Length;
            int[] selectorIndeces = new int[selectionLength];

            bool isFinished = false;
            while (!isFinished)
            {
                yield return selectorIndeces.Select(p => sourceArray[p]).ToArray();
                bool makeStep = true;
                for (int i = selectionLength - 1; i >= 0; --i)
                {
                    if (makeStep)
                    {
                        if (selectorIndeces[i] == sourceLength - 1)
                        {
                            selectorIndeces[i] = 0;
                        }
                        else
                        {
                            ++selectorIndeces[i];
                            makeStep = false;
                        }
                    }
                }
                if (makeStep)
                {
                    isFinished = true;
                }
            }
        }

        public static IEnumerable<int[]> Combinate(int n, long k)
        {
            var sourceArray = Enumerable.Range(0, n).ToArray();
            int len = sourceArray.Length;
            int[] result = new int[k];
            
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < len)
                {
                    result[index++] = sourceArray[value++];
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result.ToArray();
                        break;
                    }
                }
            }
        }


    }


}
