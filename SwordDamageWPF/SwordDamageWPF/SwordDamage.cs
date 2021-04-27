using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamageWPF
{
    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        private decimal _magicMultiplier = 1M;
        private int _flamingDamage = 0;
        public int Damage;

        private void CalculateDamage()
        {
            Damage = (int)(Roll * _magicMultiplier) + BASE_DAMAGE + _flamingDamage;
            Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");
        }

        public void SetMagic(bool isMagic)
        {
            if(isMagic)
            {
                _magicMultiplier = 1.75M;
            }
            else
            {
                _magicMultiplier = 1M;
            }

            CalculateDamage();

            Debug.WriteLine($"SetMagic finished: {Damage} (roll: {Roll})");
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();

            if(isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }

            Debug.WriteLine($"SetFlaming finished: {Damage} (roll: {Roll})");
        }
    }
}
