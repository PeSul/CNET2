using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        static string directory = @"C:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\BigFiles";

        [TestMethod]
        public void FileExists()
        {

            var files = Directory.EnumerateFiles(directory, "*.txt");

            Assert.IsTrue(files != null && files.Count() > 0);

        }

        [TestMethod]
        public void LoadBigFile()
        {
            var file = Path.Combine(directory, "word0.txt");

            var lines = File.ReadAllLines(file);

            Assert.IsTrue(lines.Any());

        }
    }
}