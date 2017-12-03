using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighestProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arryOfInts = { -10, 2, 4, -5};
            int result = HighestProductOf3(arryOfInts);
            Console.WriteLine("Highest product of three is: {0}", result);
            Console.ReadLine();
        }

        public static int HighestProductOf3(int[] arrayOfInts)
        {
            if(arrayOfInts.Length < 3)
            {
                throw new ArgumentException("Less than 3 items in the array", nameof(arrayOfInts));
            }

            // Start at index 2
            // Pre-populate highest and lowest based on the first 2 items
            int highest;
            int lowest;
            if(arrayOfInts[0] > arrayOfInts[1])
            {
                highest = arrayOfInts[0];
                lowest = arrayOfInts[1];
            }
            else
            {
                highest = arrayOfInts[1];
                lowest = arrayOfInts[0];
            }

            int highestProductOf2 = arrayOfInts[0] * arrayOfInts[1];
            int lowestProductof2 = arrayOfInts[0] * arrayOfInts[1];

            // Have to pre-populate to get started
            int highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] * arrayOfInts[2];

            // walk through all items in array starting at index 2
            for (int i = 2; i < arrayOfInts.Length; i++)
            {
                int current = arrayOfInts[i];

                // Do we have a new highest product of 3?
                // Either the current highest, or current tmies highest product of two,
                // or the current times the lowest product of two (for negative numbers)
                highestProductOf3 = Math.Max(Math.Max(highestProductOf3, current * highestProductOf2),
                    current * lowestProductof2);

                // Is there a new highest product of two?
                highestProductOf2 = Math.Max(Math.Max(highestProductOf2, current * highest),
                    current * lowest);

                // New lowest product of two?
                lowestProductof2 = Math.Min(Math.Min(lowestProductof2, current * highest),
                    current * lowest);

                // new highest?
                highest = Math.Max(highest, current);

                // new lowest?
                lowest = Math.Min(lowest, current);
            }
            return highestProductOf3;
        }
    }
}
