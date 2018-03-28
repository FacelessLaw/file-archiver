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
    public partial class CompressForm : Form
    {
        ArchiveProvider compressor = new ArchiveProvider();

        public CompressForm()
        {
            InitializeComponent();
            compressor.ProcessMessages += compressor_ProcessMessages;
            compressor.ErrorProcessing += ProcessingFileError;
        }

        void compressor_ProcessMessages(string message)
        {
            lbLog.Items.Add(message);
        }

        OperationErrorAction ProcessingFileError(string caption, string message)
        {
            using (AscActionByError form = new AscActionByError(caption, message))
            {
                form.ShowDialog();
                return form.Result;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    label1.Text = fbd.SelectedPath;
                }
            }
        }

        private void bCompress_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CompressorOption option = new CompressorOption()
                    {
                        Password = tbPassword.Text,
                        WithoutCompress = cbNoCompression.Checked,
                        RemoveSource = cbRemoveSource.Checked,
                        Output = sfd.FileName
                    };
                    foreach (string line in lbIncludes.Items)
                        option.IncludePath.Add(line);
                    foreach (string line in lbExclude.Items)
                        option.ExcludePath.Add(line);
                    compressor.Compress(option);
                }
            }
        }

        private void bInclude_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    lbIncludes.Items.Add(fbd.SelectedPath);
            }
        }

        private void bExcludeFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    lbExclude.Items.Add(fbd.SelectedPath);
            }
        }

        private void bIncludeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lbIncludes.Items.Add(ofd.FileName);
                }
            }
        }

        private void bExcludeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lbExclude.Items.Add(ofd.FileName);
                }
            }
        }
    }
}
