using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bdsh.Sync.Tabs.Utils
{
    class DragDrop
    {
        public static void TextBoxDirectory_DragEnter(object sender, DragEventArgs e)
        {
            string[] dragList = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (dragList.Length == 1 && Directory.Exists(dragList[0]))
                e.Effect = DragDropEffects.Copy;
        }

        public static void TextBoxFile_DragEnter(object sender, DragEventArgs e)
        {
            string[] dragList = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (dragList.Length == 1 && File.Exists(dragList[0]))
                e.Effect = DragDropEffects.Copy;
        }

        public static void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data as DataObject;

            if (data.ContainsFileDropList())
                (sender as TextBox).Text = (e.Data.GetData(DataFormats.FileDrop) as string[]).First();
        }

    }
}
