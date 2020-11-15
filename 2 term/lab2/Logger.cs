using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace FileWatcher
{
    class Logger
    {
        object control = new object();
        FileSystemWatcher watcher;
        bool enabled = true;
        string path = "C:\\SourceDirectory";
        public Logger()
        {
            watcher = new FileSystemWatcher(path);
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            watcher.Filter = "*.txt";
            watcher.Created += FileTransfer;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        private void FileTransfer(object sender, FileSystemEventArgs e)
        {
            lock (control)
            {
                var dirInfo = new DirectoryInfo(path);
                var filePath = Path.Combine(path, e.Name);
                var fileName = e.Name;
                var dt = DateTime.Now;
                var subPath = $"{dt.ToString("yyyy", DateTimeFormatInfo.InvariantInfo)}\\" +
                   $"{dt.ToString("MM", DateTimeFormatInfo.InvariantInfo)}\\" +
                   $"{dt.ToString("dd", DateTimeFormatInfo.InvariantInfo)}";
                var newPath = $"C:\\SourceDirectory\\" +
                   $"{dt.ToString("yyyy", DateTimeFormatInfo.InvariantInfo)}\\" +
                   $"{dt.ToString("MM", DateTimeFormatInfo.InvariantInfo)}\\" +
                   $"{dt.ToString("dd", DateTimeFormatInfo.InvariantInfo)}\\" +
                   $"{Path.GetFileNameWithoutExtension(fileName)}_" +
                   $"{dt.ToString(@"yyyy_MM_dd_HH_mm_ss", DateTimeFormatInfo.InvariantInfo)}" +
                   $"{Path.GetExtension(fileName)}";

                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }

                dirInfo.CreateSubdirectory(subPath);
                File.Move(filePath, newPath);
                FileOperations.EncryptFile(newPath, newPath);
                var compressedPath = Path.ChangeExtension(newPath, "gz");
                var newCompressedPath = Path.Combine("C:\\TargetDirectory", Path.GetFileName(compressedPath));
                var decompressedPath = Path.ChangeExtension(newCompressedPath, "txt");
                FileOperations.Compress(newPath, compressedPath);
                File.Move(compressedPath, newCompressedPath);
                FileOperations.Decompress(newCompressedPath, decompressedPath);
                FileOperations.DecryptFile(decompressedPath, decompressedPath);
                FileOperations.AddToArchive(decompressedPath);
                File.Delete(newPath);
                File.Delete(newCompressedPath);
                File.Delete(decompressedPath);
            }
        }
    }
}
