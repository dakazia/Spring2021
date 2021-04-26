using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystem
{
    public sealed class FileSystemVisitor
    {
        private  int _node = 2; // number of inner catalogs
        private readonly Predicate<FileSystemItem> _filters;
        public event EventHandler<SearchStatusEventArgs> Start;
        public event EventHandler<SearchStatusEventArgs> Finish;
        public event EventHandler<SearchStatusEventArgs> FileFound;
        public event EventHandler<SearchStatusEventArgs> DirectoryFound;
        public event EventHandler<SearchStatusEventArgs> FilteredFileFound;

        public FileSystemVisitor(Predicate<FileSystemItem> filters)
        {
            _filters = filters;
        }

        public IEnumerable<string> FileSystemScan(string path)
        {
            ShowStartEvent("Scan started.");
        
            foreach (var directory in GetFileSystemItem(GetElements, path))
            {
                yield return directory;

            }
            
            ShowFinishEvent("Scan finished.");
        }

        private IEnumerable<string> GetFileSystemItem(Func<string, IEnumerable<string>> getItemMethod, string path)
        {

            foreach (var searchResult in getItemMethod(path))
            {
                FileSystemItem item = new FileSystemItem();
                FileAttributes attributes = File.GetAttributes(searchResult);

                if (!attributes.HasFlag(FileAttributes.Directory))
                {
                    item.Name = Path.GetFileName(searchResult);
                    item.Type = File.ReadAllText(searchResult);

                    if (_filters is null)
                    {
                        ShowFileFoundEvent(("File found:"));
                        yield return searchResult;
                    }
                    else if (_filters(item))
                    {
                        ShowFilteredFileFoundEvent($"Filtered file found:");
                        yield return searchResult;
                    }
                }
                else if (_filters is null)
                {
                    ShowDirectoryFoundEvent($"Directory found:");
                    yield return searchResult;
                }
            }
        }

        private IEnumerable<string> GetElements(string path)
        {
            var files = Directory.EnumerateFiles(path, "*.*");

            foreach (var file in files)
            {
                yield return file;
            }

            var directories = Directory.EnumerateDirectories(path, "*.*");

            foreach (var directory in directories)
            {
                yield return directory;
                if (_node > 0)
                {
                    foreach (var item in GetElements(directory))
                    {
                        _node--;
                        yield return item;
                    }
                }
            }
        }

       private void ShowStartEvent(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"'{nameof(message)}' cannot be null or whitespace", nameof(message));
            }

            var args = new SearchStatusEventArgs()
            {
                ItemName = message,
                FoundTime = DateTime.Now
            };
            OnStart(args);
        }


        private void ShowFinishEvent(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"'{nameof(message)}' cannot be null or whitespace", nameof(message));
            }

            var args = new SearchStatusEventArgs()
            {
                ItemName = message,
                FoundTime = DateTime.Now
            };
            OnFinish(args);
        }


        private void ShowDirectoryFoundEvent(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"'{nameof(message)}' cannot be null or whitespace", nameof(message));
            }

            var args = new SearchStatusEventArgs()
            {
                ItemName = message,
                FoundTime = DateTime.Now
            };
            OnDirectoryFound(args);
        }

        private void ShowFileFoundEvent(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"'{nameof(message)}' cannot be null or whitespace", nameof(message));
            }

            var args = new SearchStatusEventArgs()
            {
                ItemName = message,
                FoundTime = DateTime.Now
            };
            OnFileFound(args);
        }

        private void ShowFilteredFileFoundEvent(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"'{nameof(message)}' cannot be null or whitespace", nameof(message));
            }

            var args = new SearchStatusEventArgs()
            {
                ItemName = message,
                FoundTime = DateTime.Now
            };
            OnFilteredFileFound(args);
        }
        private void OnStart(SearchStatusEventArgs e)
        {
            EventHandler<SearchStatusEventArgs> handler = Start;
            handler?.Invoke(this, e);
        }

        private void OnFinish(SearchStatusEventArgs e)
        {
            EventHandler<SearchStatusEventArgs> handler = Finish;
            handler?.Invoke(this, e);
        }

        private void OnDirectoryFound(SearchStatusEventArgs e)
        {
            EventHandler<SearchStatusEventArgs> handler = DirectoryFound;
            handler?.Invoke(this, e);
        }

        private void OnFileFound(SearchStatusEventArgs e)
        {
            EventHandler<SearchStatusEventArgs> handler = FileFound;
            handler?.Invoke(this, e);
        }

        private void OnFilteredFileFound(SearchStatusEventArgs e)
        {
            EventHandler<SearchStatusEventArgs> handler = FilteredFileFound;
            handler?.Invoke(this, e);
        }
    }
}
