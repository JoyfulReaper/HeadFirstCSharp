using System;

namespace HiLo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HiLo.");
            Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}");
            HiLoGame.Hint();
            while(HiLoGame.GetPot() > 0)
            {
                Console.WriteLine("Press h for higher, l for lower, ? to buy a hint,");
                Console.WriteLine($"or any other key to quit with {HiLoGame.GetPot()}.");

                char key = Console.ReadKey(true).KeyChar;

                switch (key)
                {
                    case 'h':
                        HiLoGame.Guess(true);
                        break;
                    case 'l':
                        HiLoGame.Guess(false);
                        break;
                    case '?':
                        HiLoGame.Hint();
                        break;
                    default:
                        return;
                }
            }

            Console.WriteLine("The pot is empty. Bye!");
        }
    }
}
