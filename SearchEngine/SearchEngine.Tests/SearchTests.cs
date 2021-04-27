using System.IO;
using FileSystem;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace SearchEngine.Tests
{

    public class SearchTests
    {
        private Mock<DirectoryInfo> _fileSystemInfo;
        private FileSystemVisitor _visitor;
        FileInfo[] _files;
        DirectoryInfo[] _directories;
        string _path;


        [SetUp]
        public void Setup()
        {
            _fileSystemInfo = new Mock<DirectoryInfo>();
            _directories = new DirectoryInfo[3];
            _files = new FileInfo[] { };
            _fileSystemInfo
                .Setup(item => item.GetDirectories())
                .Returns(_directories);
            _fileSystemInfo
                .Setup(item=> item.GetFiles())

        }
    }
}
