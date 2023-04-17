using System;
using System.IO;
using NUnit.Framework;
using FILE = System.IO.FileStream;

using static Assets.Scripts.Global;

namespace Assets.EditorTests
{
    [TestFixture]
    public class fseekTest
    {
        private FileStream _fileStream;
        private MemoryStream _memoryStream;

        private string _filePath;

        [SetUp]
        public void Setup()
        {
            _memoryStream = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 });
            _filePath = Path.GetTempFileName();
            _fileStream = File.Create(_filePath);
            _fileStream.Write(new byte[] { 1, 2, 3, 4, 5 });
            _fileStream.Flush();
        }

        [TearDown]
        public void TearDown()
        {
            _memoryStream.Dispose();
            _fileStream.Dispose();
            File.Delete(_filePath);
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenStreamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => fseek(null, 0, (int)SeekOrigin.Begin));
        }

        [Test]
        public void ShouldThrowArgumentOutOfRangeExceptionWhenOriginIsInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => fseek(_memoryStream, 0, 100));
            Assert.Throws<ArgumentOutOfRangeException>(() => fseek(_fileStream, 0, 100));
        }

        [Test]
        public void ShouldReturnZeroWhenSeekingIsSuccessful()
        {
            var result = fseek(_memoryStream, 2, (int)SeekOrigin.Begin);
            Assert.AreEqual(0, result);
            Assert.AreEqual(2, _memoryStream.Position);

            result = fseek(_fileStream, 2, (int)SeekOrigin.Begin);
            Assert.AreEqual(0, result);
            Assert.AreEqual(2, _fileStream.Position);
        }

        [Test]
        public void ShouldReturnMinusOneWhenStreamCannotSeek()
        {
            _memoryStream.Dispose();
            var result = fseek(_memoryStream, 0, (int)SeekOrigin.Begin);
            Assert.AreEqual(-1, result);

            _fileStream.Dispose();
            result = fseek(_fileStream, 0, (int)SeekOrigin.Begin);
            Assert.AreEqual(-1, result);
        }
    }
}
