using System;
using System.IO;
using System.Windows.Forms;
using Bdsh.Sync.Tools;


namespace Bdsh.Sync.Tabs.Database.PhysicalStructure
{
    public partial class DBPhysicalStructureCollectControl : UserControl
    {
        public DBPhysicalStructureCollectControl() => InitializeComponent();

        private void ButtonSelectCSVDirectory_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonDirectory_Click(textBoxCSVDirectory);

        private void ButtonGenerateCSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxConnectionString.Text))
            {
                MessageBox.Show("Insira a String de Conexão!", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxConnectionString.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCSVDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta onde ficará o CSV!", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectCSVDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCSVName.Text))
            {
                MessageBox.Show("Defina o nome do CSV!", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxCSVName.Focus();
                return;
            }

            if (!Directory.Exists(textBoxCSVDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta onde ficará o CSV é inválido!", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectCSVDirectory.Focus();
                return;
            }

            string csvDirectory = textBoxCSVDirectory.Text.Trim();
            string csvName = textBoxCSVName.Text.Trim() + (Path.GetExtension(textBoxCSVName.Text.Trim()).ToLower() == ".csv" ? "" : ".csv");
            string csvPath = Path.Combine(csvDirectory, csvName);


            if (File.Exists(csvPath))
            {
                if (MessageBox.Show("Já exite um CSV com este nome na pasta selecionada.\nDeseja sobrescreve-lo?", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    MessageBox.Show("Substitua a pasta do CSV ou altere seu nome.", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    try
                    {
                        File.Delete(csvPath);
                    }
                    catch
                    {
                        MessageBox.Show("Não é possivel sobrescrever o CSV pois ele está aberto no momento, feche-o e tente novamente.", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

            string connectionString = textBoxConnectionString.Text;
            DatabaseType dbType = DatabaseType.Oracle;
            if (connectionString.Split(';').Length <= 2)
            {
                try
                {
                    string key = Crypto.DecryptString("XouPj0kN7cDEOqexBKHEPF7v0AJ4gPTxQvMZXBbBZb0=", "GbbgCZxuIRbbNFFYnX1yN8PXUKWTyr");
                    connectionString = Crypto.DecryptString(connectionString, key);
                }
                catch (Exception) { }
            }
            string[] splited = connectionString.Split(';');
            foreach (var text in splited)
            {
                if (text.Split('=')[0].ToLower().Trim() == "initial catalog")
                {
                    dbType = DatabaseType.SQLServer;
                    break;
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            DataBaseStructureResult dbCSVResult = Tools.Database.PhysicalStructure.GenerateStructureCSV(dbType, connectionString, csvPath, csvName);

            Cursor.Current = Cursors.Arrow;

            switch (dbCSVResult)
            {
                case DataBaseStructureResult.BadConnectionString:
                    MessageBox.Show("O formato da String de conexão é inválido!", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.ConnectionError:
                    MessageBox.Show("Não foi possivel estabelecer conexão com o banco de dados!", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.ExecutionError:
                    MessageBox.Show("Houve um erro ao tentar obter as informações do banco de dados", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.WriteFileError:
                    MessageBox.Show("Houve um erro ao tentar gerar o arquivo CSV", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.Success:
                    MessageBox.Show("CSV gerado com Sucesso!", "BDS Sync - DB - Physical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    break;
            }
        }
    }
}
