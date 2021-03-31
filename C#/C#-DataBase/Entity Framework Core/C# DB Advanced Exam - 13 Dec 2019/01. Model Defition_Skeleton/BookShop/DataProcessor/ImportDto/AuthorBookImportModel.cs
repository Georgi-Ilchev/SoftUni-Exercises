using Newtonsoft.Json;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorBookImportModel
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}