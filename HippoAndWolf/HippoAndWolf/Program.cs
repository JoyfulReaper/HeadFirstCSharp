using System;
using System.Collections.Generic;

namespace HippoAndWolf
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Wolf(false),
                new Hippo(),
                new Wolf(true),
                new Wolf(false),
                new Hippo()
            };

            foreach (Animal animal in animals)
            {
                animal.MakeNoise();

                if(animal is ISwimmer swimmer)
                {
                    swimmer.Swim();
                }

                if(animal is IPackHunter hunter)
                {
                    hunter.HuntInPack();
                }

                Console.WriteLine();
            }
        }
    }
}
