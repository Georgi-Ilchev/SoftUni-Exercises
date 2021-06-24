namespace CarShop.Models.Issues
{
    using System.Collections.Generic;
    public class CarIssuesViewModel
    {
        public string Id { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public bool UserIsMechanic { get; set; }
        public IEnumerable<IssuesListingViewModel> Issues { get; init; }
    }
}
