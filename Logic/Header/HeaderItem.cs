using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PiedPiper
{
    /// <summary>
    /// Объект заголовка архива.
    /// Содержит данные об абсолютном пути к объекту, относительном пути и размере объекта
    /// </summary>
    public class HeaderItem
    {
        #region Fields
        string relativePath = string.Empty;
        string absolutePath = string.Empty;
        long length = 0;
        int item_length = 0;
        #endregion

        #region Properties
        public string RelativePath
        {
            get { return relativePath; }
        }

        public string AbsolutePath
        {
            get { return absolutePath; }
        }

        public long Length
        {
            get { return length; }
        }

        public int ItemLength
        {
            get { return item_length; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Создание объекта заголовка архива
        /// </summary>
        public HeaderItem()
        {
        }
        /// <summary>
        /// Создание объекта заголовка архива
        /// </summary>
        /// <param name="_AbsolutePath">Абсолютный путь к объекту</param>
        /// <param name="_RelativePath">Относительный путь к объекту</param>
        /// <param name="_Length">Размер(длина файла, или 0 для каталога)</param>
        public HeaderItem(string _AbsolutePath, string _RelativePath, long _Length)
        {
            relativePath = _RelativePath ?? String.Empty;
            absolutePath = _AbsolutePath ?? String.Empty;
            length = _Length;
            CalculateItemLength();
        }
        /// <summary>
        /// Преобразование объекта заголовка в массив байт
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            //Длина результирующего массива
            int index = 0;
            byte[] result = new byte[item_length];
            int rel_length = relativePath.Length;
            int abs_length = absolutePath.Length;
            Array.Copy(BitConverter.GetBytes(item_length), 0, result, index, sizeof(int));
            index += sizeof(int);
            Array.Copy(BitConverter.GetBytes(abs_length), 0, result, index, sizeof(int));
            index += sizeof(int);
            Array.Copy(Encoding.Default.GetBytes(absolutePath), 0, result, index, abs_length);
            index += abs_length;
            Array.Copy(BitConverter.GetBytes(rel_length), 0, result, index, sizeof(int));
            index += sizeof(int);
            Array.Copy(Encoding.Default.GetBytes(relativePath), 0, result, index, rel_length);
            index += rel_length;
            Array.Copy(BitConverter.GetBytes(length), 0, result, index, sizeof(long));
            return result;
        }
        /// <summary>
        /// Получение объекта заголовка из массива байт
        /// </summary>
        /// <param name="array"></param>
        public void Parse(byte[] array)
        {
            byte[] int_arr_buffer = new byte[sizeof(int)];
            byte[] long_arr_buffer = new byte[sizeof(long)];
            int int_buffer;
            using (MemoryStream ms = new MemoryStream(array))
            {
                //Считываем длину заголовка
                ms.Read(int_arr_buffer, 0, sizeof(int));
                int_buffer = BitConverter.ToInt32(int_arr_buffer, 0);
                if (array.Length != int_buffer)
                    throw new Exception("Заголовок поврежден. Реальная длина заголовка не совпадает с записанной.");
                //Считываем длину абсолютного пути
                ms.Read(int_arr_buffer, 0, sizeof(int));
                int_buffer = BitConverter.ToInt32(int_arr_buffer, 0);
                if (int_buffer < 0)
                    throw new Exception("Заголовок поврежден. Указана отрицательная длина абсолютного пути.");
                //Считываем абсолютный путь
                byte[] abs_array = new byte[int_buffer];
                ms.Read(abs_array, 0, int_buffer);
                absolutePath = Encoding.Default.GetString(abs_array);
                //Считываем длину относительного пути
                ms.Read(int_arr_buffer, 0, sizeof(int));
                int_buffer = BitConverter.ToInt32(int_arr_buffer, 0);
                if (int_buffer < 0)
                    throw new Exception("Заголовок поврежден. Указана отрицательная длина относительного пути.");
                //Считываем относительный путь
                byte[] rel_array = new byte[int_buffer];
                ms.Read(rel_array, 0, int_buffer);
                relativePath = Encoding.Default.GetString(rel_array);
                //Считываем размер файла/каталога
                ms.Read(long_arr_buffer, 0, sizeof(long));
                length = BitConverter.ToInt64(long_arr_buffer, 0);
                if (length < 0)
                    throw new Exception("Заголовок поврежден. Указана отрицательный размер содержимого.");
            }
            CalculateItemLength();
        }
        /// <summary>
        /// Расчет размера данного объекта заголовка
        /// </summary>
        void CalculateItemLength()
        {
            //Сумма длинн относительного пути и абсолютного пути, записей их длинн и записи размера файла(для каталога запись будет тоже, равная нулю) и длина самого заголовка идущая вначале массива
            item_length = relativePath.Length + absolutePath.Length + sizeof(long) + sizeof(int) * 3;
        }
        /// <summary>
        /// Перезадание размера содержимого
        /// </summary>
        /// <param name="_length"></param>
        public void SetLentgh(long _length)
        {
            length = _length;
        }
        #endregion
    }
}
