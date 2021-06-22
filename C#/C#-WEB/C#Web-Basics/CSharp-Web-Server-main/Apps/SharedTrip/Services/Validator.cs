using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using SharedTrip.Models.Trips;
using SharedTrip.Models.Users;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateTrip(AddTripInputModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.StartPoint))
            {
                errors.Add("Start point is required.");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                errors.Add("End point is required.");
            }

            if (model.Seats < 2 ||
                model.Seats > 6)
            {
                errors.Add($"Seats should between 2 and 6.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                errors.Add("Description should have max length of 80.");
            }

            if (!Uri.IsWellFormedUriString(model.ImagePath, UriKind.Absolute))
            {
                errors.Add($"Image {model.ImagePath} is not a valid URL");
            }

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                errors.Add("Invalid departure time. Please use dd.MM.yyyy HH:ss format");
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
