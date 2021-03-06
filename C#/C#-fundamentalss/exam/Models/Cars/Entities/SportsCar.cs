namespace exam.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int minPower = 250;
        private const int maxPower = 450;
        private const double cubic = 3000;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cubic, minPower, maxPower)
        {
        }
    }
}
