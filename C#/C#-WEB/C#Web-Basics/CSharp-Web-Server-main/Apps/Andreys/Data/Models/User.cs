namespace Andreys.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
