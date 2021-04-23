using System;

namespace AbilityScoreTester
{
    class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();

            while(true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide By");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add Amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Mimimum");
                calculator.CalculateAbilityScore();

                Console.WriteLine($"Calculated Ability Score: {calculator.Score}");
                Console.WriteLine("Press Q to quit, any other key to continue");

                char keyChar = Console.ReadKey(true).KeyChar;
                if(char.ToLower(keyChar) == 'q')
                {
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Write a prompt and reads and int value from the console.
        /// </summary>
        /// <param name="lastUsedValue">Default value</param>
        /// <param name="prompt">Prompt to print to the console</param>
        /// <returns>The int value read, or the default value if unable to parse</returns>
        private static double ReadDouble(double lastUsedValue, string prompt)
        {
            Console.Write($"{prompt} [{lastUsedValue}]: ");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                Console.WriteLine("\tUsing value " + result);
                return result;
            }

            Console.WriteLine("\tUsing default value " + lastUsedValue);
            return lastUsedValue;
        }

        /// <summary>
        /// Write a prompt and reads and int value from the console.
        /// </summary>
        /// <param name="lastUsedValue">Default value</param>
        /// <param name="prompt">Prompt to print to the console</param>
        /// <returns>The int value read, or the default value if unable to parse</returns>
        private static int ReadInt(int lastUsedValue, string prompt)
        {
            Console.Write($"{prompt} [{lastUsedValue}]: ");
            if(int.TryParse(Console.ReadLine(), out int result))
            {
                Console.WriteLine("\tUsing value " + result);
                return result;
            }

            Console.WriteLine("\tUsing default value " + lastUsedValue);
            return lastUsedValue;
        }
    }
}
