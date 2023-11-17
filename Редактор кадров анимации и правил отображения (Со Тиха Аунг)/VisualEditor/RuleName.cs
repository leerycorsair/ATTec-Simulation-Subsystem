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
    /// Окно редактирования имени правил
    /// </summary>
    public partial class RuleName : Form
    {
        public RuleName()
        {
            InitializeComponent();
        }
        public string nameRule
        {
            get { return nameText.Text; }
            set { nameText.Text = value; }
        }
        private void RuleName_Load(object sender, EventArgs e)
        {}
        private void addRule_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
