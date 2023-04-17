using System;
using System.IO;
using NUnit.Framework;
using FILE = System.IO.FileStream;

using static Assets.Scripts.Global;

namespace Assets.EditorTests
{
    [TestFixture]
    public class fcloseTest
    {
        private string testFile;

        [SetUp]
        public void SetUp()
        {
            testFile = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        [Test]
        public void Fclose_ClosedStream_ReturnsZero()
        {
            using var stream = new FILE(testFile, FileMode.Open, FileAccess.Read);
            int result = fclose(stream);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Fclose_NullStream_ReturnsMinusOne()
        {
            int result = fclose(null);
            Assert.AreEqual(-1, result);
        }
    }
}
