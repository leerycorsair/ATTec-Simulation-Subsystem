using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Visualizer
{
    /// <summary>
    /// Главное окно визуализатора
    /// </summary>
    public partial class VMain : Form
    {
        // Пути к файлам

        private string VisualData = "Visualization.xml";
        private string ModelData = "ResourceParameters.xml";
        private string RuleData = "Treeview.xml";
        public static int tNumber = 0;
        public static List<RuleAction> ruleActionList = new List<RuleAction>();
        public static List<PictureBox> listPicBox = new List<PictureBox>();
        public static List<Panel> listWorkspace = new List<Panel>();

        public VMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Загрузка главного окна
        /// </summary>
        private void Main_Form_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNodeList xNodeList = xDoc.SelectNodes("//Кадр");
                foreach (XmlNode node in xNodeList)
                {
                    nameKadre.Items.Add(node.Attributes[0].Value.ToString());
                    Panel WS = new Panel();
                    WS.Name = node.Attributes[0].Value.ToString();
                    WS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    if (node.Attributes[1].Value != "") { WS.BackgroundImage = Image.FromFile(node.Attributes[1].Value.ToString()); }
                    if (node.Attributes[2].Value != "") { WS.BackColor = Color.FromName(node.Attributes[2].Value.ToString()); }
                    listWorkspace.Add(WS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Запуск timers
        /// </summary>
        private void showKadre_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument visualXml = new XmlDocument();
                visualXml.Load(VisualData);
                XmlNodeList imageNodeList = visualXml.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_изображений");
                foreach (XmlNode imgNode in imageNodeList)
                {
                    PictureBox picBox = new PictureBox();
                    picBox.Name = imgNode.Attributes[0].Value.ToString();
                    int g = Convert.ToInt32(imgNode.Attributes[2].Value);
                    int k = Convert.ToInt32(imgNode.Attributes[3].Value);
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picBox.ClientSize = new Size(g, k);
                    picBox.BackColor = Color.Transparent;
                    picBox.Image = System.Drawing.Image.FromFile(imgNode.Attributes[1].Value.ToString());
                    picBox.Visible = false;
                    listPicBox.Add(picBox);
                }

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(RuleData);
                XmlNode xNode = xDoc.SelectSingleNode("//Правила");

                foreach (XmlNode ruleNode in xNode.ChildNodes)
                {
                    RuleAction newRuleAction = new RuleAction();
                    newRuleAction.DElementList = new List<DElement>();
                    newRuleAction.SElementList = new List<SElement>();
                    if (ruleNode.ChildNodes.Count > 1)
                    {
                        for (int i = 1; i < ruleNode.ChildNodes.Count; i++)
                        {
                            if (ruleNode.ChildNodes[i].ChildNodes.Count > 2)
                            {
                                DElement DElem = new DElement();
                                DElem.name = ruleNode.ChildNodes[i].Name.ToString();
                                DElem.xCorStart = ruleNode.ChildNodes[i].ChildNodes[0].InnerText.ToString();
                                DElem.xCorEnd = ruleNode.ChildNodes[i].ChildNodes[1].InnerText.ToString();
                                DElem.xChangeType = ruleNode.ChildNodes[i].ChildNodes[2].InnerText.ToString();
                                DElem.xChangeValue = ruleNode.ChildNodes[i].ChildNodes[3].InnerText.ToString();
                                DElem.yCorStart = ruleNode.ChildNodes[i].ChildNodes[4].InnerText.ToString();
                                DElem.yCorEnd = ruleNode.ChildNodes[i].ChildNodes[5].InnerText.ToString();
                                DElem.yChangeType = ruleNode.ChildNodes[i].ChildNodes[6].InnerText.ToString();
                                DElem.yChangeValue = ruleNode.ChildNodes[i].ChildNodes[7].InnerText.ToString();
                                newRuleAction.DElementList.Add(DElem);
                            }
                            else
                            {
                                SElement SElem = new SElement();
                                SElem.name = ruleNode.ChildNodes[i].Name.ToString();
                                SElem.xCor = ruleNode.ChildNodes[i].ChildNodes[0].InnerText.ToString();
                                SElem.yCor = ruleNode.ChildNodes[i].ChildNodes[1].InnerText.ToString();
                                newRuleAction.SElementList.Add(SElem);
                            }
                        }
                    }
                    ruleActionList.Add(newRuleAction);
                }
                double j = Convert.ToDouble(scanInterval.Text.ToString())*1000;                
                timer1.Interval = Convert.ToInt32(j);
                //timer2.Interval = Convert.ToInt32(j);
                timer1.Enabled = true;
                //timer2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Отображение кадров аннимации
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Panel ws in listWorkspace)
            {
                if (ws.Name == nameKadre.Text)
                {
                    WorkSpace.BackgroundImage = ws.BackgroundImage;
                    WorkSpace.BackColor = ws.BackColor;
                    WorkSpace.ClientSize = new Size(800, 600);
                    WorkSpace.BackgroundImageLayout = ws.BackgroundImageLayout;
                    WorkSpace.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            XmlDocument resultDoc = new XmlDocument();
            resultDoc.Load(ModelData);
            XmlNode lastNode = resultDoc.ChildNodes[0].LastChild;
            int lastTact = Convert.ToInt32(lastNode.Attributes[3].Value);
            if (lastTact > tNumber)
            {
                try
                {
                    tNumber = tNumber + 1;
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(VisualData);
                    XmlNodeList parameterNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_параметров");
                    foreach (XmlNode pNode in parameterNodeList)
                    {
                        string str1 = pNode.Attributes[0].Value.ToString();
                        string str2 = pNode.Attributes[1].Value.ToString();
                        XmlDocument newDoc = new XmlDocument();
                        newDoc.Load(ModelData);
                        XmlNode selectNode = newDoc.SelectSingleNode("//Ресурс[@Имя_ресурса = '" + str1 + "' and @Номер_такта = '" + tNumber.ToString() + "']/Параметр_ресурса[@Имя_параметра = '" + str2 + "']");
                        string str3 = selectNode.InnerText.ToString();
                        int q = Convert.ToInt32(pNode.Attributes[4].Value);
                        int r = Convert.ToInt32(pNode.Attributes[5].Value);
                        int s = Convert.ToInt32(pNode.Attributes[6].Value);
                        int t = Convert.ToInt32(pNode.Attributes[7].Value);
                        Label label1 = new Label();
                        label1.Name = str1;
                        label1.Text = str3;
                        label1.Location = new System.Drawing.Point(s, t);
                        label1.BackColor = Color.FromName(pNode.Attributes[2].Value.ToString());
                        label1.ForeColor = Color.FromName(pNode.Attributes[3].Value.ToString());
                        label1.ClientSize = new Size(q, r);
                        WorkSpace.Controls.Add(label1);                     
                        label1.Visible = true;
                    }

                    XmlNodeList textNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_текстов");
                    foreach (XmlNode tNode in textNodeList)
                    {
                        int q = Convert.ToInt32(tNode.Attributes[3].Value);
                        int r = Convert.ToInt32(tNode.Attributes[4].Value);
                        int s = Convert.ToInt32(tNode.Attributes[5].Value);
                        int t = Convert.ToInt32(tNode.Attributes[6].Value);
                        Label label1 = new Label();
                        label1.Text = tNode.Attributes[0].Value.ToString();
                        label1.Location = new System.Drawing.Point(s, t);
                        label1.BackColor = Color.FromName(tNode.Attributes[1].Value.ToString());
                        label1.ForeColor = Color.FromName(tNode.Attributes[2].Value.ToString());
                        label1.ClientSize = new Size(q, r);
                        WorkSpace.Controls.Add(label1);
                        label1.Visible = true;
                    }

                    XmlDocument xDoc2 = new XmlDocument();
                    xDoc2.Load(RuleData);
                    XmlNode xNode2 = xDoc2.SelectSingleNode("//Правила");
                    int ruleCount = xNode2.ChildNodes.Count;
                    bool[] bArray = new bool[ruleCount];
                    for (int i = 0; i < ruleCount; i++)
                    {
                        bArray[i] = RuleProcessing.CheckRules(xNode2.ChildNodes[i], tNumber);
                        if (bArray[i] == true)
                        {
                            int dElemCount = ruleActionList[i].DElementList.Count;
                            int sElemCount = ruleActionList[i].SElementList.Count;

                            int actionCount = xNode2.ChildNodes[i].ChildNodes.Count;
                            for (int j = 0; j < sElemCount; j++)
                            {
                                string str11 = ruleActionList[i].SElementList[j].name;
                                string str12 = ruleActionList[i].SElementList[j].xCor;
                                string str13 = ruleActionList[i].SElementList[j].yCor;
                                ShowElements(str11, str12, str13, WorkSpace);
                            }

                            for (int k = 0; k < dElemCount; k++)
                            {
                                string str21 = ruleActionList[i].DElementList[k].name;
                                string str22 = ruleActionList[i].DElementList[k].xCorStart;
                                string str23 = ruleActionList[i].DElementList[k].xCorEnd;
                                string str24 = ruleActionList[i].DElementList[k].xChangeType;
                                string str25 = ruleActionList[i].DElementList[k].xChangeValue;
                                string str26 = ruleActionList[i].DElementList[k].yCorStart;
                                string str27 = ruleActionList[i].DElementList[k].yCorEnd;
                                string str28 = ruleActionList[i].DElementList[k].yChangeType;
                                string str29 = ruleActionList[i].DElementList[k].yChangeValue;
                                int x = XCoordination(str22, str23, str24, str25);
                                int y = YCoordination(str26, str27, str28, str29);                        
                                ShowDElements(str21, x, y, WorkSpace);
                                ruleActionList[i].DElementList[k].xCorStart = "_" + x;
                                ruleActionList[i].DElementList[k].yCorStart = "_" + y;
                             }
                        }
                        else if (bArray[i] == false)
                        {
                            int dElemCount = ruleActionList[i].DElementList.Count;

                            for (int k = 0; k < dElemCount; k++)
                            {
                                string str21 = ruleActionList[i].DElementList[k].name;
                               
                                HideDElements(str21);
                            }
                        }                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }
        /// <summary>
        /// Отображение изображений
        /// </summary>
    
        private void ShowElements(string name, string xCoor, string yCoor, Panel kadre)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(VisualData);
            XmlNodeList imageNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_изображений");
            
            foreach (PictureBox picBox in listPicBox)
            {
                if (picBox.Name == name)
                {
                    string temp1 = xCoor.TrimStart('_');
                    string temp2 = yCoor.TrimStart('_');
                    int l = Convert.ToInt32(temp1);
                    int m = Convert.ToInt32(temp2);
                    picBox.Location = new System.Drawing.Point(l, m);
                    picBox.Visible = true;
                    kadre.Controls.Add(picBox);
                }
            }

            XmlNodeList commentNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_комментарий");
            foreach (XmlNode cNode in commentNodeList)
            {
                if (cNode.Attributes[0].Value.ToString() == name)
                {
                    string temp3 = xCoor.TrimStart('_');
                    string temp4 = yCoor.TrimStart('_');
                    int q = Convert.ToInt32(cNode.Attributes[4].Value);
                    int r = Convert.ToInt32(cNode.Attributes[5].Value);
                    int s = Convert.ToInt32(temp3);
                    int t = Convert.ToInt32(temp4);
                    Label label1 = new Label();
                    label1.Name = cNode.Attributes[0].Value.ToString();
                    label1.Text = cNode.Attributes[1].Value.ToString();
                    label1.Location = new System.Drawing.Point(s, t);
                    label1.BackColor = Color.FromName(cNode.Attributes[2].Value.ToString());
                    label1.ForeColor = Color.FromName(cNode.Attributes[3].Value.ToString());
                    label1.ClientSize = new Size(q, r);
                    kadre.Controls.Add(label1);
                    label1.Visible = true;
                }
            }
        }
        /// <summary>
        /// Отображение динамических изображений
        /// </summary>
        private void ShowDElements(string name, int xCoor, int yCoor, Panel kadre)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNodeList imageNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_изображений");
                foreach (PictureBox picBox in listPicBox)
                {
                    if (picBox.Name == name)
                    {
                        picBox.Location = new System.Drawing.Point(xCoor, yCoor);
                        picBox.Visible = true;
                        kadre.Controls.Add(picBox);
                    }
                }

                XmlNodeList commentNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_комментарий");
                foreach (XmlNode cNode in commentNodeList)
                {
                    if (cNode.Attributes[0].Value.ToString() == name)
                    {
                        int q = Convert.ToInt32(cNode.Attributes[4].Value);
                        int r = Convert.ToInt32(cNode.Attributes[5].Value);
                        Label label1 = new Label();
                        label1.Name = cNode.Attributes[0].Value.ToString();
                        label1.Text = cNode.Attributes[1].Value.ToString();
                        label1.Location = new System.Drawing.Point(xCoor, yCoor);
                        label1.BackColor = Color.FromName(cNode.Attributes[2].Value.ToString());
                        label1.ForeColor = Color.FromName(cNode.Attributes[3].Value.ToString());
                        label1.ClientSize = new Size(q, r);
                        kadre.Controls.Add(label1);
                        label1.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Скрытие динамических изображений
        /// </summary>
        private void HideDElements(string name)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNodeList imageNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text + "']/Описание_изображений");

                foreach (PictureBox picBox in listPicBox)
                {
                    if (picBox.Name == name)
                    {
                        picBox.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Расчет Х-координаций динамических изображений
        /// </summary>
        private int XCoordination(string xs, string xe, string xt, string xv)
        {
                string xstart = xs.TrimStart('_');
                string xend = xe.TrimStart('_');
                string xtype = xt.TrimStart('_');
                string xvalue = xv.TrimStart('_');
                int i = Convert.ToInt32(xstart);
                int j = Convert.ToInt32(xend);
                int k = Convert.ToInt32(xvalue);
                if (xtype == "Null")
                {
                    return i;
                }
                else if (xtype == "Increase")
                {
                    if (i < j)
                    {
                        i = i + k;
                        return i;
                    }
                    else return i;
                }
                else if (xtype == "Decrease")
                {
                    if (i > j)
                    {
                        i = i - k;
                        return i;
                    }
                    else return i;
                }
                return 0;
        }
        /// <summary>
        /// Расчет Y-координаций динамических изображений
        /// </summary>
        private int YCoordination(string ys, string ye, string yt, string yv)
        {
                string ystart = ys.TrimStart('_');
                string yend = ye.TrimStart('_');
                string ytype = yt.TrimStart('_');
                string yvalue = yv.TrimStart('_');
                int i = Convert.ToInt32(ystart);
                int j = Convert.ToInt32(yend);
                int k = Convert.ToInt32(yvalue);
                if (ytype == "Null")
                {
                    return i;
                }
                else if (ytype == "Increase")
                {
                    if (i < j)
                    {
                        i = i + k;
                        return i;
                    }
                    else return i;
                }
                else if (ytype == "Decrease")
                {
                    if (i > j)
                    {
                        i = i - k;
                        return i;
                    }
                    else return i;
                }
                return 0;
        }

        /// <summary>
        /// Очищение рабочего пространства
        /// </summary>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (WorkSpace.Controls.Count > 0)
            {
                for (int i = 0; i < WorkSpace.Controls.Count; i++)
                {
                    if (WorkSpace.Controls[i].Name != "")
                    {
                        WorkSpace.Controls[i].Hide();
                    }
                }
            }
        }

        /// <summary>
        /// Отрытие окна отображения графиков
        /// </summary>
        private void showChart_Click(object sender, EventArgs e)
        {
            Charts newForm = new Charts();
            newForm.Show();
        }

        /// <summary>
        /// Пауза отображения кадров аннимации
        /// </summary>
        private void pauseAnnimation_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        /// <summary>
        /// Остановка отображения кадров аннимации
        /// </summary>
        private void stopAnnimation_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            WorkSpace.Controls.Clear();
            WorkSpace.BackgroundImage = null;
            WorkSpace.BackColor = Control.DefaultBackColor;
            listPicBox.Clear();
            ruleActionList.Clear();
            tNumber = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listPicBox.Clear();
            XmlDocument visualXml = new XmlDocument();
            visualXml.Load(VisualData);
            XmlNodeList imageNodeList = visualXml.SelectNodes("//Кадр[@Имя_кадра = '" + nameKadre.Text+ "']/Описание_изображений");
            foreach (XmlNode imgNode in imageNodeList)
            {
                PictureBox picBox = new PictureBox();
                picBox.Name = imgNode.Attributes[0].Value.ToString();
                int g = Convert.ToInt32(imgNode.Attributes[2].Value);
                int k = Convert.ToInt32(imgNode.Attributes[3].Value);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox.ClientSize = new Size(g, k);
                picBox.BackColor = Color.Transparent;
                picBox.Image = System.Drawing.Image.FromFile(imgNode.Attributes[1].Value.ToString());
                picBox.Visible = false;
                listPicBox.Add(picBox);
            }
        }
    }
}
