using Panda.Data.Enums;
using System;
using System.Globalization;

namespace Panda.ViewModels.Package
{
    public class CreatePackageInputModel
    {
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string RecipientId { get; set; }

        public string Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public string EstimatedDeliveryDateAsString
            => this.EstimatedDeliveryDate.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
    }
}
