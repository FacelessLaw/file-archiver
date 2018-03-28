using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PiedPiper
{
    /// <summary>
    /// Пути объекта архива
    /// </summary>
    public class HeaderItemPath
    {
        List<string> pathes;

        public HeaderItemPath()
        {
            pathes = new List<string>();
        }
        /// <summary>
        /// Получение текущего используемого пути
        /// </summary>
        /// <returns></returns>
        public string GetCurrentPath()
        {
            return pathes[pathes.Count - 1];
        }
        /// <summary>
        /// Обновление текущего используемого пути
        /// </summary>
        /// <param name="path"></param>
        public void UpdateCurrentPath(string path)
        {
            pathes.Add(path);
        }
        /// <summary>
        /// Удаление временных файлов
        /// </summary>
        /// <param name="with_parent">Удаление включая файл источник</param>
        public void ClearTemporeryPathes(bool with_parent)
        {
            int index = (with_parent == true) ? 0 : 1;
            for (; index < pathes.Count; index++)
                Operations.DeleteFile(pathes[index]);
        }
        /// <summary>
        /// Удаление последнего пути
        /// </summary>
        public void RemoveLast()
        {
            pathes.RemoveAt(pathes.Count - 1);
        }
    }
}
