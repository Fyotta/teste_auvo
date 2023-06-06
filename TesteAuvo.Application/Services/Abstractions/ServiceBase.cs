using TesteAuvo.Application.Interfaces.Services.Abstractions;
using TesteAuvo.Domain.Abstractions;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Application.Services.Abstractions;

public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
{
    private readonly IRepositoryBase<TEntity> _repository;

    protected ServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }
    public virtual async Task AddAsync(TEntity entity)
    {
        await _repository.AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _repository.AddRangeAsync(entities);
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        await _repository.DeleteRangeAsync(entities);
    }

    public virtual async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await _repository.GetAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        await _repository.UpdateAsync(entity);
    }
}