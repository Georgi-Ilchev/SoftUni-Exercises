using Git.Models.Repositories;
using Git.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                errors.Add($"Repository {model.Name} is not valid. It must be between 3 and 10 characters long.");
            }

            if (model.RepositoryType != "Public" && model.RepositoryType != "Private")
            {
                errors.Add($"Repository type can be either 'Public' or 'Private'.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add($"Username {model.Username} is not valid. It must be between 5 and 20 characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between 6 and 20 characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not valid e-mail address.");
            }

            return errors;
        }
    }
}
