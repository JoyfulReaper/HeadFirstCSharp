using System;

namespace Clowns
{
    class Program
    {
        static void Main(string[] args)
        {
            TallGuy tallGuy = new TallGuy() { Name = "Jimmy", Height = 76 };
            tallGuy.TalkAboutYourself();

            Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}");
            tallGuy.Honk();
        }
    }
}
