using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Articles2
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<Article> list = new List<Article>();
            for (int i = 0; i < count; i++)
            {
                List<string> line = Console.ReadLine().Split(", ").ToList();
                string title = line[0];
                string content = line[1];
                string author = line[2];

                Article article = new Article(title, content, author);
                list.Add(article);
            }

            string orderCriteria = Console.ReadLine();

            var orderedList = Now<Article>(list, orderCriteria);
           // PrintByCriteria(list, orderCriteria);

           

        }
        public static List<Article> Now<T>(List<Article> input, string property)
        {
            var type = typeof(T);
            var sortProperty = type.GetProperty(property);
            return input.OrderBy(p => sortProperty.GetValue(p, null)).ToList();
        }
        public static void PrintByCriteria(List<Article> list, string criteria)
        {
            string order = $"x.{criteria}";

            List<Article> orderedList = list.OrderBy(x => order).ToList();
            foreach (var article in orderedList)
            {
                Console.WriteLine(article.ToString());

            }
        }

    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }

}
