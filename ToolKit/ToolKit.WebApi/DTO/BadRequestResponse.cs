namespace ToolKit.WebApi.DTO;

public class BadRequestResponse
{
    public string Error { get; }

    public BadRequestResponse(string error)
    {
        Error = error;
    }
}