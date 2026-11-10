using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Repository;

public class UserRepo:GenericRepo<UserDomain,User>,IUserRepo
{
    public UserRepo(TodoAppDbContext dbContext,IMapper mapper):base(dbContext,mapper)
    {
        
    }

    public async Task<UserDomain> GetByEmailAsync(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(a => a.Email == email);

        return _mapper.Map<UserDomain>(user);
        

    }
}