namespace lawler.hook.Document;

public class TableOfContents
{
    private readonly IList<TableOfContentsEntry> _entries = new List<TableOfContentsEntry>();
    public IEnumerable<TableOfContentsEntry> Entries => _entries;

    public void AddEntry(string dataPath, string references, string title, string text)
    {
        _entries.Add(new TableOfContentsEntry(dataPath, references, title, text));
    }
}