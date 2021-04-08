using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Bdsh.Sync.Tools;


namespace Bdsh.Sync.Tabs.Installation
{
    public partial class InstallationCompareControl : UserControl
    {
        public InstallationCompareControl() => InitializeComponent();

        private void InstallationCompareControl_Load(object sender, EventArgs e)
        {
            textBoxInstallationToBeAnalyzedDirectory.DragEnter += new DragEventHandler(Utils.DragDrop.TextBoxDirectory_DragEnter);
            textBoxInstallationToBeAnalyzedDirectory.DragDrop += new DragEventHandler(Utils.DragDrop.TextBox_DragDrop);
            textBoxBaseInstallationDirectory.DragEnter += new DragEventHandler(Utils.DragDrop.TextBoxDirectory_DragEnter);
            textBoxBaseInstallationDirectory.DragDrop += new DragEventHandler(Utils.DragDrop.TextBox_DragDrop);
        }

        private void ButtonSelectInstallationToBeAnalyzedDirectory_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonDirectory_Click(textBoxInstallationToBeAnalyzedDirectory);

        private void ButtonSelectBaseInstallationDirectory_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonDirectory_Click(textBoxBaseInstallationDirectory);

        private void ButtonAnalyzeInstallation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInstallationToBeAnalyzedDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta com a instalação a ser analisada!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectInstallationToBeAnalyzedDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxBaseInstallationDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta com a instalação base!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectBaseInstallationDirectory.Focus();
                return;
            }

            if (!Directory.Exists(textBoxInstallationToBeAnalyzedDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta com a instalação a ser analizada é inválido!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectInstallationToBeAnalyzedDirectory.Focus();
                return;
            }

            if (!Directory.Exists(textBoxBaseInstallationDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta com a instalação base é inválido!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxBaseInstallationDirectory.Focus();
                return;
            }

            string installationToBeAnalyzedDirectory = textBoxInstallationToBeAnalyzedDirectory.Text.Trim();
            string baseInstallationDirectory = textBoxBaseInstallationDirectory.Text.Trim();

            Dictionary<string, Tuple<string, string>> installationDiff = Versions.GetDiffAnalyze(installationToBeAnalyzedDirectory, baseInstallationDirectory);

            dataGridViewInstallationCompare.Rows.Clear();

            foreach (var row in installationDiff)
            {
                dataGridViewInstallationCompare.Rows.Add(row.Key, row.Value.Item1, row.Value.Item2);

                if (row.Value.Item1 == "-")
                    dataGridViewInstallationCompare.Rows[dataGridViewInstallationCompare.Rows.Count - 1].Cells[0].Style.ForeColor = Color.DarkOrange;
                else if (row.Value.Item2 == "-")
                    dataGridViewInstallationCompare.Rows[dataGridViewInstallationCompare.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Blue;
                else if (Versions.Compare(row.Value.Item1, row.Value.Item2) == Equality.LT)
                    dataGridViewInstallationCompare.Rows[dataGridViewInstallationCompare.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            }
        }

        private void ButtonSelectInstallationComparePDFDirectory_Click(object sender, EventArgs e)
            => Utils.Selection.ButtonDirectory_Click(textBoxInstallationComparePDFDirectory);

        private void ButtonGenerateInstallationComparePDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInstallationToBeAnalyzedDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta com a instalação a ser analisada!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectInstallationToBeAnalyzedDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxBaseInstallationDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta com a instalação base!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectBaseInstallationDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxInstallationComparePDFDirectory.Text))
            {
                MessageBox.Show("Selecione a pasta onde ficará o PDF!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectInstallationComparePDFDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxInstallationComparePDFName.Text))
            {
                MessageBox.Show("Defina o nome do PDF!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxInstallationComparePDFName.Focus();
                return;
            }

            if (!Directory.Exists(textBoxInstallationToBeAnalyzedDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta com a instalação a ser analizada é inválido!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectInstallationToBeAnalyzedDirectory.Focus();
                return;
            }

            if (!Directory.Exists(textBoxBaseInstallationDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta com a instalação base é inválido!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectBaseInstallationDirectory.Focus();
                return;
            }

            if (!Directory.Exists(textBoxInstallationComparePDFDirectory.Text.Trim()))
            {
                MessageBox.Show("O caminho para a pasta onde ficará o PDF é inválido!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                buttonSelectInstallationComparePDFDirectory.Focus();
                return;
            }

            string installationToBeAnalyzedDirectory = textBoxInstallationToBeAnalyzedDirectory.Text.Trim();
            string baseInstallationDirectory = textBoxBaseInstallationDirectory.Text.Trim();

            string pdfDirectory = textBoxInstallationComparePDFDirectory.Text.Trim();
            string pdfName = textBoxInstallationComparePDFName.Text.Trim() + (Path.GetExtension(textBoxInstallationComparePDFName.Text.Trim()).ToLower() == ".pdf" ? "" : ".pdf");
            string pdfPath = Path.Combine(pdfDirectory, pdfName);

            if (File.Exists(pdfPath))
            {
                if (MessageBox.Show("Já exite um PDF com este nome na pasta selecionada.\nDeseja sobrescreve-lo?", "BDS Sync - Instalação - Comparação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    MessageBox.Show("Substitua a pasta do PDF ou altere seu nome.", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    try
                    {
                        File.Delete(pdfPath);
                    }
                    catch
                    {
                        MessageBox.Show("Não é possivel sobrescrever o PDF pois ele esta aberto no momento, feche-o e tente novamente.", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

            Versions.GenerateDiffPDF(installationToBeAnalyzedDirectory, baseInstallationDirectory, pdfPath);

            MessageBox.Show("PDF gerado com Sucesso!", "BDS Sync - Instalação - Comparação", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
