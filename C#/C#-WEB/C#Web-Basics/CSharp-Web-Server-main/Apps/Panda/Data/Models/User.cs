﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Panda.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Package> Packages { get; set; } = new HashSet<Package>();
        public ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}