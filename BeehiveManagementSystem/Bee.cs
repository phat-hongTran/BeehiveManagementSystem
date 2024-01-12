using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Bee
    {
        public string Job { get; }

        public virtual float CostPerShift { get; }

        protected virtual void DoJob() { }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }

        public Bee(string job)
        {
            Job = job;
        }
    }
}
