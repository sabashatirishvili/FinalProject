
using static System.Reflection.Metadata.BlobBuilder;

namespace BookProject
{
    internal interface IUser
    {
        void AddBook(List<Book> books, string name, string author, int year)
        {
            books.Add(new Book(name, author, year));
            Console.WriteLine($"Book {name} added.");
        }

        void AllBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Name} | {book.Author} | {book.Published}\n");
            }
        }
        void FindBook(List<Book> books, string name)
        {
            if (books == null || books.Count == 0)
            {
                Console.WriteLine("No books");
                return;
            }

            var book = books.Find(book => book.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        }
    }
}
