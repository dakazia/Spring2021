using System;

namespace FileSystem
{
    public class SearchInterruptEventArgs : EventArgs
    {
        public bool ShouldAbortSearch { get; set; }
        public bool ShouldSkipItem { get; set; }
        public string Name { get; set; }

        public SearchInterruptEventArgs(string name)
        {
            Name = name;
        }
    }
}
