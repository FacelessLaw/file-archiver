namespace PiedPiper
{
  partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bCompress = new System.Windows.Forms.Button();
            this.bDecompress = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ExtBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bCompress
            // 
            this.bCompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCompress.Location = new System.Drawing.Point(133, 12);
            this.bCompress.Name = "bCompress";
            this.bCompress.Size = new System.Drawing.Size(198, 23);
            this.bCompress.TabIndex = 0;
            this.bCompress.Text = "Архивация";
            this.bCompress.UseVisualStyleBackColor = true;
            this.bCompress.Click += new System.EventHandler(this.bCompress_Click);
            // 
            // bDecompress
            // 
            this.bDecompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDecompress.Location = new System.Drawing.Point(133, 41);
            this.bDecompress.Name = "bDecompress";
            this.bDecompress.Size = new System.Drawing.Size(198, 23);
            this.bDecompress.TabIndex = 1;
            this.bDecompress.Text = "Разархивация";
            this.bDecompress.UseVisualStyleBackColor = true;
            this.bDecompress.Click += new System.EventHandler(this.bDecompress_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 98);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ExtBtn
            // 
            this.ExtBtn.Location = new System.Drawing.Point(256, 87);
            this.ExtBtn.Name = "ExtBtn";
            this.ExtBtn.Size = new System.Drawing.Size(75, 23);
            this.ExtBtn.TabIndex = 3;
            this.ExtBtn.Text = "Выход";
            this.ExtBtn.UseVisualStyleBackColor = true;
            this.ExtBtn.Click += new System.EventHandler(this.ExtBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 122);
            this.Controls.Add(this.ExtBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bDecompress);
            this.Controls.Add(this.bCompress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PiedPiper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button bCompress;
    private System.Windows.Forms.Button bDecompress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ExtBtn;
    }
}