public interface ILibrary<T>
{
    void Add(T item);
    void Remove(int id);
    T? GetById(int id);
    IEnumerable<T> GetAll();
}
