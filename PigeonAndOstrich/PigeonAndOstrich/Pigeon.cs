using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonAndOstrich
{
    class Pigeon : Bird
    {
        public override List<Egg> LayEggs(int numberOfEggs)
        {
            List<Egg> output = new List<Egg>();

            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Randomizer.Next(4) == 0)
                {
                    output.Add(new BrokenEgg("white"));
                }
                else
                {
                    output.Add(new Egg(Randomizer.NextDouble() * 2 + 1, "white"));
                }
            }

            return output;
        }
    }
}
