using HomeCinema.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Domain
{
    public class Error: BaseEntity
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
