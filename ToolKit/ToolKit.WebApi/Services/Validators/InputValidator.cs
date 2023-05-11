using System.Text;
using System.Text.RegularExpressions;
using ToolKit.WebApi.Services.Interfaces;

namespace ToolKit.WebApi.Services.Validators;

public class InputValidator : IInputValidator
{
    private readonly ILogger _logger;

    public InputValidator(ILogger<InputValidator> logger)
    {
        _logger = logger;
    }

    public bool ValidateBase64Input(string base64Input)
    {
        if (string.IsNullOrWhiteSpace(base64Input))
        {
            _logger.LogWarning("Input {Base64Input} string is null, empty, or whitespace-only.", base64Input);
            return false;
        }

        string pattern = "^[a-zA-Z0-9+/]*={0,2}$";
        
        if(Regex.IsMatch(base64Input, pattern))
        {
            _logger.LogInformation("Base64 input {Base64Input} is valid.", base64Input);
            return true;
        }

        _logger.LogWarning("Base64 input {Base64Input} is invalid.", base64Input);
        return false;
        
    }

    public bool ValidateStringInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            _logger.LogWarning("Input {StringInput} string is null, empty, or whitespace-only.", input);
            return false;
        }

        _logger.LogInformation("Input {StringInput} is valid.", input);
        return true;
    }
    
    public bool ValidateUTF8BytesInput(byte[] bytes)
    {
        if (bytes.Length == 0 || bytes == null)
        {
            _logger.LogError("Input array {bytes} is null or empty", bytes);
            return false;
        }

        try
        {
            int charCount = Encoding.UTF8.GetCharCount(bytes);
            char[] chars = new char[charCount];
            int charsDecodedCount = Encoding.UTF8.GetChars(bytes, 0, bytes.Length, chars, 0);

            return charsDecodedCount == charCount;
        }
        catch (DecoderFallbackException ex)
        {
            _logger.LogError(ex, "Input bytes could not be decoded as UTF-8.");
            return false;
        }
    }
}