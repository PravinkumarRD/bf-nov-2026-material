using Microsoft.EntityFrameworkCore;
using PO.Application.Contracts;
using PO.Dal;

namespace PO.Repository;

public class CommonRepository<T> : ICommonRepository<T> where T : class
{
    private readonly PoDbContext _dbContext;
    //Constrcutor Injection
    public CommonRepository(PoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetDetailsAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task InsertAsync(T item)
    {
        await _dbContext.Set<T>().AddAsync(item);
    }

    public async Task UpdateAsync(T item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
    }
    public async Task DeleteAsync(T item)
    {
        _dbContext.Set<T>().Remove(item);
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
