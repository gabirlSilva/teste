using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Bdsh.Sync.Tools;


namespace Bdsh.Sync.Tabs.Database.PhysicalStructure
{
    public partial class DBPhysicalStructureCompareControl : UserControl
    {
        public DBPhysicalStructureCompareControl() => InitializeComponent();

        private void DBPhysicalStructureCompare_Load(object sender, EventArgs e)
        {
            textBoxStructureToBeComparedCSV.DragEnter += new DragEventHandler(Utils.DragDrop.TextBoxFile_DragEnter);
            textBoxStructureToBeComparedCSV.DragDrop += new DragEventHandler(Utils.DragDrop.TextBox_DragDrop);
            textBoxStructureBaseCSV.DragEnter += new DragEventHandler(Utils.DragDrop.TextBoxFile_DragEnter);
            textBoxStructureBaseCSV.DragDrop += new DragEventHandler(Utils.DragDrop.TextBox_DragDrop);
        }

        private void ButtonSelectStructureToBeComparedCSV_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonFile_Click(textBoxStructureToBeComparedCSV);

        private void ButtonSelectStructureBaseCSV_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonFile_Click(textBoxStructureBaseCSV);

        private void ButtonSelectStructureCompareCSVDirectory_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonDirectory_Click(textBoxStructureCompareCSVDirectory);

        private void RadioButtonStructureBaseCSV_CheckedChanged(object sender, EventArgs e)
        {
            textBoxStructureBaseCSV.Enabled = radioButtonStructureBaseCSV.Enabled;
            buttonSelectStructureBaseCSV.Enabled = radioButtonStructureBaseCSV.Enabled;
            textBoxStructureBaseConnectionString.Enabled = !radioButtonStructureBaseCSV.Enabled;
        }

        private void RadioButtonStructureBaseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            textBoxStructureBaseCSV.Enabled = !radioButtonStructureBaseCSV.Enabled;
            buttonSelectStructureBaseCSV.Enabled = !radioButtonStructureBaseCSV.Enabled;
            textBoxStructureBaseConnectionString.Enabled = radioButtonStructureBaseCSV.Enabled;
        }

        private void ButtonGenerateStructureCompareCSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxStructureToBeComparedCSV.Text))
            {
                MessageBox.Show("Insira o arquivo da database a ser a analisada!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxStructureToBeComparedCSV.Focus();
                return;
            }

            if (radioButtonStructureBaseCSV.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxStructureBaseCSV.Text))
                {
                    MessageBox.Show("Insira o arquivo da database base!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    textBoxStructureBaseCSV.Focus();
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBoxStructureBaseConnectionString.Text))
                {
                    MessageBox.Show("Insira a String de Conexão da database base!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    textBoxStructureBaseConnectionString.Focus();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(textBoxStructureCompareCSVDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta onde ficará o CSV!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxStructureCompareCSVDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxStructureCompareCSVName.Text))
            {
                MessageBox.Show("Defina o nome dos CSV!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxStructureCompareCSVName.Focus();
                return;
            }

            if (!Directory.Exists(textBoxStructureCompareCSVDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta onde ficará o CSV é inválido!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectStructureCompareCSVDirectory.Focus();
                return;
            }

            if (!File.Exists(textBoxStructureToBeComparedCSV.Text.Trim()))
            {
                MessageBox.Show("O caminho para o arquivo da database a ser analisada é inválido!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonSelectStructureToBeComparedCSV.Focus();
                return;
            }

            string csvDirectory = textBoxStructureCompareCSVDirectory.Text.Trim();
            string csvName = textBoxStructureCompareCSVName.Text.Trim() + (Path.GetExtension(textBoxStructureCompareCSVName.Text.Trim()).ToLower() == ".csv" ? "" : ".csv");
            string csvPath = Path.Combine(csvDirectory, csvName);

            if (File.Exists(csvPath))
            {
                if (MessageBox.Show("Já exite um CSV com este nome na pasta selecionada.\nDeseja sobrescreve-lo?", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    MessageBox.Show("Substitua a pasta do CSV ou altere seu nome.", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    try
                    {
                        File.Delete(csvPath);
                    }
                    catch
                    {
                        MessageBox.Show("Não é possivel sobrescrever o CSV pois ele está aberto no momento, feche-o e tente novamente.", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

            UseWaitCursor = true;

            backgroundWorkerGenerateStructureCompareCSV.RunWorkerAsync(csvPath);
        }

        private void BackgroundWorkerGenerateStructureCompareCSV_DoWork(object sender, DoWorkEventArgs e)
        {
            var csvPath = e.Argument as string;

            string databaseBasePath;

            DatabaseType dbType = radioButtonSQLServer.Checked ? DatabaseType.SQLServer : DatabaseType.Oracle;

            if (radioButtonStructureBaseCSV.Checked)
            {
                if (!File.Exists(textBoxStructureBaseCSV.Text.Trim()))
                {
                    MessageBox.Show("O caminho para o arquivo da database base é inválido!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    textBoxStructureBaseCSV.Focus();
                    return;
                }

                databaseBasePath = textBoxStructureBaseCSV.Text.Trim();
            }
            else
            {
                string connectionString = textBoxStructureBaseConnectionString.Text;
                if (connectionString.Split(';').Length <= 2)
                {
                    try
                    {
                        string key = Crypto.DecryptString("XouPj0kN7cDEOqexBKHEPF7v0AJ4gPTxQvMZXBbBZb0=", "GbbgCZxuIRbbNFFYnX1yN8PXUKWTyr");
                        connectionString = Crypto.DecryptString(connectionString, key);
                    }
                    catch (Exception) { }
                }

                databaseBasePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

                DataBaseStructureResult dbCSVResult = Tools.Database.PhysicalStructure.GenerateStructureCSV(dbType, connectionString, databaseBasePath);

                switch (dbCSVResult)
                {
                    case DataBaseStructureResult.BadConnectionString:
                        MessageBox.Show("O formato da String de conexão é inválido!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;

                    case DataBaseStructureResult.ConnectionError:
                        MessageBox.Show("Não foi possivel estabelecer conexão com o banco de dados!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;

                    case DataBaseStructureResult.ExecutionError:
                        MessageBox.Show("Houve um erro ao tentar obter as informações do banco de dados!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;

                    case DataBaseStructureResult.WriteFileError:
                        MessageBox.Show("Houve um erro ao tentar guadar as informções do banco de dados!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                }
            }

            string databaseToBeComparedPath = textBoxStructureToBeComparedCSV.Text.Trim();

            DatabaseStructureCompareResult databaseStructureCompareResult = Tools.Database.PhysicalStructure.GenerateStructureCompareCSV(databaseToBeComparedPath, databaseBasePath, csvPath, radioButtonStructureBaseConnectionString.Checked);

            UseWaitCursor = false;

            switch (databaseStructureCompareResult)
            {
                case DatabaseStructureCompareResult.CSVReadError:
                    MessageBox.Show("Houve um erro na leitura do arquvivo da database a ser analisada!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DatabaseStructureCompareResult.CSVComnpareError:
                    MessageBox.Show("Houve um erro durante a comparação da estrutura das databases!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DatabaseStructureCompareResult.WriteFileError:
                    MessageBox.Show("Houve um erro durante a escrita do arquivo CSV!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DatabaseStructureCompareResult.Success:
                    MessageBox.Show("CSV gerado com Sucesso!", "BDS Sync - DB - Phisical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    break;
            }
        }
    }
}
