using AutoMapper;
using EventManagement.Application.ViewModels.UserContextViewModels;
using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Application.Mappings
{
    public class EntityToViewModelMappings : Profile
    {
        public EntityToViewModelMappings()
        {
            CreateMap<UserEntity, UserViewModel>();
        }
    }
}
