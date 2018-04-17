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
        public DateTime? RetrunedDate { get; set; }
        public RentalStatus Status { get; set; }
    }
}
