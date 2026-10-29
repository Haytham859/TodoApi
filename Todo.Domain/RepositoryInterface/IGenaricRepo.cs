namespace Todo.Domain.RepositoryInterface;

public interface IGenaricRepo<TDomain>where TDomain :class
{
Task<TDomain>GetByIdAsync(object id);

Task<IEnumerable<TDomain>> GetAllAsync();

Task CreateAsync(TDomain item);

Task<int> CommitAsync();

}