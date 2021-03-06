using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories.Contracts
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>)this.models;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerRepository);
            }
            this.models.Add(model);
        }

        public IPlayer FindByName(string name) => this.models.FirstOrDefault(x => x.Username == name);
        //{
        //    var currGun = models.FirstOrDefault(x => x.Username == name);
        //    if (currGun == null)
        //    {
        //        return null;
        //    }
        //    return currGun;
        //}

        public bool Remove(IPlayer model) => this.models.Remove(model);
        //{
        //    if (!models.Contains(model))
        //    {
        //        return false;
        //    }
        //    models.Remove(model);
        //    return true;
        //}
    }
}
