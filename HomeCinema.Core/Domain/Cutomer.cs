using HomeCinema.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Domain
{
    public class Cutomer : BaseEntity
    {
        public Cutomer()
        {
            Rentals = new List<Rental>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityCard { get; set; }
        public Guid UniqueKey { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string RegistrationDate { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
