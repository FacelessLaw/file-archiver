using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PiedPiper
{
  /// <summary>
  /// Заголовок архива
  /// Содержит тип архива и блоки описывающие объекты архива
  /// </summary>
  public class Header
  {
    #region Fields
    List<HeaderItem> items;
    public int Length
    {
      get
      {
        int length = sizeof(int);
        foreach (HeaderItem item in items)
          length += item.ItemLength;
        return length;
      }
    }
    #endregion

    #region Properties
    public List<HeaderItem> Items
    {
      get { return items; }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Создание пустого заголовка архива
    /// </summary>
    public Header()
    {
      items = new List<HeaderItem>();
    }
    /// <summary>
    /// Добавление объекта заголовка
    /// </summary>
    /// <param name="item"></param>
    public void Insert(HeaderItem item)
    {
      items.Add(item);
    }
    /// <summary>
    /// Перевод заголовка архива в массив байт
    /// </summary>
    /// <returns></returns>
    public byte[] ToArray()
    {
      int length = sizeof(int);
      foreach (HeaderItem item in items)
        length += item.ItemLength;
      byte[] result = new byte[length];
      int index = 0;
      //Пишем размер заголовка
      Array.Copy(BitConverter.GetBytes(length), 0, result, index, sizeof(int));
      index += sizeof(int);
      //Пишем блоки заголовка
      foreach (HeaderItem item in items)
      {
        Array.Copy(item.ToArray(), 0, result, index, item.ItemLength);
        index += item.ItemLength;
      }
      return result;
    }
    /// <summary>
    /// Распознавание заголовка архива из массива байт
    /// </summary>
    /// <param name="array"></param>
    public void Parse(byte[] array)
    {
      if (array.Length <= 0)
        throw new Exception("Невозможно распознать заголовок архива, в переданном массиве отсутствуют данные.");
      items.Clear();
      byte[] int_arr_buf = new byte[sizeof(int)];
      int int_buf;
      int length;
      using (MemoryStream ms = new MemoryStream(array))
      {
        //Читаем размер заголовка
        ms.Read(int_arr_buf, 0, sizeof(int));
        length = BitConverter.ToInt32(int_arr_buf, 0);
        if (length > ms.Length)
        {
          throw new Exception("Некорректный заголовок. Записанная длина заголовка превышает размер файла.");
        }
        while (ms.Position < ms.Length)
        {
          //Читаем размер блока заголовка
          ms.Read(int_arr_buf, 0, sizeof(int));
          int_buf = BitConverter.ToInt32(int_arr_buf, 0);
          //Создаем массив под блок заголовка
          byte[] item_array = new byte[int_buf];
          //Читаем блок(уже без его размера)
          ms.Read(item_array, sizeof(int), int_buf - sizeof(int));
          //Дописываем в блок его ранее считанный размер
          Array.Copy(int_arr_buf, 0, item_array, 0, sizeof(int));
          //Создаем блок заголовка архива и добавляем в список
          HeaderItem item = new HeaderItem();
          item.Parse(item_array);
          items.Add(item);
        }
      }
    }
    #endregion
  }
}
