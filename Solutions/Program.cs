using Solutions.Challenges;
using System;
using System.Diagnostics;

namespace Solutions
{
    class Program
    {
        static void Main(string[] args)
        {
            Euler31.Test();
            WaitOnExit();
        }

        [Conditional("DEBUG")]
        static void WaitOnExit()
        {
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
