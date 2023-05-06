﻿using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.UserContextEntities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RoleEntity(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}