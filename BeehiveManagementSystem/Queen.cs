using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen : Bee, INotifyPropertyChanged
    {
        public override float CostPerShift { get { return 2.15f; } }
        public string StatusReport { get; private set; }

        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private float eggs=0;
        private float unassignedWorkers=3;

        private IWorker[] workers = new Bee[0];

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (IWorker worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
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
            UpdateStatusReport();
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (IWorker worker in workers)
                if (worker.Job == job) count++;
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
            $"\nEgg count: {eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
            $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" +
            $"\n{WorkerStatus("Egg Care")}\nTOTAL WORKERS: {workers.Length}";
            OnPropertyChanged("StatusReport");
        }

        /// <summary>
        /// Expand the workers array by one slot and add a Bee reference.
        /// </summary>
        /// <param name="worker">Worker to add to the workers array.</param>
        private void AddWorker(IWorker worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        public Queen() : base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }
    }
}
