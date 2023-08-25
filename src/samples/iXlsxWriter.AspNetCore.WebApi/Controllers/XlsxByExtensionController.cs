
using Microsoft.AspNetCore.Mvc;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.AspNetCore.WebApi.Code;

namespace iXlsxWriter.AspNetCore.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class XlsxByExtensionController : ControllerBase
{
    private readonly IHttpContextAccessor _context;


    public XlsxByExtensionController(IHttpContextAccessor context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task Get()
    {
        var downloadResult = await (await Sample01.GenerateAsync()).DownloadAsync(context: _context.HttpContext).ConfigureAwait(false);
        if (!downloadResult.Success)
        {
            // Handle error(s)
        }
    }
}
