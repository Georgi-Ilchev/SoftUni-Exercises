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

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var games = JsonConvert.DeserializeObject<IEnumerable<GameJsonImport>>(jsonString);

            foreach (var jsonGame in games)
            {
                if (!IsValid(jsonGame) || jsonGame.Tags.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer) ??
                    new Developer { Name = jsonGame.Developer };

                var genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre) ??
                    new Genre { Name = jsonGame.Genre };

                var game = new Game
                {
                    Name = jsonGame.Name,
                    Price = jsonGame.Price,
                    ReleaseDate = jsonGame.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var jsonTag in jsonGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag) ??
                        new Tag { Name = jsonTag };
                    game.GameTags.Add(new GameTag { Tag = tag });
                }

                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var users = JsonConvert.DeserializeObject<IEnumerable<UserJsonImport>>(jsonString);

            foreach (var jsonUser in users)
            {
                if (!IsValid(jsonUser) || !jsonUser.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = jsonUser.FullName,
                    Username = jsonUser.Username,
                    Email = jsonUser.Email,
                    Age = jsonUser.Age,
                    Cards = jsonUser.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.CVC,
                        Type = x.Type.Value,
                    }).ToList()
                };

                context.Users.Add(user);
                sb.AppendLine($"Imported {jsonUser.Username} with {jsonUser.Cards.Count()} cards");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            string root = "Purchases";

            var purchases = XmlConverter.Deserializer<PurchaseXmlImport>(xmlString, root);

            foreach (var xmlPurchase in purchases)
            {
                if (!IsValid(xmlPurchase))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool parsedDate = DateTime.TryParseExact(xmlPurchase.Date, "dd/MM/yyyy HH:mm",
                                                         CultureInfo.InvariantCulture, DateTimeStyles.None,
                                                         out var date);

                var purchase = new Purchase
                {
                    Game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.Title),
                    Type = xmlPurchase.Type.Value,
                    ProductKey = xmlPurchase.Key,
                    Card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card),
                    Date = date,
                };

                context.Purchases.Add(purchase);

                var username = context.Users.Where(x => x.Id == purchase.Card.UserId)
                    .Select(x => x.Username).FirstOrDefault();

                sb.AppendLine($"Imported {xmlPurchase.Title} for {username}");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}