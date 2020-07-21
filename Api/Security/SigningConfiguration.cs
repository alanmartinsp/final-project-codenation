using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Api.Security
{
    public class SigningConfiguration
    {
        public SecurityKey key { get; }
        public SigningCredentials signingCredentials { get; set; }

        public SigningConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
