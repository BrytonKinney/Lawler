namespace lawler.hook.Document;

public class StatuteDocument
{
    public string Title { get; set; }
    public TableOfContents TableOfContents { get; private set; } = new TableOfContents();
}