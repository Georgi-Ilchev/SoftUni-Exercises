using exam.Repositories.Contracts;
using System.Collections.Generic;

namespace exam.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }
        public IReadOnlyCollection<T> Models => (IReadOnlyCollection<T>)this.models;

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models;
        }

        public abstract T GetByName(string name);


        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
