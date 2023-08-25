
using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.AspNetCore.WebApi.Code;

internal static class Sample01
{
    public static XlsxInput BuildXlsxInput()
    {
        var doc = XlsxInput.Create("Sheet1");

        doc.Insert(
            new InsertText
            {
                SheetName = "Sheet1",
                Data = "Hello world! from iXlsxWriter"
            });

        return doc;
    }


    public static async Task<OutputResult> GenerateAsync(CancellationToken cancellationToken = default) => 
        await BuildXlsxInput().CreateResultAsync(cancellationToken: cancellationToken);
}
