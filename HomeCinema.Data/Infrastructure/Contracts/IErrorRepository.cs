using HomeCinema.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Infrastructure.Contracts
{
    public interface IErrorRepository: IEntityBaseRepository<Error>
    {
    }
}
