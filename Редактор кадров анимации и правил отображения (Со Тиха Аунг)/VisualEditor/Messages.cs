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
    /// Окно редактирования сообщений
    /// </summary>
    public partial class Messages : Form
    {
        public Messages()
        {
            InitializeComponent();
        }
        public string messageName
        {
            get { return nameMessage.Text; }
            set { nameMessage.Text = value; }
        }
        public string messageDiscription
        {
            get { return discriptionMessage.Text; }
            set { discriptionMessage.Text = value; }
        }
        public string messageBackColor
        {
            get { return bgcolorMessage.Text; }
            set { bgcolorMessage.Text = value; }
        }
        public string messageTextColor
        {
            get { return forecolorMessage.Text; }
            set { forecolorMessage.Text = value; }
        }
        public string messageWidth
        {
            get { return widthMessage.Text; }
            set { widthMessage.Text = value; }
        }
        public string messageHeight
        {
            get { return heightMessage.Text; }
            set { heightMessage.Text = value; }
        }
        private void addMessage_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
