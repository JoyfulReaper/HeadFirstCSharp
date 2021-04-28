using System;

namespace PaintballGun
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = ReadInt(20, "Number of balls");
            int magazineSize = ReadInt(16, "Magazine size");

            Console.Write("Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);

            while(true)
            {
                //Console.WriteLine($"{gun.GetBalls()} balls, {gun.GetBallsLoaded()} loaded");
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
                if (gun.IsEmpty())
                {
                    Console.WriteLine("WARNING: You're out of ammo");
                }

                Console.WriteLine("Space to shoot, r to reload, + to add ammon, q to quit");

                char key = Console.ReadKey(true).KeyChar;
                
                switch(key)
                {
                    case ' ':
                        Console.WriteLine($"Shooting returned {gun.Shoot()}");
                        break;
                    case 'r':
                        gun.Reload();
                        break;
                    case '+':
                        //gun.SetBalls(gun.GetBalls() + PaintballGun.MAGAZINE_SIZE);
                        gun.Balls += gun.MagazineSize;
                        break;
                    case 'q':
                        return;
                }
            }
        }

        static int ReadInt(int lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int value))
            {
                Console.WriteLine("   using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine("   using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }
    }
}
