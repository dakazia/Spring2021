using System;

namespace FileSystem
{
    public class SearchStatusEventArgs : EventArgs
    {
        public string ItemName { get; set; }
        public DateTime FoundTime { get; set; }
    }
}
