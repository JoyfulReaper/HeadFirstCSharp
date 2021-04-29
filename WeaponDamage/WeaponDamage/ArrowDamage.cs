using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    class ArrowDamage : WeaponDamage
    {
        public const decimal BASE_MULTIPLIER = 0.35M;
        public const decimal MAGIC_MULTIPLIER = 2.5M;
        public const decimal FLAME_DAMAGE = 1.25M;

        public ArrowDamage(int initialRoll) : base (initialRoll) { }

        protected override void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic)
            {
                baseDamage *= MAGIC_MULTIPLIER;
            }
            if (Flaming)
            {
                Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            }
            else
            {
                Damage = (int)Math.Ceiling(baseDamage);
            }
        }
    }
}
