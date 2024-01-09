using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        public static string StatusReport 
        { 
            get 
            {
                string report = "";
                report += "Vault report:";
                report += "\n";
                report += $"{honey} units of honey";
                report += "\n";
                report += $"{nectar} units of nectar";
                if (honey < LOW_LEVEL_WARNING)
                {
                    report += "\n";
                    report += "LOW HONEY - ADD A HONEY MANUFACTURER";
                }
                report += "\n";
                return report;
            } 
        }

        private static float honey = 25f;
        private static float nectar = 100f;

        private const float NECTAR_CONVERSION_RATIO = .19f;
        private const float LOW_LEVEL_WARNING = 10f;

        public static void CollectNectar(float amount)
        {
            if (amount > 0f)
            {
                nectar += amount;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount > nectar)
            {
                amount = nectar;
            }

            nectar -= amount;
            honey += amount * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount > honey)
            {
                return false;
            }
            else
            {
                honey -= amount;
                return true;
            }
        }
    }
}
