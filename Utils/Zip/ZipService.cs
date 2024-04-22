using System.IO.Compression;

namespace ChatServer.Utils.Zip
{
    public class ZipService
    {
        public byte[] Compress(byte[] data, int offset, int length)
        {
            using MemoryStream outputStream = new();
            using DeflateStream compressordStream = new(outputStream, CompressionMode.Compress);
            compressordStream.Write(data, offset, length);
            compressordStream.Flush();
            return outputStream.ToArray();
        }

        public byte[] DeCompress(byte[] data)
        {
            using MemoryStream outputStream = new();
            using MemoryStream compressedStream = new(data);
            using DeflateStream inputStream = new(compressedStream, CompressionMode.Decompress);
            inputStream.CopyTo(outputStream);
            outputStream.Position = 0;
            return outputStream.ToArray();
        }
    }
}
