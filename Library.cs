public class Repository<T> : ILibrary<T> where T : class
{
     List<T> items = new();

    public void Add(T item) => items.Add(item);
    
    public void Remove(int id)
{
    var itemToDelete = items.Find(item => (item as BaseBook)?.Id == id);

    if (itemToDelete != null)
    {
        items.Remove(itemToDelete);
    }
}

public T? GetById(int id)
{
    return items.FirstOrDefault(item => item is BaseBook book && book.Id == id);
}

    
    public IEnumerable<T> GetAll() => items;
}
