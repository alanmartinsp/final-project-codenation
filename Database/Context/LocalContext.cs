using Business.Models;
using Database.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Context
{
    public class LocalContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=codenationlog;Uid=root;SslMode=None");
        //}

        public LocalContext(DbContextOptions<LocalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
