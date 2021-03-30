namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                        Players = g.Purchases.Count(),
                    }).Where(x => x.Players > 0)
                         .OrderByDescending(x => x.Players)
                         .ThenBy(x => x.Id)
                         .ToList(),
                    TotalPlayers = x.Games.Sum(g => g.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();
            var result = JsonConvert.SerializeObject(games, Formatting.Indented);
            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var root = "Users";

            var purchases = context.Users
                .ToList()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(p=>p.Type.ToString() == storeType)))
                .Select(x => new UserXmlExport
                {
                    UserName = x.Username,
                    Purchases = x.Cards.SelectMany(c => c.Purchases)
                                       .Where(p=>p.Type.ToString() == storeType)
                                       .Select(p => new PurchaseXmlExport
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameXmlExport
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(x => x.Date)
                    .ToArray(),
                    TotalSpent = x.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType)
                                                                               .Sum(p => p.Game.Price))
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.UserName)
                .ToList();

            var result = XmlConverter.Serialize(purchases, root);
            return result;
        }
    }
}