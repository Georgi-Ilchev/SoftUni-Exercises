namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                                    .OrderByDescending(b => b.Book.Price)
                                    .Select(b => new
                                    {
                                        BookName = b.Book.Name,
                                        BookPrice = $"{b.Book.Price:f2}"
                                    })
                                    .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count)
                .ThenBy(x => x.AuthorName);

            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var root = "Books";

            var books = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .ToList()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new BookXmlExportModel
                {
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = b.Pages
                })
                .ToList();

            var result = XmlConverter.Serialize(books, root);
            return result;
        }
    }
}