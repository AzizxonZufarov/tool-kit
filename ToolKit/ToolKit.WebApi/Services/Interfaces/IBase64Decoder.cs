namespace ToolKit.WebApi.Services.Interfaces;

public interface IBase64Decoder
{
    string DecodeToString(byte[] bytes);
}