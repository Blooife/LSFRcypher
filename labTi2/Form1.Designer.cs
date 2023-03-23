namespace labTi2
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.inputKey = new System.Windows.Forms.TextBox();
            this.FileText = new System.Windows.Forms.RichTextBox();
            this.keyText = new System.Windows.Forms.RichTextBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.cipherText = new System.Windows.Forms.RichTextBox();
            this.ButCrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ButSave = new System.Windows.Forms.Button();
            this.butDecipher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // inputKey
            // 
            this.inputKey.Location = new System.Drawing.Point(400, 51);
            this.inputKey.MaxLength = 26;
            this.inputKey.Name = "inputKey";
            this.inputKey.Size = new System.Drawing.Size(270, 20);
            this.inputKey.TabIndex = 0;
            this.inputKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputKey_KeyPress);
            // 
            // FileText
            // 
            this.FileText.Location = new System.Drawing.Point(12, 110);
            this.FileText.Name = "FileText";
            this.FileText.Size = new System.Drawing.Size(275, 367);
            this.FileText.TabIndex = 1;
            this.FileText.Text = "";
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(400, 114);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(270, 363);
            this.keyText.TabIndex = 2;
            this.keyText.Text = "";
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(23, 25);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(102, 27);
            this.OpenFile.TabIndex = 3;
            this.OpenFile.Text = "OpenFile";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // cipherText
            // 
            this.cipherText.Location = new System.Drawing.Point(710, 114);
            this.cipherText.Name = "cipherText";
            this.cipherText.Size = new System.Drawing.Size(283, 363);
            this.cipherText.TabIndex = 4;
            this.cipherText.Text = "";
            // 
            // ButCrypt
            // 
            this.ButCrypt.Location = new System.Drawing.Point(298, 200);
            this.ButCrypt.Name = "ButCrypt";
            this.ButCrypt.Size = new System.Drawing.Size(96, 32);
            this.ButCrypt.TabIndex = 5;
            this.ButCrypt.Text = "Зашифровать";
            this.ButCrypt.UseVisualStyleBackColor = true;
            this.ButCrypt.Click += new System.EventHandler(this.ButCrypt_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(400, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сгенерированный ключ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(710, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Шифротекст";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(30, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Исходный текст";
            // 
            // ButSave
            // 
            this.ButSave.Location = new System.Drawing.Point(156, 26);
            this.ButSave.Name = "ButSave";
            this.ButSave.Size = new System.Drawing.Size(92, 25);
            this.ButSave.TabIndex = 10;
            this.ButSave.Text = "SaveToFile";
            this.ButSave.UseVisualStyleBackColor = true;
            this.ButSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // butDecipher
            // 
            this.butDecipher.Location = new System.Drawing.Point(298, 250);
            this.butDecipher.Name = "butDecipher";
            this.butDecipher.Size = new System.Drawing.Size(96, 32);
            this.butDecipher.TabIndex = 11;
            this.butDecipher.Text = "Расшифровать";
            this.butDecipher.UseVisualStyleBackColor = true;
            this.butDecipher.Click += new System.EventHandler(this.butDecipher_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 506);
            this.Controls.Add(this.butDecipher);
            this.Controls.Add(this.ButSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButCrypt);
            this.Controls.Add(this.cipherText);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.FileText);
            this.Controls.Add(this.inputKey);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button butDecipher;

        private System.Windows.Forms.Button ButSave;

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.RichTextBox cipherText;
        private System.Windows.Forms.Button ButCrypt;

        private System.Windows.Forms.RichTextBox FileText;
        private System.Windows.Forms.RichTextBox keyText;
        private System.Windows.Forms.Button OpenFile;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox inputKey;

        #endregion
    }
}