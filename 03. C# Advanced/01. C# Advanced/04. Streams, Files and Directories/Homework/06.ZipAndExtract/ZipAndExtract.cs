using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    public class ZipAndExtract
    {
        public static void Main()
        {
            string path = "copyMe.png";
            using ZipArchive zipArchive = ZipFile.Open("../../../zipArchive.zip", ZipArchiveMode.Create);
            zipArchive.CreateEntryFromFile(path, path);

        }
    }
}
