using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panda.Data.Models
{
    public class Receipt
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string RecipientId { get; set; }
        public User Recipient { get; set; }


        [Required]
        public string PackageId { get; set; }
        public Package Package { get; set; }
    }
}
//•	Id - a GUID String, Primary Key
//•	Fee - a decimal number
//•	Issued On - a DateTime object
//•	RecipientId - GUID foreign key (required)
//•	Recipient - a User object
//•	PackageId - GUID foreign key(required)
//•	Package – a Package object
