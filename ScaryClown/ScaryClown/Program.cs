using System;

namespace ScaryClown
{
    class Program
    {
        static void Main(string[] args)
        {
            IClown fingersTheClown = new ScaryScary("big red nose", 14);
            fingersTheClown.Honk();

            if (fingersTheClown is IScaryClown iScaryClownReference)
            {
                iScaryClownReference.ScareLittleChildren();
            }
            else
            {
                Console.WriteLine("He's not so scary...");
            }
        }
    }
}
