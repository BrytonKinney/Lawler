using AngleSharp;

namespace lawler.hook;

public class Parser 
{
    AngleSharp.IConfiguration _configuration;
    IBrowsingContext _browsingCtx;

    public async Task
    public Parser() 
    {
        _configuration = Configuration.Default;
        _browsingCtx = BrowsingContext.New(_configuration);
    }
}