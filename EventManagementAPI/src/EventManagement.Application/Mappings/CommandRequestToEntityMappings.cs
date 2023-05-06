using AutoMapper;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandUpdateCategory;
using EventManagement.Application.CQRSs.LocationContextCQRSs.CommandCreateLocation;
using EventManagement.Application.CQRSs.LocationContextCQRSs.CommandUpdateLocation;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings()
        {
            #region User Bounded Context Mappings
            CreateMap<CreateUserCommandRequest, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ConstructUsing(src => new UserEntity(src.Name, src.Surname, src.Email, src.Password));

            CreateMap<UpdateUserCommandRequest, UserEntity>();
            #endregion

            #region Category Bounded Context Mappings
            CreateMap<CreateCategoryCommandRequest, CategoryEntity>();

            CreateMap<UpdateCategoryCommandRequest, CategoryEntity>();
            #endregion

            #region Location Bounded Context Mappings
            CreateMap<CreateLocationCommandRequest, LocationEntity>();

            CreateMap<UpdateLocationCommandRequest, LocationEntity>();
            #endregion
        }
    }
}
