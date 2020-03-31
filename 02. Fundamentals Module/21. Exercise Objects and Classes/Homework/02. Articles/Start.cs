using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Start
    {
        static void Main()
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();
            string title = list[0];
            string content = list[1];
            string author = list[2];

            int count = int.Parse(Console.ReadLine());
            Article article = new Article(title, content, author);

            for (int i = 0; i < count; i++)
            {
                List<string> input = Console.ReadLine().Split(": ").ToList();

                if (input[0]== "Edit")
                {
                    article.Edit(input[1]);
                }

                else if (input[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(input[1]);
                }
                else if (input[0]== "Rename")
                {
                    article.Rename(input[1]);
                }
            }

            Console.WriteLine(article);

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

        public void Edit(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string name)
        {
            this.Author = name;
        }

        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
