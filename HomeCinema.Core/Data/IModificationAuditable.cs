using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Data
{
    public interface IModificationAuditable
    {
        string LastModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
