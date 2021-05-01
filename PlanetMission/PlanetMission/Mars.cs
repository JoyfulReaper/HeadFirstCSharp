using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetMission
{
    class Mars : PlanetMission
    {
        public Mars()
        {
            _kmToPlanet = 92000000;
            _fuelPerKm = 1.73f;
            _kmPerHour = 37000;
        }
    }
}
