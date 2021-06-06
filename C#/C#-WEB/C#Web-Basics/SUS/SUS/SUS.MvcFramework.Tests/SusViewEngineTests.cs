namespace SUS.MvcFramework.Tests
{
    using SUS.MvcFramework.ViewEngine;
    using System;
    using System.IO;
    using Xunit;
    public class SusViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel
            {
                DateOfBirth = new DateTime(2019, 6, 1),
                Name = "Doggo Argentino",
                Price = 12345.67M,
            };

            IViewEngine viewEngine = new SusViewEngine();

            var view = File.ReadAllText($"ViewTests/{fileName}.html");

            var actual = viewEngine.GetHtml(view, viewModel);
            var expected = File.ReadAllText($"ViewTests/{fileName}.Result.html");

            Assert.Equal(expected, actual);
        }

        public class TestViewModel
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public DateTime DateOfBirth { get; set; }
        }
    }
}
