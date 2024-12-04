using System.Data;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ALBRIGHT_ASSIGNMENT_5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MSSA CCAD16 - CHRIS ALBRIGHT
            //ASSIGNMENT 5.3
            //WEEK 5 - 04DEC2024

            // Assignment 5.3.1 ---------------------------------------------------------------------------------------------

            //  You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be
            //  planted in adjacent plots. Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1
            //  means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating
            //  the no-adjacent - flowers rule and false otherwise.

            Console.WriteLine("Assignment 5.3.1 ----------------------------------------------------------------------------");
            Console.WriteLine("FLOWERBED ARRAY SOLVER:");
            char hold1 = 'y';
            do
            {
                Console.WriteLine("\nEnter the length of your flowerbed:");
                int flowerBedSize = int.Parse(Console.ReadLine());
                int [] flowerBed = new int[flowerBedSize];
                Console.WriteLine("\nNow please enter flowerbed slot plant status for each positon (i.e. 0 = empty and 1 = planted):");
                for (int i = 0;i<flowerBedSize;i++)
                {
                    Console.WriteLine($"Flowerbed slot {i + 1}:");
                    flowerBed[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Your Flowerbed looks as follows:");
                Console.Write("[");
                foreach (int i in flowerBed)
                {
                    Console.Write(i + ",");
                }
                Console.Write("]");
                Console.WriteLine("\n\nHow many flowers are you looking to plant?");
                int targetNumber = int.Parse(Console.ReadLine());
                if(FlowerbedPlanter(flowerBed, targetNumber) == true)
                {
                    Console.WriteLine("\nSounds good! Sufficient slots to plant your target value.");
                }
                else
                {
                    Console.WriteLine("\nSorry, your target value violates the adjacent planting rule.");
                }
                Console.WriteLine($"\nWant to go again? type y/n");
                hold1 = Convert.ToChar(Console.ReadLine());
            }
            while (hold1 == 'y');

            // Assignment 5.3.2 ---------------------------------------------------------------------------------------------

            // You are climbing a staircase. It takes n steps to reach the top. Each time you can either climb 1 or 2 steps.
            // In how many distinct ways can you climb to the top?

            Console.WriteLine("\nAssignment 5.3.2 ----------------------------------------------------------------------------");
            Console.WriteLine(" (n) STAIRSTEP PERMUTATION FINDER:");
            char hold2 = 'y';
            do
            {
                Console.WriteLine("\nHow many stairs would you like to climb?:");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nUsing recursion, there are {ClimbPermutationsWithRecursion(n)} ascent permutations using 1 or 2 steps.");
                Console.WriteLine($"\nUsing a fib sequence array, there are {ClimbPermutationsWithArrays(n)} ascent permutations using 1 or 2 steps.");
                Console.WriteLine($"\nWant to go again? type y/n");
                hold2 = Convert.ToChar(Console.ReadLine());
            }
            while (hold2 == 'y');

        }
        //---------------------------------------------------METHODS---------------------------------------------------------
        //5.3.1 Method:
        public static bool FlowerbedPlanter(int[] flowerBed, int targetNumber)
        { int plantedCounter = 0;
            for (int i = 0; i < flowerBed.Length; i++)
            {
                if (flowerBed[i] == 0)
                {
                    bool leftCheck = (i == 0) | (flowerBed[i - 1] == 0);
                    bool rightCheck = (i == flowerBed.Length) | (flowerBed[i + 1] == 0);
                    if (leftCheck && rightCheck == true)
                    {
                        flowerBed[i] = 1;
                        plantedCounter++;
                        if (plantedCounter >= targetNumber)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //5.3.2 Method:
        static int ClimbPermutationsWithRecursion(int n)
        {
            if (n <= 1) return 1;
            return ClimbPermutationsWithRecursion(n-1)+ClimbPermutationsWithRecursion(n - 2);
        }
        static int ClimbPermutationsWithArrays(int n)
        {
            if (n <= 1) return 1;
            int[] FibSequence = new int[n+1];
            FibSequence[0] = 1;
            FibSequence[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                FibSequence[i] = FibSequence[i-1]+FibSequence[i-2];
            }
            return FibSequence[n];
        }



    }
}
