using AutoMapper;
using Todo.Domain.DomainEntities;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Mappers;

public class UserMappingExtention:Profile
{

    public UserMappingExtention()
    {
        CreateMap<User, UserDomain>();
    }
}