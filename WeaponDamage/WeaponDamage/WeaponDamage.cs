using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    abstract class WeaponDamage
    {
        private int _roll;
        private bool _flaming;
        private bool _magic;

        public WeaponDamage(int roll)
        {
            _roll = roll;
            CalculateDamage();
        }

        public int Roll
        {
            get => _roll;
            set
            {
                _roll = value;
                CalculateDamage();
            }
        }

        public bool Magic
        {
            get => _magic;
            set
            {
                _magic = value;
                CalculateDamage();
            }
        }

        public bool Flaming
        {
            get => _flaming;
            set
            {
                _flaming = value;
                CalculateDamage();
            }
        }

        public int Damage { get; protected set; }

        protected abstract void CalculateDamage();
    }
}
