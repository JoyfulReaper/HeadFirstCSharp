using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonAndOstrich
{
    class Egg
    {
        public double Size { get; private set; }
        public string Color { get; private set; }
        public string Description
        {
            get => ToString();
        }

        public Egg(double size, string color)
        {
            Size = size;
            Color = color;
        }

        public override string ToString()
        {
            return $"A {Size:0.0}cm {Color} egg";
        }
    }
}
