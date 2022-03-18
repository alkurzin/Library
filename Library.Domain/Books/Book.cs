namespace Library.Domain.Books
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Article { get; set; }
        public int PublicationYear { get; set; }
        public int Amount { get; set; }

        public Book()
        {

        }

        public Book(string title, string author, int article, int publicationYear, int amount)
        {
            Title = title;
            Author = author;
            Article = article;
            PublicationYear = publicationYear;
            Amount = amount;
        }

        public void Update(string title, string author, int article, int publicationYear, int amount)
        {
            Title = title;
            Author = author;
            Article = article;
            PublicationYear = publicationYear;
            Amount = amount;
        }
    }
}
