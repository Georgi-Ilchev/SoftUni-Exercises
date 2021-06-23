using Panda.ViewModels.User;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);
    }
}
