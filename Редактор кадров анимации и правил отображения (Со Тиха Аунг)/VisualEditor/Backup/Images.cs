using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisualEditor
{
    /// <summary>
    /// Окно редактирования изображений
    /// </summary>
    public partial class Images : Form
    {
        public Images()
        {
            InitializeComponent();
        }
        public string imageName
        {
            get { return nameImage.Text; }
            set { nameImage.Text = value; }
        }
        public string imagePath
        {
            get { return pathImage.Text; }
            set { pathImage.Text = value; }
        }
        public string imageWidth
        {
            get { return widthImage.Text ; }
            set { widthImage.Text = value; }
        }
        public string imageHeight
        {
            get { return heightImage.Text; }
            set { heightImage.Text = value; }
        }

        private void addImage_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
