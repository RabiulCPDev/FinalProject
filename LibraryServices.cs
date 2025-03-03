public class LibraryService : ILibraryService
{
    private readonly ILibrary<BaseBook> bookList;

    public LibraryService(ILibrary<BaseBook> bookRepository)
    {
        bookList = bookRepository;
    }

    public void AddBook(BaseBook book) => bookList.Add(book);

    public void LendBook(int bookId)
    {
        var book = bookList.GetById(bookId);
        if (book == null) 
        {
            Console.WriteLine("Invalid Book ID.");
            return;
        }

        if (book.Type == BookType.Ebook)
        {
            Console.WriteLine($"Ebook '{book.Title}' can be accessed online. No lending required.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine($"Printed book '{book.Title}' is already borrowed.");
            return;
        }

        book.IsAvailable = false;
        Console.WriteLine($"Printed book '{book.Title}' has been lent.");
    }

    public void ReturnBook(int bookId)
    {
        var book = bookList.GetById(bookId);
        if (book == null)
        {
            Console.WriteLine("Invalid Book ID.");
            return;
        }

        if (book.Type == BookType.Ebook)
        {
            Console.WriteLine("Ebooks do not need to be returned.");
            return;
        }

        book.IsAvailable = true;
        Console.WriteLine($"Printed book '{book.Title}' has been returned.");
    }

    public IEnumerable<BaseBook> GetAllBooks() => bookList.GetAll();
}
