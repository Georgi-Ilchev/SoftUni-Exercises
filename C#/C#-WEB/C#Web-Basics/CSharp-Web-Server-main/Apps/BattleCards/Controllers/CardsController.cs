using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models.Cards;
using BattleCards.Services;
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
        private readonly IValidator validator;

        public CardsController(BattleCardsDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
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

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddCardInputModel model)
        {
            var modelErrors = this.validator.ValidateCard(model);
            var userId = this.GetUserId();

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var card = new Card()
            {
               Name = model.Name,
               ImageUrl = model.ImageUrl,
               Keyword = model.Keyword,
               Attack = model.Attack,
               Health = model.Health,
               Description = model.Description
            };

            this.data.Cards.Add(card);
            this.data.SaveChanges();

            this.data.UserCards.Add(new UserCard()
            {
                CardId = card.Id,
                UserId = userId
            });

            this.data.SaveChanges();

            return Redirect("/Cards/All");
        }
    }
}
