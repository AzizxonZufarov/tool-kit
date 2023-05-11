using System.Text;
using ToolKit.WebApi.Services.Interfaces;

namespace ToolKit.WebApi.Services.Converters;

public class Base64Decoder : IBase64Decoder
{
    private readonly ILogger<Base64Decoder> _logger;

    public Base64Decoder(ILogger<Base64Decoder> logger)
    {
        _logger = logger;
    }

    public string DecodeToString(byte[] bytes)
    {
        try
        {
            string base64 = Encoding.UTF8.GetString(bytes);
            byte[] base64bytes = Convert.FromBase64String(base64);
            string result = Encoding.UTF8.GetString(base64bytes);
            
            _logger.LogInformation("Base64ToString conversion successful. Input: {Bytes}, Output: {Result}", bytes, result);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Base64ToString conversion failed. Input: {Bytes}", bytes);
            throw new ArgumentException("Error Base64ToString conversion", nameof(bytes));
        }
    }
}