using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Interfaces.Abstractions;


public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity?> FindByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task DeleteAsync(TEntity entity);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
}