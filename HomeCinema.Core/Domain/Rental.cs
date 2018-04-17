using HomeCinema.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Domain
{
    public enum RentalStatus { Borrowed, Returned }
    public class Rental : BaseEntity
    {
        public int CustomerId { get; set; }
        public int StockId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public RentalStatus Status { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
