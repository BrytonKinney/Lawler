using AngleSharp;
using AngleSharp.Dom;
using lawler.hook.Document;

namespace lawler.hook;

public class Parser 
{
    readonly AngleSharp.IConfiguration _configuration;
    readonly IBrowsingContext _browsingCtx;

    public async Task<StatuteDocument> LoadDocumentAsync(string path)
    {
        await using var fs = new FileStream(path, FileMode.Open);
        var htmlDocument = await _browsingCtx.OpenAsync(req => req.Content(fs));
        var statuteDocument = new StatuteDocument();
        var mainDocument = htmlDocument.All.FirstOrDefault(c => c.Id != null && c.Id.Equals("document", StringComparison.CurrentCultureIgnoreCase));
        string statuteTitle = mainDocument.Children.FirstOrDefault(s => s.ClassList.Contains("qs_title_chapter_")).Children.FirstOrDefault().TextContent.Trim('\n', '\r');
        statuteDocument.Title = statuteTitle;
        var tocEntries = mainDocument.Children.Where(c => c.ClassList.Contains("qs_toc_entry_"));
        foreach (var tocEntry in tocEntries)
        {
            var dataPath = tocEntry.Attributes.GetNamedItem("data-path").Value;
            var references = tocEntry.Children.FirstOrDefault(a => a.TagName.Equals("a", StringComparison.CurrentCultureIgnoreCase)).Attributes.GetNamedItem("rel").Value;
            var title = tocEntry.Children.FirstOrDefault(a => a.TagName.Equals("a", StringComparison.CurrentCultureIgnoreCase)).TextContent;
            statuteDocument.TableOfContents.AddEntry(dataPath, references, title, tocEntry.TextContent);
        }
        return statuteDocument;
    }

    public Parser() 
    {
        _configuration = Configuration.Default;
        _browsingCtx = BrowsingContext.New(_configuration);
    }
}