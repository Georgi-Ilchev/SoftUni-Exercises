using BattleCards.Data;
using BattleCards.Models.Cards;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly BattleCardsDbContext data;

        public CardsController(BattleCardsDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var viewModel = this.data.Cards
                                     .Select(t => new DisplayAllCardsViewModel()
                                     {
                                         Id = t.Id,
                                         Name = t.Name, 
                                         ImageUrl = t.ImageUrl,
                                         Description = t.Description, 
                                         Keyword = t.Keyword,
                                         Attack = t.Attack,
                                         Health = t.Health
                                     })
                                     .ToList();

            return this.View(viewModel);
        }
    }
}
