using AutoMapper;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandUpdateCategory;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandCancelEvent;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandCreateEvent;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandReviewEvent;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandUpdateEvent;
using EventManagement.Application.CQRSs.LocationContextCQRSs.CommandCreateLocation;
using EventManagement.Application.CQRSs.LocationContextCQRSs.CommandUpdateLocation;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Enums.CategoryContextEnums;

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

            #region Event Bounded Context Mappings
            CreateMap<CreateEventCommandRequest, EventEntity>()
                .ConstructUsing(src => EventEntity.Create(src.Title, src.Date, src.Description, src.LocationID, src.Address, src.Quota, src.CategoryID));

            CreateMap<UpdateEventCommandRequest, EventEntity>();

            CreateMap<CancelEventCommandRequest, EventEntity>();

            CreateMap<ReviewEventCommandRequest, EventEntity>();
            #endregion
        }
    }
}
