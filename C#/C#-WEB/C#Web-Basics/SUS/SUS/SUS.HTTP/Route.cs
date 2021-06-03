namespace SUS.HTTP
{
    using System;
    public class Route
    {
        public Route(string path, HttpMethod method, Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            this.Action = action;
            this.Method = method;
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        //in - out
        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
