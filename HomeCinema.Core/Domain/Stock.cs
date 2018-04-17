using HomeCinema.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Domain
{
    public class Stock: BaseEntity
    {
        public Stock()
        {
            Rentals = new List<Rental>();
        }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public Guid UniqueKey { get; set; }
        public bool IsAvailable { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
