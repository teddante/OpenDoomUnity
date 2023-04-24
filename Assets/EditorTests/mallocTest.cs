using System;
using System.IO;
using NUnit.Framework;
using FILE = System.IO.FileStream;

using static Assets.Scripts.Global;

namespace Assets.EditorTests
{
    [TestFixture]
    public class mallocTest
    {
        [Test]
        public void Malloc_ValidSize_ReturnsNonNull()
        {
            // Arrange
            uint size = 10;

            // Act
            byte[] result = malloc(size);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Malloc_NegativeSize_ReturnsNull()
        {
            // Arrange
            uint size = 0;

            // Act
            byte[] result = malloc(size);

            // Assert
            Assert.IsNull(result);
        }
    }
}
