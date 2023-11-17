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
    /// Окно редактирования логических операторов правил
    /// </summary>
    public partial class Operator : Form
    {
        public Operator()
        {
            InitializeComponent();
        }
        public bool operatorAnd
        {
            get { return radioButton1.Checked; }
            set { radioButton1.Checked = value; }
        }
        public bool operatorOr
        {
            get { return radioButton2.Checked; }
            set { radioButton2.Checked = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
