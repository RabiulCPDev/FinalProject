public interface ILibraryService
{
    void AddBook(BaseBook book);
    void LendBook(int bookId);
    void ReturnBook(int bookId);
    IEnumerable<BaseBook> GetAllBooks();
}
