using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    interface IWorker
    {
        public string Job { get; }
        void WorkTheNextShift();
    }
}
