using System.IdentityModel.Tokens.Jwt;
using Core;
using Microsoft.IdentityModel.Logging;

namespace IdentityServer.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            IdentityModelEventSource.ShowPII = true;

            services.AddIdentityServer()
                .AddInMemoryClients(InMemoryConfig.Clients)
                .AddInMemoryApiResources(InMemoryConfig.ApiResources)
                .AddInMemoryApiScopes(InMemoryConfig.ApiScopes)
                .AddDeveloperSigningCredential(); // This is for development purposes only.
        }
    }
}
