using Core;
using Core.Extensions;

namespace Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            const string authScheme = "Bearer";
            services
                .AddAuthentication(authScheme)
                .AddIdentityServerAuthentication(authScheme, options =>
                {
                    options.ApiName = configuration["ClientConfigurations:Name"];
                    options.Authority = configuration["ClientConfigurations:Authority"];
                });

            services.AddAuthorization(x =>
            {
                x.AddPolicy(nameof(Permissions.Read),
                    policy => policy.RequireClaim("scope", Permissions.Read.ToFullString()));
                x.AddPolicy(nameof(Permissions.Write),
                    policy => policy.RequireClaim("scope", Permissions.Read.ToFullString()));
                x.AddPolicy(nameof(Permissions.Delete),
                    policy => policy.RequireClaim("scope", Permissions.Read.ToFullString()));
            });

            services.AddControllers();
        }
    }
}
