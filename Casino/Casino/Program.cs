using System;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = 0.75;
            Guy player = new Guy() { Name = "The Player", Cash = 100 };

            int wins = 0;
            int losses = 0;

            ConsoleColor color = Console.ForegroundColor;

            Console.WriteLine($"Welcome to The Casino. The odds are {odds:f2}");
            Console.WriteLine();

            while (player.Cash > 0)
            {
                player.WriteMyInfo();

                string howMuch = string.Empty;
                int amount;
                while(!int.TryParse(howMuch, out amount) || amount < 1 || amount > player.Cash)
                {
                    Console.Write("How much do you want to bet: ");
                    howMuch = Console.ReadLine();
                }

                decimal pot = player.GiveCash(amount) * 2;

                if(random.NextDouble() > odds)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You win {pot:C2}");
                    Console.ForegroundColor = color;
                    player.ReceiveCash(pot);

                    wins++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad luck, you lose");
                    Console.ForegroundColor = color;

                    losses++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("The house always wins");
            Console.ForegroundColor = color;

            Console.WriteLine();
            Console.WriteLine($"You won {wins} rounds and lost {losses} rounds ({(((double)wins/losses) * 100):F2}% win rate)");
        }
    }
}
