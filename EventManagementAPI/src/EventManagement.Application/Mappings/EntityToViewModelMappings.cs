﻿using AutoMapper;
using EventManagement.Application.ViewModels.CategoryContextViewModels;
using EventManagement.Application.ViewModels.UserContextViewModels;
using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Application.Mappings
{
    public class EntityToViewModelMappings : Profile
    {
        public EntityToViewModelMappings()
        {
            #region User Bounded Context Mappings
            CreateMap<UserEntity, UserViewModel>();
            #endregion

            #region Category Bounded Context Mappings
            CreateMap<CategoryEntity, CategoryViewModel>();
            #endregion
        }
    }
}
