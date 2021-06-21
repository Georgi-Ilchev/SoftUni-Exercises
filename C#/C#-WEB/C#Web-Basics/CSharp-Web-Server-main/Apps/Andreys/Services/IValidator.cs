namespace Andreys.Services
{
    using Andreys.Models.Users;
    using System.Collections.Generic;
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

    }
}
