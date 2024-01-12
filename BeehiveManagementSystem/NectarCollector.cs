﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class NectarCollector : Bee
    {
        public override float CostPerShift { get { return 1.95f; } }
        public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }

        public NectarCollector() : base("Nectar Collector") { }
    }
}
