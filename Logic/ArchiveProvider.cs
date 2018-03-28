using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using zlib;
using System.Security.Cryptography;
using System.Reflection;

namespace PiedPiper
{
  public enum OperationErrorAction
  {
    Abort,
    Ignore,
    IgnoreAll,
    Replay
  }

  /// <summary>
  /// Опции сжатия
  /// </summary>
  public class CompressorOption
  {
    /// <summary>
    /// Создание архива без сжатия
    /// </summary>
    public bool WithoutCompress { get; set; }
    /// <summary>
    /// Путь к файлу архива
    /// </summary>
    public string Output { get; set; }
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// Флаг указывающий на удаление источника архива после успешного сжатия
    /// </summary>
    public bool RemoveSource { get; set; }
    /// <summary>
    /// Пути для включения в архив
    /// </summary>
    public List<string> IncludePath = new List<string>();
    /// <summary>
    /// Пути для исключения из архива
    /// </summary>
    public List<string> ExcludePath = new List<string>();
  }

  public delegate void ArchiveProviderProcessHandler(string message);
  public delegate OperationErrorAction ArchiveProviderErrorHandler(string caption, string message);
  /// <summary>
  /// Предоставляет функции архивации/разархивации
  /// </summary>
  public class ArchiveProvider
  {
    #region Fields
    /// <summary>
    /// Обработка ошибки возникшей при архивации файла, ожидает возвращение решения
    /// </summary>
    public event ArchiveProviderErrorHandler ErrorProcessing;
    /// <summary>
    /// Оповещения о процессе сжатия/разархивации
    /// </summary>
    public event ArchiveProviderProcessHandler ProcessMessages;
    /// <summary>
    /// Объект для копирования данных между потоками
    /// </summary>
    StreamTransfer transfer = new StreamTransfer();
    /// <summary>
    /// Заголовок архива
    /// </summary>
    Header header;
    [Flags]
    //Тип архива определяет какие процессоры обработки файлов будут подключены
    enum PrimeArchiverType : byte
    {
      Nothing = 0x0,      //Простой архив
      NoCompression = 0x1,//Архив без сжатия
      Password = 0x2      //Зашифрованный архив
    }
    /// <summary>
    /// Процессоры обработки файлов
    /// </summary>
    List<IProcessFile> processors = new List<IProcessFile>();
    #endregion

