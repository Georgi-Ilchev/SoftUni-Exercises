using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();

    }
}