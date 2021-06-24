using Suls.ViewModels.Problems;
using Suls.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Suls.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateProblem(CreateProblemViewModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 5 || model.Name.Length > 20)
            {
                errors.Add("Name should be between 5 and 20 symbols.");
            }

            if (model.Points < 50 || model.Points > 300)
            {
                errors.Add("Points should be between 50 and 300 symbols.");
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

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add($"The provided password must be between 6 and 20 symbols.");
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
