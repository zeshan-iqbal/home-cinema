using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeCinema.Services.Contracts
{
    public interface IEncryptionService
    {
        string CreateSalt();
        string EncryptPassword(string password);
        string EncryptPassword(string password, string salt);
    }
}
