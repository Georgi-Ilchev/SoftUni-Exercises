namespace CarShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using CarShop.Models.Cars;
    using CarShop.Models.Issues;
    using CarShop.Models.Users;
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 4 ||
                model.Username.Length > 20)
            {
                errors.Add($"Username {model.Username} is not valid. It must be between 4 and 20 characters long.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not valid e-mail address.");
            }

            if (model.Password.Length < 5 ||
                model.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between 5 and 20 characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            if (model.UserType != "Mechanic" &&
                model.UserType != "Client")
            {
                errors.Add($"User should be either a 'Mechanic' or 'Client'.");
            }

            return errors;
        }

        public ICollection<string> ValidateCar(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < 5 ||
                model.Model.Length > 20)
            {
                errors.Add($"Model '{model.Model}' is not valid. It must be between 5 and 20 characters long.");
            }

            if (model.Year < 1900 || model.Year > 2022)
            {
                errors.Add($"Year '{model.Year}' is not valid. It must be between 1900 and 2022.");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image {model.Image} is not a valid URL");
            }

            if (!Regex.IsMatch(model.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                errors.Add($"Plate number {model.PlateNumber} is not valid. It should be in format 'AA0000AA'.");
            }

            return errors;
        }

        public ICollection<string> ValidateIssue(AddIssueFormModel model)
        {
            var errors = new List<string>();

            if (model.CarId == null)
            {
                errors.Add($"Car ID cannot be empty.");
            }

            if (model.Description.Length < 5)
            {
                errors.Add($"Description '{model.Description}' is not valid. It must have more than 5 characters.");
            }

            return errors;
        }
    }
}
