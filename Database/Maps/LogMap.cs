using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Maps
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Level).HasColumnType("INT(1)").IsRequired();
            builder.Property(x => x.Enviroment).HasColumnType("INT(1)").IsRequired();
            builder.Property(x => x.Event).HasColumnType("INT(3)").IsRequired();
            builder.Property(x => x.Title).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(x => x.Origin).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(x => x.Details).HasColumnType("TEXT").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP()").IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Logs);
        }
    }
}
