using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories.Contracts
{
    public class GunRepository : IRepository<IGun>
    {

        private readonly ICollection<IGun> models;
        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.models;

        //2
        //private List<IGun> modelss;

        //2
        //public IReadOnlyCollection<IGun> Modelss
        //{
        //    get
        //    {
        //        return this.modelss.AsReadOnly();
        //    }
        //}
           

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidGunRepository);
            }
            models.Add(model);
        }

        public IGun FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
        //{
        //    var currGun = models.FirstOrDefault(x => x.Name == name);
        //    if (currGun == null)
        //    {
        //        return null;
        //    }
        //    return currGun;
        //}

        public bool Remove(IGun model) => this.models.Remove(model);
        //{
        //if (!models.Contains(model))
        //{
        //    return false;
        //}
        //models.Remove(model);
        //return true;
        //}
    }
}
