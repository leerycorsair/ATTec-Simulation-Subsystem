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
    /// Окно редактирования действий
    /// </summary>
    public partial class Action : Form
    {
        private string VisualData = "Visualization.xml";

        public Action()
        {
            InitializeComponent();
        }
        public string imageName
        {
            get { return sImage.Text; }
            set { sImage.Text = value; }
        }
        public string commentName
        {
            get { return sImage.Text; }
            set { sImage.Text = value; }
        }

        public string xCoordination
        {
            get { return xCoor.Text; }
            set { xCoor.Text = value; }
        }

        public string yCoordination
        {
            get { return yCoor.Text; }
            set { yCoor.Text = value; }
        }

        public string dimageName
        {
            get { return dImage.Text; }
            set { dImage.Text = value; }
        }

        public string xStart
        {
            get { return xCorStart.Text ; }
            set { xCorStart.Text = value; }
        }

        public string xEnd
        {
            get { return xCorEnd.Text; }
            set { xCorEnd.Text = value; }
        }

        public string yStart
        {
            get { return yCorStart.Text; }
            set { yCorStart.Text = value; }
        }

        public string yEnd
        {
            get { return yCorEnd.Text; }
            set { yCorEnd.Text = value; }
        }

        public string xType
        {
            get { return xChangeType.Text; }
            set { xChangeType.Text = value; }
        }

        public string xValue
        {
            get { return xChangedValue.Text; }
            set { xChangedValue.Text = value; }
        }

        public string yType
        {
            get { return yChangedType.Text; }
            set { yChangedType.Text = value; }
        }

        public string yValue
        {
            get { return yChangedValue.Text; }
            set { yChangedValue.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Action_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNodeList nodeList = xDoc.SelectNodes("//Кадр");
                foreach (XmlNode node in nodeList)
                {
                    snameKadre.Items.Add(node.Attributes[0].Value);
                    dnameKadre.Items.Add(node.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void snameKadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sImage.Items.Clear();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNodeList xNodeList1 = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + snameKadre.Text + "']/Описание_изображений");
                foreach (XmlNode node in xNodeList1)
                {
                    sImage.Items.Add(node.Attributes[0].Value);
                }
                XmlNodeList xNodeList2 = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + snameKadre.Text + "']/Описание_комментарий");
                foreach (XmlNode node2 in xNodeList2)
                {
                    sImage.Items.Add(node2.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dnameKadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dImage.Items.Clear();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNodeList xNodeList1 = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + dnameKadre.Text + "']/Описание_изображений");
                foreach (XmlNode node in xNodeList1)
                {
                    dImage.Items.Add(node.Attributes[0].Value);
                }

                XmlNodeList xNodeList2 = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + dnameKadre.Text + "']/Описание_комментарий");
                foreach (XmlNode node2 in xNodeList2)
                {
                    dImage.Items.Add(node2.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void sImage_SelectedIndexChanged(object sender, EventArgs e)
        {}

    }
}
