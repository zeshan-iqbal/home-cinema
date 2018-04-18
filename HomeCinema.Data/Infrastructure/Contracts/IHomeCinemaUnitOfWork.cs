using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure.Contracts
{
    public interface IHomeCinemaUnitOfWork
    {
        Task CommitAsync();
    }
}
