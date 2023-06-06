using Microsoft.EntityFrameworkCore;
using TesteAuvo.Domain.Abstractions;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Infra.Data.Repositories.Abstractions;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    protected RepositoryBase(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(); 
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}