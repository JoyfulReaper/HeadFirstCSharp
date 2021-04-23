using System;

namespace ElephantExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Elephant lucinda = new Elephant() { Name = "Lucinda", EarSize = 33 };
            Elephant lloyd = new Elephant() { Name = "Lloyd", EarSize = 40 };

            while(true)
            {
                Console.WriteLine("Press 1 for Lloyd, 2 for Lucinda, 3 to swap");
                var inputKey = Console.ReadKey(true).KeyChar;

                Console.WriteLine("You pressed " + inputKey);

                switch (inputKey)
                {
                    case '1':
                        ShowElephantInfo(lloyd);
                        break;
                    case '2':
                        ShowElephantInfo(lucinda);
                        break;
                    case '3':
                        SwapReferences(ref lloyd, ref lucinda);
                        break;
                    case 'q':
                    case 'Q':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"{inputKey} is not a valid option");
                        continue;
                }
            }
        }

        private static void SwapReferences(ref Elephant e1, ref Elephant e2)
        {
            Elephant temp = e1;
            e1 = e2;
            e2 = temp;
            Console.WriteLine("References have been swapped");
            Console.WriteLine();
        }

        private static void ShowElephantInfo(Elephant elephant)
        {
            Console.WriteLine($"Calling {elephant.Name.ToLower()}.WhoAmI()");
            elephant.WhoAmI();
            Console.WriteLine();
        }
    }
}
