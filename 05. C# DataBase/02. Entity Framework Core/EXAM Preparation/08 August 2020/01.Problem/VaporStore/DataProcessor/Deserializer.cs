namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.XMLHelper;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var deserialisedGames = JsonConvert.DeserializeObject<IEnumerable<GameJsonInputModel>>(jsonString);

            var sb = new StringBuilder();

            foreach (var currentGame in deserialisedGames)
            {
                if (!IsValid(currentGame) ||
                    currentGame.Tags.Length == 0 ||
                    !currentGame.Tags.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                var genre = context.Genres.FirstOrDefault(x => x.Name == currentGame.Genre);
                if (genre == null)
                {
                    genre = new Genre { Name = currentGame.Genre };
                    context.Genres.Add(genre);

                }

                var developer = context.Developers.FirstOrDefault(x => x.Name == currentGame.Developer);
                if (developer == null)
                {
                    developer = new Developer { Name = currentGame.Developer };
                    context.Developers.Add(developer);
                }

                var game = new Game
                {
                    Name = currentGame.Name,
                    Price = currentGame.Price,
                    ReleaseDate = currentGame.ReleaseDate,
                    Developer = developer,
                    Genre = genre,

                };

                foreach (var currentTagName in currentGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == currentTagName);

                    if (tag == null)
                    {
                        tag = new Tag { Name = currentTagName };
                    }

                    game.GameTags.Add(new GameTag { Tag = tag });

                }

                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine($"Added {currentGame.Name} ({currentGame.Genre}) with {currentGame.Tags.Length} tags"!);

            }

            return sb.ToString().Trim();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var deserialisedUsers = JsonConvert.DeserializeObject<IEnumerable<UserJsonInputModel>>(jsonString);

            var sb = new StringBuilder();

            foreach (var currentUser in deserialisedUsers)
            {
                if (!IsValid(currentUser) ||
                    currentUser.Cards.Count == 0 ||
                    !currentUser.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = currentUser.FullName,
                    Username = currentUser.Username,
                    Email = currentUser.Email,
                    Age = currentUser.Age,
                    Cards = currentUser.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.CVC,
                        Type = x.Type
                    }).ToList()
                };

                context.Users.Add(user);
                context.SaveChanges();

                sb.AppendLine($"Imported {currentUser.Username} with {currentUser.Cards.Count} cards");
            }

            return sb.ToString().Trim();

        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var desereliezedPurchase = XmlConverter.Deserializer<PurchaseXMLInputModel>(xmlString, "Purchases");
            var result = new StringBuilder();

            foreach (var currentPurchase in desereliezedPurchase)
            {
                if (!IsValid(currentPurchase))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.FirstOrDefault(g => g.Name == currentPurchase.Title)
                    ?? new Game { Name = currentPurchase.Title };

                var card = context.Cards.FirstOrDefault(c => c.Number == currentPurchase.Card)
                   ?? new Card { Number = currentPurchase.Card };

                var date = DateTime.ParseExact(
                    currentPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var purchase = new Purchase
                {
                    Game = game,
                    Type = currentPurchase.Type,
                    Card = card,
                    Date = date,
                    ProductKey = currentPurchase.Key,
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
                string username = context.Cards
                    .Where(c => c.Number == currentPurchase.Card)
                    .Select(c => c.User.Username)
                    .FirstOrDefault();

                result.AppendLine($"Imported {currentPurchase.Title} for {username}");

            }

            return result.ToString().Trim();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}