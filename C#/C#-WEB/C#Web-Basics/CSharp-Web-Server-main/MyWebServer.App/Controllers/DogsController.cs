﻿namespace MyWebServer.App.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using MyWebServer.App.Models.Animals;

    public class DogsController : Controller
    {
        [HttpGet]
        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Create(DogFormModel model)
        => Text($"Dog: {model.Name} - {model.Age} - {model.Breed}");
    }
}
