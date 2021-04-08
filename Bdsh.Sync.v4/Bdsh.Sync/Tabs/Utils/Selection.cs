using System.IO;
using System.Windows.Forms;

namespace Bdsh.Sync.Tabs.Utils
{
    public class Selection
    {
        public static void ButtonDirectory_Click(TextBox textBox)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog { SelectedPath = textBox.Text };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textBox.Text = folderBrowserDialog.SelectedPath;
        }

        public static void ButtonFile_Click(TextBox textBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            try { openFileDialog.InitialDirectory = Path.GetDirectoryName(textBox.Text); } catch { }

            openFileDialog.FileName = textBox.Text;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBox.Text = openFileDialog.FileName;
        }
    }
}
