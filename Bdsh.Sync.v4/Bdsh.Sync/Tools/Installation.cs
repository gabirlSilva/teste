using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Bdsh.Sync.Tools
{
    class Installation
    {
        public static void GenerateZip(string zipPath, string zipName, string installationDirectory, bool[] exceptions, bool includeFilesByWriteTime, uint interval, Action<int> ReportProgress, string[] infos)
        {
            string[] files = filter(installationDirectory, exceptions, includeFilesByWriteTime, interval);            

            int i = 1;
            double progress = 0.0;
            double step = 100.0 / (files.Length + infos.Length + 1);

            ZipArchive zip = ZipFile.Open($@"{zipPath}\{i} - {zipName}", ZipArchiveMode.Create);

            foreach (string file in files)
            {
                string fileZipPath = file.Substring(installationDirectory.Length).Trim('\\', '/');
                var zipInfo = new FileInfo($@"{zipPath}\{i} - {zipName}");
                var fileInfo = new FileInfo(file);
                var zipSize = zipInfo.Length / 1000000;
                var fileSize = fileInfo.Length / 1000000;

                if (zipSize >= 150 || (fileSize + zipSize) >= 150)
                {
                    zip.Dispose();
                    zip = ZipFile.Open($@"{zipPath}\{++i} - {zipName}", ZipArchiveMode.Create);
                }

                zip.CreateEntryFromFile(file, fileZipPath);
                progress += step;
                ReportProgress((int)progress);
            }
            zip.Dispose();

            using (zip = ZipFile.Open($@"{zipPath}\infoZip.zip", ZipArchiveMode.Create))
            {
                for (i = 0; i < infos.Length; i++)
                {
                    progress += step;
                    ReportProgress((int)progress);
                    ZipArchiveEntry readmeEntry = zip.CreateEntry(infos[i]);
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        writer.Write(infos[++i]);
                        writer.Close();
                    }
                }
            }    
        }
        
        public static void GenerateDirectoryStructure(string installationDirectory, string fileName, string txtPath, bool[] exceptions, bool includeFilesByWriteTime, uint interval, Action<int> ReportProgress)
        {
            string[] files = filter(installationDirectory, exceptions, includeFilesByWriteTime, interval);

            double progress = 0.0;
            double step = 100.0 / (files.Length + 1);
            StringBuilder info = new StringBuilder();
            info.AppendLine("Caminho;Versão;Data de Modificação");

            foreach (var filePath in files)
            {
                progress += step;
                ReportProgress((int)progress);

                FileInfo file = new FileInfo(filePath);
                string Version = FileVersionInfo.GetVersionInfo(filePath).FileVersion == null ? "Null" : FileVersionInfo.GetVersionInfo(filePath).FileVersion;
                DateTime ModTime = file.LastWriteTime;
                info.AppendLine($"{filePath};{Version};{ModTime};");
            }

            File.WriteAllText($@"{txtPath}\{fileName}.txt", info.ToString(), Encoding.UTF8);
        }

        private static string[] filter(string installationDirectory, bool[] exceptions, bool includeFilesByWriteTime, uint interval)
        {
            string[] filesByWriteTime = { };
            List<string> list = new List<string>();
            DateTime writeTime = DateTime.Now.AddDays(-interval);
            var installationFiles = Directory.GetFiles(installationDirectory, "*", SearchOption.AllDirectories);

            #region Filter
            //Folders
            if (exceptions[0])
                installationFiles = Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() != "temp");
            else if (includeFilesByWriteTime)
            {
                list.AddRange(Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() == "temp"
                && new FileInfo(path).LastWriteTime >= writeTime));
                installationFiles = Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() != "temp");
            }
            if (exceptions[1])
                installationFiles = Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() != "backup");
            else if (includeFilesByWriteTime)
            {
                list.AddRange(Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() == "backup"
                && new FileInfo(path).LastWriteTime >= writeTime));
                installationFiles = Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() != "backup");
            }
            if (exceptions[2])
                installationFiles = Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() != "bkp");
            else if (includeFilesByWriteTime)
            {
                list.AddRange(Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() == "bkp"
                && new FileInfo(path).LastWriteTime >= writeTime));
                installationFiles = Array.FindAll(installationFiles, path => new FileInfo(path).Directory.Name.ToLower() != "bkp");
            }
            //Extensions
            if (exceptions[3])
                installationFiles = Array.FindAll(installationFiles, path => Path.GetExtension(path).ToLower() != ".dat");
            if (exceptions[4])
                installationFiles = Array.FindAll(installationFiles, path => Path.GetExtension(path).ToLower() != ".zip");
            if (exceptions[5])
                installationFiles = Array.FindAll(installationFiles, path => Path.GetExtension(path).ToLower() != ".bak");
            if (exceptions[6])
                installationFiles = Array.FindAll(installationFiles, path => Path.GetExtension(path).ToLower() != ".log");
            #endregion

            list.AddRange(installationFiles);
            return list.ToArray();
        }

        private static string GetMachineInfo()
            => Info.GetWindowsVersion() +
               "\r\n\r\n.NET Framework 1 a 4:\r\n" +
               string.Join("\r\n", Info.GetDotNet1To4Versions().Select(version => "    " + version)) +
               "\r\n\r\n.NET Framework 4.5 e posteriores:\r\n" +
               "    " + Info.GetDotNet45PlusVersion() + "\r\n";
    }
}
