using System;
using System.Collections.Generic;

namespace PigeonAndOstrich
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Bird bird;

                Console.Write("\nPress P for pigeon, O for ostrich: ");

                char key = Char.ToUpper(Console.ReadKey().KeyChar);
                if(key == 'P')
                {
                    bird = new Pigeon();
                }
                else if (key == 'O')
                {
                    bird = new Ostrich();
                }
                else
                {
                    return;
                }

                Console.Write("\nHow many eggs should it lay? ");
                if(!int.TryParse(Console.ReadLine(), out int numberOfEggs))
                {
                    return;
                }

                List<Egg> eggs = bird.LayEggs(numberOfEggs);
                foreach(Egg e in eggs)
                {
                    Console.WriteLine(e.Description);
                }

            }
        }
    }
}
