using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class HoneyManufacturer : Bee
    {
        public override float CostPerShift { get { return 1.7f; } }

        protected override void DoJob()
        {

        }

        public HoneyManufacturer() : base("Honey Manufacturer")
        {

        }
    }
}
