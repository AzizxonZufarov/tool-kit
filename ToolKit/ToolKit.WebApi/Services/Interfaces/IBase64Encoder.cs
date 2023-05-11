namespace ToolKit.WebApi.Services.Interfaces;

public interface IBase64Encoder
{
    string EncodeFromString(byte[] bytes);
}