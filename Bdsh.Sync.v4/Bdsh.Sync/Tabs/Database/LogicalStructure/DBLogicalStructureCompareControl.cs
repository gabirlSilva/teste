using System;
using System.IO;
using System.Windows.Forms;
using Bdsh.Sync.Tools;

namespace Bdsh.Sync.Tabs.Database.LogicalStructure
{
    public partial class DBLogicalStructureCompareControl : UserControl
    {
        public DBLogicalStructureCompareControl() => InitializeComponent();

        private void DBLogicalStructureCompareControl_Load(object sender, EventArgs e)
        {
            textBoxConfigFilePath.DragEnter += new DragEventHandler(Utils.DragDrop.TextBoxFile_DragEnter);
            textBoxConfigFilePath.DragDrop += new DragEventHandler(Utils.DragDrop.TextBox_DragDrop);
        }

        private void ButtonSelectConfigFilePath_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonFile_Click(textBoxConfigFilePath);

        private void ButtonGenerateStructureCompareCSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxConfigFilePath.Text))
            {
                MessageBox.Show("Insira o arquivo de configuração para a comparação!", "BDS Sync - DB - Logical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectConfigFilePath.Focus();
                return;
            }

            if (!File.Exists(textBoxConfigFilePath.Text.Trim()))
            {
                MessageBox.Show("O caminho para o arquivo de configuração é inválido!", "BDS Sync - DB - Logical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonSelectConfigFilePath.Focus();
                return;
            }

            UseWaitCursor = true;

            DatabaseLogicalStructureCompareConfig config;

            try
            {
                config = Tools.Database.LogicalStructure.GetConfig(textBoxConfigFilePath.Text.Trim());
            }
            catch
            {
                MessageBox.Show("A estrutura do arquivo de configuração é inválida!", "BDS Sync - DB - Logical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = Tools.Database.LogicalStructure.GenerateStructureCompareCSV(config);

            UseWaitCursor = false;

            switch (result)
            {
                case DatabaseStructureCompareResult.CSVReadError:
                    MessageBox.Show("Houve um erro na leitura do arquvivo da database a ser analisada!", "BDS Sync - DB - Logical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DatabaseStructureCompareResult.CSVComnpareError:
                    MessageBox.Show("Houve um erro durante a comparação da estrutura das databases!", "BDS Sync - DB - Logical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DatabaseStructureCompareResult.WriteFileError:
                    MessageBox.Show("Houve um erro durante a escrita do arquivo CSV!", "BDS Sync - DB - Logical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DatabaseStructureCompareResult.Success:
                    MessageBox.Show("CSV gerado com Sucesso!", "BDS Sync - DB - Logical Structure - Compare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    break;

            }
        }
    }
}
