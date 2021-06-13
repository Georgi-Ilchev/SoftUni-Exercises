namespace MyWebServer.Controllers
{
    using System;
    using MyWebServer.Http;

    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        public HttpMethodAttribute(HttpMethod httpmethod)
        {
            this.HttpMethod = httpmethod;
        }

        public HttpMethod HttpMethod { get; }
    }
}
