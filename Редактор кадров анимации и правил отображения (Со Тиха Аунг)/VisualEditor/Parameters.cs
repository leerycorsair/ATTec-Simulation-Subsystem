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
    /// Окно редактирования параметров ресурсов
    /// </summary>
    public partial class Parameters : Form
    {
        private string ModelData = "TempResource.xml";

        public Parameters()
        {
            InitializeComponent();
        }
        public string resourceName
        {
            get { return nameResource.Text; }
            set { nameResource.Text = value; }
        }
        public string parameterName
        {
            get { return nameParameter.Text; }
            set { nameParameter.Text = value; }
        }
        public string parameterBackColor
        {
            get { return backTextColor.Text; }
            set { backTextColor.Text = value; }
        }
        public string parameterTextColor
        {
            get { return foreTextColor.Text; }
            set { foreTextColor.Text = value; }
        }
        public string paramterWidth
        {
            get { return widthParameter.Text; }
            set { widthParameter.Text = value; }
        }
        public string paramterHeight
        {
            get { return heightParameter.Text; }
            set { heightParameter.Text = value; }
        }
        public string paramterXCor
        {
            get { return xCorParamter.Text; }
            set { xCorParamter.Text = value; }
        }
        public string paramterYCor
        {
            get { return yCorParamerter.Text; }
            set { yCorParamerter.Text = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void Parameters_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ModelData);
                XmlNodeList nodeList = xDoc.SelectNodes("//Ресурс");
                foreach (XmlNode node in nodeList)
                {
                    nameResource.Items.Add(node.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void nameResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nameParameter.Items.Clear();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ModelData);
                XmlNode xNode = xDoc.SelectSingleNode("//Ресурс[@Имя_ресурса = '" + nameResource.Text + "']");
                XmlNodeList xNodeList = xNode.ChildNodes;
                foreach (XmlNode node in xNodeList)
                {
                    nameParameter.Items.Add(node.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
