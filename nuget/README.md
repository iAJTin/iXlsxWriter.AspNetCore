# What is iXlsxWriter.AspNetCore?

**iXlsxWriter.AspNet**, extends [iXlsxWriter](https://github.com/iAJTin/iXlsxWriter) to work in **AspNetCore** projects, contains extension methods to download **XlsxInput** instances as well as **OutputResult**, facilitating its use in this environment.

I hope it helps someone. :smirk:

## Usage

### Samples

#### Sample 1 - Shows the use by extension method

##### Program.cs

- Adds **HttpContextAccessor** service.

```csharp
...
...
builder.Services.AddHttpContextAccessor();
...
...
```

##### Controller

```csharp
[ApiController]
[Route("[controller]")]
public class XlsxByExtensionController : ControllerBase
{
    private readonly IHttpContextAccessor _context;


    public XlsxByExtensionController.cs(IHttpContextAccessor context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task GetAsync()
    {
        var downloadResult = await (await Sample01.GenerateAsync()).DownloadAsync(context: _context.HttpContext).ConfigureAwait(false);
        if (!downloadResult.Success)
        {
            // Handle error(s)
        }
    }
}
```

#### Sample 2 - Shows the use by DownloadAsync action

##### Program.cs

- Adds **HttpContextAccessor** service.

```csharp
...
...
builder.Services.AddHttpContextAccessor();
...
...
```

##### Controller

```csharp   
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
```

# Changes

For more information, please visit the next link [CHANGELOG](https://github.com/iAJTin/iXlsxWriter.AspNetCore/blob/master/CHANGELOG.md)
