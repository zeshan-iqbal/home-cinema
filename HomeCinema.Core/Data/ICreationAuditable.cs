using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Data
{
    public interface ICreationAuditable
    {
        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
    }
}
