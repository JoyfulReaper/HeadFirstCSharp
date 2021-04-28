using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLo
{
    static class HiLoGame
    {
        public const int MAXIMUM = 10;

        private static Random _random = new Random();
        private static int _currentNumber = _random.Next(1, MAXIMUM + 1);
        private static int _pot = 10;

        public static int GetPot() => _pot;

        public static void Guess(bool higher)
        {
            var nextNumber = _random.Next(1, MAXIMUM + 1);
            if(higher && nextNumber >= _currentNumber
                || !higher && nextNumber <= _currentNumber)
            {
                Console.WriteLine("You guessed right!");
                _pot++;
            }
            else
            {
                Console.WriteLine("Bad luck, you guessed wrong");
                _pot--;
            }

            _currentNumber = nextNumber;
            Console.WriteLine($"The current number is {_currentNumber}");
            Console.WriteLine();
        }

        public static void Hint()
        {
            int half = MAXIMUM / 2;
            if(_currentNumber >= half)
            {
                Console.WriteLine($"The number is at least {half}");
            }
            else
            {
                Console.WriteLine($"The number is at most {half}");
            }

            Console.WriteLine();
            _pot--;
        }
    }
}
