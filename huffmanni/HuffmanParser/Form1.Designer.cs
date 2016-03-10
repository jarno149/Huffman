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
            this.SuspendLayout();
            // 
            // FilePack
            // 
            this.FilePack.Location = new System.Drawing.Point(757, 14);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 430);
            this.Controls.Add(this.TextBlock);
            this.Controls.Add(this.FilePack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FilePack;
        private System.Windows.Forms.RichTextBox TextBlock;
    }
}

