using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryClown
{
    interface IClown
    {
        static int CarCapacity
        {
            get
            {
                return _carCapacity;
            }
            set
            {
                if (value > 10)
                {
                    _carCapacity = value;
                }
                else
                {
                    throw new ArgumentException($"Warning: Car capacity {value} is too small", nameof(value));
                }
            }
        }

        private static int _carCapacity;

        protected static Random _random = new Random();

        string FunnyThingIHave { get; }
        void Honk();

        static string ClownCarDescription()
        {
            return $"A clown car with {_random.Next(_carCapacity / 2, _carCapacity)} clowns";
        }
    }
}