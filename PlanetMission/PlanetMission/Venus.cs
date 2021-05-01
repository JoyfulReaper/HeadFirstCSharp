using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetMission
{
    class Venus : PlanetMission
    {
        public Venus()
        {
            _kmToPlanet = 41000000;
            _fuelPerKm = 2.11f;
            _kmPerHour = 29500;
        }
    }
}
