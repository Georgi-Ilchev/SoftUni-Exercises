using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;
        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models => (IReadOnlyCollection<T>)this.models;


        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models;
        }

        public abstract T GetByName(string name);

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
