using System;

namespace WeaponDamage
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(RollDice(3));
            ArrowDamage arrowDamage = new ArrowDamage(RollDice(1));

            while (true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
                var keyPressed = Console.ReadKey(false).KeyChar;
                Console.WriteLine();

                if (!int.TryParse(keyPressed.ToString(), out int result) || result < 0 || result > 3)
                {
                    Environment.Exit(0);
                }

                Console.Write("S for sword, A for arrow, anything else to quit: ");
                char weaponKey = Console.ReadKey().KeyChar;

                weaponKey = Char.ToLowerInvariant(weaponKey);
                switch (weaponKey)
                {
                    case 's':
                        swordDamage.Roll = RollDice(3);
                        swordDamage.Magic = (keyPressed == '1' || keyPressed == '3');
                        swordDamage.Flaming = (keyPressed == '2' || keyPressed == '3');

                        Console.WriteLine($"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP\n\n");
                        break;
                    case 'a':
                        arrowDamage.Roll = RollDice(1);
                        arrowDamage.Magic = (keyPressed == '1' || keyPressed == '3');
                        arrowDamage.Flaming = (keyPressed == '2' || keyPressed == '3');

                        Console.WriteLine($"\nRolled {arrowDamage.Roll} for {arrowDamage.Damage} HP\n\n");
                        break;
                    default:
                        return;
                }
            }
        }

        private static int RollDice(int numberOfRolls)
        {
            int total = 0;

            for (int i = 0; i < numberOfRolls; i++)
            {
                total += random.Next(1, 7);
            }

            return total;
        }
    }
}
