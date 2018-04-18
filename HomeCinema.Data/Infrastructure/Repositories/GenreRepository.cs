using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Infrastructure.Repositories
{
    public class GenreRepository : EntityBaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IHomeCinemaDbContext context) : base(context)
        {
        }
    }
}
