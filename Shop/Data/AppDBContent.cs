using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;



namespace Shop.Data
{
    public class AppDBContent: IdentityDbContext
    {

        public AppDBContent(DbContextOptions<AppDBContent> options)
            :base(options)
        {
            
        }

        

        public DbSet<Medicines> Drug { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> Item { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDatail> OrderDetail { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1",
                    UserName = "Vova",
                    PhoneNumber = "0981747054"

                }
            );

            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");


        }
    }

    
}
