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

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            var userId = this.GetUserId();
            var result = this.AddCardToUser(cardId, userId);

            if (result == false)
            {
                return this.Error("You already have this card.");
            }

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            var userId = this.GetUserId();
            var result = this.RemoveCardFromUser(cardId, userId);

            if (result == false)
            {
                return this.Error("You don't have this card in your collection");
            }

            return Redirect("/Cards/Collection");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var userId = this.GetUserId();
            var viewModel = this.data.UserCards
                                     .Where(uc => uc.UserId == userId)
                                     .Select(uc => new GetUserCardCollectionViewModel()
                                     {
                                         Id = uc.Card.Id,
                                         Name = uc.Card.Name,
                                         Image = uc.Card.ImageUrl,
                                         Description = uc.Card.Description,
                                         Keyword = uc.Card.Keyword,
                                         Attack = uc.Card.Attack,
                                         Health = uc.Card.Health
                                     })
                                     .ToList();

            return this.View(viewModel);
        }

        public bool AddCardToUser(int cardId, string userId)
        {
            if (this.data.UserCards.Any(uc => uc.UserId == userId &&
                                              uc.CardId == cardId))
            {
                return false;
            }

            this.data.UserCards.Add(new UserCard()
            {
                CardId = cardId,
                UserId = userId,
            });

            this.data.SaveChanges();
            return true;
        }

        public bool RemoveCardFromUser(int cardId, string userId)
        {
            var card = this.data.UserCards
                                .FirstOrDefault(uc => uc.UserId == userId &&
                                                      uc.CardId == cardId);

            if (card == null)
            {
                return false;
            }

            this.data.UserCards.Remove(card);
            this.data.SaveChanges();

            return true;
        }
    }
}
