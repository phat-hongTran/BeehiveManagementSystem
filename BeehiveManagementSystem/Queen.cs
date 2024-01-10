using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        public override float CostPerShift { get { return 2.15f; } }

        protected override void DoJob()
        {

        }

        public Queen() : base("Queen")
        {

        }
    }
}
