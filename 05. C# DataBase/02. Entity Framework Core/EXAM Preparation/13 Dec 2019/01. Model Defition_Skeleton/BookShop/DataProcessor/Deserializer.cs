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
    using SoftJail.XMLHelper;
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
            const string root = "Books";
            var desereliezedBooks = XmlConverter.Deserializer<BookXMLInputModel>(xmlString, root);

            var sb = new StringBuilder();

            foreach (var currentBook in desereliezedBooks)
            {
                if (!IsValid(currentBook))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var book = new Book
                {
                    Genre = (Genre)currentBook.Genre, // check the logic
                    Name = currentBook.Name,
                    Pages = currentBook.Pages,
                    Price = currentBook.Price,
                    PublishedOn = DateTime.Parse(currentBook.PublishedOn, CultureInfo.InvariantCulture),
                };

                context.Books.Add(book);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported book {currentBook.Name} for {currentBook.Price:F2}.");


            }

            return sb.ToString().Trim();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var deserializedAuthors = JsonConvert.DeserializeObject<IEnumerable<AuthorJsonInputModel>>(jsonString);

            var sb = new StringBuilder();

            foreach (var currentAuthor in deserializedAuthors)
            {
                var existingEmail = context.Authors.FirstOrDefault(a => a.Email == currentAuthor.Email);
                if (!IsValid(currentAuthor) ||
                    existingEmail != null ||
                    currentAuthor.Books.Count() == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var author = new Author
                {
                    Email = currentAuthor.Email,
                    FirstName = currentAuthor.FirstName,
                    LastName = currentAuthor.LastName,
                    Phone = currentAuthor.Phone,
                };

                var bookIds = context.Books
                                    .Select(x => x.Id)
                                    .ToList();

                foreach (var book in currentAuthor.Books)
                {

                    if (book.Id.HasValue && bookIds.Contains((int)book.Id))
                    {
                        author.AuthorsBooks.Add(new AuthorBook { BookId = (int)book.Id });
                        //context.SaveChanges();

                    }
                }


                if (author.AuthorsBooks.Count() > 0)
                {
                    context.Authors.Add(author);
                    context.SaveChanges();
                    sb.AppendLine($"Successfully imported author - {author.FirstName + " " + author.LastName} with {author.AuthorsBooks.Count} books.");
                }
                else {
                    sb.AppendLine("Invalid data!");
                }



            }

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}