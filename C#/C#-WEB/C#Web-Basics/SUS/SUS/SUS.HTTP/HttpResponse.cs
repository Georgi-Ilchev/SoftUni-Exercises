namespace SUS.HTTP
{
    using System.Collections.Generic;
    using System.Text;

    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            this.StatusCode = statusCode;
            this.Body = body;
            this.Headers = new List<Header>()
            {
                {new Header ( "Content-Type", contentType) },
                {new Header("Content-Length", body.Length.ToString()) }
            };
        }
        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            StringBuilder responseBuilder = new StringBuilder();

            responseBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}" + HttpConstants.NewLine);

            foreach (var header in this.Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            return responseBuilder.ToString();
        }
    }
}
