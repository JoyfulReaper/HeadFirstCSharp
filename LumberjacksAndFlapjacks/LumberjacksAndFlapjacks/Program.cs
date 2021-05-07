using System;
using System.Collections.Generic;
using System.Linq;

namespace LumberjacksAndFlapjacks
{
    class Program
    {
        private static Random _random = new();

        static void Main(string[] args)
        {
            Queue<Lumberjack> lumberjackQueue = new();

            Console.Write("First lumberjack's name: ");
            while (true)
            {
                string name = Console.ReadLine();
                if(string.IsNullOrEmpty(name))
                {
                    break;
                }

                Console.Write("Number of flapjacks: ");
                if(!int.TryParse(Console.ReadLine(), out int numberOfFlapjacks))
                {
                    Console.WriteLine("That's not a number.");
                    return;
                }

                Lumberjack lumberjack = new Lumberjack(name);
                for(int i = 0; i < numberOfFlapjacks; i++)
                {
                    lumberjack.TakeFlapJack(GetRandomFlapjack());
                }
                lumberjackQueue.Enqueue(lumberjack);

                Console.Write("Next lumberjack's name (blank to end): ");
            }

            Console.WriteLine();
            while(lumberjackQueue.Count > 0)
            {
                lumberjackQueue.Dequeue().EatFlapjacks();
            }
            
        }
        public static Flapjack GetRandomFlapjack()
        {
            var minMax = GetEnumMinMax<Flapjack>();
            return (Flapjack)_random.Next(minMax.min, minMax.max + 1);
        }

        public static (int min, int max) GetEnumMinMax<T>()
        {
            return (
                Enum.GetValues(typeof(T)).Cast<int>().Min(),
                Enum.GetValues(typeof(T)).Cast<int>().Max()
            );
        }
    }
}
