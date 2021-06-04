namespace MyWebServer.Server.Routing
{
    using MyWebServer.Server.Common;
    using MyWebServer.Server.Http;
    using MyWebServer.Server.Responses;
    using System;
    using System.Collections.Generic;
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable() => this.routes = new()
        {
            // = new Dictionary<string, HttpResponse>(),
            [HttpMethod.Get] = new(),
            [HttpMethod.Post] = new(),
            [HttpMethod.Put] = new(),
            [HttpMethod.Delete] = new(),
        };

        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {
            Guard.AgainstNull(response, nameof(response));

            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path] = responseFunction;

            return this;
        }

        //for chaining -> 
        //.MapGet ... .MapPost ...
        //return IRoutingTable

        public IRoutingTable MapGet(string path, HttpResponse response)
        {
            return this.MapGet(path, request => response);
        }
        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            return this.Map(HttpMethod.Get, path, responseFunction);
        }


        public IRoutingTable MapPost(string path, HttpResponse response)
        {
            return this.MapPost(path, request => response);
        }
        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            return this.Map(HttpMethod.Post, path, responseFunction);
        }


        public IRoutingTable MapPut(string path, HttpResponse response)
        {
            return this.Map(HttpMethod.Put, path, response);
        }


        public IRoutingTable MapDelete(string path, HttpResponse response)
        {
            return this.Map(HttpMethod.Delete, path, response);
        }

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }
    }
}
