using Todo.Domain.DomainEntities;

namespace Todo.Domain.RepositoryInterface;

public interface IUserRepo:IGenaricRepo<UserDomain>
{
    Task<UserDomain>GetByEmailAsync(string email);
}