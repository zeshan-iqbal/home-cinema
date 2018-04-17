using HomeCinema.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Domain
{
    public class Genre: BaseEntity
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }

        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
