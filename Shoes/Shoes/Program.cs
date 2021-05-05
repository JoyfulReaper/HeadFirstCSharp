using System;

namespace Shoes
{
    class Program
    {
        static readonly ShoeCloset _shoeCloset = new();
        static void Main(string[] args)
        {
            while (true)
            {
                _shoeCloset.PrintShoes();
                Console.Write("\nPress 'a' to add or 'r' to remove a shoe: ");
                char key = Char.ToUpperInvariant(Console.ReadKey().KeyChar);

                switch (key)
                {
                    case 'A':
                        _shoeCloset.AddShoe();
                        break;
                    case 'R':
                        _shoeCloset.RemoveShoe();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
