using System;
using System.IO;
using NUnit.Framework;
using FILE = System.IO.FileStream;

using static Assets.Scripts.Global;

namespace Assets.EditorTests
{
    [TestFixture]
    public class fwriteTest
    {
        [Test]
        public void FWrite_ZeroSize_ZeroCount_WritesNothing()
        {
            using var stream = new MemoryStream();
            var buffer = new byte[10];
            var bytesWritten = fwrite(buffer, 0, 0, stream);

            Assert.AreEqual(0, bytesWritten);
            Assert.AreEqual(0, stream.Length);
        }

        [Test]
        public void FWrite_NonZeroSize_ZeroCount_WritesNothing()
        {
            using var stream = new MemoryStream();
            var buffer = new byte[10];
            var bytesWritten = fwrite(buffer, 5, 0, stream);

            Assert.AreEqual(0, bytesWritten);
            Assert.AreEqual(0, stream.Length);
        }

        [Test]
        public void FWrite_ZeroSize_NonZeroCount_WritesNothing()
        {
            using var stream = new MemoryStream();
            var buffer = new byte[10];
            var bytesWritten = fwrite(buffer, 0, 3, stream);

            Assert.AreEqual(0, bytesWritten);
            Assert.AreEqual(0, stream.Length);
        }

        [Test]
        public void FWrite_NonZeroSize_NonZeroCount_WritesExpectedData()
        {
            using var stream = new MemoryStream();
            var buffer = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var bytesWritten = fwrite(buffer, 2, 3, stream);

            Assert.AreEqual(6, bytesWritten);
            Assert.AreEqual(6, stream.Length);

            var expectedData = new byte[] { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AreEqual(expectedData, stream.ToArray());
        }

        [Test]
        public void FWrite_ThrowsException_ReturnsPartialBytesWritten()
        {
            var faultyStream = new FaultyStream();
            var buffer = new byte[10];
            var bytesWritten = fwrite(buffer, 2, 5, faultyStream);

            Assert.AreEqual(2, bytesWritten);
        }

        [Test]
        public void FWrite_WritesToFile_Success()
        {
            // Create a temporary file
            var tempFilePath = Path.GetTempFileName();
            try
            {
                using (var fileStream = File.Open(tempFilePath, FileMode.Open))
                {
                    var buffer = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                    var bytesWritten = fwrite(buffer, 2, 3, fileStream);
                    Assert.AreEqual(6, bytesWritten);
                }

                // Check the written data in the file
                var expectedData = new byte[] { 1, 2, 3, 4, 5, 6 };
                var writtenData = File.ReadAllBytes(tempFilePath);
                CollectionAssert.AreEqual(expectedData, writtenData);
            }
            finally
            {
                // Clean up the temporary file
                File.Delete(tempFilePath);
            }
        }

        private class FaultyStream : MemoryStream
        {
            private int _bytesWritten;
            private int _maxBytesBeforeError = 2;

            public override void Write(byte[] buffer, int offset, int count)
            {
                if (_bytesWritten + count > _maxBytesBeforeError)
                {
                    var remainingBytes = _maxBytesBeforeError - _bytesWritten;
                    base.Write(buffer, offset, remainingBytes);
                    _bytesWritten += remainingBytes;
                    throw new IOException("An error occurred while writing to the stream.");
                }

                base.Write(buffer, offset, count);
                _bytesWritten += count;
            }
        }
    }
}
