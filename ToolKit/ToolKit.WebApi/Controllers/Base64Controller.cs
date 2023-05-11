using Microsoft.AspNetCore.Mvc;
using ToolKit.WebApi.DTO;
using ToolKit.WebApi.Services.Interfaces;

namespace ToolKit.WebApi.Controllers;

[ApiController]
[Route("api/base64")]
public class Base64Controller : Controller
{
    private readonly IInputValidator _validator;
    private readonly IBase64Encoder _encoder;
    private readonly IBase64Decoder _decoder;

    public Base64Controller(IInputValidator validator, IBase64Encoder encoder, IBase64Decoder decoder)
    {
        _validator = validator;
        _encoder = encoder;
        _decoder = decoder;
    }

    [HttpPost("encode")]
    public async Task<IActionResult> EncodeFromString()
    {
        try
        {
            var bytes = await ReadRequestContent(HttpContext.Request);

            if (_validator.ValidateUTF8BytesInput(bytes))
            {
                var result = _encoder.EncodeFromString(bytes);
                return Ok(new SuccessfullResponse(result));
            }

            throw new ArgumentException("Bytes input is invalid");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new BadRequestResponse(ex.Message));
        }
        catch (NotSupportedException)
        {
            return StatusCode((int) System.Net.HttpStatusCode.MethodNotAllowed);
        }
    }

    [HttpPost("decode")]
    public async Task<IActionResult> DecodeToString()
    {
        try
        {
            var bytes = await ReadRequestContent(HttpContext.Request);

            if (_validator.ValidateUTF8BytesInput(bytes))
            {
                var result = _decoder.DecodeToString(bytes);
                return Ok(new SuccessfullResponse(result));
            }

            throw new ArgumentException("Bytes input is invalid");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new BadRequestResponse(ex.Message));
        }
        catch (NotSupportedException)
        {
            return StatusCode((int)System.Net.HttpStatusCode.MethodNotAllowed);
        }
    }

    /// <exception cref="NotSupportedException"/>
    static async Task<byte[]> ReadRequestContent(HttpRequest request)
    {
        const string requiredContentType = "application/octet-stream";

        var currentContentType = request.ContentType ?? string.Empty;

        if (string.Equals(currentContentType, requiredContentType, StringComparison.OrdinalIgnoreCase) == false)
        {
            throw new NotSupportedException();
        }

        await using var stream = new MemoryStream();
        await request.Body.CopyToAsync(stream);

        return stream.ToArray();
    }
}
