/*
using System;

namespace ToolKit.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class HashController : ControllerBase
{
    public HashController()
    {

    }

    [HttpPost("md5")]
    public Task<IActionResult> MD5([FromBody] string value)
    {
        // Better here?

        if (string.IsNullOrEmpty(value))
        {
            return BadRequest(new { errorMessage = "Argument is null or empty" });
        }
    
        return Ok(new MD5HashResponse { MD5 = await MD5(value) });
    }
    
    Task<string> MD5(string value)
    {
        // Or here?

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException(nameof(value));    
        }

        return Task.FromResult(string.Empty);  
    }

    class MD5HashResponse
    {
        [JsonProperty("md5")] public string MD5 { get; set; }
    }
}
*/
