using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoes
{
    class ShoeCloset
    {
        private readonly List<Shoe> shoes = new List<Shoe>();

        public void PrintShoes()
        {
            if(shoes.Count == 0)
            {
                Console.WriteLine("\nThe closet is empty.");
                return;
            }

            Console.WriteLine("\nThe shoe closet contains:");
            for (int i = 0; i < shoes.Count; i++)
            {
                Console.WriteLine($"Shoe #{i + 1}: {shoes[i]}");
            }
        }

        public void AddShoe()
        {
            Console.WriteLine("\nAdd a shoe");
            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Press {i} to add a {(Style)i}");
            }

            Console.Write("Enter a style: ");
            if(int.TryParse(Console.ReadKey().KeyChar.ToString(), out int style))
            {
                if(!Enum.IsDefined(typeof(Style), style))
                {
                    Console.WriteLine("\nNot a valid style!");
                    return;
                }

                Console.Write("\nEnter the color: ");
                string color = Console.ReadLine();
                Shoe shoe = new Shoe((Style)style, color);
                shoes.Add(shoe);
            }
        }

        public void RemoveShoe()
        {
            Console.Write("\nEnter the number of the shoe to remove: ");

            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) &&
                (shoeNumber >= 1) && (shoeNumber <= shoes.Count))
            {
                Console.WriteLine($"Removing {shoes[shoeNumber - 1].Description}");
                shoes.RemoveAt(shoeNumber - 1);
            }
        }
    }
}
