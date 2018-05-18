using HomeCinema.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace HomeCinema.Services.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string CreateSalt()
        {
            return BCrypt.BCryptHelper.GenerateSalt(BCrypt.SaltRevision.Revision2B);
        }

        public string EncryptPassword(string password)
        {
            return EncryptPassword(password, CreateSalt());
        }

        public string EncryptPassword(string password, string salt)
        {
            return BCrypt.BCryptHelper.HashPassword(password, salt);
        }
    }
}
