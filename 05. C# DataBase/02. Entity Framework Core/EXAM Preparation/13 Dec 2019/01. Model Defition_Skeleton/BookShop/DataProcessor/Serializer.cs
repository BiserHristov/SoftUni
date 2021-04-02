namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.XMLHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                            .OrderByDescending(ab => ab.Book.Price)
                            .Select(ab => new
                            {
                                BookName = ab.Book.Name,
                                BookPrice = ab.Book.Price.ToString("F2")
                            })
                            .ToList()
                })
                .ToList()
                .OrderByDescending(a => a.Books.Count)
                .ThenBy(a => a.AuthorName)
                .ToList();

            //var authors = context
            //    .Authors
            //    .Select(a => new
            //    {
            //        AuthorName = a.FirstName + " " + a.LastName,
            //        Books = a.AuthorsBooks
            //            .Select(ab => ab.Book)
            //            .OrderByDescending(b => b.Price)
            //            .Select(b => new
            //            {
            //                BookName = b.Name,
            //                BookPrice = b.Price.ToString("f2")
            //            })
            //            .ToArray()
            //    })
            //    .ToArray()
            //    .OrderByDescending(a => a.Books.Length)
            //    .ThenBy(a => a.AuthorName)
            //    .ToArray();

            string result = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return result;

        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {

            var books = context.Books.ToList()
                .Where(b => b.PublishedOn < date && b.Genre.ToString() == "Science")
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new BookXMLOutputModel
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToList();

            var xml = XmlConverter.Serialize(books, "Books");

            return xml;


        }
    }
}