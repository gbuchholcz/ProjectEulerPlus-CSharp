using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler26
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
            var positionMaxCycles = new List<Tuple<int, int>>();
            int maxCycle = -1;
            for (int i = 1; i <= 10000; ++i)
            {
                int cycle = CalculateReciprocalCycleLength(i);
                if (cycle > maxCycle)
                {
                    positionMaxCycles.Add(Tuple.Create(i, cycle));
                    maxCycle = cycle;
                }
            }


            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                output.WriteLine(MaxCycleUptoPosition(positionMaxCycles, N).ToString());
            }

        }

        public static int MaxCycleUptoPosition(List<Tuple<int, int>> list, int position)
        {
            int min = 0;
            int max = list.Count - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                int comparison = list[mid].Item1.CompareTo(position);
                if (comparison == 0)
                {
                    return list[mid - 1].Item1;
                }
                if (comparison < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            return list[min - 1].Item1;
        }

        private static int CalculateReciprocalCycleLength(int divisor)
        {
            if (divisor < 1) throw new ArgumentException("divisor");

            var remainderPosition = new int[divisor];
            int position = 0;
            int dividend = 1;
            do
            {
                while (dividend < divisor)
                {
                    ++position;
                    dividend *= 10;
                }
                dividend = dividend % divisor;
                if (remainderPosition[dividend] != 0)
                {
                    return position - remainderPosition[dividend];
                }
                remainderPosition[dividend] = position;
            } while (dividend != 0);
            return 0;
        }

        public static void Test()
        {
            string inputData = @"2
5
10";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
