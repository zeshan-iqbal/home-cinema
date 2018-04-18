using HomeCinema.Core;
using HomeCinema.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure
{
    public class HomeCinemaUnitOfWork : IHomeCinemaUnitOfWork
    {
        private readonly IHomeCinemaDbContext context;

        public HomeCinemaUnitOfWork(IHomeCinemaDbContext context)
        {
            Guard.ArgumentIsNotNull(context, $"{nameof(context)} connot be null");
            this.context = context;
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
