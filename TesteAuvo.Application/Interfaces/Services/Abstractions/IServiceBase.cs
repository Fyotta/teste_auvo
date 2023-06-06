using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Application.Interfaces.Services.Abstractions;


public interface IServiceBase<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity?> FindByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task DeleteAsync(TEntity entity);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
}