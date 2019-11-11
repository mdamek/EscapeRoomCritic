using System.IO;
using Microsoft.Extensions.Configuration;

namespace EscapeRoomCritic.Core.Services
{
    public class SecretProvider : ISecretProvider
    {
        public string GetSecret()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "\\..\\EscapeRoomCritic.Core\\IdentityConfiguration\\secret.json");

            var configuration = builder.Build();
            return configuration["IdentitySecret:Secret"];
        }
    }
}
