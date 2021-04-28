using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamageConsole
{
    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll
        {
            get => _roll;
            set
            {
                _roll = value;
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

        public bool Magic
        {
            get => _magic;
            set
            {
                _magic = value;
                CalculateDamage();
            }
        }

        public int Damage { get; private set; }

        private int _roll;
        private bool _flaming;
        private bool _magic;

        public SwordDamage(int initialRoll)
        {
            _roll = initialRoll;
        }

        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;

            if(_magic)
            {
                magicMultiplier = 1.75M;
            }

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if(_flaming)
            {
                Damage += FLAME_DAMAGE;
            }
        }
    }
}
