namespace ApiConsumer.Services;

public interface ITokenService
{
    Task<string> GetAccessTokenAsync();
}