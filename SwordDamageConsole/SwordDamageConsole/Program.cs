using System;

namespace SwordDamageConsole
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(RollDice());
            

            while(true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
                var keyPressed = Console.ReadKey(false).KeyChar;
                Console.WriteLine();

                if(!int.TryParse(keyPressed.ToString(), out int result) || result < 0 || result > 3)
                {
                    Environment.Exit(0);
                }

                swordDamage.Roll = RollDice();
                swordDamage.Magic = (keyPressed == '1' || keyPressed == '3');
                swordDamage.Flaming = (keyPressed == '2' || keyPressed == '3');

                Console.WriteLine($"Rolled {swordDamage.Roll} for {swordDamage.Damage} HP\n\n");
            }
        }

        private static int RollDice()
        {
            return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        }
    }
}
