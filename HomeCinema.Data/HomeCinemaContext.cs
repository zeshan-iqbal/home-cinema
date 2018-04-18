using HomeCinema.Core.Domain;
using HomeCinema.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data
{
    public class HomeCinemaContext : DbContext
    {
        public HomeCinemaContext(DbContextOptions<HomeCinemaContext> options)
            : base(options)
        {}

        public HomeCinemaContext()
        {
            //Default constructor for 
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Server=NX00432\SQLEXPRESS;Database=HomeCinemaDb;Trusted_Connection=False;User Id=HomeCinemaDb;Password=word2pass;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ErrorMap());
            modelBuilder.ApplyConfiguration(new GenreMap());
            modelBuilder.ApplyConfiguration(new MovieMap());
            modelBuilder.ApplyConfiguration(new RentalMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }
    }

}
