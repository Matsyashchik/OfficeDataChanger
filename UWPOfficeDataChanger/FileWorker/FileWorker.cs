using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UWPOfficeDataChanger
{
    public class FileWorker
    {
        readonly string cachePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OfficeDataChanger";
        readonly XmlDocument xmlDocCore = new XmlDocument();
        readonly XmlDocument xmlDocApp = new XmlDocument();
        FileInfo file;
        string initialPath;
        string extractedPath;

        public FileWorker()
        {
            //DirectoryInfo cacheDirectory = Directory.CreateDirectory(cachePath);
            //cacheDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }

        /// <summary>
        /// Метод для для загрузки файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public FileData LoadFile(string path)
        {
            initialPath = path;
            file = new FileInfo(path);
            ExtractFile(path);
            return ExtractData(file.Extension);
        }

        /// <summary>
        /// Метод для разархивации файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private void ExtractFile(string path)
        {
            extractedPath = cachePath + $@"\{file.Name}";
            Directory.CreateDirectory(extractedPath);
            try
            {
                ZipFile.ExtractToDirectory(path, extractedPath);
                xmlDocCore.Load(extractedPath + @"\docProps\core.xml");
                xmlDocApp.Load(extractedPath + @"\docProps\app.xml");
            }
            catch (InvalidDataException)
            {
                // TODO: Обработчик ошибок 
            }

        }

        /// <summary>
        /// Метод для извлечения данных файла
        /// </summary>
        /// <param name="extension">Расширение файла</param>
        private FileData ExtractData(string extension)
        {
            FileData extractedData = new FileData();
            switch (extension)
            {
                case ".doc":
                case ".docx":
                    extractedData.TotalEditingTime = UInt16.Parse(xmlDocApp.ChildNodes[1].ChildNodes[1].InnerText);
                    extractedData.Creator = xmlDocCore.ChildNodes[1].ChildNodes[2].InnerText;
                    extractedData.LastModifiedBy = xmlDocCore.ChildNodes[1].ChildNodes[5].InnerText;
                    string revision = xmlDocCore.ChildNodes[1].ChildNodes[6].InnerText;
                    extractedData.Revision = revision != "" ? UInt16.Parse(revision) : (ushort)1;
                    extractedData.Created = xmlDocCore.ChildNodes[1].ChildNodes[7].InnerText.InvertFormat();
                    extractedData.Modified = xmlDocCore.ChildNodes[1].ChildNodes[8].InnerText.InvertFormat();
                    break;
                case ".xlsx":
                case ".xlsm":
                case ".xls":
                    extractedData.Creator = xmlDocCore.ChildNodes[1].ChildNodes[0].InnerText;
                    extractedData.LastModifiedBy = xmlDocCore.ChildNodes[1].ChildNodes[1].InnerText;
                    extractedData.Created = xmlDocCore.ChildNodes[1].ChildNodes[2].InnerText.InvertFormat();
                    extractedData.Modified = xmlDocCore.ChildNodes[1].ChildNodes[3].InnerText.InvertFormat();
                    extractedData.Opened = file.LastAccessTime;
                    break;
                default:
                    return null;
            }
            return extractedData;
        }

        /// <summary>
        /// Модификация файла
        /// </summary>
        /// <param name="modifiedData"></param>
        public void ModifyFile(FileData modifiedData)
        {
            ModifyData(modifiedData);
            file.Delete();
            SaveFile();
            ModifyFileTime(modifiedData);
            ClearCache();
        }


        /// <summary>
        /// Модификация скрытых данных файла
        /// </summary>
        /// <param name="modifiedData">изменённые данные</param>
        public void ModifyData(FileData modifiedData)
        {
            switch (file.Extension)
            {
                case ".doc":
                case ".docx":
                    xmlDocApp.ChildNodes[1].ChildNodes[1].InnerText = modifiedData.TotalEditingTime.ToString();
                    xmlDocApp.Save(extractedPath + @"\docProps\app.xml");
                    xmlDocCore.ChildNodes[1].ChildNodes[2].InnerText = modifiedData.Creator;
                    xmlDocCore.ChildNodes[1].ChildNodes[5].InnerText = modifiedData.LastModifiedBy;
                    xmlDocCore.ChildNodes[1].ChildNodes[6].InnerText = modifiedData.Revision.ToString();
                    xmlDocCore.ChildNodes[1].ChildNodes[7].InnerText = modifiedData.Created.ToFormatString();
                    xmlDocCore.ChildNodes[1].ChildNodes[8].InnerText = modifiedData.Modified.ToFormatString();
                    break;
                case ".xlsx":
                case ".xlsm":
                case ".xls":
                    xmlDocCore.ChildNodes[1].ChildNodes[0].InnerText = modifiedData.Creator;
                    xmlDocCore.ChildNodes[1].ChildNodes[1].InnerText = modifiedData.LastModifiedBy;
                    xmlDocCore.ChildNodes[1].ChildNodes[2].InnerText = modifiedData.Created.ToFormatString();
                    xmlDocCore.ChildNodes[1].ChildNodes[3].InnerText = modifiedData.Modified.ToFormatString();
                    break;
            }
            xmlDocCore.Save(extractedPath + @"\docProps\core.xml");

        }

        /// <summary>
        /// Сохранение файла
        /// </summary>
        public void SaveFile()
        {
            ZipFile.CreateFromDirectory(extractedPath, initialPath);
        }

        /// <summary>
        /// Модификация времени создания/редактирования/просмотра файла
        /// </summary>
        /// <param name="modifiedData"></param>
        private void ModifyFileTime(FileData modifiedData)
        {
            file = new FileInfo(file.FullName)
            {
                CreationTime = modifiedData.Created,
                LastWriteTime = modifiedData.Modified,
                LastAccessTime = modifiedData.Opened
            };
            //System.IO.File.SetCreationTime();
        }

        /// <summary>
        /// Очистка кэша
        /// </summary>
        public void ClearCache()
        {
            Directory.Delete(extractedPath, true);
        }
    }
}
