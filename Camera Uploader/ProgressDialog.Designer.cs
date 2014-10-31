namespace Camera_Uploader
{
    partial class ProgressDialog
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.imageHolder = new System.Windows.Forms.PictureBox();
            this.progressText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageHolder)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 66);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(255, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.UseWaitCursor = true;
            // 
            // imageHolder
            // 
            this.imageHolder.Location = new System.Drawing.Point(273, 12);
            this.imageHolder.Name = "imageHolder";
            this.imageHolder.Size = new System.Drawing.Size(130, 102);
            this.imageHolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageHolder.TabIndex = 1;
            this.imageHolder.TabStop = false;
            // 
            // progressText
            // 
            this.progressText.AutoSize = true;
            this.progressText.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressText.Location = new System.Drawing.Point(50, 36);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(173, 18);
            this.progressText.TabIndex = 2;
            this.progressText.Text = "Moving picture 1 of 32";
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 126);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.imageHolder);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProgressDialog";
            this.Text = "ProgressDialog";
            ((System.ComponentModel.ISupportInitialize)(this.imageHolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox imageHolder;
        private System.Windows.Forms.Label progressText;
    }
}