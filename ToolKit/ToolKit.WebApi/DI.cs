using ToolKit.WebApi.Services.Converters;
using ToolKit.WebApi.Services.Interfaces;
using ToolKit.WebApi.Services.Validators;

namespace ToolKit.WebApi.Services.DI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddScoped<IInputValidator, InputValidator>()
                       .AddScoped<IBase64Encoder, Base64Encoder>()
                       .AddScoped<IBase64Decoder, Base64Decoder>()
        ;
    }
}
