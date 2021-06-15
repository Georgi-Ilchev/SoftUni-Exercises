﻿namespace MyWebServer.App.Controllers
{
    using System;
    using MyWebServer.Http;
    using MyWebServer.Controllers;

    public class HomeController : Controller
    {
        public HttpResponse Index() => Text("Hello from Ivo!");

        public HttpResponse LocalRedirect() => Redirect("/Animals/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");

        public HttpResponse StaticFiles() => View();

        public HttpResponse Error() => throw new InvalidOperationException("Invalid action!");
    }
}
