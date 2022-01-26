using System;
using System.Collections.Generic;
using ITCompany.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ITCompany.EntitiesConfigs
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("Client").HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.CooperationStartDate).IsRequired();
            builder.HasData(new List<ClientEntity>()
            {
                new ClientEntity { ClientId = -1, Name = "Client 1", Email = "Email 1", PhoneNumber = "PhoneNumber 1", CooperationStartDate = DateTimeOffset.UtcNow },
                new ClientEntity { ClientId = -2, Name = "Client 2", Email = "Email 2", PhoneNumber = "PhoneNumber 2", CooperationStartDate = DateTimeOffset.UtcNow },
                new ClientEntity { ClientId = -3, Name = "Client 3", Email = "Email 3", PhoneNumber = "PhoneNumber 3", CooperationStartDate = DateTimeOffset.UtcNow },
                new ClientEntity { ClientId = -4, Name = "Client 4", Email = "Email 4", PhoneNumber = "PhoneNumber 4", CooperationStartDate = DateTimeOffset.UtcNow },
                new ClientEntity { ClientId = -5, Name = "Client 5", Email = "Email 5", PhoneNumber = "PhoneNumber 5", CooperationStartDate = DateTimeOffset.UtcNow },
            });
        }
    }
}
