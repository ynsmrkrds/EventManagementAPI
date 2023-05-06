using AutoMapper;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings()
        {
            CreateMap<CreateUserCommandRequest, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ConstructUsing(src => new UserEntity(src.Name, src.Surname, src.Email, src.Password));

            CreateMap<UpdateUserCommandRequest, UserEntity>();
        }
    }
}
