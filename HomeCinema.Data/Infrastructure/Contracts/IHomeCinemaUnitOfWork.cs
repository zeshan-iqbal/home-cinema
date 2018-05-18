using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure.Contracts
{
    public interface IHomeCinemaUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IErrorRepository ErrorRepository { get; }
        IGenreRepository GenreRepository { get; }
        IMovieRepository MovieRepository { get; }
        IRentalRepository RentalRepository { get; }
        IStockRepository StockRepository { get; }

        Task CommitAsync();
    }
}
