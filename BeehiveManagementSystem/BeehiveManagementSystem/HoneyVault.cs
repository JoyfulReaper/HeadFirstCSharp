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
        public const float LOW_LEVEL_WARNING = 100f;

        public static string StatusReport
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Honey Valut status report:");
                sb.AppendLine($"Honey: {_honey}");
                sb.AppendLine($"Nectar: {_honey}");

                if(_honey < LOW_LEVEL_WARNING)
                {
                    sb.AppendLine("LOW HONEY - ADD A HONEY MANUFACTURER");
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
            if(amount < _honey)
            {
                return false;
            }

            _honey -= amount;
            return true;
        }
    }
}
