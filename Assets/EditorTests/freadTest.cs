using System;
using System.IO;
using NUnit.Framework;
using FILE = System.IO.FileStream;

using static Assets.Scripts.Global;
using System.Text;

namespace Assets.EditorTests
{
    [TestFixture]
    public class freadTest
    {
        [Test]
        public void Fread_WithValidInput_ReturnsCorrectNumberOfElementsRead()
        {
            // Arrange
            byte[] buffer = new byte[32];
            uint size = 4;
            uint count = 5;
            string testContent = "This is a test content for the fread function.";
            string tempFilePath = Path.GetTempFileName();

            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(testContent)))
            {
                using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
                {
                    ms.CopyTo(fs);
                }
            }

            using FileStream fileStream = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);

            // Act
            uint elementsRead = fread(buffer, size, count, fileStream);

            // Assert
            Assert.AreEqual(count, elementsRead);

            // Cleanup
            fileStream.Close();
            File.Delete(tempFilePath);
        }

        [Test]
        public void Fread_WithSizeOrCountZero_ReturnsZero()
        {
            // Arrange
            byte[] buffer = new byte[32];
            uint size = 4;
            uint count = 0;
            string testContent = "This is a test content for the fread function.";
            string tempFilePath = Path.GetTempFileName();

            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(testContent)))
            {
                using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
                {
                    ms.CopyTo(fs);
                }
            }

            using FileStream fileStream = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);

            // Act
            uint elementsRead = fread(buffer, size, count, fileStream);

            // Assert
            Assert.AreEqual(0, elementsRead);

            // Cleanup
            fileStream.Close();
            File.Delete(tempFilePath);
        }

        [Test]
        public void Fread_WithInvalidFileStream_ThrowsException()
        {
            // Arrange
            byte[] buffer = new byte[32];
            uint size = 4;
            uint count = 5;
            FileStream fileStream = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => fread(buffer, size, count, fileStream));
        }
    }
}
