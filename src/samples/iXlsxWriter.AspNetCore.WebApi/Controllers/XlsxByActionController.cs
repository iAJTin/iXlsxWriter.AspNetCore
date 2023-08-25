
using Microsoft.AspNetCore.Mvc;

using iXlsxWriter.Abstractions.Writer.Operations.Actions;
using iXlsxWriter.AspNetCore.WebApi.Code;

namespace iXlsxWriter.AspNetCore.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class XlsxByActionController : ControllerBase
{
    private readonly IHttpContextAccessor _context;


    public XlsxByActionController(IHttpContextAccessor context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task GetAsync()
    {
        var result = await Sample01.GenerateAsync().ConfigureAwait(false);
        if (result.Success)
        {
            var safeOutputData = result.Result;
            var downloadResult = await safeOutputData.Action(new DownloadAsync { Context = _context.HttpContext }).ConfigureAwait(false);
            if (!downloadResult.Success)
            {
                // Handle error(s)
            }
        }
    }
}
