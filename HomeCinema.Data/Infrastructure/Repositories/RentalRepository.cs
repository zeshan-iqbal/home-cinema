﻿using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Infrastructure.Repositories
{
    public class RentalRepository : EntityBaseRepository<Rental>, IRentalRepository
    {
        public RentalRepository(IHomeCinemaDbContext context) : base(context)
        {
        }
    }
}