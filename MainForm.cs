using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace PiedPiper
{
  public partial class MainForm : Form
  {
        public MainForm()
        {
          InitializeComponent();
        }

        private void bCompress_Click(object sender, EventArgs e)
        {
          new CompressForm().ShowDialog();
        }

        private void bDecompress_Click(object sender, EventArgs e)
        {
          new DecompressForm().ShowDialog();
        }

        private void ExtBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
  }
}
