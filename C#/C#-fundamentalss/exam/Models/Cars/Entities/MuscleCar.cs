namespace exam.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int minPower = 400;
        private const int maxPower = 600;
        private const double cubic = 5000;
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, cubic, minPower, maxPower)
        {
        }
    }
}
