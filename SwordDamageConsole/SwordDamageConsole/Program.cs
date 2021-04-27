using System;

namespace SwordDamageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage();
            Random random = new Random();

            while(true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
                var keyPressed = Console.ReadKey(false).KeyChar;
                Console.WriteLine();

                if(!int.TryParse(keyPressed.ToString(), out int result) || result < 0 || result > 3)
                {
                    Environment.Exit(0);
                }

                int roll = 0;
                for (int i = 0; i < 3; i++)
                {
                    roll += random.Next(1, 7);
                }
                swordDamage.Roll = roll;

                swordDamage.SetMagic(keyPressed == '1' || keyPressed == '3');
                swordDamage.SetFlaming(keyPressed == '2' || keyPressed == '3');

                Console.WriteLine($"Rolled {swordDamage.Roll} for {swordDamage.Damage} HP\n\n");
            }
        }
    }
}
