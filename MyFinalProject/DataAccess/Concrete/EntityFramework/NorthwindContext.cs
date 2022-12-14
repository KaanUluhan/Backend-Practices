using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak
   public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //override yazıp entere basıp ilk çıkanı seçince yapı geliyor
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");  //görünüm sql server objectten kaynağımızı yazdık parantez içine
        }
        public DbSet<Product> Products { get; set; }  //context hangi veritabanına baağlanacağını buldu yukarıda benim hangi classım hangi tabloya karşılık geliyo onu yazdık
        public DbSet<Category> Categories { get; set; } //context hangi veritabanına baağlanacağını buldu yukarıda benim hangi classım hangi tabloya karşılık geliyo onu yazdık
        public DbSet<Customer> Customers { get; set; } //context hangi veritabanına baağlanacağını buldu yukarıda benim hangi classım hangi tabloya karşılık geliyo onu yazdık
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
