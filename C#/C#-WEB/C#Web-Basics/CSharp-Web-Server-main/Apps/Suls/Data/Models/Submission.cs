using System;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data.Models
{
    public class Submission
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string ProblemId { get; set; }
        public Problem Problem { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}