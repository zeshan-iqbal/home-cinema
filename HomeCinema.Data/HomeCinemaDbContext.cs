using HomeCinema.Core.Data;
using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using HomeCinema.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeCinema.Data
{
    public class HomeCinemaDbContext : DbContext, IHomeCinemaDbContext
    {
        public HomeCinemaDbContext(DbContextOptions<HomeCinemaDbContext> options)
            : base(options)
        { }

        public HomeCinemaDbContext()
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

        public override int SaveChanges()
        {
            SetAuditableProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetAuditableProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditableProperties()
        {
            const string Username = "sub";
            const string UserId = "userId";
            foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    string userName = "HOMECINEMA_USER";
                    DateTime dateTimeNow = DateTime.Now;

                    /*if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                    {
                        var principal = (ClaimsPrincipal)Thread.CurrentPrincipal;
                        var claim = principal.Claims.Where(p => p.Type == Username).FirstOrDefault();
                        userName = claim == null ? userName : claim.Value;
                    }*/

                    // modify updated date and updated by column for 
                    // adds of updates.
                    auditableEntity.Entity.LastModifiedDate = dateTimeNow;
                    auditableEntity.Entity.LastModifiedBy = userName;

                    // populate created date and created by columns for
                    // newly added record.
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedDate = dateTimeNow;
                        auditableEntity.Entity.CreatedBy = userName;
                    }
                    else
                    {
                        // we also want to make sure that code is not inadvertly
                        // modifying created date and created by columns
                        //https://stackoverflow.com/a/44422124/3536123
                        if (auditableEntity.Property(p => p.CreatedDate).IsModified)
                            auditableEntity.Property(p => p.CreatedDate).IsModified = false;

                        if (auditableEntity.Property(p => p.CreatedBy).IsModified)
                            auditableEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }
            }
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
