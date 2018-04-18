using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Infrastructure.Repositories
{
    public class StockRepository : EntityBaseRepository<Stock>, IStockRepository
    {
        public StockRepository(IHomeCinemaDbContext context) : base(context)
        {
        }
    }
}
