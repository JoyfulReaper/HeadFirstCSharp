using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoe
{
    class MenuItem
    {
        private static Random _randomizer = new Random();

        public string[] Proteins { get; set; } = { "Roast Beef", "Salami", "Turkey", "Ham", "Pastrami", "Tofu" };
        public string[] Condiments { get; set; } = { "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing" };
        public string[] Breads { get; set; } = { "rye", "white", "wheat", "pumpernickel", "a roll" };

        public string Description { get; set; } = string.Empty;
        public string Price
        {
            get => _price.ToString("c");
            set
            {
                _price = decimal.Parse(value);
            }
        }


        private decimal _price;

        public void Generate()
        {
            string randomProtein = Proteins[_randomizer.Next(Proteins.Length)];
            string randomCondiment = Condiments[_randomizer.Next(Condiments.Length)];
            string randomBread = Breads[_randomizer.Next(Breads.Length)];

            Description = $"{randomProtein} with {randomCondiment} on {randomBread}";

            decimal bucks = _randomizer.Next(2, 5);
            decimal cents = _randomizer.Next(1, 98);
            _price = bucks + (cents * .01M);
        }
    }
}
