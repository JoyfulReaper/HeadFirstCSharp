using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreTester
{
    public class AbilityScoreCalculator
    {
        public int RollResult { get; set; } = 14;
        public double DivideBy { get; set; } = 1.75;
        public int AddAmount { get; set; } = 2;
        public int Minimum { get; set; } = 3;
        public int Score { get; set; }

        public void CalculateAbilityScore()
        {
            double divided = RollResult / DivideBy;
            int added = AddAmount + (int)divided;

            if(added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }
    }
}
