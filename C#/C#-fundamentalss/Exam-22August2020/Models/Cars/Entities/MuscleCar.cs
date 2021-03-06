namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MaxHorsePowerr = 600;
        private const int MinHorsePowerr = 400;
        private const double CubicCentimeterss = 5000;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimeterss, MinHorsePowerr, MaxHorsePowerr)
        {
        }
    }
}
