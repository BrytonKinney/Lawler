namespace lawler.hook;

internal class Program
{
    private static Parser _parser = new Parser();
    private static async Task<int> Main(string[] args)
    {
        var document = await _parser.LoadDocumentAsync(@"C:\Users\bryto\source\repos\lawler\statutes\ch1.html");
        return 0;
    }
}