using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler25
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        [System.Diagnostics.DebuggerDisplay("[{Length}]:{num[0]}{num[1]}{num[2]}...")]
        private struct MyBigInt
        {
            int[] num;

            public int Length { get; private set; }

            public MyBigInt(int n)
                : this()
            {
                int i = 0;
                num = new int[5001];
                while (n != 0)
                {
                    num[i++] = n % 10;
                    n /= 10;
                    ++Length;
                }
            }

            public MyBigInt(MyBigInt b)
                : this()
            {
                this.Length = b.Length;
                this.num = new int[5001];
                Array.Copy(b.num, this.num, 5001);
            }

            public void Add(MyBigInt right)
            {
                int remainder = 0;
                int oldLength = this.Length;
                for (int i = 0; i < Math.Max(oldLength, right.Length) || remainder != 0; ++i)
                {
                    int sum = this.num[i] + right.num[i] + remainder;
                    this.num[i] = sum % 10;
                    this.Length = i + 1;
                    remainder = sum / 10;
                }
            }

        }

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            result.Add(1, 1);

            MyBigInt n1 = new MyBigInt(1);
            MyBigInt n2 = new MyBigInt(1);

            int cnt = 2;
            do
            {
                MyBigInt tmp = new MyBigInt(n2);
                n2.Add(n1);
                n1 = tmp;
                ++cnt;

                if (!result.ContainsKey(n2.Length))
                {
                    result[n2.Length] = cnt;
                }
            } while (n2.Length <= 5000);

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                output.WriteLine(result[N]);

            }

        }

        public static void Test()
        {
            string inputData = @"2
3
4";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
