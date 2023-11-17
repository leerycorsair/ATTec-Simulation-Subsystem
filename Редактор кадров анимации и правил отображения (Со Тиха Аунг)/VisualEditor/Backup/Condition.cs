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
    /// Окно редактирования условий правил
    /// </summary>
    public partial class Condition : Form
    {
        private string ModelData = "TempResource.xml";

        public Condition()
        {
            InitializeComponent();
        }

        public string resourceName
        {
            get { return comboBox1.Text;}
            set {comboBox1.Text = value ;}
        }
        public string parameterName
        {
            get { return comboBox2.Text; }
            set { comboBox2.Text = value; }
        }

        public string comparisonOperator
        {
            get { return comboBox3.Text; }
            set { comboBox3.Text = value; }
        }

        public string parameterValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }



        private void Condition_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ModelData);
                XmlNodeList nodeList = xDoc.SelectNodes("//Ресурс");
                foreach (XmlNode node in nodeList)
                {
                    comboBox1.Items.Add(node.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  
        }

        private void addCondition_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ModelData);
                XmlNode xNode = xDoc.SelectSingleNode("//Ресурс[@Имя_ресурса = '" + comboBox1.Text + "']");
                XmlNodeList xNodeList = xNode.ChildNodes;
                foreach (XmlNode node in xNodeList)
                {
                    comboBox2.Items.Add(node.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
