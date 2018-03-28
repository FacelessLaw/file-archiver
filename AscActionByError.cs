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
  public partial class AscActionByError : Form
  {
    public OperationErrorAction Result = 0;

    public AscActionByError(string caption, string text)
    {
      InitializeComponent();
      lText.Text = caption;
      tbMsg.Text = text;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Result = OperationErrorAction.Abort;
      Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Result = OperationErrorAction.Ignore;
      Close();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      Result = OperationErrorAction.Replay;
      Close();
    }

    private void bIgnoreAll_Click(object sender, EventArgs e)
    {
      Result = OperationErrorAction.IgnoreAll;
      Close();
    }
  }
}
