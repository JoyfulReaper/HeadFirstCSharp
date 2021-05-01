using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clowns
{
    class TallGuy : IClown
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string FunnyThingIHave { get; } = "Big Shoes";

        public void Honk()
        {
            Console.WriteLine("Honk honk!");
        }

        public void TalkAboutYourself()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"My name is {Name} and I'm {Height} inches tall";
        }
    }
}
