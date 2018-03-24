using System;
using System.Security;

namespace Onero.Helper.License
{
    public class LicenseHelper
    {
        public License GenerateNewLicense(string firstname, string lastname, string email, string organisation)
        {
            string serialNumber = Generate(firstname, lastname, email, organisation);

            return new License
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Organization = organisation,
                Created = DateTime.Today,
                SerialNumber = serialNumber
            };
        }

        private string Generate(string firstname, string lastname, string email, string organisation)
        {
            string code = null;

            string value = $"{firstname}|{lastname}|{email}|{organisation}";

            using (var password = GetPassword())
            {
                var encryptor = new Encryptor(password);

                code = encryptor.Encrypt(value);
            }

            return code?.TrimEnd('=');
        }
        
        private static SecureString GetPassword()
        {
            var password = new SecureString();

            password.AppendChar((char)80); // P
            password.AppendChar((char)97); // a
            password.AppendChar((char)115); // s
            password.AppendChar((char)115); // s
            password.AppendChar((char)119); // w
            password.AppendChar((char)111); // o
            password.AppendChar((char)114); // r
            password.AppendChar((char)100); // d
            password.AppendChar((char)49); // 1

            return password;
        }
    }
}
