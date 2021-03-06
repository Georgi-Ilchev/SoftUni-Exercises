using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //1
            //string input = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(db, input);
            //Console.WriteLine(result);

            //2
            //Console.WriteLine(GetGoldenBooks(db));

            //3
            //Console.WriteLine(GetBooksByPrice(db));

            //4
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            //5
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            //6
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //7
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //8
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //9
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, input));

            //10
            //int lengthCheck = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, lengthCheck));

            //11
            //Console.WriteLine(CountCopiesByAuthor(db));

            //12
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //13
            //Console.WriteLine(GetMostRecentBooks(db));

            //14
            //IncreasePrices(db);

            //15
            //Console.WriteLine(RemoveBooks(db));
        }

        //1. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            //where(x=>x.AgeRestriction == ageRestriction);

            var books = context.Books
                .AsEnumerable()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        //2. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);

            //2
            //var books = context.Books
            //    .Where(b => b.EditionType == EditionType.Gold &&
            //                b.Copies < 5000)
            //    .Select(b => new
            //    {
            //        b.BookId,
            //        b.Title,
            //    })
            //    .OrderBy(x => x.BookId)
            //    .ToList();

            //var result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            //return result.ToString();
        }

        //3. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();

            //var result = string.Join(Environment.NewLine, 
            //    books.Select(x=> $"{x.Title} - ${x.Price}"));
        }

        //4. Not Released Inca
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year) //&& x.ReleaseDate.HasValue)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //5. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.ToLower())
                .ToList();

            //1
            //List<string> bookTitles = new List<string>();

            //foreach (var category in categories)
            //{
            //    List<string> booksWithCurrentCatecory = context.Books
            //        .Where(x => x.BookCategories.Any(c => c.Category.Name.ToLower() == category))
            //        .Select(x => x.Title)
            //        .ToList();

            //    bookTitles.AddRange(booksWithCurrentCatecory);
            //}
            //return string.Join(Environment.NewLine, bookTitles.OrderBy(x => x));

            //2
            var bookTitles = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(books => books.Book.Title)
                .OrderBy(title => title)
                .ToList();
            return string.Join(Environment.NewLine, bookTitles);
        }

        //6. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < dateTime)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //7. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var names = context.Authors
                .Where(x => EF.Functions.Like(x.FirstName, $"%{input}"))
                //.Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .ToList();

            return string.Join(Environment.NewLine, names.OrderBy(x => x));
        }

        //8. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
            .Where(x => x.Title.ToLower().Contains(input.ToLower()))
            .Select(x => x.Title)
            .ToList();

            return string.Join(Environment.NewLine, books.OrderBy(x => x));
        }

        //9. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                //.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Where(x => EF.Functions.Like(x.Author.LastName, $"{input}%"))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    Titles = x.Title,
                    FullName = x.Author.FirstName + " " + x.Author.LastName
                })
                .ToList();

            //1
            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Titles} ({book.FullName})");
            }

            return sb.ToString().TrimEnd();

            //2
            //var result = string.Join(Environment.NewLine, books
            //    .Select(x => $"{x.Titles} ({x.FullName})"));

            //return result;
        }

        //10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            //1
            //return context.Books
            //    .Where(x => x.Title.Length > lengthCheck)
            //    .Count();

            //2
            var book = context.Books
                .Where(x => x.Title.Length > lengthCheck).ToList();

            int bookCount = book.Count();

            return bookCount;
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Authors
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    TotalCopies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.FullName} - {book.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(c => c.Book.Price * c.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in categories)
            {
                sb.AppendLine($"{book.CategoryName} ${book.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context
                .Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(c => new
                    {
                        c.Book.Title,
                        c.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(c => c.Value)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in books)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count();
        }
    }
}
