using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class EggCare : Bee
    {
        public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        private readonly Queen _queen;

        public override float CostPerShift { get => 1.35f; }

        public EggCare(Queen queen) : base("Egg Care")
        {
            _queen = queen;
        }

        protected override void DoJob()
        {
            _queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
