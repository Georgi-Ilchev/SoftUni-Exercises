using MyWebServer.Controllers;
using MyWebServer.Http;
using Panda.Services;

namespace Panda.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public HttpResponse Index()
        {
            var userId = this.GetUserId();

            var viewModel = this.receiptsService.GetAll(userId);

            return this.View(viewModel);
        }
    }
}
