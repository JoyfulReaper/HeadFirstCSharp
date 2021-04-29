using System;

namespace JewelTheif
{
    class Program
    {
        static void Main(string[] args)
        {
            SafeOwner owner = new SafeOwner();
            Safe safe = new Safe();

            JewelTheif jewelTheif = new JewelTheif();
            jewelTheif.OpenSafe(safe, owner);

            Console.ReadKey(true);
        }
    }
}
