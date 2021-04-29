using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonAndOstrich
{
    class Ostrich : Bird
    {
        public override List<Egg> LayEggs(int numberOfEggs)
        {
            List<Egg> output = new List<Egg>();

            for (int i = 0; i < numberOfEggs; i++)
            {
                output.Add(new Egg(Randomizer.NextDouble() + 12, "speckled"));
            }

            return output;
        }
    }
}
