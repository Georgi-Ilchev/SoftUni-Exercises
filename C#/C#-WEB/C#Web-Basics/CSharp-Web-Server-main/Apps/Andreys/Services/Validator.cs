namespace Andreys.Services
{
    using Andreys.Models.Products;
    using Andreys.Models.Users;
    using System;
    using System.Collections.Generic;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 4 || model.Username.Length > 10)
            {
                errors.Add($"Username {model.Username} is not valid. It must be between 4 and 10 characters long.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between 6 and 20 characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateProduct(AddProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < 4 ||
                model.Name.Length > 20)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be between 4 and 20 characters long.");
            }

            if (model.Description.Length > 10)
            {
                errors.Add($"Maximum 10 symbols in the description");
            }

            if (!Uri.IsWellFormedUriString(model.ImageUrl, UriKind.Absolute))
            {
                errors.Add($"Image {model.ImageUrl} is not a valid URL");
            }

            if (model.Category != "Shirt" &&
                model.Category != "Denim" &&
                model.Category != "Shorts" &&
                model.Category != "Jacket")
            {
                errors.Add($"Category should be either a 'Shirt', 'Denim', 'Shorts', or 'Jacket'.");
            }

            if (model.Gender != "Male" &&
                model.Gender != "Female")
            {
                errors.Add($"Genre should be either a 'Male' or 'Female'.");
            }

            return errors;
        }

    }
}
