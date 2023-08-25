<p align="center">
  <img src="https://github.com/iAJTin/iXlsxWriter.AspNetCore/blob/master/nuget/iXlsxWriter.AspNetCore.png" height="32"/>
</p>
<p align="center">
  <a href="https://github.com/iAJTin/iXlsxWriter.AspNetCore">
    <img src="https://img.shields.io/badge/iTin-iXlsxWriter.AspNetCore-green.svg?style=flat"/>
  </a>
</p>

***

# What is iXlsxWriter.AspNetCore?

**iXlsxWriter.AspNetCore**, extends [iXlsxWriter](https://github.com/iAJTin/iXlsxWriter) to work in **AspNetCore** projects, contains extension methods to download **XlsxInput** instances as well as **OutputResult**, facilitating its use in this environment.

I hope it helps someone. :smirk:

# Install via NuGet

- From nuget gallery

<table>
  <tr>
    <td>
      <a href="https://github.com/iAJTin/iXlsxWriter.AspNetCore">
        <img src="https://img.shields.io/badge/-iXlsxWriter.AspNetCore-green.svg?style=flat"/>
      </a>
    </td>
    <td>
      <a href="https://www.nuget.org/packages/iXlsxWriter.AspNetCore/">
        <img alt="NuGet Version" 
             src="https://img.shields.io/nuget/v/iXlsxWriter.AspNetCore.svg" /> 
      </a>
    </td>  
  </tr>
</table>

- From package manager console

```PM> Install-Package iXlsxWriter.AspNetCore```

# Usage

## Samples

### Sample 1 - Shows the use by extension method

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

### Sample 2 - Shows the use by DownloadAsync action

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

# Documentation

 - Please see next link [documentation]

# How can I send feedback!!!

If you have found **iXlsxWriter.AspNetCore** useful at work or in a personal project, I would love to hear about it. If you have decided not to use **iXlsxWriter.AspNetCore**, please send me and email stating why this is so. I will use this feedback to improve **iXlsxWriter.AspNetCore** in future releases.

My email address is 

![email.png][email] 


[email]: ./assets/email.png "email"

[documentation]: ./documentation/iXlsxWriter.AspNetCore.md
