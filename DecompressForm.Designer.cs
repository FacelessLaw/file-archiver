namespace PiedPiper
{
  partial class DecompressForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecompressForm));
            this.bArcView = new System.Windows.Forms.Button();
            this.bDecompress = new System.Windows.Forms.Button();
            this.tbArchive = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // bArcView
            // 
            this.bArcView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bArcView.Location = new System.Drawing.Point(374, 10);
            this.bArcView.Name = "bArcView";
            this.bArcView.Size = new System.Drawing.Size(89, 23);
            this.bArcView.TabIndex = 0;
            this.bArcView.Text = "Архив";
            this.bArcView.UseVisualStyleBackColor = true;
            this.bArcView.Click += new System.EventHandler(this.bArcView_Click);
            // 
            // bDecompress
            // 
            this.bDecompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDecompress.Location = new System.Drawing.Point(374, 39);
            this.bDecompress.Name = "bDecompress";
            this.bDecompress.Size = new System.Drawing.Size(89, 23);
            this.bDecompress.TabIndex = 1;
            this.bDecompress.Text = "Распаковать";
            this.bDecompress.UseVisualStyleBackColor = true;
            this.bDecompress.Click += new System.EventHandler(this.bDecompress_Click);
            // 
            // tbArchive
            // 
            this.tbArchive.Location = new System.Drawing.Point(12, 12);
            this.tbArchive.Name = "tbArchive";
            this.tbArchive.ReadOnly = true;
            this.tbArchive.Size = new System.Drawing.Size(356, 20);
            this.tbArchive.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(268, 41);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Пароль";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(0, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(475, 69);
            this.listBox1.TabIndex = 5;
            // 
            // DecompressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 140);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbArchive);
            this.Controls.Add(this.bDecompress);
            this.Controls.Add(this.bArcView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DecompressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Разархивация";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bArcView;
    private System.Windows.Forms.Button bDecompress;
    private System.Windows.Forms.TextBox tbArchive;
    private System.Windows.Forms.TextBox tbPassword;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox listBox1;
  }
}