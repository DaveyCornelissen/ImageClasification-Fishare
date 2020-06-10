using ClassificationSandboxML.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandBox
{
    public partial class Form1 : Form
    {
        public string _selectedFile { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pbSelectedImage.Image = new Bitmap(open.FileName);
                // image file path  
                _selectedFile = open.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Add input data
            var input = new ModelInput
            {
                ImageSource = _selectedFile
            };


            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            lblResult.Text = result.Prediction;
        }

    }
}
