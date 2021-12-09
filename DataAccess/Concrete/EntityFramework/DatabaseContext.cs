using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=C:\USERS\AHMET\SOURCE\REPOS\RECAPPROJECT\DATAACCESS\CONCRETE\ENTITYFRAMEWORK\DATABASE1.MDF;Trusted_Connection=true");
        }
        public DbSet<Car> CarDb { get; set; }
        public DbSet<Brand> BrandDb { get; set; }
        public DbSet<Color> ColorDb { get; set; }

    }
}
