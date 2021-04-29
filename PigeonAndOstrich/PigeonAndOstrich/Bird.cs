using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonAndOstrich
{
    class Bird
    {
        public static Random Randomizer = new Random();
        public virtual List<Egg> LayEggs(int numberOfEggs)
        {
            Console.Error.WriteLine("Bird.LayEggs should never get called");
            return new List<Egg>();
        }
    }
}
