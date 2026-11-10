using System.Text;
using Todo.Application.Contracts;
using Todo.Application.DTOs.Request;
using Todo.Application.DTOs.Response;
using Todo.Domain.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.DomainEntities;

namespace Todo.Application.Implementation;

public class TokenService:ITokenService
{

    private readonly IUserRepo _userRepo;

    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher _passwordHasher;
    public TokenService(IUserRepo userRepo,IConfiguration configuration,IPasswordHasher passwordHasher)
    {
        _userRepo = userRepo;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
        
    }
    public async Task<TokenResponseDto> GetTokenAsync(TokenRequestDto tokenRequestDto)
    {
        var userDomain=await _userRepo.GetByEmailAsync(tokenRequestDto.Username);

        if (userDomain == null)
            throw new Exception() ;

        bool isPasswordValid = _passwordHasher.VerifyHashedPassword(tokenRequestDto.Password,userDomain.PasswordHash);

        if (!isPasswordValid)
            throw new Exception();
        
        

    }

    private string GenerateToken(UserDomain userResponse)
    {
        string secretKey = _configuration["Jwt:Secret"];
        
        var secKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        
        

    }
    
    
}