using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler22
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
            SortedSet<string> names = new SortedSet<string>();
            for (int N = int.Parse(input.ReadLine()); N > 0; --N)
            {
                names.Add(input.ReadLine().Trim().ToUpper());
            }
            Dictionary<string, int> results = new Dictionary<string, int>();

            int i = 0;
            foreach (string name in names)
            {
                results.Add(name, GetNameHash(++i, name));
            }
            for (int N = int.Parse(input.ReadLine()); N > 0; --N)
            {
                output.WriteLine(results[input.ReadLine().Trim().ToUpper()]);
            }
        }

        private static int GetNameHash(int i, string name)
        {
            int hash = 0;
            for (int j = 0; j < name.Length; ++j)
            {
                hash += (1 + name[j] - 'A');
            }
            return i * hash;
        }

        public static void Test()
        {
            string inputData = @"5
                                    ALEX
                                    LUIS
                                    JAMES
                                    BRIAN
                                    PAMELA
                                    1
                                    PAMELA";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
