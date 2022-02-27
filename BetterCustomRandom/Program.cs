using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterCustomRandom 
{
    internal class Program
    {
        static void Main()
        {
            int[] distribution = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            const int nTests = 100000;
            RNG random = new();

            for(int i = 0; i <= nTests; i++)
            {
                int current = random.Next();
                // Console.Write(current + ", ");
                distribution[current]++;
            }
            Console.WriteLine();

            for(int i = 0; i <= 9; i++)
            {
                Console.WriteLine(i + " count: " + distribution[i]);
            }
        }
    }
}