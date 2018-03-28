using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PiedPiper
{
    /// <summary>
    /// Генератор имени для временного файла
    /// </summary>
    public static class TempNameGenerator
    {
        /// <summary>
        /// Создание пути ко временному файлу
        /// </summary>
        /// <param name="path">Путь к файлу из чъего пути будет создан путь ко временному файлу</param>
        /// <returns>Путь ко временному файлу</returns>
        public static string GenerateTempNameFromFile(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string result;
            int count = 0;
            do
            {
                result = Path.Combine(dir, String.Format("{0}_{1}.ztemp", count++, name));
            } while (File.Exists(result));
            return result;
        }
    }
}
