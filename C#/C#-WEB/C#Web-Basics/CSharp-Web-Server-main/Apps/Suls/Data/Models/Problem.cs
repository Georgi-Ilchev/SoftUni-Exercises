using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data.Models
{
    public class Problem
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; init; }

        public int Points { get; init; }

        public ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
    }
}