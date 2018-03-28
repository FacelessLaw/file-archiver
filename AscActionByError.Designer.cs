namespace PiedPiper
{
  partial class AscActionByError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AscActionByError));
            this.bAbort = new System.Windows.Forms.Button();
            this.bIgnore = new System.Windows.Forms.Button();
            this.bReplay = new System.Windows.Forms.Button();
            this.lText = new System.Windows.Forms.Label();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.bIgnoreAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAbort
            // 
            this.bAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAbort.Location = new System.Drawing.Point(242, 191);
            this.bAbort.Name = "bAbort";
            this.bAbort.Size = new System.Drawing.Size(102, 23);
            this.bAbort.TabIndex = 0;
            this.bAbort.Text = "Прервать";
            this.bAbort.UseVisualStyleBackColor = true;
            this.bAbort.Click += new System.EventHandler(this.button1_Click);
            // 
            // bIgnore
            // 
            this.bIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bIgnore.Location = new System.Drawing.Point(134, 191);
            this.bIgnore.Name = "bIgnore";
            this.bIgnore.Size = new System.Drawing.Size(102, 23);
            this.bIgnore.TabIndex = 1;
            this.bIgnore.Text = "Пропустить";
            this.bIgnore.UseVisualStyleBackColor = true;
            this.bIgnore.Click += new System.EventHandler(this.button2_Click);
            // 
            // bReplay
            // 
            this.bReplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReplay.Location = new System.Drawing.Point(350, 191);
            this.bReplay.Name = "bReplay";
            this.bReplay.Size = new System.Drawing.Size(102, 23);
            this.bReplay.TabIndex = 2;
            this.bReplay.Text = "Повторить";
            this.bReplay.UseVisualStyleBackColor = true;
            this.bReplay.Click += new System.EventHandler(this.button3_Click);
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Location = new System.Drawing.Point(23, 13);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(35, 13);
            this.lText.TabIndex = 3;
            this.lText.Text = "label1";
            // 
            // tbMsg
            // 
            this.tbMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMsg.Location = new System.Drawing.Point(26, 42);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ReadOnly = true;
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMsg.Size = new System.Drawing.Size(426, 143);
            this.tbMsg.TabIndex = 4;
            // 
            // bIgnoreAll
            // 
            this.bIgnoreAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bIgnoreAll.Location = new System.Drawing.Point(26, 191);
            this.bIgnoreAll.Name = "bIgnoreAll";
            this.bIgnoreAll.Size = new System.Drawing.Size(102, 23);
            this.bIgnoreAll.TabIndex = 5;
            this.bIgnoreAll.Text = "Пропустить все";
            this.bIgnoreAll.UseVisualStyleBackColor = true;
            this.bIgnoreAll.Click += new System.EventHandler(this.bIgnoreAll_Click);
            // 
            // AscActionByError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 224);
            this.Controls.Add(this.bIgnoreAll);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.bReplay);
            this.Controls.Add(this.bIgnore);
            this.Controls.Add(this.bAbort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AscActionByError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ошибка";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bAbort;
    private System.Windows.Forms.Button bIgnore;
    private System.Windows.Forms.Button bReplay;
    private System.Windows.Forms.Label lText;
    private System.Windows.Forms.TextBox tbMsg;
    private System.Windows.Forms.Button bIgnoreAll;
  }
}