namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int MaxHorsePowerr = 450;
        private const int MinHorsePowerr = 250;
        private const double CubicCentimeterss = 3000;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimeterss, MinHorsePowerr, MaxHorsePowerr)
        {
        }
    }
}
