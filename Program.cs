class Program
{
    static void Main()
    {
        ILibrary<BaseBook> bookRepository = new Repository<BaseBook>();
        ILibraryService libraryService = new LibraryService(bookRepository);

        
        libraryService.AddBook(new PrintedBook { Id = 1, Title = "C Programming", Author = "Asif" });
        libraryService.AddBook(new Ebook { Id = 2, Title = "C# Programming", Author = "Naim" }); 
        libraryService.AddBook(new Ebook { Id = 3, Title = "Java Programming", Author = "Haris" }); 

        Console.WriteLine("\nLibrary Books:");
        DisplayBooks(libraryService);

        libraryService.LendBook(1);
        libraryService.LendBook(2);

        Console.WriteLine("\nUpdated Library Books:");
        DisplayBooks(libraryService);
        libraryService.ReturnBook(1);
        libraryService.ReturnBook(2);

        Console.WriteLine("\nFinal Library Books:");
        DisplayBooks(libraryService);
    }

    static void DisplayBooks(ILibraryService libraryService)
    {
        foreach (var book in libraryService.GetAllBooks())
        {
            string status = book.IsAvailable ? "Available" : "Borrowed";
            Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} [{book.Type}] - {status}");
        }
    }
}
