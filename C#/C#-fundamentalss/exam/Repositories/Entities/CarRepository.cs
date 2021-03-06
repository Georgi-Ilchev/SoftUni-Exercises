using exam.Models.Cars.Contracts;
using System.Linq;

namespace exam.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Model == name);
        }
    }
}
