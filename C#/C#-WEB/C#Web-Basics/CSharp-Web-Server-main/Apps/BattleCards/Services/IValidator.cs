using BattleCards.Models.Users;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

    }
}
