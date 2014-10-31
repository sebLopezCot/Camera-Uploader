using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camera_Uploader
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void setProgressText(String message)
        {
            progressText.Text = message;
        }

        public void setProgressBarValue(int value)
        {
            progressBar.Value = value;
        }

        public void setImageHolder(Image picture) 
        {
            imageHolder.Image = picture;
        }
    }
}
