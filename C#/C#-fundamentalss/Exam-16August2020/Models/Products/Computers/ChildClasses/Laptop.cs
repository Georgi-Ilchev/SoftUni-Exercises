namespace OnlineShop.Models.Products.Computers.ChildClasses
{
    public class Laptop : Computer
    {
        public const double OverallPerformanceValue = 10;
        public Laptop(int id, string manufacturer, string model, decimal price) 
            : base(id, manufacturer, model, price, OverallPerformanceValue)
        {
        }
    }
}
