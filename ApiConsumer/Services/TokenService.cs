using Core;
using Core.Extensions;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace ApiConsumer.Services
{
    public class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenServiceSettings _settings;

        public TokenService(HttpClient httpClient, IOptions<TokenServiceSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var tokenRequest = new ClientCredentialsTokenRequest
            {
                Address = $"{_httpClient.BaseAddress}{_settings.Address}",
                ClientId = _settings.ClientId,
                ClientSecret = _settings.ClientSecret,
                Scope = Permissions.Read.ToFullString()
            };

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(tokenRequest);

            if (tokenResponse.IsError)
                throw new HttpRequestException("Failed to retrieve access token");

            return tokenResponse.AccessToken;
        }
    }

}
