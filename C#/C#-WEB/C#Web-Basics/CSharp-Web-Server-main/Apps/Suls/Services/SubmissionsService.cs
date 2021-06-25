using Suls.Data.Models;
using SulsApp.Data;
using System;
using System.Linq;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SulsDbContext data;
        private readonly Random random;

        public SubmissionsService(SulsDbContext data, Random random)
        {
            this.data = data;
            this.random = random;
        }

        public void Create(string problemId, string code, string userId)
        {
            var problemMaxPoints = this.data
                .Problems
                .Where(p => p.Id == problemId)
                .Select(p => p.Points)
                .FirstOrDefault();

            var submission = new Submission()
            {
                AchievedResult = this.random.Next(0, problemMaxPoints + 1),
                Code = code,
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId,
            };

            this.data.Submissions.Add(submission);

            this.data.SaveChanges();
        }
    }
}
