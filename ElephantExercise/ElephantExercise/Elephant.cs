using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantExercise
{
    public class Elephant
    {
        public string Name { get; set; }
        public int EarSize { get; set; }

        public void WhoAmI()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"My name is {Name}.\nMy ears are {EarSize} inches tall.";
        }
    }
}
