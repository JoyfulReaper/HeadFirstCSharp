using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;

        public static string StatusReport
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Vault Report:");
                sb.AppendLine($"{_honey:0.0} units of honey");
                sb.AppendLine($"{_nectar:0.0} units of nectar");

                if(_nectar < LOW_LEVEL_WARNING)
                {
                    sb.AppendLine("LOW NECTAR - ADD A NECTAR COLLECTOR");
                }

                if (_honey < LOW_LEVEL_WARNING)
                {
                    sb.AppendLine("LOW HONEY - ADD A HONEY MANUFACURER");
                }

                return sb.ToString();
            }
        }

        private static float _honey = 25f;
        private static float _nectar = 100f;

        public static void CollectNectar(float amount)
        {
            if (amount > 0)
            {
                _nectar += amount;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be => 0", nameof(amount));
            }

            if (amount > _nectar)
            {
                amount = _nectar;
            }

            _nectar -= amount;

            _honey += amount * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if(amount > _honey)
            {
                return false;
            }

            _honey -= amount;
            return true;
        }
    }
}
