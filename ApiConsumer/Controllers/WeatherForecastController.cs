using ApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;

        public WeatherForecastController(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
            _tokenService = tokenService;

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            // Set the Authorization header before making the request
            await SetAuthorizationHeaderAsync();

            return await HttpClientHelper.GetAsync<IEnumerable<WeatherForecast>>(_httpClient, "WeatherForecast/Get");
        }

        private async Task SetAuthorizationHeaderAsync()
        {
            // Retrieve the access token using the TokenService
            var token = await _tokenService.GetAccessTokenAsync();

            // Set the Authorization header with the Bearer token
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
