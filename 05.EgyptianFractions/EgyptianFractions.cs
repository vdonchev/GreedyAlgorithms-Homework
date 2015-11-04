namespace _05.EgyptianFractions
{
    using System;
    using System.Linq;

    class EgyptianFractions
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
            int numerator = nums[0];
            int denominator = nums[1];

            if (numerator >= denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
            }
            else
            {
                Console.Write($"{numerator}/{denominator} = ");
                int denom = 2;
                bool first = true;
                while (numerator > 0)
                {
                    int currentNumerator = (numerator * denom - denominator * 1);
                    int currentDenominator = denominator * denom;

                    if (currentNumerator < numerator && currentNumerator >= 0)
                    {
                        numerator = currentNumerator;
                        denominator = currentDenominator;
                        if (first)
                        {
                            first = false;
                            Console.Write($"1/{denom}");
                            continue;
                        }

                        Console.Write($" + 1/{denom}");
                    }
                    else
                    {
                        denom++;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}