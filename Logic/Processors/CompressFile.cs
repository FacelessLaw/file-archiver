using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using zlib;

namespace PiedPiper
{
    /// <summary>
    /// Упаковка/распаковка файла
    /// </summary>
    public class CompressFile : IProcessFile
    {
        StreamTransfer transfer = new StreamTransfer();
        /// <summary>
        /// Сжатие файла
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string ProcessExecute(string fileName)
        {
            string outFile = TempNameGenerator.GenerateTempNameFromFile(fileName);
            using (FileStream outFileStream = new FileStream(outFile, FileMode.Create, FileAccess.Write))
            {
                using (ZOutputStream outZStream = new ZOutputStream(outFileStream, zlibConst.Z_BEST_COMPRESSION))
                {
                    using (FileStream inFileStream = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        transfer.Transfer(inFileStream, outZStream);
                    }
                }
            }
            return outFile;
        }
        /// <summary>
        /// Распаковка файла
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string BackProcessExecute(string fileName)
        {
            int data = 0;
            int stopByte = -1;
            string out_file = TempNameGenerator.GenerateTempNameFromFile(fileName);
            using (FileStream outFileStream = new FileStream(out_file, FileMode.Create))
            {
                using (ZInputStream inZStream = new ZInputStream(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    while (stopByte != (data = inZStream.Read()))
                    {
                        byte _dataByte = (byte)data;
                        outFileStream.WriteByte(_dataByte);
                    }
                    inZStream.Close();
                }
                outFileStream.Close();
            }
            return out_file;
        }
    }
}
