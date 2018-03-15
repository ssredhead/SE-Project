namespace Parse
{
    partial class frmChooseFile
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
            this.btnFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblTest = new System.Windows.Forms.Label();
            this.lstTest = new System.Windows.Forms.ListBox();
            this.lblChoose = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(131, 33);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "Choose File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(46, 110);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(244, 13);
            this.lblTest.TabIndex = 1;
            this.lblTest.Text = "This label and listbox are both solely for debugging";
            // 
            // lstTest
            // 
            this.lstTest.FormattingEnabled = true;
            this.lstTest.HorizontalScrollbar = true;
            this.lstTest.Location = new System.Drawing.Point(35, 126);
            this.lstTest.Name = "lstTest";
            this.lstTest.Size = new System.Drawing.Size(267, 199);
            this.lstTest.TabIndex = 2;
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(114, 17);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(109, 13);
            this.lblChoose.TabIndex = 3;
            this.lblChoose.Text = "Choose a file to parse";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.ForeColor = System.Drawing.Color.Red;
            this.lblCreated.Location = new System.Drawing.Point(21, 69);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(294, 13);
            this.lblCreated.TabIndex = 4;
            this.lblCreated.Text = "Your file has been created and is in the My Documents folder";
            this.lblCreated.Visible = false;
            // 
            // frmChooseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 350);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.lstTest);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnFile);
            this.Name = "frmChooseFile";
            this.Text = "Choose File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.ListBox lstTest;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.Label lblCreated;
    }
}

