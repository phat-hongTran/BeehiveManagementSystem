using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class EggCare : Bee
    {
        public override float CostPerShift { get { return 1.35f; } }

        protected override void DoJob()
        {

        }
        public EggCare() : base("Egg Care")
        {

        }
    }
}
