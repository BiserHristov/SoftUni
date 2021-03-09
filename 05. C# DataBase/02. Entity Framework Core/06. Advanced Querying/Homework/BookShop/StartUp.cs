namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    //using Models;

    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    //using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            var result = string.Empty;

            //Task 2: Age Restriction
            //result = GetBooksByAgeRestriction(db, "miNor");


            //Таск 3
            //result = GetGoldenBooks(db);

            //Task 4
            //result = GetBooksByPrice(db);

            //Task 5
            //result = GetBooksNotReleasedIn(db, 1998);

            //Task 6
            //result = GetBooksByCategory(db, "horror mystery drama");

            //Task 7
            //result = GetBooksReleasedBefore(db, "30-12-1989");

            //Task 8
            //result = GetAuthorNamesEndingIn(db, "dy");

            //Task 9
            //result = GetBookTitlesContaining(db, "sK");

            //Task 10
            //result = GetBooksByAuthor(db, "R");

            //Task 11
            //result = CountBooks(db, 40).ToString();

            //Task 12
            //result = CountCopiesByAuthor(db);

            //Task 13
            //result = GetTotalProfitByCategory(db);

            //Task 14
            //result = GetMostRecentBooks(db);

            //Task 15
            //IncreasePrices(db);

            //Task 16
            result = RemoveBooks(db).ToString();
            Console.WriteLine(result);


        }
        /*
         *Remove all books, which have less than 4200 copies. Return an int - the number of books that were deleted from the database.
         */

        //Task 16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            int count = books.Count();
            foreach (var book  in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return count;
        }

        //Task 15
        public static void IncreasePrices(BookShopContext context)
        {
            var books=context.Books
                   .Where(x => x.ReleaseDate.Value.Year < 2010)
                   .ToList();
                    //.Update(x => new Book { Price = x.Price + 5 });


            foreach (var book in books)
            {
                book.Price += 5;

            }

            context.SaveChanges();
        }


        //Task 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks
                    .OrderByDescending(y => y.Book.ReleaseDate)
                    .Take(3)
                    .Select(z => new
                    {
                        BookTitle = z.Book.Title,
                        ReleaseYear = z.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var category in books)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");

                }
            }
            return sb.ToString().Trim();
        }




        //Task 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            //var result = context.BooksCategories
            //    .Include(x=>x.Category)
            //    .GroupBy(x => x.Category.Name);
            //.Select(g => new { g.Key, TotalProfit = g.Sum(b => b.Book.Price * b.Book.Copies) });
            //.OrderByDescending(x => x.TotalProfit)
            //.ThenBy(x => x);


            var result = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();

            //return result.ToString();

            var sb = new StringBuilder();
            foreach (var group in result)
            {
                sb.AppendLine($"{group.Name} ${group.TotalProfit:F2}");

            }
            return sb.ToString().Trim();
        }


        //Task 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Copies = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x => $"{x.FullName} - {x.Copies}"));

        }



        //Task 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var result = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return result;
        }


        //Task 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {

            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .ToList();


            var sb = new StringBuilder();


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");

            }
            return sb.ToString().Trim();


            //ANOTHER SOLUTION STARTING FROM AUTHORS TABLE:

            //var authors = context.Authors
            //    .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
            //    .Select(x => new
            //    {
            //        books = x.Books
            //            .Select(x => new { x.Title, x.BookId })
            //            .OrderBy(x => x.BookId)
            //            .ToList(),
            //        FirstName = x.FirstName,
            //        LastName = x.LastName
            //    }).ToList();

            //var sb = new StringBuilder();
            //foreach (var author in authors)
            //{
            //    foreach (var book in author.books)
            //    {
            //        sb.AppendLine($"{book.Title} ({author.FirstName} {author.LastName})");
            //    }


            //}
        }



        //Task 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }



        //Task 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var fullNames = context.Authors
                .Where(x => EF.Functions.Like(x.FirstName, $"%{input}"))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, fullNames);
        }


        //Task 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            var checkDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value < checkDate)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");

            }
            return sb.ToString().Trim();
        }


        //Task 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(t => t.ToLower())
                            .ToList();

            var titles = context.Books
                .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();


            return String.Join(Environment.NewLine, titles);
        }



        //Task 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();


            return String.Join(Environment.NewLine, titles);
        }



        //Task 4: Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {

            var books = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");

            }
            return sb.ToString().Trim();
        }


        //Task 3:
        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var title in titles)
            {
                sb.AppendLine(title);

            }
            return sb.ToString().Trim();

        }



        //Task 2: Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            var ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var titles = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(t => t)
                .ToList();

            var sb = new StringBuilder();
            foreach (var title in titles)
            {
                sb.AppendLine(title);

            }
            return sb.ToString().Trim();

        }

    }
}
