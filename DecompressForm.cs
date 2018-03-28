using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiedPiper
{
    public partial class DecompressForm : Form
    {
        ArchiveProvider decompressor = new ArchiveProvider();

        public DecompressForm()
        {
            InitializeComponent();
        }

        private void bArcView_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbArchive.Text = ofd.FileName;
                }
            }
        }

        private void bDecompress_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    decompressor.Decompress(tbArchive.Text, fbd.SelectedPath, tbPassword.Text);
                }
            }
        }
    }
}
