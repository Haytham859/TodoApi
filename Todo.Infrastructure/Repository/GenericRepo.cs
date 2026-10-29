using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Repository;

public class GenericRepo<TDomain,TEntity>:IGenaricRepo<TDomain> 
    where  TDomain:class
    where TEntity :class
{
    
    private readonly TodoAppDbContext _dbContext;
    private readonly IMapper _mapper;
    

    public GenericRepo(TodoAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<TDomain> GetByIdAsync(object id)
    {
        var entity=await  _dbContext.Set<TEntity>().FindAsync(id);
        return entity==null ? null:_mapper.Map<TDomain>(entity);
    }

    public async Task<IEnumerable<TDomain>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>()
            .ProjectTo<TDomain>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task CreateAsync(TDomain item)
    {
        var entity = _mapper.Map<TEntity>(item);

        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public Task<int> CommitAsync()
    {
        throw new NotImplementedException();
    }
}