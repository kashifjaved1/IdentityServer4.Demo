using ApiConsumer.Services;

namespace ApiConsumer.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7067/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });

            // Bind TokenServiceSettings from appsettings.json to a C# class
            services.Configure<TokenServiceSettings>(configuration.GetSection("TokenServiceSettings"));

            // Register services for the HttpClient, TokenService, etc.
            services
                .AddHttpClient<ITokenService, TokenService>()
                .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7138/");
            });


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
