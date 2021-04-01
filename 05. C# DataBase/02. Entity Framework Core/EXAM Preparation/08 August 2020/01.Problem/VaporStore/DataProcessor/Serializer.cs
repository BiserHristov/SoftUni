namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.XMLHelper;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .ToList() //Because of Judge, or else InMemory exception!!!
                .Where(g => genreNames.Contains(g.Name) && g.Games.Any(ga => ga.Purchases.Count > 0))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Where(g => g.Purchases.Count > 0)
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name).ToList()),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(x => x.Players)
                        .ThenBy(x => x.Id)
                        .ToList(),
                    TotalPlayers = x.Games.SelectMany(gam => gam.Purchases).Count()

                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();


            string result = JsonConvert.SerializeObject(genres, Formatting.Indented);
            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            PurchaseType type = (PurchaseType)Enum.Parse(typeof(PurchaseType), storeType);

            var users = context.Users
                .ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type == type)))
                .Select(u => new UserXMLOutputModel
                {
                    UserName = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases.Where(p => p.Type == type))
                        .Select(p => new PurchaseXMLOutputModel
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameXMLOutputModel
                            {
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price,
                                Title = p.Game.Name
                            }
                        })
                    .OrderBy(x => x.Date)
                    .ToList(),
                    TotalSpent = u.Cards.SelectMany(c => c.Purchases.Where(p => p.Type == type)).Sum(x => x.Game.Price)
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.UserName)
                .ToList();



            var xml = XmlConverter.Serialize(users, "Users");

            return xml;
        }
    }
}