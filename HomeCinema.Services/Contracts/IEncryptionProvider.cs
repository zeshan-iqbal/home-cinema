using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeCinema.Services.Contracts
{
    public interface IEncryptionProvider
    {
        bool TryEncryptString(string plain, out string output);
        bool TryDecryptString(string cipher, out string output);

        byte[] Encrypt(byte[] plain);
        void Encrypt(Stream plain, Stream output);

        byte[] Decrypt(byte[] cipher);
        void Decrypt(Stream cipher, Stream output);
    }
}
