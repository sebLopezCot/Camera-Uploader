namespace Camera_Uploader
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.driveFeedbackLabel = new System.Windows.Forms.Label();
            this.selectPhotosButton = new System.Windows.Forms.Button();
            this.selectPhotosDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.destinationFolderButton = new System.Windows.Forms.Button();
            this.destinationFolderDialogBox = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Azure;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(296, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Welcome to Camera Uploader!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Step 1: Plug your device into the computer.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Step 2: Select the photos you want.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(342, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Step 3: Choose where you want to put them.";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 41);
            this.panel1.TabIndex = 4;
            // 
            // driveFeedbackLabel
            // 
            this.driveFeedbackLabel.AutoSize = true;
            this.driveFeedbackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveFeedbackLabel.Location = new System.Drawing.Point(47, 91);
            this.driveFeedbackLabel.Name = "driveFeedbackLabel";
            this.driveFeedbackLabel.Size = new System.Drawing.Size(193, 18);
            this.driveFeedbackLabel.TabIndex = 5;
            this.driveFeedbackLabel.Text = "Still waiting for your device...";
            // 
            // selectPhotosButton
            // 
            this.selectPhotosButton.BackColor = System.Drawing.Color.AliceBlue;
            this.selectPhotosButton.Enabled = false;
            this.selectPhotosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPhotosButton.Location = new System.Drawing.Point(27, 178);
            this.selectPhotosButton.Name = "selectPhotosButton";
            this.selectPhotosButton.Size = new System.Drawing.Size(272, 27);
            this.selectPhotosButton.TabIndex = 6;
            this.selectPhotosButton.Text = "Select Photos...";
            this.selectPhotosButton.UseVisualStyleBackColor = false;
            this.selectPhotosButton.Click += new System.EventHandler(this.selectPhotosButton_Click);
            // 
            // selectPhotosDialogBox
            // 
            this.selectPhotosDialogBox.Multiselect = true;
            this.selectPhotosDialogBox.Title = "Select Photos";
            this.selectPhotosDialogBox.FileOk += new System.ComponentModel.CancelEventHandler(this.selectPhotosDialogBox_FileOk);
            // 
            // destinationFolderButton
            // 
            this.destinationFolderButton.BackColor = System.Drawing.Color.AliceBlue;
            this.destinationFolderButton.Enabled = false;
            this.destinationFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationFolderButton.Location = new System.Drawing.Point(27, 280);
            this.destinationFolderButton.Name = "destinationFolderButton";
            this.destinationFolderButton.Size = new System.Drawing.Size(272, 27);
            this.destinationFolderButton.TabIndex = 7;
            this.destinationFolderButton.Text = "Select Destination Folder...";
            this.destinationFolderButton.UseVisualStyleBackColor = false;
            this.destinationFolderButton.Click += new System.EventHandler(this.destinationFolderButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 355);
            this.Controls.Add(this.destinationFolderButton);
            this.Controls.Add(this.selectPhotosButton);
            this.Controls.Add(this.driveFeedbackLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Camera Uploader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label driveFeedbackLabel;
        private System.Windows.Forms.Button selectPhotosButton;
        private System.Windows.Forms.OpenFileDialog selectPhotosDialogBox;
        private System.Windows.Forms.Button destinationFolderButton;
        private System.Windows.Forms.FolderBrowserDialog destinationFolderDialogBox;
    }
}

