using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PiedPiper
{
  public delegate byte[] StreamTransferBlockHandler(byte[] body, string arg);
  /// <summary>
  /// Передача данных между потоками
  /// </summary>
  public class StreamTransfer
  {
    /// <summary>
    /// Обработка блока данных при передаче
    /// </summary>
    public StreamTransferBlockHandler ProcessBlock;
    /// <summary>
    /// Размер передаваемого блока (байт)
    /// </summary>
    public int BlockSize = 16384;
    /// <summary>
    /// Параметры для функции обработки блока
    /// </summary>
    public string ProcessBlockArgs;
    /// <summary>
    /// Передача данных между потоками
    /// </summary>
    /// <param name="source">Поток источник</param>
    /// <param name="destination">Поток приемник</param>
    /// <returns>Количество переданных данных (байт)</returns>
    public int Transfer(Stream source, Stream destination)
    {
      int count = 0;
      if (!source.CanRead)
        throw new Exception("Исходящий поток недоступен для чтения");
      int length;
      byte[] buffer = new byte[BlockSize];
      length = BlockSize;
      while (length == BlockSize && (length = source.Read(buffer, 0, BlockSize)) != 0)
      {
        if (length < BlockSize)
          Array.Resize<byte>(ref buffer, length);
        if (ProcessBlock != null)
          buffer = ProcessBlock(buffer, ProcessBlockArgs);
        destination.Write(buffer, 0, buffer.Length);
        count += buffer.Length;
      }
      destination.Flush();
      return count;
    }
  }
}
