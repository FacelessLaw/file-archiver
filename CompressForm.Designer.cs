namespace PiedPiper
{
  partial class CompressForm
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompressForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lbIncludes = new System.Windows.Forms.ListBox();
            this.bIncludeFolder = new System.Windows.Forms.Button();
            this.bExcludeFolder = new System.Windows.Forms.Button();
            this.lbExclude = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNoCompression = new System.Windows.Forms.CheckBox();
            this.cbRemoveSource = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bCompress = new System.Windows.Forms.Button();
            this.bIncludeFile = new System.Windows.Forms.Button();
            this.bExcludeFile = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Включаемые пути";
            // 
            // lbIncludes
            // 
            this.lbIncludes.FormattingEnabled = true;
            this.lbIncludes.HorizontalScrollbar = true;
            this.lbIncludes.Location = new System.Drawing.Point(12, 25);
            this.lbIncludes.Name = "lbIncludes";
            this.lbIncludes.Size = new System.Drawing.Size(400, 69);
            this.lbIncludes.TabIndex = 5;
            // 
            // bIncludeFolder
            // 
            this.bIncludeFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bIncludeFolder.Location = new System.Drawing.Point(419, 25);
            this.bIncludeFolder.Name = "bIncludeFolder";
            this.bIncludeFolder.Size = new System.Drawing.Size(75, 23);
            this.bIncludeFolder.TabIndex = 6;
            this.bIncludeFolder.Text = "Каталог";
            this.bIncludeFolder.UseVisualStyleBackColor = true;
            this.bIncludeFolder.Click += new System.EventHandler(this.bInclude_Click);
            // 
            // bExcludeFolder
            // 
            this.bExcludeFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExcludeFolder.Location = new System.Drawing.Point(418, 121);
            this.bExcludeFolder.Name = "bExcludeFolder";
            this.bExcludeFolder.Size = new System.Drawing.Size(75, 23);
            this.bExcludeFolder.TabIndex = 7;
            this.bExcludeFolder.Text = "Каталог";
            this.bExcludeFolder.UseVisualStyleBackColor = true;
            this.bExcludeFolder.Click += new System.EventHandler(this.bExcludeFolder_Click);
            // 
            // lbExclude
            // 
            this.lbExclude.FormattingEnabled = true;
            this.lbExclude.HorizontalScrollbar = true;
            this.lbExclude.Location = new System.Drawing.Point(12, 121);
            this.lbExclude.Name = "lbExclude";
            this.lbExclude.Size = new System.Drawing.Size(400, 69);
            this.lbExclude.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Исключающие пути";
            // 
            // cbNoCompression
            // 
            this.cbNoCompression.AutoSize = true;
            this.cbNoCompression.Location = new System.Drawing.Point(12, 197);
            this.cbNoCompression.Name = "cbNoCompression";
            this.cbNoCompression.Size = new System.Drawing.Size(85, 17);
            this.cbNoCompression.TabIndex = 10;
            this.cbNoCompression.Text = "Без сжатия";
            this.cbNoCompression.UseVisualStyleBackColor = true;
            // 
            // cbRemoveSource
            // 
            this.cbRemoveSource.AutoSize = true;
            this.cbRemoveSource.Location = new System.Drawing.Point(12, 220);
            this.cbRemoveSource.Name = "cbRemoveSource";
            this.cbRemoveSource.Size = new System.Drawing.Size(118, 17);
            this.cbRemoveSource.TabIndex = 11;
            this.cbRemoveSource.Text = "Удалять источник";
            this.cbRemoveSource.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(283, 197);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(129, 20);
            this.tbPassword.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Пароль";
            // 
            // bCompress
            // 
            this.bCompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCompress.Location = new System.Drawing.Point(283, 223);
            this.bCompress.Name = "bCompress";
            this.bCompress.Size = new System.Drawing.Size(210, 56);
            this.bCompress.TabIndex = 14;
            this.bCompress.Text = "Сжать";
            this.bCompress.UseVisualStyleBackColor = true;
            this.bCompress.Click += new System.EventHandler(this.bCompress_Click);
            // 
            // bIncludeFile
            // 
            this.bIncludeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bIncludeFile.Location = new System.Drawing.Point(419, 54);
            this.bIncludeFile.Name = "bIncludeFile";
            this.bIncludeFile.Size = new System.Drawing.Size(75, 23);
            this.bIncludeFile.TabIndex = 15;
            this.bIncludeFile.Text = "Файл";
            this.bIncludeFile.UseVisualStyleBackColor = true;
            this.bIncludeFile.Click += new System.EventHandler(this.bIncludeFile_Click);
            // 
            // bExcludeFile
            // 
            this.bExcludeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExcludeFile.Location = new System.Drawing.Point(418, 150);
            this.bExcludeFile.Name = "bExcludeFile";
            this.bExcludeFile.Size = new System.Drawing.Size(75, 23);
            this.bExcludeFile.TabIndex = 16;
            this.bExcludeFile.Text = "Файл";
            this.bExcludeFile.UseVisualStyleBackColor = true;
            this.bExcludeFile.Click += new System.EventHandler(this.bExcludeFile_Click);
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.Location = new System.Drawing.Point(0, 287);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(508, 69);
            this.lbLog.TabIndex = 17;
            // 
            // CompressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 356);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.bExcludeFile);
            this.Controls.Add(this.bIncludeFile);
            this.Controls.Add(this.bCompress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.cbRemoveSource);
            this.Controls.Add(this.cbNoCompression);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbExclude);
            this.Controls.Add(this.bExcludeFolder);
            this.Controls.Add(this.bIncludeFolder);
            this.Controls.Add(this.lbIncludes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CompressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Архивация";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox lbIncludes;
    private System.Windows.Forms.Button bIncludeFolder;
    private System.Windows.Forms.Button bExcludeFolder;
    private System.Windows.Forms.ListBox lbExclude;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox cbNoCompression;
    private System.Windows.Forms.CheckBox cbRemoveSource;
    private System.Windows.Forms.TextBox tbPassword;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button bCompress;
    private System.Windows.Forms.Button bIncludeFile;
    private System.Windows.Forms.Button bExcludeFile;
    private System.Windows.Forms.ListBox lbLog;
  }
}