    #region Сжатие
    /// <summary>
    /// Создание архива
    /// </summary>
    /// <param name="option">Опции создания архива</param>
    public void Compress(CompressorOption option)
    {
      bool ignore_all = false;
      //Определим параметры сжатия
      PrimeArchiverType type = PrimeArchiverType.Nothing;
      processors.Clear();
      if (option.WithoutCompress)
      {
        type |= PrimeArchiverType.NoCompression;
      }
      else
      {
        processors.Add(new CompressFile());
      }
      if (!String.IsNullOrEmpty(option.Password))
      {
        type |= PrimeArchiverType.Password;
        EncryptFile ef = new EncryptFile();
        ef.SetKey(option.Password);
        processors.Add(ef);
      }
      //Создаем заголовок архива
      header = new Header();
      //Пути для заголовка
      HeaderItemPath hip = new HeaderItemPath();
      try
      {
        string temp_archive = TempNameGenerator.GenerateTempNameFromFile(option.Output);
        using (FileStream archiveStream = new FileStream(temp_archive, FileMode.Create, FileAccess.Write))
        {
          //Собираем заголовок
          IncludesPathCreate(option);
          //Перебираем элементы архива
          for (int i = 0; i < header.Items.Count; i++)
          {
            HeaderItemPath hip_file = new HeaderItemPath();
            try
            {
              Process(header.Items[i].AbsolutePath);
              //Выбираем только файлы
              if (header.Items[i].Length != 0)
              {

                hip_file.UpdateCurrentPath(header.Items[i].AbsolutePath);
                //Прогоняем файл через процессоры
                foreach (IProcessFile processor in processors)
                {
                  hip_file.UpdateCurrentPath(processor.ProcessExecute(hip_file.GetCurrentPath()));
                }
                //Записываем в конечный файл архива
                using (FileStream fr = new FileStream(hip_file.GetCurrentPath(), FileMode.Open, FileAccess.Read))
                {
                  header.Items[i].SetLentgh(fr.Length);
                  transfer.Transfer(fr, archiveStream);
                }
              }
            }
            catch (Exception ex)
            {
              if (ignore_all) continue;
              OperationErrorAction action = OperationErrorAction.Abort;
              if (ErrorProcessing != null)
              {
                action = ErrorProcessing(header.Items[i].RelativePath, ex.Message);
              }
              switch (action)
              {
                case OperationErrorAction.Abort:
                  throw ex;
                case OperationErrorAction.Ignore:
                  continue;
                case OperationErrorAction.IgnoreAll:
                  ignore_all = true;
                  continue;
                case OperationErrorAction.Replay:
                  i--;
                  break;
              }
            }
            finally
            {
              hip_file.ClearTemporeryPathes(option.RemoveSource);
            }
          }
        }
        //Сохраняем заголовок
        string header_path = TempNameGenerator.GenerateTempNameFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "header.dat"));
        hip.UpdateCurrentPath(header_path);
        using (FileStream fs = new FileStream(hip.GetCurrentPath(), FileMode.Create, FileAccess.Write))
        {
          new StreamTransfer().Transfer(new MemoryStream(header.ToArray()), fs);
        }
        //Прогоняем файл заголовка через процессоры
        foreach (IProcessFile processor in processors)
        {
          hip.UpdateCurrentPath(processor.ProcessExecute(hip.GetCurrentPath()));
        }
        //Собираем архив
        using (FileStream endArchiveStream = new FileStream(option.Output, FileMode.Create, FileAccess.Write))
        {
          using (FileStream fr = new FileStream(hip.GetCurrentPath(), FileMode.Open, FileAccess.Read))
          {
            //Запишем тип архива
            endArchiveStream.WriteByte((byte)type);
            //Запишем длину заголовка после обработок
            int after_processors_header_length = (int)fr.Length;
            endArchiveStream.Write(BitConverter.GetBytes(after_processors_header_length), 0, sizeof(int));
            //Запишем обработанный заголовок
            transfer.Transfer(fr, endArchiveStream);
          }
          using (FileStream fr = new FileStream(temp_archive, FileMode.Open, FileAccess.Read))
          {
            transfer.Transfer(fr, endArchiveStream);
          }
          Operations.DeleteFile(temp_archive);
        }
      }
      catch (Exception ex)
      {
        Process(ex.Message);
      }
      finally
      {
        //Удаляем временные файлы и при необходимости источники архива
        hip.ClearTemporeryPathes(true);
        processors.Clear();
      }
    }
    /// <summary>
    /// Проверка включаемых путей для сжатия
    /// создание непересекающегося списка путей
    /// </summary>
    /// <param name="option">Опции создания архива</param>
    /// <returns>Список путей для сжатия</returns>
    void IncludesPathCreate(CompressorOption option)
    {
      List<string> includes = new List<string>();
      bool alreadyUse = false;
      foreach (string str in option.IncludePath)
      {
        alreadyUse = false;
        for (int i = 0; i < includes.Count; i++)
        {
          if (str.IndexOf(includes[i], StringComparison.OrdinalIgnoreCase) >= 0 || includes[i].IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0)
          {
            alreadyUse = true;
            if (str.Length < includes[i].Length)
              includes[i] = str;
          }
        }
        if (!alreadyUse)
          includes.Add(str);
      }
      foreach (string str in option.ExcludePath)
        if (includes.Contains(str))
          includes.Remove(str);
      //Собираем заголовок
      foreach (string path in includes)
      {
        AppendToArchive(path, option);
      }
      return;
    }
    /// <summary>
    /// Добавление объекта в архив
    /// </summary>
    /// <param name="path">Путь к объекту</param>
    /// <param name="option">Параметры сжатия</param>
    void AppendToArchive(string path, CompressorOption option)
    {
      if (Directory.Exists(path))
        AppendFolderToArchive(Path.GetDirectoryName(path), path, option);
      else if (File.Exists(path))
        AppendFileToArchive(Path.GetDirectoryName(path), path, option);
    }
    /// <summary>
    /// Добавление каталога в архив
    /// </summary>
    /// <param name="path">Путь к каталогу</param>
    /// <param name="option">Параметры сжатия</param>
    void AppendFolderToArchive(string root, string path, CompressorOption option)
    {
      //Проверка на отсутствие текущего пути в списке исключенных
      if (!option.ExcludePath.Contains(path))
      {
        //Запись данных о пути каталога
        string relationName = Operations.GetPathDifferent(root, path);
        header.Insert(new HeaderItem(path, relationName, 0));
        //Архивация файлов каталога
        string[] files = Operations.ListFiles(path);
        if (files != null)
          foreach (string file in files)
            AppendFileToArchive(root, file, option);
        //Архивация подкаталогов
        string[] folders = Operations.ListDirectoies(path);
        if (folders != null)
          foreach (string folder in folders)
            AppendFolderToArchive(root, folder, option);
      }
    }
    /// <summary>
    /// Добавление файла в архив
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <param name="option">Параметры сжатия</param>
    void AppendFileToArchive(string root, string path, CompressorOption option)
    {
      //Проверка на отсутствие текущего пути в списке исключенных
      if (!option.ExcludePath.Contains(path))
      {
        string relationPath = Operations.GetPathDifferent(root, path);
        HeaderItem item = new HeaderItem(path, relationPath, 1);
        header.Insert(item);
      }
    }
    #endregion

    #region Разархивация
    /// <summary>
    /// Разархивация
    /// </summary>
    /// <param name="source">Файл архива</param>
    /// <param name="output">Каталог для разархивации</param>
    /// <param name="password">Пароль к архиву(пусто или null в случае отсутствия)</param>
    public void Decompress(string source, string output, string password)
    {
      CompressorOption option = new CompressorOption();
      processors.Clear();
      FileStream fs = null;
      BinaryReader br = null;
      Header unpack_header = new Header();
      try
      {
        using (fs = new FileStream(source, FileMode.Open, FileAccess.Read))
        {
          using (br = new BinaryReader(fs))
          {
            //Считаем тип архива
            PrimeArchiverType type = (PrimeArchiverType)br.ReadByte();
            //Добавляем процессоры для обработки файлов исходя из типа архива
            //ВАЖНО! Порядок добавления должен быть обратным порядку добавления в методе сжатия
            if ((type & PrimeArchiverType.Password) == PrimeArchiverType.Password)
            {
              EncryptFile ef = new EncryptFile();
              ef.SetKey(password);
              processors.Add(ef);
            }
            if ((type & PrimeArchiverType.NoCompression) != PrimeArchiverType.NoCompression)
            {
              processors.Add(new CompressFile());
            }
            //Считаем длину обработанного заголовка
            byte[] header_length_arr = br.ReadBytes(sizeof(int));
            //Считываем обработанный заголовок
            byte[] header_arr = br.ReadBytes(BitConverter.ToInt32(header_length_arr, 0));
            //Пишем заголовок в файл
            string header_path = TempNameGenerator.GenerateTempNameFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "header.dat"));
            HeaderItemPath hip_header = new HeaderItemPath();
            hip_header.UpdateCurrentPath(header_path);
            using (FileStream fw = new FileStream(header_path, FileMode.Create, FileAccess.Write))
            {
              transfer.Transfer(new MemoryStream(header_arr), fw);
            }
            //Преобразуем заголовок через процессоры
            foreach (IProcessFile processor in processors)
            {
              hip_header.UpdateCurrentPath(processor.BackProcessExecute(hip_header.GetCurrentPath()));
            }
            //Парсим заголовок
            using (FileStream fr = new FileStream(hip_header.GetCurrentPath(), FileMode.Open, FileAccess.Read))
            {
              byte[] header_body = new byte[fr.Length];
              int count = fr.Read(header_body, 0, (int)fr.Length);
              unpack_header.Parse(header_body);
            }
            hip_header.ClearTemporeryPathes(true);
            //Обрабатываем распарсенный заголовок
            foreach (HeaderItem item in unpack_header.Items)
            {
              //Если объект является каталогом, просто создаем его, в теле архива записей нет
              if (item.Length == 0)
              {
                string full_path = Path.Combine(output, item.RelativePath);
                Process(full_path);
                Operations.CreateDirectory(full_path);
              }
              //Если объект является файлом
              else
              {
                string full_path = Path.Combine(output, item.RelativePath);
                Process(full_path);
                //Считываем тело файла
                byte[] file_body = br.ReadBytes((int)item.Length);
                //Записываем в файл
                HeaderItemPath hip_file = new HeaderItemPath();
                hip_file.UpdateCurrentPath(TempNameGenerator.GenerateTempNameFromFile(full_path));
                using (FileStream fw = new FileStream(hip_file.GetCurrentPath(), FileMode.Create, FileAccess.Write))
                {
                  transfer.Transfer(new MemoryStream(file_body), fw);
                }
                //Преобразуем через процессоры
                foreach (IProcessFile processor in processors)
                {
                  hip_file.UpdateCurrentPath(processor.BackProcessExecute(hip_file.GetCurrentPath()));
                }
                //Сохраняем в конечный файл
                Operations.MoveFile(hip_file.GetCurrentPath(), full_path);
                hip_file.RemoveLast();
                //Удаляем временные файлы
                hip_file.ClearTemporeryPathes(true);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Process(ex.Message);
      }
      finally
      {
        if (br != null)
          br.Close();
        if (fs != null)
          fs.Close();
      }
    }
    #endregion

    private void Process(string msg)
    {
      if (ProcessMessages != null)
        ProcessMessages(String.Format("{0}: {1}", DateTime.Now.ToString(), msg));
    }
  }
}
