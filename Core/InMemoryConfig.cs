using Core.Extensions;
using IdentityModel;
using IdentityServer4.Models;

namespace Core
{
    public static class InMemoryConfig
    {
        private const string ClientSecret = "SOME_SUPER_STRONG_CLIENT_SECRET";
        private const string ScopeSecret = "SOME_SUPER_STRONG_SCOPE_SECRET";

        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope(Permissions.Read.ToFullString()),
            new ApiScope(Permissions.Write.ToFullString())
        };

        public static IEnumerable<Client> Clients => new[]
        {
            new Client()
            {
                ClientId = "Weather",
                ClientName = "Weather API",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret(ClientSecret.ToSha256()) },
                AllowedScopes = { Permissions.Read.ToFullString() }
            }
        };

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("weatherapi")
            {
                Scopes = new List<string> { Permissions.Read.ToFullString(), Permissions.Write.ToFullString() },
                ApiSecrets = new List<Secret> { new Secret(ScopeSecret.ToSha256()) },
                UserClaims = new List<string> { Roles.Admin.ToString(), Roles.Developer.ToString() }
            }
        };
    }
}
