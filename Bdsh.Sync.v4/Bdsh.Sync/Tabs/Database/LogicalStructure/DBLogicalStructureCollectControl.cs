using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Bdsh.Sync.Tools;


namespace Bdsh.Sync.Tabs.Database.LogicalStructure
{
    public partial class DBLogicalStructureCollectControl : UserControl
    {
        public DBLogicalStructureCollectControl() => InitializeComponent();

        private void ButtonSelectCSVsDirectory_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonDirectory_Click(textBoxCSVsDirectory);

        private void ButtonGenerateCSVs_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxConnectionString.Text))
            {
                MessageBox.Show("Insira a String de Conexão!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxConnectionString.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCSVsDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta onde ficarão os CSVs!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectCSVsDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCSVsName.Text))
            {
                MessageBox.Show("Defina o nome dos CSVs!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxCSVsName.Focus();
                return;
            }

            if (!Directory.Exists(textBoxCSVsDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta onde ficarão o CSVs é inválido!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectCSVsDirectory.Focus();
                return;
            }

            string csvsDirectory = textBoxCSVsDirectory.Text.Trim();
            string csvsName = textBoxCSVsName.Text.Trim() + (Path.GetExtension(textBoxCSVsName.Text.Trim()).ToLower() == ".csv" ? "" : ".csv");

            string[] tables = new[] { Tuple.Create("familia"   , checkBoxFamilia.Checked   )
                                    , Tuple.Create("atributo"  , checkBoxAtributo.Checked  )
                                    , Tuple.Create("serie"     , checkBoxSerie.Checked     )
                                    , Tuple.Create("filtro"    , checkBoxFiltro.Checked    )
                                    , Tuple.Create("fonte"     , checkBoxFonte.Checked     )
                                    , Tuple.Create("cadastro"  , checkBoxCadastro.Checked  )
                                    , Tuple.Create("lista"     , checkBoxLista.Checked     )
                                    , Tuple.Create("listaserie", checkBoxListaSerie.Checked)
                                    , Tuple.Create("diasuteis", checkBoxDiasUteis.Checked)
                                    , Tuple.Create("feriado", checkBoxFeriado.Checked)
                                    , Tuple.Create("users", checkBoxUsers.Checked)
                                    , Tuple.Create("prefixo_storedProcedures", checkBoxPrefixoStoredProcedures.Checked)
                                    , Tuple.Create("prefixo_functions", checkBoxPrefixoFunctions.Checked)
                                    , Tuple.Create("prefixo_tabelas", checkBoxPrefixoTabelas.Checked)
                                    , Tuple.Create("colunas_existentes", checkBoxColunasExistentes.Checked)
                                    , Tuple.Create("objetos_existentes", checkBoxObjetosExistentes.Checked)
                                    , Tuple.Create("tabelas_existentes", checkBoxTabelasExistentes.Checked)
                                    , Tuple.Create("foreignKeys_existentes", checkBoxForeignKeysExistentes.Checked)
                                    , Tuple.Create("primaryKeys", checkBoxPrimaryKeys.Checked)
                                    , Tuple.Create("database_size_name", checkBoxDatabaseSizeName.Checked)
                                    }.Where(t => t.Item2).Select(t => t.Item1).ToArray();                                    

            if (tables.Length == 0)
            {
                MessageBox.Show("É necessario selecionar pelo menos uma tabela!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            foreach (string table in tables)
                if (File.Exists(Path.Combine(csvsDirectory, $"{table}-{csvsName}")))
                {
                    if (MessageBox.Show("Já exitem um CSVs com estes nomes na pasta selecionada.\nDeseja sobrescreve-los?", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        MessageBox.Show("Substitua a pasta do CSV ou altere seus nomes.", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        try
                        {
                            foreach (string t in tables)
                            {
                                string file = Path.Combine(csvsDirectory, $"{t}-{csvsName}");
                                if (File.Exists(file))
                                    File.Delete(file);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Não é possivel sobrescrever os CSVs pois um ou mais deles está aberto no momento, feche-o(s) e tente novamente.", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                }

            string connectionString = textBoxConnectionString.Text.Trim();
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
            string prefix = checkBoxPrefix.Checked == true ? textBoxPrefix.Text : "";

            Cursor.Current = Cursors.WaitCursor;
            DataBaseStructureResult dbCSVResult = Tools.Database.LogicalStructure.GenerateStructureCSV(dbType, connectionString, tables, csvsDirectory, csvsName, prefix);

            switch (dbCSVResult)
            {
                case DataBaseStructureResult.BadConnectionString:
                    MessageBox.Show("O formato da String de conexão é inválido!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.ConnectionError:
                    MessageBox.Show("Não foi possivel estabelecer conexão com o banco de dados!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.ExecutionError:
                    MessageBox.Show("Houve um erro ao tentar obter as informações do banco de dados", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.WriteFileError:
                    MessageBox.Show("Ocorreu um problema durante a escrita dos arquivos", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;

                case DataBaseStructureResult.Success:
                    MessageBox.Show("CSVs gerados com Sucesso!", "BDS Sync - DB - Logical Structure - Coleta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    break;
            }
        }
    }
}
