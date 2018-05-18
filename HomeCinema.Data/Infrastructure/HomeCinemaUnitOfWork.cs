using HomeCinema.Core;
using HomeCinema.Data.Infrastructure.Contracts;
using HomeCinema.Data.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure
{
    public class HomeCinemaUnitOfWork : IHomeCinemaUnitOfWork
    {
        private volatile IHomeCinemaDbContext context;
        private volatile IUserRepository userRepository;
        private volatile IRoleRepository roleRepository;
        private volatile IUserRoleRepository userRoleRepository;
        private volatile ICustomerRepository customerRepository;
        private volatile IErrorRepository errorRepository;
        private volatile IGenreRepository genreRepository;
        private volatile IMovieRepository movieRepository;
        private volatile IRentalRepository rentalRepository;
        private volatile IStockRepository stockRepository;


        public HomeCinemaUnitOfWork(IHomeCinemaDbContext context)
        {
            Guard.ArgumentIsNotNull(context, $"{nameof(context)} connot be null");
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(context);
                return roleRepository;
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (userRoleRepository == null)
                    userRoleRepository = new UserRoleRepository(context);
                return userRoleRepository;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(context);
                return customerRepository;
            }
        }

        public IErrorRepository ErrorRepository
        {
            get
            {
                if (errorRepository == null)
                    errorRepository = new ErrorRepository(context);
                return errorRepository;
            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(context);
                return genreRepository;
            }
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                if (movieRepository == null)
                    movieRepository = new MovieRepository(context);
                return movieRepository;
            }
        }

        public IRentalRepository RentalRepository
        {
            get
            {
                if (rentalRepository == null)
                    rentalRepository = new RentalRepository(context);
                return rentalRepository;
            }
        }

        public IStockRepository StockRepository
        {
            get
            {
                if (stockRepository == null)
                    stockRepository = new StockRepository(context);
                return stockRepository;
            }
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
