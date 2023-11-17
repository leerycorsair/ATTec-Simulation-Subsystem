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
    /// Окно редактирования свободных текстов
    /// </summary>
    public partial class FreeText : Form
    {
        public FreeText()
        {
            InitializeComponent();
        }

        public string textDescription
        {
            get { return desText.Text; }
            set { desText.Text = value; }
        }
        public string textBackColor
        {
            get { return backTextColor.Text; }
            set { backTextColor.Text = value; }
        }
        public string textColor
        {
            get { return foreTextColor.Text; }
            set { foreTextColor.Text = value; }
        }

        public string textWidth
        {
            get { return widthText.Text; }
            set { widthText.Text = value; }
        }
        public string textHeight
        {
            get { return heightText.Text; }
            set { heightText.Text = value; }
        }
        public string textXCor
        {
            get { return xCorText.Text; }
            set { xCorText.Text = value; }
        }
        public string textYCor
        {
            get { return yCorText.Text; }
            set { yCorText.Text = value; }
        }
        private void FreeText_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
