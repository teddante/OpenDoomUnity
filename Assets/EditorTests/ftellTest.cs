using System;
using System.IO;
using NUnit.Framework;
using FILE = System.IO.FileStream;

using static Assets.Scripts.Global;

namespace Assets.EditorTests
{
    [TestFixture]
    public class ftellTest
    {
        [Test]
        public void TestFtellWithMemoryStream()
        {
            var stream = new MemoryStream();
            var position = ftell(stream);
            Assert.AreEqual(0L, position);
        }

        [Test]
        public void TestFtellWithFileStream()
        {
            var fileContent = "This is a test file.";
            var fileName = Path.GetTempFileName();
            File.WriteAllText(fileName, fileContent);
            var stream = new FileStream(fileName, FileMode.Open);
            var position = ftell(stream);
            Assert.AreEqual(0L, position);
            stream.Close();
            File.Delete(fileName);
        }

        [Test]
        public void TestFtellWithNullStream()
        {
            var position = ftell(null);
            Assert.AreEqual(-1L, position);
        }
    }
}
