using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class NectarCollector : Bee
    {
        public override float CostPerShift { get { return 1.95f; } }

        protected override void DoJob()
        {

        }

        public NectarCollector() : base("Nectar Collector")
        {

        }
    }
}
