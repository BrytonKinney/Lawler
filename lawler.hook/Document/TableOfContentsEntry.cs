using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lawler.hook.Document
{
    public class TableOfContentsEntry
    {
        public string DataPath { get; set; }
        public string References { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public TableOfContentsEntry(string dataPath, string references, string title, string text)
        {
            DataPath = dataPath;
            References = references;
            Title = title;
            Text = text;
        }
    }
}
