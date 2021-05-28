﻿namespace BasicWebServer.Server.Http
{
    using System.Collections.Generic;
    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
            => this.headers.Add(header.Name, header);

        public int Count => this.headers.Count;
    }
}
