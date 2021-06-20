namespace Git.Services
{
    using Git.Models.Repositories;
    using Git.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateRepository(CreateRepositoryFormModel model);
    }
}
