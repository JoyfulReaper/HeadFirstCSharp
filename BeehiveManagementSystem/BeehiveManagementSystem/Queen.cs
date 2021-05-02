using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        public override float CostPerShift { get => 2.15f; }
        public string StatusReport
        {
            get
            {
                var nc = _workers.Where(x => x.Job == "Nectar Collector").Count();
                var hm = _workers.Where(x => x.Job == "Honey Manufacturer").Count();
                var ec = _workers.Where(x => x.Job == "Egg Care").Count();

                StringBuilder sb = new StringBuilder(HoneyVault.StatusReport);
                sb.AppendLine();
                sb.AppendLine($"Egg count: {_eggs}");
                sb.AppendLine($"Unassigned Workers: {_unassignedWorkers}");
                sb.AppendLine($"{nc} Nectar Collector bee{(nc > 1 ? "s" : "")}");
                sb.AppendLine($"{hm} Honey Manufacturer bee{(hm > 1 ? "s" : "")}");
                sb.AppendLine($"{ec} Egg Care bee{(ec > 1 ? "s" : "")}");
                sb.AppendLine($"TOTAL WORKERS {_workers.Count}");

                return sb.ToString();
            }
        }

        private List<IWorker> _workers = new List<IWorker>();
        private float _unassignedWorkers = 3;
        private float _eggs = 0;

        public Queen() : base("Queen") 
        {
            AssignBee("Egg Care");
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
        }

        public void CareForEggs(float eggsToConvert)
        {
            if(_eggs >= eggsToConvert)
            {
                _eggs -= eggsToConvert;
                _unassignedWorkers += eggsToConvert;
            }
        }

        protected override void DoJob()
        {
            _eggs += EGGS_PER_SHIFT;
            foreach (IWorker bee in _workers)
            {
                bee.WorkTheNextShift();
            }

            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * _unassignedWorkers);
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
            }
        }

        private void AddWorker(IWorker bee)
        {
            if (_unassignedWorkers >= 1)
            {
                _workers.Add(bee);
                _unassignedWorkers--;
            }
        }
    }
}
