using IdentityServer4.Models;

namespace Core
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("inventoryapi.read"),
            new ApiScope("inventoryapi.write")
        };

        public static IEnumerable<Client> Clients => new[]
        {
            new Client // E2E client
            {
                ClientId = "Inventory",
                ClientName = "Inventory Api",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // It is used by clients to obtain an access token outside of the context of a user
                ClientSecrets = { new Secret("MyClientSecret".Sha256())}, // Client is aware of this value
                AllowedScopes = { "inventoryapi.read", "inventoryapi.write" }
            }
        };

        public static IEnumerable<ApiResource> ApiResources => new[] // This is what we try to protect
        {
            new ApiResource("inventoryapi")
            {
                Scopes = new List<string> { "inventoryapi.read", "inventoryapi.write" },
                ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) }, // Client is aware of this value
                UserClaims = new List<string> {"role"}
            }
        };
    }
}
