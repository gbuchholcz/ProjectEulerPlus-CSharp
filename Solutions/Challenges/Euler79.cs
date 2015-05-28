using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler79
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
            Dictionary<char, HashSet<char>> forwardEdgeList = new Dictionary<char, HashSet<char>>();
            Dictionary<char, HashSet<char>> backwardEdgeList = new Dictionary<char, HashSet<char>>();

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                String pin = input.ReadLine().Trim();
                for (int i = 0; i < 3; ++i)
                {
                    char pinChar = pin[i];
                    if (!forwardEdgeList.ContainsKey(pinChar)) forwardEdgeList[pinChar] = new HashSet<char>();
                    if (!backwardEdgeList.ContainsKey(pinChar)) backwardEdgeList[pinChar] = new HashSet<char>();
                }
                forwardEdgeList[pin[0]].Add(pin[1]);
                forwardEdgeList[pin[1]].Add(pin[2]);
                backwardEdgeList[pin[2]].Add(pin[1]);
                backwardEdgeList[pin[1]].Add(pin[0]);
            }

            StringBuilder password = new StringBuilder();
            do
            {
                char minNode = char.MaxValue;
                foreach (var node in backwardEdgeList)
                {
                    if (node.Value.Count == 0 && node.Key < minNode)
                    {
                        minNode = node.Key;
                    }
                }
                if (minNode == char.MaxValue)
                {
                    output.WriteLine("SMTH WRONG");
                    return;
                }
                password.Append(minNode);
                foreach(char node in forwardEdgeList[minNode])
                {
                    backwardEdgeList[node].Remove(minNode);
                }
                backwardEdgeList.Remove(minNode);
                forwardEdgeList.Remove(minNode);
            } while (backwardEdgeList.Count > 0) ;

            output.WriteLine(password.ToString());
        }

        public static void Test()
        {
            string inputData = @"5
                                    SMH
                                    TON
                                    RNG
                                    WRO
                                    THG";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
