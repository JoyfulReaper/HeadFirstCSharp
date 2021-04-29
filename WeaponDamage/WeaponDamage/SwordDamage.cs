using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    class SwordDamage : WeaponDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public SwordDamage(int initialRoll) : base(initialRoll) { }

        protected override void CalculateDamage()
        {
            decimal magicMultiplier = 1M;

            if(Magic)
            {
                magicMultiplier = 1.75M;
            }

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if(Flaming)
            {
                Damage += FLAME_DAMAGE;
            }
        }
    }
}
