using AutoMapper;
using Todo.Application.Contracts;
using Todo.Application.DTOs.Request;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;

namespace Todo.Application.Implementation;

public class UserService:IUserService
{
    
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepo userRepo, IMapper mapper,IPasswordHasher passwordHasher)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }
    public async Task<bool> CreateUserAsync(CreateUserDto dto)
    {
        //

        var userDomain = _mapper.Map<UserDomain>(dto);
        
        userDomain.PasswordHash=_passwordHasher.HashPassword(dto.Password);

         await _userRepo.CreateAsync(userDomain);
         
         var response = await _userRepo.CommitAsync();
         
         return response > 0;
         
    }
}