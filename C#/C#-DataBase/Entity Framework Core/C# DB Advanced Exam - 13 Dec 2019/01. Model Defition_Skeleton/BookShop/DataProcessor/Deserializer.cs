namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
            string root = "Books";
            var books = XmlConverter.Deserializer<BookXmlImportModel>(xmlString, root);

            var validBooks = new List<Book>();
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookXmlImportModel[]),
            //                                                new XmlRootAttribute(root));

            //var books = (IEnumerable<BookXmlImportModel>)xmlSerializer
            //    .Deserialize(new StringReader(xmlString));

            foreach (var xmlBook in books)
            {
                if (!IsValid(xmlBook))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;
                bool isValidDate = DateTime.TryParseExact(xmlBook.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = xmlBook.Name,
                    Genre = (Genre)xmlBook.Genre,
                    Price = xmlBook.Price,
                    Pages = xmlBook.Pages,
                    PublishedOn = publishedOn
                };

                validBooks.Add(book);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(validBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var validAuthors = new List<Author>();

            var authors = JsonConvert.DeserializeObject<IEnumerable<AuthorsXmlImportModel>>(jsonString);

            foreach (var xmlAuthor in authors)
            {
                if (!IsValid(xmlAuthor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validAuthors.Any(a => a.Email == xmlAuthor.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = xmlAuthor.FirstName,
                    LastName = xmlAuthor.LastName,
                    Phone = xmlAuthor.Phone,
                    Email = xmlAuthor.Email
                };

                foreach (var xmlBook in xmlAuthor.Books)
                {
                    if (!xmlBook.BookId.HasValue)
                    {
                        continue;
                    }

                    var book = context.Books.FirstOrDefault(x => x.Id == xmlBook.BookId);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook()
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validAuthors.Add(author);
                sb.AppendLine(
                    string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(validAuthors);
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