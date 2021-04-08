using System;
using System.Drawing;
using System.Windows.Forms;


namespace Bdsh.Sync
{
    public partial class FormSync : Form
    {
        public FormSync()
        {
            InitializeComponent();
            Height = 410;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlSync.SelectedIndex)
            {
                case 0:
                    switch (Include.SelectedIndex)
                    {
                        case 0: MinimumSize = new Size(650, 410); break;
                        case 1: MinimumSize = new Size(650, 700); break;
                    }
                    break;
                case 1:
                    switch (tabControlDBPhysicalStructure.SelectedIndex)
                    {
                        case 0: MinimumSize = new Size(650, 330); break;
                        case 1: MinimumSize = new Size(650, 473); break;
                    }
                    break;
                case 2:
                    switch (tabControlDBLogicalStructure.SelectedIndex)
                    {
                        case 0: MinimumSize = new Size(650, 540); break;
                        case 1: MinimumSize = new Size(650, 200); break;
                    }
                    break;
            }

            Height = MinimumSize.Height;
        }

        private void installationCollectControl_Load(object sender, EventArgs e)
        {

        }
    }
}
