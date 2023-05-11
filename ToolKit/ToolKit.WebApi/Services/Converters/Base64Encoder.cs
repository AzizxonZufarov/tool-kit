using ToolKit.WebApi.Services.Interfaces;

namespace ToolKit.WebApi.Services.Converters;

public class Base64Encoder : IBase64Encoder
{
    private readonly ILogger<Base64Encoder> _logger;

    public Base64Encoder(ILogger<Base64Encoder> logger)
    {
        _logger = logger;
    }
    
    // Check bytes before convert
    // Why?
    // Incoming bytes can be null, array can be empty. It's ArgumentException group
    // But, in other cases we can use bytes as is...
    public string EncodeFromString(byte[] bytes)
    {
        try
        {
            string base64 = Convert.ToBase64String(bytes);
            _logger.LogInformation("StringToBase64 encoding successful. Input: {Bytes}, Output: {Base64}", bytes, base64);
            return base64;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "StringToBase64 encoding failed. Input: {Bytes}", bytes);
            throw new ArgumentException("Error StringToBase64 encoding", nameof(bytes));
        }
    }
    
    /*
    public string EncodeFromString(byte[] bytes)
    {
        if (bytes is null || bytes.Length == 0)
        {
            _logger.LogError(ex, "Bytes is null or empty");
            
            throw new ArgumentException(nameof(bytes));
        }
    
        try
        {
            return Convert.ToBase64String(bytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "EncodeFromString failed. Bytes: {0}", bytes);
            
            throw ex;
        }
    }
    */
}
