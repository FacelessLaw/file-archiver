using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PiedPiper
{
  /// <summary>
  /// Список часто употребляемых операций
  /// </summary>
  public static class Operations
  {
    #region Общее
    /// <summary>
    /// Принудительная очистка памяти
    /// </summary>
    public static void Collect()
    {
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }
    #endregion

    #region Работа с файлами

    #region Список файлов
    /// <summary>
    /// Получение списка файлов в указанном каталоге
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <returns>Список файлов, или null при ошибке</returns>
    public static string[] ListFiles(string path)
    {
      try
      {
        return Directory.GetFiles(path);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Получение списка файлов по пути {0}", path), ex.Message);
        return null;
      }
    }
    /// <summary>
    /// Получение списка файлов в указанном каталоге
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <param name="mask">Маска файлов для поиска</param>
    /// <returns>Список файлов, или null при ошибке</returns>
    public static string[] ListFiles(string path, string mask)
    {
      try
      {
        return Directory.GetFiles(path, mask, SearchOption.TopDirectoryOnly);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Получение списка файлов по пути {0}", path), ex.Message);
        return null;
      }
    }
    /// <summary>
    /// Получение списка файлов в указанном каталоге и всех подкаталогах
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <returns>Список файлов, или null при ошибке</returns>
    public static string[] RecursiveListFiles(string path)
    {
      try
      {
        return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Рекурсивное получение списка файлов по пути {0}", path), ex.Message);
        return null;
      }
    }
    /// <summary>
    /// Получение списка файлов в указанном каталоге и всех подкаталогах
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <param name="mask">Маска файлов для поиска</param>
    /// <returns>Список файлов, или null при ошибке</returns>
    public static string[] RecursiveListFiles(string path, string mask)
    {
      try
      {
        return Directory.GetFiles(path, mask, SearchOption.AllDirectories);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Рекурсивное получение списка файлов по пути {0}", path), ex.Message);
        return null;
      }
    }
    #endregion

    /// <summary>
    /// Удаление указанного файла
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <returns>true - в случае удачного выполнения</returns>
    public static void DeleteFile(string path)
    {
      try
      {
        File.Delete(path);
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("Не удалось удалить файл {0}, причина: {1}", path, ex.Message));
      }
    }
    /// <summary>
    /// Перемещение указанного файла
    /// </summary>
    /// <param name="src">Файл для перемещения</param>
    /// <param name="dest">Путь перемещения</param>
    /// <returns>true - в случае удачного выполнения</returns>
    public static void MoveFile(string src, string dest)
    {
      try
      {
        if (!Directory.Exists(Path.GetDirectoryName(dest)))
          Directory.CreateDirectory(Path.GetDirectoryName(dest));
        File.Move(src, dest);
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("Не удалось переместить файл из {0} в {1}, причина: {2}", src, dest, ex.Message));
      }
    }
    /// <summary>
    /// Копирование указанного файла
    /// </summary>
    /// <param name="src">Исходный файл</param>
    /// <param name="dest">Путь копирования</param>
    /// <returns>true - в случае удачного выполнения</returns>
    public static void CopyFile(string src, string dest)
    {
      try
      {
        if (!Directory.Exists(Path.GetDirectoryName(dest)))
          Directory.CreateDirectory(Path.GetDirectoryName(dest));
        File.Copy(src, dest, true);
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("Не удалось копировать файл из {0} в {1}, причина: {2}", src, dest, ex.Message));
      }
    }
    #endregion

    #region Работа с каталогами
    /// <summary>
    /// Удаление указанного каталога
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <returns>true - в случае удачного выполнения</returns>
    public static void DeleteDirectory(string path)
    {
      try
      {
        Directory.Delete(path);
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("Не удалось удалить каталог {0}, причина: {1}", path, ex.Message));
      }
    }
    /// <summary>
    /// Строгое удаление каталога (с удалением файлов и подкаталогов)
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <returns></returns>
    public static void StrongDeleteDirectory(string path)
    {
      try
      {
        string[] files = Directory.GetFiles(path);
        if (files != null)
          for (int i = 0; i < files.Length; i++)
            DeleteFile(files[i]);
        string[] catalog = Directory.GetDirectories(path);
        if (catalog != null)
          for (int i = 0; i < catalog.Length; i++)
            StrongDeleteDirectory(catalog[i]);
        Directory.Delete(path);
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("Не удалось рекурсивно удалить каталог {0}, причина: {1}", path, ex.Message));
      }
    }
    #region Списки каталогов
    /// <summary>
    /// Список подкаталогов
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <returns></returns>
    public static string[] ListDirectoies(string path)
    {
      try
      {
        return Directory.GetDirectories(path);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Получение списка каталогов по пути {0}", path), ex.Message);
        return null;
      }
    }
    /// <summary>
    /// Список подкаталогов
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <param name="mask">Маска подкаталогов для поиска</param>
    /// <returns></returns>
    public static string[] ListDirectoies(string path, string mask)
    {
      try
      {
        return Directory.GetDirectories(path, mask);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Получение списка каталогов по пути {0}", path), ex.Message);
        return null;
      }
    }
    /// <summary>
    /// Рекурсивный список подкаталогов
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <returns></returns>
    public static string[] RecursiveListDirectoies(string path)
    {
      try
      {
        return Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Получение рекурсивного списка каталогов по пути {0}", path), ex.Message);
        return null;
      }
    }
    /// <summary>
    /// Рекурсивный список подкаталогов
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <param name="mask">Маска подкаталогов для поиска</param>
    /// <returns></returns>
    public static string[] RecursiveListDirectoies(string path, string mask)
    {
      try
      {
        return Directory.GetDirectories(path, mask, SearchOption.AllDirectories);
      }
      catch (Exception ex)
      {
        //InfoServer.Send("EOP", String.Format("Получение рекурсивного списка каталогов по пути {0}", path), ex.Message);
        return null;
      }
    }
    #endregion

    /// <summary>
    /// Перемещеине указанного каталога
    /// </summary>
    /// <param name="src">Путь к текущему расположению</param>
    /// <param name="dest">Путь к новому расположению</param>
    /// <returns>true - в случае удачного выполнения</returns>
    public static void MoveDirectory(string src, string dest)
    {
      try
      {
        Directory.Move(src, dest);
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("Не удалось переместить каталог {0} в {1}, причина: {2}", src, dest, ex.Message));
      }
    }
    /// <summary>
    /// Создание нового каталога
    /// </summary>
    /// <param name="path">Путь к новому каталогу</param>
    /// <returns>true - в случае удачного выполнения</returns>
    public static void CreateDirectory(string path)
    {
      try
      {
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("Не удалось создать каталог {0}, причина: {1}", path, ex.Message));
      }
    }
    #endregion

    /// <summary>
    /// Получает список всех поддиректорий указанного пути
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string[] GetDirectoriesFromPath(string path)
    {
      List<string> result = new List<string>();
      string buffer = String.Empty;
      Match root = Regex.Match(path, @"^\w:\\", RegexOptions.Singleline);
      MatchCollection parts = Regex.Matches(path, @"\\[\w\.\s]{1,}", RegexOptions.Singleline);
      if (root.Success)
      {
        buffer = root.Value;
      }
      else
      {
        buffer = "\\\\";
      }
      foreach (Match match in parts)
      {
        buffer = Path.Combine(buffer, match.Value.Trim('\\'));
        result.Add(buffer);
      }
      return result.ToArray();
    }
    /// <summary>
    /// Создание каталога с созданием всех предшествующих путей
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    public static void CreateFullPathDirectory(string path)
    {
      string[] directories = GetDirectoriesFromPath(path);
      foreach (string dir in directories)
        CreateDirectory(dir);
    }
    /// <summary>
    /// Вернет путь каталога Path относительно каталога RootPath
    /// </summary>
    /// <param name="RootPath">Каталог содержащий Path</param>
    /// <param name="Path">Каталог находящийся во вложении RootPath, или в его подкаталогах</param>
    /// <returns></returns>
    public static string GetPathDifferent(string RootPath, string Path)
    {
      if (Path.IndexOf(RootPath) == 0)
      {
        return Path.Remove(0, RootPath.Length).Trim('\\');
      }
      return Path;
    }
  }
}
