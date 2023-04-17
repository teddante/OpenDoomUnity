using System;
using System.IO;
using FILE = System.IO.FileStream;

namespace Assets.Scripts
{
    public static class Global
    {
        public static void printf(string format)
        {
            Console.Write(format);
        }

        public static int fseek(Stream stream, long offset, int origin)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (origin < (int)SeekOrigin.Begin || origin > (int)SeekOrigin.End)
            {
                throw new ArgumentOutOfRangeException(nameof(origin));
            }

            if (stream.CanSeek)
            {
                try
                {
                    stream.Seek(offset, (System.IO.SeekOrigin)origin);
                    return 0;
                }
                catch (IOException)
                {
                    return -1;
                }
            }

            return -1;
        }

        public static uint fread(byte[] ptr, uint size, uint count, FILE stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "The provided FileStream cannot be null.");
            }

            if (size == 0 || count == 0) return 0;

            var bytesRead = 0;
            var bytesToRead = size * count;

            try
            {
                bytesRead = stream.Read(ptr, 0, (int)bytesToRead);
            }
            catch (Exception)
            {
                // ignored
            }

            return (uint)(bytesRead / size);
        }

        public static uint fwrite(byte[] buffer, uint size, uint count, Stream stream)
        {
            if (size == 0 || count == 0)
            {
                return 0;
            }

            var totalBytesToWrite = size * count;
            int bytesWritten;

            try
            {
                stream.Write(buffer, 0, (int)totalBytesToWrite);
                bytesWritten = (int)totalBytesToWrite;
            }
            catch (IOException)
            {
                // Calculate the number of objects written successfully
                var positionBeforeException = (int)stream.Position;
                bytesWritten = positionBeforeException;
            }

            return (uint)bytesWritten;
        }

        public static FILE fopen(string filename, string mode)
        {
            FileMode fileMode;
            FileAccess fileAccess;

            switch (mode)
            {
                case "r":
                    fileMode = FileMode.Open;
                    fileAccess = FileAccess.Read;
                    break;
                case "w":
                    fileMode = FileMode.Create;
                    fileAccess = FileAccess.Write;
                    break;
                case "a":
                    fileMode = FileMode.Append;
                    fileAccess = FileAccess.Write;
                    break;
                case "r+":
                    fileMode = FileMode.Open;
                    fileAccess = FileAccess.ReadWrite;
                    break;
                case "w+":
                    fileMode = FileMode.Create;
                    fileAccess = FileAccess.ReadWrite;
                    break;
                case "a+":
                    fileMode = FileMode.Append;
                    fileAccess = FileAccess.ReadWrite;
                    break;
                default:
                    throw new ArgumentException("Invalid mode provided");
            }

            try
            {
                return new FILE(filename, fileMode, fileAccess);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int fclose(FILE stream)
        {
            if (stream == null) return -1; // EOF is -1 in C#

            try
            {
                stream.Flush();
                stream.Dispose();

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static long ftell(Stream stream)
        {
            if (stream != null)
            {
                return stream.Position;
            }

            return -1L;
        }
    }
}