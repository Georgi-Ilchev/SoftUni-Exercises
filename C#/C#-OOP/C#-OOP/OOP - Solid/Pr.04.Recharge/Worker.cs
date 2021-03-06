namespace Pr._04.Recharge
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        protected Worker(string id)
        {
            this.id = id;
        }

        public int WorkingHours
        {
            get => this.workingHours;
            set => this.workingHours = value;
        }
        public virtual void Work(int hours)
        {
            System.Console.WriteLine($"{this.GetType().Name} is working {hours} hours.");
            this.workingHours += hours;
        }
    }
}