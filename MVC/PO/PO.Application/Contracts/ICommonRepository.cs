namespace PO.Application.Contracts;

public interface ICommonRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetDetailsAsync(int id);
    Task InsertAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(T item);
    Task<int> SaveChangesAsync();
}
