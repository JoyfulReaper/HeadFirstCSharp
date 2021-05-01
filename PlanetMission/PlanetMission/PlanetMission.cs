using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetMission
{
    abstract class PlanetMission
    {
        protected float _fuelPerKm;
        protected long _kmPerHour;
        protected long _kmToPlanet;

        public string MissionInfo()
        {
            long fuel = (long)(_kmToPlanet * _fuelPerKm);
            long time = _kmToPlanet / _kmPerHour;

            return $"We'll burn {fuel} units of fuel in {time} hours";
        }
    }
}
