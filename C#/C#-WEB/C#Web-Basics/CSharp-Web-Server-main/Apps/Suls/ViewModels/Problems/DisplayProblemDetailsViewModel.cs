using Suls.ViewModels.Submissions;
using System.Collections.Generic;

namespace Suls.ViewModels.Problems
{
    public class DisplayProblemDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
