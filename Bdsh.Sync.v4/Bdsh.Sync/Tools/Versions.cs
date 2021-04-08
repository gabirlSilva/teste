using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Bdsh.Sync.Tools
{
    public enum Equality { LT, EQ, GT }

    class Versions
    {
        public static Equality Compare(string analizedVersion, string baseVersion)
        {
            int[] analizedVersionList = analizedVersion.Split('.').Select(i => int.Parse(i)).ToArray();
            int[] baseVersionList = baseVersion.Split('.').Select(i => int.Parse(i)).ToArray();

            for (int i = 0; i < baseVersionList.Length; i++)
                if (baseVersionList[i] > analizedVersionList[i])
                    return Equality.LT;

            return Equality.EQ;
        }

        public static Dictionary<string, Tuple<string, string>> GetDiffAnalyze(string installationToBeAnalyzedDirectory, string baseInstallationDirectory)
        {
            Dictionary<string, string> GetBDSFileRelativePathsFrom(string directory, string[] fileTypes)
            {
                Tuple<string, string>[] fileRelativePaths = { };

                foreach (string fileType in fileTypes)
                    fileRelativePaths = fileRelativePaths.Concat(
                        Directory.GetFiles(directory, fileType, SearchOption.AllDirectories)
                                 .Where(path => FileVersionInfo.GetVersionInfo(path).FileDescription.ToUpper().Contains("BDS"))
                                 .Select(path => Tuple.Create(path.Substring(directory.Length).Trim('\\', '/'), FileVersionInfo.GetVersionInfo(path).FileVersion)))
                                 .ToArray();

                return fileRelativePaths.ToDictionary(k => k.Item1, v => v.Item2);
            }

            string[] extensions = { "*.exe", "*.dll" };

            Dictionary<string, string> filesToBeAnalyzed = GetBDSFileRelativePathsFrom(installationToBeAnalyzedDirectory, extensions);
            Dictionary<string, string> baseFiles = GetBDSFileRelativePathsFrom(baseInstallationDirectory, extensions);

            var installationDiff = new Dictionary<string, Tuple<string, string>>();

            foreach (var baseFile in baseFiles)
            {
                string key = baseFile.Key;
                string baseVersion = baseFile.Value;

                if (!filesToBeAnalyzed.TryGetValue(key, out string analizedVersion))
                    analizedVersion = "-";

                installationDiff.Add(baseFile.Key, Tuple.Create(analizedVersion, baseVersion));
            }

            foreach (var analizedFile in filesToBeAnalyzed)
            {
                string key = analizedFile.Key;
                string value = analizedFile.Value;

                if (!baseFiles.ContainsKey(analizedFile.Key))
                    installationDiff.Add(key, Tuple.Create(value, "-"));
            }

            return installationDiff;
        }

        public static void GenerateDiffPDF(string installationToBeAnalyzedDirectory, string baseInstallationDirectory, string pdfPath)
        {
            var installationDiff = GetDiffAnalyze(installationToBeAnalyzedDirectory, baseInstallationDirectory);

            Document pdf = new Document();

            PdfDocumentRenderer renderer = new PdfDocumentRenderer { Document = pdf };

            Section section = pdf.AddSection();

            Paragraph header = section.AddParagraph();

            header.Format.LineSpacingRule = LineSpacingRule.Double;

            header.AddText("BDS Sync");
            header.AddLineBreak();

            header.AddText("Instalação analisada: " + installationToBeAnalyzedDirectory.Split(Path.DirectorySeparatorChar).Last());
            header.AddLineBreak();

            header.AddText("Instalação base: " + baseInstallationDirectory.Split(Path.DirectorySeparatorChar).Last());
            header.AddLineBreak();

            header.Format.SpaceAfter = "0.25cm";

            Table table = section.AddTable();

            table.Borders.Visible = true;

            table.TopPadding = 2;
            table.BottomPadding = 2;

            table.AddColumn(280);
            table.AddColumn(90);
            table.AddColumn(90);

            Row tableHeader = table.AddRow();

            tableHeader.HeadingFormat = true;

            tableHeader.Cells[0].AddParagraph("Arquivo");
            tableHeader.Cells[1].AddParagraph("Versão Analizada");
            tableHeader.Cells[2].AddParagraph("Versão Base");

            foreach (var file in installationDiff)
            {
                Row row = table.AddRow();

                row.Cells[0].AddParagraph(file.Key);
                row.Cells[1].AddParagraph(file.Value.Item1);
                row.Cells[2].AddParagraph(file.Value.Item2);

                if (file.Value.Item1 == "-")
                    row.Cells[0].Format.Font.Color = Colors.DarkOrange;
                else if (file.Value.Item2 == "-")
                    row.Cells[0].Format.Font.Color = Colors.Blue;
                else if (Compare(file.Value.Item1, file.Value.Item2) == Equality.LT)
                    row.Cells[0].Format.Font.Color = Colors.Red;
            }

            Paragraph dateTime = section.AddParagraph();

            dateTime.Format.SpaceBefore = "1cm";
            dateTime.Format.Alignment = ParagraphAlignment.Right;
            dateTime.AddText(DateTime.Now.ToString());

            renderer.RenderDocument();

            renderer.PdfDocument.Save(pdfPath);
        }
    }
}
