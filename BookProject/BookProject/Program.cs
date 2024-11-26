using static System.Reflection.Metadata.BlobBuilder;

namespace BookProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User(new BookManager());
            while (true)
            {
                Console.WriteLine("Enter an operation (add, all, find):");
                var operation = Console.ReadLine();
                
                switch(operation)
                {
                    case "add":
                        user.AddBook();
                        break;
                    case "all":
                        user.AllBooks();
                        break;
                    case "find":
                        user.FindBook();
                        break;
                }
            }
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
        public List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(string name, string author, int publishYear)
        {
            Book book = new Book(name, author, publishYear);
            Books.Add(book);
        }

        public List<Book> AllBooks()
        {
            return Books;
        }

        public List<Book> FindBook(string query)
        {
            if (Books == null || Books.Count == 0)
            {
                return null;  
            }

            var book = Books.FindAll(book => book.Name.Contains(query, StringComparison.OrdinalIgnoreCase));

            return book;
        }
    }

    public class User : IUser
    {
        public BookManager Manager { get; set; }

        public User(BookManager manager)
        {
            Manager = manager;
        }

        public void AddBook()
        {
            Console.WriteLine("Enter name, author and year of publish");
            var name = Console.ReadLine();
            var author = Console.ReadLine();
            var yearCheck = int.TryParse(Console.ReadLine(), out var year);
            Manager.AddBook(name, author, year);
            Console.WriteLine("Book created");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public void AllBooks()
        {
            List<Book> books = Manager.AllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books.");
            } else {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Name} | {book.Author} | {book.Published}");
                }
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public void FindBook()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine();
            List<Book> books = Manager.FindBook(query);
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Name} | {book.Author} | {book.Published}\n");
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
