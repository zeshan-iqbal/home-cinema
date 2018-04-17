using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Data
{
    public interface IAuditable: ICreationAuditable, IModificationAuditable
    {
    }
}
