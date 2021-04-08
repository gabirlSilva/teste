using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Bdsh.Sync.Tabs.Utils;
using System.Net;
using System.Globalization;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System.Management;
using System.Security;
using SP = Microsoft.SharePoint.Client;
using Bdsh.Sync.Tools;

namespace Bdsh.Sync.Tabs.Installation
{
    public partial class InstallationCollectControl : UserControl
    {
        public InstallationCollectControl() => InitializeComponent();

        private void InstallationCollectControl_Load(object sender, EventArgs e)
        {
            textBoxInstallationDirectory.DragEnter += new DragEventHandler(Utils.DragDrop.TextBoxDirectory_DragEnter);
            textBoxInstallationDirectory.DragDrop += new DragEventHandler(Utils.DragDrop.TextBox_DragDrop);
        }

        private void ButtonSelectInstallationDirectory_Click(object sender, EventArgs e)
            => Selection.ButtonDirectory_Click(textBoxInstallationDirectory);

        private void ButtonSelectZipDirectory_Click(object sender, EventArgs e)
            => Selection.ButtonDirectory_Click(textBoxZipDirectory);

        private void buttonGenerateStructure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInstallationDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta com a instalação!", "BDS Sync - Instalação - Coleta");
                buttonSelectInstallationDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxZipDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta onde ficará o arquivo!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectZipDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxZipName.Text))
            {
                MessageBox.Show("Defina o nome do arquivo!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxZipName.Focus();
                return;
            }

            bool[] exceptions = {
                checkBoxIncludeFolderTemp.Checked, checkBoxIncludeFolderBackup.Checked,
                checkBoxIncludeFolderBkp.Checked, checkBoxIncludeExtensionDAT.Checked,
                checkBoxIncludeExtensionZip.Checked, checkBoxIncludeExtensionBak.Checked,
                checkBoxIncludeLog.Checked
            };

            string path = textBoxInstallationDirectory.Text.Trim();
            string fileName = textBoxZipName.Text.Trim();
            string destiny = textBoxZipDirectory.Text.Trim();
            uint day = (uint)writeTime.Value;
            bool includeFilesByWriteTime = checkBoxIncludeFilesByWriteTime.Checked;

            AwaitGeneration(true);
            BackgroundWorkerGenerateStructure.RunWorkerAsync((path, fileName, destiny, exceptions, includeFilesByWriteTime, day));


        }

        private void ButtonGenerateZip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInstallationDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta com a instalação!", "BDS Sync - Instalação - Coleta");
                buttonSelectInstallationDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxZipDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta onde ficará o Zip!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectZipDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxZipName.Text))
            {
                MessageBox.Show("Defina o nome do Zip!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxZipName.Focus();
                return;
            }

            if (!Directory.Exists(textBoxInstallationDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta com a instalção é inválido!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectInstallationDirectory.Focus();
                return;
            }

            if (!Directory.Exists(textBoxZipDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta onde ficará o Zip é inválido!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectZipDirectory.Focus();
                return;
            }

            string installationDirectory = textBoxInstallationDirectory.Text.Trim();

            string zipDirectory = textBoxZipDirectory.Text.Trim();
            string zipName = textBoxZipName.Text.Trim() + (Path.GetExtension(textBoxZipName.Text.Trim()).ToLower() == ".zip" ? "" : ".zip");
            string zipPath = Path.Combine(zipDirectory, zipName);
            bool[] exceptions = {
                checkBoxIncludeFolderTemp.Checked, checkBoxIncludeFolderBackup.Checked,
                checkBoxIncludeFolderBkp.Checked, checkBoxIncludeExtensionDAT.Checked,
                checkBoxIncludeExtensionZip.Checked, checkBoxIncludeExtensionBak.Checked,
                checkBoxIncludeLog.Checked
            };
            uint day = (uint)writeTime.Value;
            bool includeFilesByWriteTime = checkBoxIncludeFilesByWriteTime.Checked;

            if (File.Exists(zipPath))
            {
                if (MessageBox.Show("Já exite um Zip com este nome na pasta selecionada.\nDeseja sobrescreve-lo?", "BDS Sync - Instalação - Coleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    MessageBox.Show("Substitua a pasta do Zip ou altere seu nome.", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    try
                    {
                        File.Delete(zipPath);
                    }
                    catch
                    {
                        MessageBox.Show("Não é possivel sobrescrever o Zip pois ele está aberto no momento, feche-o e tente novamente.", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

            string[] infos = new string[6];
            StringBuilder info = new StringBuilder();
            ComputerInfo pcInfo = new ComputerInfo();
            CultureInfo ci = CultureInfo.InstalledUICulture;

            #region filesInfo
            string fileName = "filesInfo.txt";


            string key = Crypto.DecryptString("XouPj0kN7cDEOqexBKHEPF7v0AJ4gPTxQvMZXBbBZb0=", "GbbgCZxuIRbbNFFYnX1yN8PXUKWTyr");

            var securePassword = new SecureString();
            const string listName = "Aplicacoes_Teste_Dev";
            string password = Crypto.DecryptString("FhrvG1vpQG1tPiRjLbstcQ==", key);
            string login = Crypto.DecryptString("sfVh95biTx0B4rDthzU6DP9HIyMK/w+T1URynohcxMQ=", key);
            const string webUrl = "https://bdsdatasolution.sharepoint.com/sites/BDS-RaioX-ClientesOnPremise/";

            foreach (char c in password)
                securePassword.AppendChar(c);

            var onlineCredentials = new SP.SharePointOnlineCredentials(login, securePassword);

            using (SP.ClientContext CContext = new SP.ClientContext(webUrl))
            {
                CContext.Credentials = onlineCredentials;
                SP.List list = CContext.Web.Lists.GetByTitle(listName);
                try
                {
                    SP.ListItemCreationInformation itemCreateInfo = new SP.ListItemCreationInformation();
                    SP.ListItem newItem = list.AddItem(itemCreateInfo);

                    fileName = "softwareInfo.txt";
                    info.Clear().Append("SO;Versão do SO;Idioma;Padrão do Calendário;Bits;Versão do .Net Framework;Versão do Office");
                    try
                    {

                        info.Append("Nome;Caminho;Versão;Tamanho;Data de Criação;Data de Modificação");

                        string[] extensions = { "*.dll", "*.exe" };
                        foreach (string extension in extensions)
                        {
                            var rootfiles = Directory.GetFiles(installationDirectory, extension, SearchOption.AllDirectories);
                            foreach (var filePath in rootfiles)
                            {
                                FileInfo file = new FileInfo(filePath);
                                string Name = file.Name;
                                string Version = FileVersionInfo.GetVersionInfo(filePath).FileVersion;
                                string Size = file.Length.ToString();
                                DateTime ModTime = file.LastWriteTime;
                                DateTime CreateTime = file.CreationTime;

                                newItem["Aplica_x00e7__x00e3_o"] = Name;
                                newItem["Vers_x00e3_o_x0020_da_x0020_Apli"] = Version;
                                newItem["Data_x0020_da_x0020_Vers_x00e3_o"] = CreateTime;

                                newItem.Update();
                                CContext.ExecuteQuery();

                                info.Append($"\n{Name};{filePath};{Version};{Size};{CreateTime};{ModTime};");
                            }



                        }
                        infos[1] = info.ToString();
                        infos[0] = fileName;
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show(f.Message);
                    }
                }
                catch (Exception s) { MessageBox.Show(s.Message); }
            }


            #endregion

            #region softwareInfo

            try
            {
                string OS = pcInfo.OSFullName;
                string language = ci.DisplayName;
                string OSVersion = pcInfo.OSVersion;
                string dotNetVersion = GetDotNetVersion();
                string datePattern = ci.DateTimeFormat.ShortDatePattern;
                string bits = Environment.Is64BitOperatingSystem ? "64 Bits" : "32 Bits";
                info.Append($"\n{OS};{OSVersion};{language};{datePattern};{bits};{dotNetVersion};");

                string regOutlook32Bit = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\OUTLOOK.EXE";
                string regOutlook64Bit = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\App Paths\OUTLOOK.EXE";
                string outlookPath = "";

                try
                {
                    outlookPath = Registry.LocalMachine.OpenSubKey(regOutlook32Bit).GetValue("", "").ToString();
                }
                catch (NullReferenceException)
                {
                    try
                    {
                        outlookPath = Registry.LocalMachine.OpenSubKey(regOutlook64Bit).GetValue("", "").ToString();
                    }
                    catch (NullReferenceException) { }
                }
                finally
                {
                    if (!string.IsNullOrEmpty(outlookPath) && File.Exists(outlookPath))
                    {
                        var outlookFileInfo = FileVersionInfo.GetVersionInfo(outlookPath);
                        string officeVersion = outlookFileInfo.FileVersion;
                        info.Append($"{officeVersion}");
                    }
                    else
                    {
                        info.Append("");
                    }
                }

                infos[3] = info.ToString();
                infos[2] = fileName;
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

            #endregion

            #region hardwareInfo

            fileName = "hardwareInfo.txt";
            info.Clear().Append("Núcleos;CPU (MHz);RAM (Bytes);Espaço livre no HD (Bytes); Espaço total no HD (Bytes);DNS;Endereço IP");

            try
            {
                ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_Processor");
                ManagementObjectCollection results = new ManagementObjectSearcher(wql).Get();
                foreach (ManagementObject result in results)
                {
                    var numberOfCores = result["NumberOfCores"];
                    var maxClockSpeed = result["MaxClockSpeed"];
                    info.Append($"\n{numberOfCores};{maxClockSpeed};");
                    break;
                }

                var ram = pcInfo.TotalPhysicalMemory;

                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in allDrives)
                {
                    var freeSpace = d.AvailableFreeSpace;
                    var totalSize = d.TotalSize;
                    info.Append($"{ram};{freeSpace};{totalSize};");
                }

                string dnsName = Dns.GetHostName();
                string ip = Dns.GetHostByName(dnsName).AddressList[0].ToString();
                info.Append($"{dnsName};{ip}");

                infos[5] = info.ToString();
                infos[4] = fileName;

            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }

            #endregion

            AwaitGeneration(true);
            backgroundWorkerGenerateZip.RunWorkerAsync((zipDirectory, zipName, installationDirectory, exceptions, includeFilesByWriteTime, day, infos));

        }

        private object Version(string fileVersionInfo)
        {
            throw new NotImplementedException();
        }

        private void AwaitGeneration(bool state)
        {
            textBoxInstallationDirectory.Enabled = !state;
            textBoxZipDirectory.Enabled = !state;
            textBoxZipName.Enabled = !state;

            checkBoxIncludeLog.Enabled = !state;

            buttonSelectInstallationDirectory.Enabled = !state;
            buttonSelectZipDirectory.Enabled = !state;
            buttonGenerateZip.Enabled = !state;
            buttonGenerateStructure.Enabled = !state;

            progressBarZipInstallation.Value = 0;
        }

        #region Background Worker

        private void BackgroundWorkerGenerateZip_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var (zipDirectory, zipName, installationDirectory, exceptions, includeFilesByWriteTime, day, infos) = ((string, string, string, bool[], bool, uint, string[]))e.Argument;

            Tools.Installation.GenerateZip(zipDirectory, zipName, installationDirectory, exceptions, includeFilesByWriteTime, day, worker.ReportProgress, infos);
        }
        private void BackgroundWorkerGenerateStructure_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var (path, fileName, destiny, exceptions, includeFilesByWriteTime, day) = ((string, string, string, bool[], bool, uint))e.Argument;

            Tools.Installation.GenerateDirectoryStructure(path, fileName, destiny, exceptions, includeFilesByWriteTime, day, worker.ReportProgress);
        }

        private void BackgroundWorkerGenerateZip_ProgressChanged(object sender, ProgressChangedEventArgs e)
            => progressBarZipInstallation.Value = e.ProgressPercentage;

        private void BackgroundWorkerGenerateZip_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Zip gerado com Sucesso!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            AwaitGeneration(false);
        }
        private void BackgroundWorkerGenerateStructure_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Arquivo gerado com Sucesso!", "BDS Sync - Instalação - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            AwaitGeneration(false);
        }

        #endregion

        #region DotNet Version
        string GetDotNetVersion()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                return CheckDotNetVersion((int)ndpKey.GetValue("Release"));
            }

            string CheckDotNetVersion(int releaseKey)
            {
                if (releaseKey >= 528040)
                    return "4.8 or later";
                if (releaseKey >= 461808)
                    return "4.7.2";
                if (releaseKey >= 461308)
                    return "4.7.1";
                if (releaseKey >= 460798)
                    return "4.7";
                if (releaseKey >= 394802)
                    return "4.6.2";
                if (releaseKey >= 394254)
                    return "4.6.1";
                if (releaseKey >= 393295)
                    return "4.6";
                if (releaseKey >= 379893)
                    return "4.5.2";
                if (releaseKey >= 378675)
                    return "4.5.1";
                if (releaseKey >= 378389)
                    return "4.5";
                return "No 4.5 or later version detected";
            }
        }
        #endregion


    }
}
