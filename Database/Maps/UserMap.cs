using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARCHAR(255)").IsRequired();
        }
    }
}
