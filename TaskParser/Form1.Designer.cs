namespace TaskParser
{
    partial class Form1
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
         this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
         this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
         this.beginLabel = new System.Windows.Forms.Label();
         this.endLabel = new System.Windows.Forms.Label();
         this.doItButton = new System.Windows.Forms.Button();
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.jiraAddressTextBox = new System.Windows.Forms.TextBox();
         this.jiraLabel = new System.Windows.Forms.Label();
         this.loginLabel = new System.Windows.Forms.Label();
         this.loginTextBox = new System.Windows.Forms.TextBox();
         this.passwordTextBox = new System.Windows.Forms.TextBox();
         this.passwordLabel = new System.Windows.Forms.Label();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.checkBox_Resolved = new System.Windows.Forms.CheckBox();
         this.buttonSaveToFile = new System.Windows.Forms.Button();
         this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
         this.checkBox_asHtml = new System.Windows.Forms.CheckBox();
         this.checkBox_NeedShowPriority = new System.Windows.Forms.CheckBox();
         this.checkBox_FIxVersion = new System.Windows.Forms.CheckBox();
         this.checkBox_IgnoreClosed = new System.Windows.Forms.CheckBox();
         this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
         this.panel_Header = new System.Windows.Forms.Panel();
         this.panel_Header.SuspendLayout();
         this.SuspendLayout();
         // 
         // beginDateTimePicker
         // 
         this.beginDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
         this.beginDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.beginDateTimePicker.Location = new System.Drawing.Point(53, 13);
         this.beginDateTimePicker.Name = "beginDateTimePicker";
         this.beginDateTimePicker.Size = new System.Drawing.Size(139, 20);
         this.beginDateTimePicker.TabIndex = 0;
         // 
         // endDateTimePicker
         // 
         this.endDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
         this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.endDateTimePicker.Location = new System.Drawing.Point(245, 13);
         this.endDateTimePicker.Name = "endDateTimePicker";
         this.endDateTimePicker.Size = new System.Drawing.Size(139, 20);
         this.endDateTimePicker.TabIndex = 1;
         // 
         // beginLabel
         // 
         this.beginLabel.AutoSize = true;
         this.beginLabel.Location = new System.Drawing.Point(34, 17);
         this.beginLabel.Name = "beginLabel";
         this.beginLabel.Size = new System.Drawing.Size(13, 13);
         this.beginLabel.TabIndex = 2;
         this.beginLabel.Text = "с";
         // 
         // endLabel
         // 
         this.endLabel.AutoSize = true;
         this.endLabel.Location = new System.Drawing.Point(213, 17);
         this.endLabel.Name = "endLabel";
         this.endLabel.Size = new System.Drawing.Size(19, 13);
         this.endLabel.TabIndex = 3;
         this.endLabel.Text = "по";
         // 
         // doItButton
         // 
         this.doItButton.Location = new System.Drawing.Point(390, 88);
         this.doItButton.Name = "doItButton";
         this.doItButton.Size = new System.Drawing.Size(125, 23);
         this.doItButton.TabIndex = 4;
         this.doItButton.Text = "Распарсить";
         this.doItButton.UseVisualStyleBackColor = true;
         this.doItButton.Click += new System.EventHandler(this.doItButton_Click);
         // 
         // richTextBox1
         // 
         this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox1.Location = new System.Drawing.Point(0, 129);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(751, 285);
         this.richTextBox1.TabIndex = 5;
         this.richTextBox1.Text = "";
         this.richTextBox1.WordWrap = false;
         this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
         // 
         // jiraAddressTextBox
         // 
         this.jiraAddressTextBox.Location = new System.Drawing.Point(53, 39);
         this.jiraAddressTextBox.Name = "jiraAddressTextBox";
         this.jiraAddressTextBox.Size = new System.Drawing.Size(331, 20);
         this.jiraAddressTextBox.TabIndex = 6;
         this.jiraAddressTextBox.Text = "http://jira/";
         // 
         // jiraLabel
         // 
         this.jiraLabel.AutoSize = true;
         this.jiraLabel.Location = new System.Drawing.Point(3, 43);
         this.jiraLabel.Name = "jiraLabel";
         this.jiraLabel.Size = new System.Drawing.Size(49, 13);
         this.jiraLabel.TabIndex = 7;
         this.jiraLabel.Text = "сайт Jira";
         // 
         // loginLabel
         // 
         this.loginLabel.AutoSize = true;
         this.loginLabel.Location = new System.Drawing.Point(11, 67);
         this.loginLabel.Name = "loginLabel";
         this.loginLabel.Size = new System.Drawing.Size(36, 13);
         this.loginLabel.TabIndex = 8;
         this.loginLabel.Text = "логин";
         // 
         // loginTextBox
         // 
         this.loginTextBox.Location = new System.Drawing.Point(53, 64);
         this.loginTextBox.Name = "loginTextBox";
         this.loginTextBox.Size = new System.Drawing.Size(331, 20);
         this.loginTextBox.TabIndex = 9;
         this.loginTextBox.Text = "ninja";
         // 
         // passwordTextBox
         // 
         this.passwordTextBox.Location = new System.Drawing.Point(53, 90);
         this.passwordTextBox.Name = "passwordTextBox";
         this.passwordTextBox.PasswordChar = '*';
         this.passwordTextBox.Size = new System.Drawing.Size(331, 20);
         this.passwordTextBox.TabIndex = 11;
         this.passwordTextBox.Text = "123";
         // 
         // passwordLabel
         // 
         this.passwordLabel.AutoSize = true;
         this.passwordLabel.Location = new System.Drawing.Point(11, 93);
         this.passwordLabel.Name = "passwordLabel";
         this.passwordLabel.Size = new System.Drawing.Size(43, 13);
         this.passwordLabel.TabIndex = 10;
         this.passwordLabel.Text = "пароль";
         // 
         // progressBar1
         // 
         this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.progressBar1.Location = new System.Drawing.Point(0, 510);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(751, 17);
         this.progressBar1.TabIndex = 12;
         // 
         // checkBox_Resolved
         // 
         this.checkBox_Resolved.AutoSize = true;
         this.checkBox_Resolved.Location = new System.Drawing.Point(401, 16);
         this.checkBox_Resolved.Name = "checkBox_Resolved";
         this.checkBox_Resolved.Size = new System.Drawing.Size(112, 17);
         this.checkBox_Resolved.TabIndex = 13;
         this.checkBox_Resolved.Text = "Только решеные";
         this.checkBox_Resolved.UseVisualStyleBackColor = true;
         this.checkBox_Resolved.CheckedChanged += new System.EventHandler(this.checkBox_Resolved_CheckedChanged);
         // 
         // buttonSaveToFile
         // 
         this.buttonSaveToFile.Location = new System.Drawing.Point(521, 88);
         this.buttonSaveToFile.Name = "buttonSaveToFile";
         this.buttonSaveToFile.Size = new System.Drawing.Size(123, 23);
         this.buttonSaveToFile.TabIndex = 14;
         this.buttonSaveToFile.Text = "Сохранить в файл";
         this.buttonSaveToFile.UseVisualStyleBackColor = true;
         this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
         // 
         // checkBox_asHtml
         // 
         this.checkBox_asHtml.AutoSize = true;
         this.checkBox_asHtml.Location = new System.Drawing.Point(401, 43);
         this.checkBox_asHtml.Name = "checkBox_asHtml";
         this.checkBox_asHtml.Size = new System.Drawing.Size(98, 17);
         this.checkBox_asHtml.TabIndex = 15;
         this.checkBox_asHtml.Text = "Save as HTML";
         this.checkBox_asHtml.UseVisualStyleBackColor = true;
         // 
         // checkBox_NeedShowPriority
         // 
         this.checkBox_NeedShowPriority.AutoSize = true;
         this.checkBox_NeedShowPriority.Checked = true;
         this.checkBox_NeedShowPriority.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_NeedShowPriority.Location = new System.Drawing.Point(401, 67);
         this.checkBox_NeedShowPriority.Name = "checkBox_NeedShowPriority";
         this.checkBox_NeedShowPriority.Size = new System.Drawing.Size(116, 17);
         this.checkBox_NeedShowPriority.TabIndex = 16;
         this.checkBox_NeedShowPriority.Text = "Need Show Priority";
         this.checkBox_NeedShowPriority.UseVisualStyleBackColor = true;
         // 
         // checkBox_FIxVersion
         // 
         this.checkBox_FIxVersion.AutoSize = true;
         this.checkBox_FIxVersion.Checked = true;
         this.checkBox_FIxVersion.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_FIxVersion.Location = new System.Drawing.Point(523, 66);
         this.checkBox_FIxVersion.Name = "checkBox_FIxVersion";
         this.checkBox_FIxVersion.Size = new System.Drawing.Size(77, 17);
         this.checkBox_FIxVersion.TabIndex = 17;
         this.checkBox_FIxVersion.Text = "Fix Version";
         this.checkBox_FIxVersion.UseVisualStyleBackColor = true;
         // 
         // checkBox_IgnoreClosed
         // 
         this.checkBox_IgnoreClosed.AutoSize = true;
         this.checkBox_IgnoreClosed.Location = new System.Drawing.Point(523, 16);
         this.checkBox_IgnoreClosed.Name = "checkBox_IgnoreClosed";
         this.checkBox_IgnoreClosed.Size = new System.Drawing.Size(113, 17);
         this.checkBox_IgnoreClosed.TabIndex = 18;
         this.checkBox_IgnoreClosed.Text = "Кроме Закрытых";
         this.checkBox_IgnoreClosed.UseVisualStyleBackColor = true;
         this.checkBox_IgnoreClosed.CheckedChanged += new System.EventHandler(this.checkBox_IgnoreClosed_CheckedChanged);
         // 
         // richTextBox_Log
         // 
         this.richTextBox_Log.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.richTextBox_Log.Location = new System.Drawing.Point(0, 414);
         this.richTextBox_Log.Name = "richTextBox_Log";
         this.richTextBox_Log.ReadOnly = true;
         this.richTextBox_Log.Size = new System.Drawing.Size(751, 96);
         this.richTextBox_Log.TabIndex = 19;
         this.richTextBox_Log.Text = "";
         // 
         // panel_Header
         // 
         this.panel_Header.Controls.Add(this.beginLabel);
         this.panel_Header.Controls.Add(this.beginDateTimePicker);
         this.panel_Header.Controls.Add(this.checkBox_IgnoreClosed);
         this.panel_Header.Controls.Add(this.endDateTimePicker);
         this.panel_Header.Controls.Add(this.checkBox_FIxVersion);
         this.panel_Header.Controls.Add(this.endLabel);
         this.panel_Header.Controls.Add(this.checkBox_NeedShowPriority);
         this.panel_Header.Controls.Add(this.doItButton);
         this.panel_Header.Controls.Add(this.checkBox_asHtml);
         this.panel_Header.Controls.Add(this.jiraAddressTextBox);
         this.panel_Header.Controls.Add(this.buttonSaveToFile);
         this.panel_Header.Controls.Add(this.jiraLabel);
         this.panel_Header.Controls.Add(this.checkBox_Resolved);
         this.panel_Header.Controls.Add(this.loginLabel);
         this.panel_Header.Controls.Add(this.loginTextBox);
         this.panel_Header.Controls.Add(this.passwordTextBox);
         this.panel_Header.Controls.Add(this.passwordLabel);
         this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_Header.Location = new System.Drawing.Point(0, 0);
         this.panel_Header.Name = "panel_Header";
         this.panel_Header.Size = new System.Drawing.Size(751, 129);
         this.panel_Header.TabIndex = 20;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(751, 527);
         this.Controls.Add(this.richTextBox1);
         this.Controls.Add(this.panel_Header);
         this.Controls.Add(this.richTextBox_Log);
         this.Controls.Add(this.progressBar1);
         this.Name = "Form1";
         this.Text = "JIRA Task Parser";
         this.panel_Header.ResumeLayout(false);
         this.panel_Header.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label beginLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Button doItButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox jiraAddressTextBox;
        private System.Windows.Forms.Label jiraLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox_Resolved;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBox_asHtml;
        private System.Windows.Forms.CheckBox checkBox_NeedShowPriority;
        private System.Windows.Forms.CheckBox checkBox_FIxVersion;
		private System.Windows.Forms.CheckBox checkBox_IgnoreClosed;
      private System.Windows.Forms.RichTextBox richTextBox_Log;
      private System.Windows.Forms.Panel panel_Header;
   }
}

