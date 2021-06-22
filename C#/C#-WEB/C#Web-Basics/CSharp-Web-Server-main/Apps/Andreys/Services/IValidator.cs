namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models.Products;
    using Andreys.Models.Users;
    using System.Collections.Generic;
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateProduct(AddProductFormModel model);
    }
}
