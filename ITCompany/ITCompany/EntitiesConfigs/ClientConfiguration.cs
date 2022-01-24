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
                new ClientEntity
                {
                    ClientId = -1,
                    Name = "Test Client 1",
                    Email = "Test Email 1",
                    PhoneNumber = "Test PhoneNumber 1",
                    CooperationStartDate = DateTimeOffset.UtcNow
                },
                new ClientEntity
                {
                    ClientId = -2,
                    Name = "Test Client 2",
                    Email = "Test Email 2",
                    PhoneNumber = "Test PhoneNumber 2",
                    CooperationStartDate = DateTimeOffset.UtcNow
                },
                new ClientEntity
                {
                    ClientId = -3,
                    Name = "Test Client 3",
                    Email = "Test Email 3",
                    PhoneNumber = "Test PhoneNumber 3",
                    CooperationStartDate = DateTimeOffset.UtcNow
                },
                new ClientEntity
                {
                    ClientId = -4,
                    Name = "Test Client 4",
                    Email = "Test Email 4",
                    PhoneNumber = "Test PhoneNumber 4",
                    CooperationStartDate = DateTimeOffset.UtcNow
                },
                new ClientEntity
                {
                    ClientId = -5,
                    Name = "Test Client 5",
                    Email = "Test Email 5",
                    PhoneNumber = "Test PhoneNumber 5",
                    CooperationStartDate = DateTimeOffset.UtcNow
                }
            });
        }
    }
}
