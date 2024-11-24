namespace BookProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Published { get; set; }

        public Book(string name, string author, int published)
        {
            Name = name;
            Author = author;
            Published = published;
        }
    }

    public class BookManager
    {
        public List<Book> Books { get; set; }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AllBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Name} | {book.Author} | {book.Published}\n");
            }
        }

        public Book FindBook(string name)
        {
            if (Books == null || Books.Count == 0)
            {
                return null;  
            }

            var book = Books.Find(book => book.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return book;
        }
    }
    
    public class User : IUser
    {

    }
}
