namespace HuffmanParser
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
            this.FilePack = new System.Windows.Forms.Button();
            this.TextBlock = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FilePack
            // 
            this.FilePack.Location = new System.Drawing.Point(608, 12);
            this.FilePack.Name = "FilePack";
            this.FilePack.Size = new System.Drawing.Size(98, 23);
            this.FilePack.TabIndex = 0;
            this.FilePack.Text = "Pakkaa tiedosto";
            this.FilePack.UseVisualStyleBackColor = true;
            this.FilePack.Click += new System.EventHandler(this.FilePack_Click);
            // 
            // TextBlock
            // 
            this.TextBlock.Location = new System.Drawing.Point(12, 14);
            this.TextBlock.Name = "TextBlock";
            this.TextBlock.Size = new System.Drawing.Size(590, 404);
            this.TextBlock.TabIndex = 1;
            this.TextBlock.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(608, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pura tiedosto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 430);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBlock);
            this.Controls.Add(this.FilePack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FilePack;
        private System.Windows.Forms.RichTextBox TextBlock;
        private System.Windows.Forms.Button button1;
    }
}

