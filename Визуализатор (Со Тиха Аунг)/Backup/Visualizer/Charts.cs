using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;

namespace Visualizer
{
    /// <summary>
    /// Окно отображения графиков
    /// </summary>
    public partial class Charts : Form
    {
        // Путь к файлу "esourceParameters.xml"
        private string ModelData = "ResourceParameters.xml";
        public Charts()
        {
            InitializeComponent();
        }

        private void nameResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                parameterResource.Items.Clear();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ModelData);
                XmlNode xNode = xDoc.SelectSingleNode("//Ресурс[@Имя_ресурса = '" + nameResource.Text + "']");
                XmlNodeList xNodeList = xNode.ChildNodes;
                foreach (XmlNode node in xNodeList)
                {
                    parameterResource.Items.Add(node.Attributes[0].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Charts_Load(object sender, EventArgs e)
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

        private void ChartLoad()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ModelData);
                XmlNode xNode = xDoc.SelectSingleNode("//Ресурс[@Имя_ресурса = '" + nameResource.Text + "' and @Номер_такта = '" + VMain.tNumber.ToString() + "']/Параметр_ресурса[@Имя_параметра = '" + parameterResource.Text + "']");
                // Fill series data
                string str = xNode.InnerText.ToString();
                int chartPoint = Convert.ToInt32(str);
                int chartTypeIndex = typeChart.SelectedIndex;
                chart1.Series["Series1"].ChartType = (SeriesChartType)chartTypeIndex;
                //(SeriesChartType)chartTypeIndex;
                chart1.Series["Series1"].Points.AddXY(DateTime.Now.ToLongTimeString(), chartPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChartLoad();
        }

        private void startChart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void endChart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            chart1.Series[0].Points.Clear();
        }

    }
}
