using Panda.ViewModels.Package;
using Panda.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Panda.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidatePackage(CreatePackageInputModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 20 || model.Description.Length < 5)
            {
                errors.Add("Description must be between 5 and 20 characters long.");
            }

            if (model.Status != "Pending" && model.Status != "Delivered")
            {
                errors.Add($"Repository type can be either 'Pending' or 'Delivered'.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterFormModel model)
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

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") ||
                model.Email.Length < 5 || model.Email.Length > 20 || string.IsNullOrWhiteSpace(model.Email))
            {
                errors.Add($"Email {model.Email} is not valid e-mail address.");
            }

            return errors;
        }
    }
}
