namespace ToolKit.WebApi.DTO;

public class SuccessfullResponse
{
    public string Result { get; }

    public SuccessfullResponse(string result)
    {
        Result = result;
    }
}