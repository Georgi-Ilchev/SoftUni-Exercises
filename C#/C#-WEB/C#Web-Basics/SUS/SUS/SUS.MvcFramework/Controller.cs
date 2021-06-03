namespace SUS.MvcFramework
{
    using SUS.HTTP;
    using System.Runtime.CompilerServices;
    using System.Text;
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            var responseHtml = System.IO.File.ReadAllText
                                ("Views/" + this.GetType().Name.Replace("Controller", string.Empty) + "/" + viewPath + ".html");
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);

            return response;
        }
    }
}
