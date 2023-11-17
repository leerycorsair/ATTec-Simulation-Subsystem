using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VisualEditor
{
    /// <summary>
    /// Окно выбора кадров аннимации
    /// </summary>
    public partial class ChoiceKadre : Form
    {
        private string VisualData = "Visualization.xml";

        public ChoiceKadre()
        {
            InitializeComponent();

        }

        public int kadreIndex
        {
            get { return listKadre.SelectedIndex; }
            set { listKadre.SelectedIndex = value; }
        }
        public string kadreName
        {
            get { return listKadre.Text; }
            set { listKadre.Text = value; }
        }
        private void Choice_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void ChoiceKadre_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNodeList nodeList = xDoc.SelectNodes("//Кадр");
                foreach (XmlNode node in nodeList)
                {
                    listKadre.Items.Add(node.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
