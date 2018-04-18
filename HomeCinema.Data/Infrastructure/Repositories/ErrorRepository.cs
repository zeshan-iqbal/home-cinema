using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Infrastructure.Repositories
{
    public class ErrorRepository : EntityBaseRepository<Error>, IErrorRepository
    {
        public ErrorRepository(IHomeCinemaDbContext context) : base(context)
        {
        }
    }
}
