using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Interfaces.Abstractions;


public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> FindByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}