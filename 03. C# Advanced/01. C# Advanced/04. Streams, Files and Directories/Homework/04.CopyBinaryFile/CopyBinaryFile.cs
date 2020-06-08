using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            const int DEF_SIZE = 4096;
            using FileStream reader = new FileStream("copyMe.png", FileMode.Open);
            using FileStream saveStream = new FileStream("result.png", FileMode.Create);

            byte[] buffer = new byte[DEF_SIZE];

            while (reader.CanRead)
            {
                int readBytes = reader.Read(buffer, 0, buffer.Length);
                if (readBytes == 0)
                {
                    break;
                }
                saveStream.Write(buffer);
            }
        }
    }
}
