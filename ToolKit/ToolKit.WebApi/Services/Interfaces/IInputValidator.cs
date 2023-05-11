namespace ToolKit.WebApi.Services.Interfaces;

public interface IInputValidator
{
    bool ValidateBase64Input(string base64Input);
    bool ValidateStringInput(string input);
    bool ValidateUTF8BytesInput(byte[] bytes);
}