using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EscapeRoomCritic.Core.Services;
using Microsoft.Extensions.Configuration;

namespace EscapeRoomCritic.Core.IdentityManager
{
    public class SecretProvider : ISecretProvider
    {
        public string GetSecret()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("../IdentityConfiguration/secret.json");

            var configuration = builder.Build();
            return configuration["IdentitySecret:Secret"];
        }
    }
}
