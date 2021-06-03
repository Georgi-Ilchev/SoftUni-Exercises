namespace SUS.HTTP
{
    using System;
    public class Route
    {
        public Route(string path, Func<HttpRequest, HttpResponse> action)
        {
            Path = path;
            Action = action;
        }

        public string Path { get; set; }

        //in - out
        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
