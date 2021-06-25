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
        private readonly BattleCardsDbContext db;
        private readonly IValidator validator;

        public CardsController(BattleCardsDbContext db, IValidator validator)
        {
            this.db = db;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add() => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CreateCardFormModel model)
        {
            var modelErrors = this.validator.ValidateCard(model);

            if (modelErrors.Count > 0)
            {
                return Error(modelErrors);
            }

            var card = new Card
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();

            this.db.UsersCards.Add(new UserCard
            {
                CardId = card.Id,
                UserId = this.User.Id
            });
            this.db.SaveChanges();

            return Redirect("/Cards/All");

        }

        [Authorize]
        public HttpResponse All()
        {
            var cards = this.db.Cards
                .Select(c => new CardOutputModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Keyword = c.Keyword,
                    ImageUrl = c.ImageUrl,
                    Attack = c.Attack,
                    Health = c.Health,
                    Description = c.Description,


                })
                .ToList();

            var userCards = this.db.UsersCards
                .Where(uc => uc.UserId == this.User.Id)
                .ToList();

            for (int i = 0; i < cards.Count(); i++)
            {
                var currentCard = cards[i];
                if (userCards.Any(uc => uc.CardId == currentCard.Id))
                {
                    currentCard.IsInCollection = true;
                    continue;
                }

                currentCard.IsInCollection = false;
            }

            return View(cards);
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            if (cardId == 0)
            {
                return Error("Cardid is zero!");

            }

            var userCards = this.db.UsersCards
                .Where(uc => uc.UserId == this.User.Id && uc.CardId == cardId)
                .FirstOrDefault();

            if (userCards == null)
            {
                this.db.UsersCards.Add(new UserCard { CardId = cardId, UserId = this.User.Id });
                this.db.SaveChanges();
            }


            return Redirect("/Cards/All");

        }

        [Authorize]
        public HttpResponse Collection()
        {
            var cards = this.db.UsersCards
                .Where(uc => uc.UserId == this.User.Id)
                .Select(uc => new CardOutputModel
                {
                    Id = uc.Card.Id,
                    Keyword = uc.Card.Keyword,
                    ImageUrl = uc.Card.ImageUrl,
                    Description = uc.Card.Description,
                    Name = uc.Card.Name,
                    Attack = uc.Card.Attack,
                    Health = uc.Card.Health
                }).ToList();

            return View(cards);
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            var card = this.db.UsersCards
                .Where(uc => uc.UserId == this.User.Id && uc.CardId == cardId)
                .FirstOrDefault();

            if (card == null)
            {
                return Error("Missing user/card");
            }

            this.db.UsersCards.Remove(card);
            this.db.SaveChanges();
            return Redirect("/Cards/Collection");
        }
    }
}
