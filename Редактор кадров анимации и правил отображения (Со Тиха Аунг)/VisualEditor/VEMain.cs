/*
 Исполнитель: Со Тиха Аунг	
 Дата утверждения: _._.2013	
 Версия: 1.0	
 Характеристика: Разработка визуального редактора для подсистемы имитационного моделирования,
 входящей в состав динамической версии комплекса АТ-ТЕХНОЛОГИЯ
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace VisualEditor
{
    /// <summary>
    /// Главное окно визуального редактора
    /// </summary>
    public partial class VEMain : Form
    {
        public VEMain()
        {
            InitializeComponent();
        }
        private string VisualData = "Visualization.xml";
        private string RuleData = "Treeview.xml";
        private StreamWriter sr;
        static string filePath;
        /// <summary>
        /// Загрузка главного окна
        /// </summary>
        private void Main_Form_Load(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Загрузить имитационную модель на языке ЯДОАТ");
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {                    
                    filePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                }
                this.Size = new Size(1000, 600);
                // добавление ContextMenuStrip в TreeView
                treeView1.ContextMenuStrip = contextMenuStrip1;
                foreach (TreeNode tNode in treeView1.Nodes)
                {
                    tNode.ContextMenuStrip = contextMenuStrip1;
                }
                // загрузка правил в TreeView
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(RuleData);
                if (xDoc.DocumentElement.ChildNodes[0] == null)
                {
                    treeView1.Nodes.Add("Правила");
                }
                else
                {
                    LoadRules();
                }
                // загрузка параметров кадров в DataGridViews
                XmlDocument xDoc2 = new XmlDocument();
                xDoc2.Load(VisualData);
                XmlNodeList kadreNodeList = xDoc2.SelectNodes("//Кадр");
                string kadreName = kadreNodeList[0].Attributes[0].Value;
                XmlNode xNode = xDoc2.SelectSingleNode("//Кадр[@Имя_кадра = '" + kadreName + "']");
                string str1 = xNode.Attributes[0].Value;
                string str2 = xNode.Attributes[1].Value;
                string str3 = xNode.Attributes[2].Value;
                nameKadre.Text = str1;
                pathToImage.Text = str2;
                colorCombo.Text = str3;
                dataView1.Rows.Clear();
                dataView2.Rows.Clear();
                XmlNodeList imageNodeList = xDoc2.SelectNodes("//Кадр[@Имя_кадра = '" + kadreName + "']/Описание_изображений");
                string iCell1; string iCell2; string iCell3; string iCell4;
                foreach (XmlNode node in imageNodeList)
                {
                    iCell1 = node.Attributes[0].Value;
                    iCell2 = node.Attributes[1].Value;
                    iCell3 = node.Attributes[2].Value;
                    iCell4 = node.Attributes[3].Value;
                    dataView1.Rows.Add(iCell1, iCell2, iCell3, iCell4);
                }

                XmlNodeList messageNodeList = xDoc2.SelectNodes("//Кадр[@Имя_кадра = '" + kadreName + "']/Описание_комментарий");
                string cCell1; string cCell2; string cCell3; string cCell4; string cCell5; string cCell6;
                foreach (XmlNode node in messageNodeList)
                {
                    cCell1 = node.Attributes[0].Value;
                    cCell2 = node.Attributes[1].Value;
                    cCell3 = node.Attributes[2].Value;
                    cCell4 = node.Attributes[3].Value;
                    cCell5 = node.Attributes[4].Value;
                    cCell6 = node.Attributes[5].Value;
                    dataView2.Rows.Add(cCell1, cCell2, cCell3, cCell4, cCell5, cCell6);
                }
                XmlNodeList parameterNodeList = xDoc2.SelectNodes("//Кадр[@Имя_кадра = '" + kadreName + "']/Описание_параметров");
                string pCell1; string pCell2; string pCell3; string pCell4; string pCell5; string pCell6; string pCell7; string pCell8;
                foreach (XmlNode node in parameterNodeList)
                {
                    pCell1 = node.Attributes[0].Value;
                    pCell2 = node.Attributes[1].Value;
                    pCell3 = node.Attributes[2].Value;
                    pCell4 = node.Attributes[3].Value;
                    pCell5 = node.Attributes[4].Value;
                    pCell6 = node.Attributes[5].Value;
                    pCell7 = node.Attributes[6].Value;
                    pCell8 = node.Attributes[7].Value;
                    dataView3.Rows.Add(pCell1, pCell2, pCell3, pCell4, pCell5, pCell6, pCell7, pCell8);
                }
                XmlNodeList textNodeList = xDoc2.SelectNodes("//Кадр[@Имя_кадра = '" + kadreName + "']/Описание_текстов");
                string tCell1; string tCell2; string tCell3; string tCell4; string tCell5; string tCell6; string tCell7;
                foreach (XmlNode node in textNodeList)
                {
                    tCell1 = node.Attributes[0].Value;
                    tCell2 = node.Attributes[1].Value;
                    tCell3 = node.Attributes[2].Value;
                    tCell4 = node.Attributes[3].Value;
                    tCell5 = node.Attributes[4].Value;
                    tCell6 = node.Attributes[5].Value;
                    tCell7 = node.Attributes[6].Value;
                    dataView4.Rows.Add(tCell1, tCell2, tCell3, tCell4, tCell5, tCell6, tCell7);
                }
            XmlDocument resDoc = new XmlDocument();
            resDoc.Load("TempResource.xml");
            resDoc.DocumentElement.RemoveAll();
            XmlDocument xDoc3 = new XmlDocument();
            xDoc3.Load(filePath);
            XmlNodeList xNodes = xDoc3.SelectNodes("//Ресурс");
            foreach (XmlNode paraNode in xNodes)
            {
                XmlNode newNode = resDoc.CreateElement("Ресурс");
                resDoc.DocumentElement.AppendChild(newNode);
                XmlAttribute atr1 = resDoc.CreateAttribute("Имя_ресурса");
                atr1.Value = paraNode.Attributes[0].Value;
                newNode.Attributes.Append(atr1);
                XmlAttribute atr2 = resDoc.CreateAttribute("Имя_типа_ресурса");
                atr2.Value = paraNode.Attributes[1].Value;
                newNode.Attributes.Append(atr2);
                XmlAttribute atr3 = resDoc.CreateAttribute("Трассировка");
                atr3.Value = paraNode.Attributes[2].Value;
                newNode.Attributes.Append(atr3);
                string pValues = paraNode.Attributes[3].Value.Trim(new Char[] { '{', '}' });
                string[] split = pValues.Split(new Char[] { ',' });
                int j = split.Count();
                string[] str = new string[j];
                for (int i = 0; i < j; i++)
                {
                    if (split[i] != "*")
                    {
                        XmlNode typeNode1 = xDoc3.SelectSingleNode("//Тип_ресурсов[@Имя_типа_ресурсов='" + paraNode.Attributes[1].Value + "']");
                        XmlNode paraNode1 = resDoc.CreateElement("Параметр_ресурса");
                        XmlAttribute pAtr1 = resDoc.CreateAttribute("Имя_параметра");
                        pAtr1.Value = typeNode1.ChildNodes[i].Attributes[0].Value;
                        paraNode1.Attributes.Append(pAtr1);
                        paraNode1.InnerText = split[i];
                        newNode.AppendChild(paraNode1);
                    }
                    else
                    {
                        XmlNode typeNode2 = xDoc3.SelectSingleNode("//Тип_ресурсов[@Имя_типа_ресурсов='" + paraNode.Attributes[1].Value + "']");
                        XmlNode paraNode2 = resDoc.CreateElement("Параметр_ресурса");
                        XmlAttribute pAtr2 = resDoc.CreateAttribute("Имя_параметра");
                        pAtr2.Value = typeNode2.ChildNodes[i].Attributes[0].Value;
                        paraNode2.Attributes.Append(pAtr2);
                        paraNode2.InnerText = typeNode2.ChildNodes[i].Attributes[2].Value;
                        newNode.AppendChild(paraNode2);
                    }
                }

                resDoc.Save("TempResource.xml");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Загрузка правил отображения
        /// </summary>
        private void LoadRules()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(RuleData);
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(new TreeNode(xDoc.DocumentElement.Name));
                TreeNode tNode = new TreeNode();
                tNode = (TreeNode)treeView1.Nodes[0];
                AddRuleNode(xDoc.DocumentElement, tNode);
                //treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Загрузка правил отображения
        /// </summary>
        private void AddRuleNode(XmlNode xmlNode, TreeNode treeNode)
        {
            try
            {
                XmlNode xNode;
                TreeNode tNode;
                XmlNodeList xNodeList;
                if (xmlNode.HasChildNodes)
                {
                    xNodeList = xmlNode.ChildNodes;
                    for (int x = 0; x <= xNodeList.Count - 1; x++)
                    {
                        xNode = xmlNode.ChildNodes[x];
                        treeNode.Nodes.Add(new TreeNode(xNode.Name));
                        tNode = treeNode.Nodes[x];
                        AddRuleNode(xNode, tNode);
                    }
                }
                else
                    treeNode.Remove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Сохранение правили отображения в XML
        /// </summary>
        private void saveNodes_Click(object sender, EventArgs e)
        {
            try
            {
                string str = RuleData;
                ExportRules(treeView1, str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Сохранение правил отображения
        /// </summary>
        private void ExportRules(TreeView tv, string filename)
        {
            try
            {
                sr = new StreamWriter(filename, false, System.Text.Encoding.UTF8);
                sr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sr.WriteLine("<" + treeView1.Nodes[0].Text + ">");
                foreach (TreeNode node in tv.Nodes)
                {
                    if (node.Nodes[0].Nodes.Count > 1)
                    {
                        SaveNodes(node.Nodes);
                    }
                    else
                    {
                        MessageBox.Show("Либо условие правило, либо действие правило отсутствует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                sr.WriteLine("</" + treeView1.Nodes[0].Text + ">");
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Сохранение правил отображения
        /// </summary>
        private void SaveNodes(TreeNodeCollection tnc)
        {
            try
            {
                foreach (TreeNode node in tnc)
                {
                    if (node.Nodes.Count > 0)
                    {
                        sr.WriteLine("<" + node.Text + ">");
                        SaveNodes(node.Nodes);
                        sr.WriteLine("</" + node.Text + ">");
                    }
                    else
                        sr.WriteLine("<" + node.Text + ">" + node.Text + "</" + node.Text + ">");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// удаление правил отображения
        /// </summary>
        private void deleteNode_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

        /// <summary>
        /// Добавление нового правила в список правил отображения
        /// </summary>
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RuleName newForm = new RuleName();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = newForm.nameRule;
                    treeView1.Nodes[0].Nodes.Add(newNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Добавление логических операторов в правила отображения
        /// </summary>
        private void операторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Operator newForm = new Operator();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    if (newForm.operatorAnd == true)
                    {
                        TreeNode newNode = new TreeNode();
                        newNode.Text = "И";
                        treeView1.SelectedNode.Nodes.Add(newNode);
                    }
                    else
                    {
                        TreeNode newNode = new TreeNode();
                        newNode.Text = "ИЛИ";
                        treeView1.SelectedNode.Nodes.Add(newNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Изменение логических операторов в правилах отображения
        /// </summary>
        private void изменитьоператорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Operator newForm = new Operator();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    if (newForm.operatorAnd == true)
                    {
                        TreeNode node = treeView1.SelectedNode;
                        node.Text = "И";
                    }
                    else
                    {
                        TreeNode node = treeView1.SelectedNode;
                        node.Text = "ИЛИ";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Добавление условий в правила отображения
        /// </summary>
        private void условияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Condition newForm = new Condition();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = newForm.resourceName;
                    treeView1.SelectedNode.Nodes.Add(newNode);
                    TreeNode subNode1 = new TreeNode();
                    subNode1.Text = "_" + newForm.parameterName;
                    newNode.Nodes.Add(subNode1);
                    TreeNode subNode2 = new TreeNode();
                    subNode2.Text = "_" + newForm.comparisonOperator;
                    newNode.Nodes.Add(subNode2);
                    TreeNode subNode3 = new TreeNode();
                    subNode3.Text = "_" + newForm.parameterValue;
                    newNode.Nodes.Add(subNode3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Изменение условий в правилах отображения
        /// </summary>
        private void изменитьусловиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Condition newForm = new Condition();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    TreeNode node = treeView1.SelectedNode;
                    node.Text = newForm.resourceName;
                    node.Nodes[0].Text = "_" + newForm.parameterName;
                    node.Nodes[1].Text = "_" + newForm.comparisonOperator;
                    node.Nodes[2].Text = "_" + newForm.parameterValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Добавление действий в правила отображения
        /// </summary>
        private void действияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Action newForm = new Action();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    if (newForm.imageName == "")
                    {
                        TreeNode newNode11 = new TreeNode();
                        newNode11.Text = newForm.dimageName;
                        treeView1.SelectedNode.Nodes.Add(newNode11);
                        TreeNode newNode12 = new TreeNode();
                        newNode12.Text = "_" + newForm.xStart;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode12);
                        TreeNode newNode13 = new TreeNode();
                        newNode13.Text = "_" + newForm.xEnd;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode13);
                        TreeNode newNode14 = new TreeNode();
                        newNode14.Text = "_" + newForm.xType;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode14);
                        TreeNode newNode15 = new TreeNode();
                        newNode15.Text = "_" + newForm.xValue;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode15);
                        TreeNode newNode16 = new TreeNode();
                        newNode16.Text = "_" + newForm.yStart;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode16);
                        TreeNode newNode17 = new TreeNode();
                        newNode17.Text = "_" + newForm.yEnd;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode17);
                        TreeNode newNode18 = new TreeNode();
                        newNode18.Text = "_" + newForm.yType;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode18);
                        TreeNode newNode19 = new TreeNode();
                        newNode19.Text = "_" + newForm.yValue;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode19);
                    }
                    else
                    {
                        TreeNode newNode21 = new TreeNode();
                        newNode21.Text = newForm.imageName;
                        treeView1.SelectedNode.Nodes.Add(newNode21);
                        TreeNode newNode22 = new TreeNode();
                        newNode22.Text = "_" + newForm.xCoordination;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode22);
                        TreeNode newNode23 = new TreeNode();
                        newNode23.Text = "_" + newForm.yCoordination;
                        treeView1.SelectedNode.LastNode.Nodes.Add(newNode23);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Изменение действий в правилах отображения
        /// </summary>
        private void изменитьдействиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Action newForm = new Action();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    if (newForm.imageName == "")
                    {
                        TreeNode newNode11 = treeView1.SelectedNode;
                        newNode11.Text = newForm.dimageName;
                        TreeNode newNode12 = treeView1.SelectedNode.Nodes[0];
                        newNode12.Text = "_" + newForm.xStart;
                        TreeNode newNode13 = treeView1.SelectedNode.Nodes[1];
                        newNode13.Text = "_" + newForm.xEnd;
                        TreeNode newNode14 = treeView1.SelectedNode.Nodes[2];
                        newNode14.Text = "_" + newForm.xType;
                        TreeNode newNode15 = treeView1.SelectedNode.Nodes[3];
                        newNode15.Text = "_" + newForm.xValue;
                        TreeNode newNode16 = treeView1.SelectedNode.Nodes[4];
                        newNode16.Text = "_" + newForm.yStart;
                        TreeNode newNode17 = treeView1.SelectedNode.Nodes[5];
                        newNode17.Text = "_" + newForm.yEnd;
                        TreeNode newNode18 = treeView1.SelectedNode.Nodes[6];
                        newNode18.Text = "_" + newForm.yType;
                        TreeNode newNode19 = treeView1.SelectedNode.Nodes[7];
                        newNode19.Text = "_" + newForm.yValue;
                    }
                    else
                    {
                        TreeNode newNode21 = treeView1.SelectedNode;
                        newNode21.Text = newForm.imageName;
                        TreeNode newNode22 = treeView1.SelectedNode.Nodes[0];
                        newNode22.Text = "_" + newForm.xCoordination;
                        TreeNode newNode23 = treeView1.SelectedNode.Nodes[1];
                        newNode23.Text = "_" + newForm.yCoordination;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Подготовка к созданию нового кадра аннимации
        /// </summary>  
        private void createKadre_Click(object sender, EventArgs e)
        {
            nameKadre.Text = "";
            pathToImage.Text = "";
            colorCombo.Text = "";
            dataView1.Rows.Clear();
            dataView2.Rows.Clear();
            dataView3.Rows.Clear();
            dataView4.Rows.Clear();
        }

        /// <summary>
        /// Сохранение описания кадров аннимации в XML
        /// </summary>  
        private void saveKadre_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameKadre.Text != "")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(VisualData);
                    XmlNode xNode = doc.DocumentElement;

                    XmlNode element1 = doc.CreateElement("Кадр");
                    doc.DocumentElement.AppendChild(element1);

                    XmlAttribute atr1 = doc.CreateAttribute("Имя_кадра");
                    atr1.Value = nameKadre.Text.ToString();
                    element1.Attributes.Append(atr1);
                    XmlAttribute atr2 = doc.CreateAttribute("Путь_к_фоновой_картинке");
                    atr2.Value = pathToImage.Text.ToString();
                    element1.Attributes.Append(atr2);
                    XmlAttribute atr3 = doc.CreateAttribute("Цвет_фона");
                    atr3.Value = colorCombo.Text.ToString();
                    element1.Attributes.Append(atr3);
                    for (int i = 0; i < dataView1.RowCount; i++)
                    {
                        XmlNode subelement1 = doc.CreateElement("Описание_изображений");
                        element1.AppendChild(subelement1);
                        XmlAttribute atr11 = doc.CreateAttribute("Имя_изображения");
                        atr11.Value = dataView1.Rows[i].Cells[0].Value.ToString();
                        subelement1.Attributes.Append(atr11);
                        XmlAttribute atr12 = doc.CreateAttribute("Путь_к_изображению");
                        atr12.Value = dataView1.Rows[i].Cells[1].Value.ToString();
                        subelement1.Attributes.Append(atr12);
                        XmlAttribute atr13 = doc.CreateAttribute("Ширина");
                        atr13.Value = dataView1.Rows[i].Cells[2].Value.ToString();
                        subelement1.Attributes.Append(atr13);
                        XmlAttribute atr14 = doc.CreateAttribute("Высота");
                        atr14.Value = dataView1.Rows[i].Cells[3].Value.ToString();
                        subelement1.Attributes.Append(atr14);
                    }
                    for (int j = 0; j < dataView2.RowCount; j++)
                    {
                        XmlNode subelement2 = doc.CreateElement("Описание_комментарий");
                        element1.AppendChild(subelement2);
                        XmlAttribute atr21 = doc.CreateAttribute("Имя_комментария");
                        atr21.Value = dataView2.Rows[j].Cells[0].Value.ToString();
                        subelement2.Attributes.Append(atr21);
                        XmlAttribute atr22 = doc.CreateAttribute("Описание");
                        atr22.Value = dataView2.Rows[j].Cells[1].Value.ToString();
                        subelement2.Attributes.Append(atr22);
                        XmlAttribute atr23 = doc.CreateAttribute("Цвет_фона");
                        atr23.Value = dataView2.Rows[j].Cells[2].Value.ToString();
                        subelement2.Attributes.Append(atr23);
                        XmlAttribute atr24 = doc.CreateAttribute("Цвет_шрифта");
                        atr24.Value = dataView2.Rows[j].Cells[3].Value.ToString();
                        subelement2.Attributes.Append(atr24);
                        XmlAttribute atr25 = doc.CreateAttribute("Ширина");
                        atr25.Value = dataView2.Rows[j].Cells[4].Value.ToString();
                        subelement2.Attributes.Append(atr25);
                        XmlAttribute atr26 = doc.CreateAttribute("Высота");
                        atr26.Value = dataView2.Rows[j].Cells[5].Value.ToString();
                        subelement2.Attributes.Append(atr26);
                    }
                    for (int k = 0; k < dataView3.RowCount; k++)
                    {
                        XmlNode subelement3 = doc.CreateElement("Описание_параметров");
                        element1.AppendChild(subelement3);
                        XmlAttribute atr31 = doc.CreateAttribute("Имя_ресурса");
                        atr31.Value = dataView3.Rows[k].Cells[0].Value.ToString();
                        subelement3.Attributes.Append(atr31);
                        XmlAttribute atr32 = doc.CreateAttribute("Имя_параметра");
                        atr32.Value = dataView3.Rows[k].Cells[1].Value.ToString();
                        subelement3.Attributes.Append(atr32);
                        XmlAttribute atr33 = doc.CreateAttribute("Цвет_фона");
                        atr33.Value = dataView3.Rows[k].Cells[2].Value.ToString();
                        subelement3.Attributes.Append(atr33);
                        XmlAttribute atr34 = doc.CreateAttribute("Цвет_шрифта");
                        atr34.Value = dataView3.Rows[k].Cells[3].Value.ToString();
                        subelement3.Attributes.Append(atr34);
                        XmlAttribute atr35 = doc.CreateAttribute("Ширина");
                        atr35.Value = dataView3.Rows[k].Cells[4].Value.ToString();
                        subelement3.Attributes.Append(atr35);
                        XmlAttribute atr36 = doc.CreateAttribute("Высота");
                        atr36.Value = dataView3.Rows[k].Cells[5].Value.ToString();
                        subelement3.Attributes.Append(atr36);
                        XmlAttribute atr37 = doc.CreateAttribute("X-координация");
                        atr37.Value = dataView3.Rows[k].Cells[6].Value.ToString();
                        subelement3.Attributes.Append(atr37);
                        XmlAttribute atr38 = doc.CreateAttribute("Y-координация");
                        atr38.Value = dataView3.Rows[k].Cells[7].Value.ToString();
                        subelement3.Attributes.Append(atr38);
                    }
                    for (int l = 0; l < dataView4.RowCount; l++)
                    {
                        XmlNode subelement4 = doc.CreateElement("Описание_текстов");
                        element1.AppendChild(subelement4);
                        XmlAttribute atr41 = doc.CreateAttribute("Описание_текста");
                        atr41.Value = dataView4.Rows[l].Cells[0].Value.ToString();
                        subelement4.Attributes.Append(atr41);
                        XmlAttribute atr42 = doc.CreateAttribute("Цвет_фона");
                        atr42.Value = dataView4.Rows[l].Cells[1].Value.ToString();
                        subelement4.Attributes.Append(atr42);
                        XmlAttribute atr43 = doc.CreateAttribute("Цвет_шрифта");
                        atr43.Value = dataView4.Rows[l].Cells[2].Value.ToString();
                        subelement4.Attributes.Append(atr43);
                        XmlAttribute atr44 = doc.CreateAttribute("Ширина");
                        atr44.Value = dataView4.Rows[l].Cells[3].Value.ToString();
                        subelement4.Attributes.Append(atr44);
                        XmlAttribute atr45 = doc.CreateAttribute("Высота");
                        atr45.Value = dataView4.Rows[l].Cells[4].Value.ToString();
                        subelement4.Attributes.Append(atr45);
                        XmlAttribute atr46 = doc.CreateAttribute("X-координация");
                        atr46.Value = dataView4.Rows[l].Cells[5].Value.ToString();
                        subelement4.Attributes.Append(atr46);
                        XmlAttribute atr47 = doc.CreateAttribute("Y-координация");
                        atr47.Value = dataView4.Rows[l].Cells[6].Value.ToString();
                        subelement4.Attributes.Append(atr47);
                    }
                    doc.Save(VisualData);
                }
                else
                {
                    MessageBox.Show("Имя кадра отсутствует!","Ошибка!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Загрузка описания кадров аннимации 
        /// </summary>  
        private void loadKadre_Click(object sender, EventArgs e)
        {
            try
            {
                ChoiceKadre newForm = new ChoiceKadre();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(VisualData);
                    XmlNode xNode = xDoc.SelectSingleNode("//Кадр[@Имя_кадра = '" + newForm.kadreName + "']");
                    string str1 = xNode.Attributes[0].Value;
                    string str2 = xNode.Attributes[1].Value;
                    string str3 = xNode.Attributes[2].Value;
                    nameKadre.Text = str1;
                    pathToImage.Text = str2;
                    colorCombo.Text = str3;
                    dataView1.Rows.Clear();
                    dataView2.Rows.Clear();
                    dataView3.Rows.Clear();
                    dataView4.Rows.Clear();
                    XmlNodeList imageNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + newForm.kadreName + "']/Описание_изображений");
                    string iCell1; string iCell2; string iCell3; string iCell4;
                    foreach (XmlNode node in imageNodeList)
                    {
                        iCell1 = node.Attributes[0].Value;
                        iCell2 = node.Attributes[1].Value;
                        iCell3 = node.Attributes[2].Value;
                        iCell4 = node.Attributes[3].Value;
                        dataView1.Rows.Add(iCell1, iCell2, iCell3, iCell4);
                    }
                    XmlNodeList messageNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + newForm.kadreName + "']/Описание_комментарий");
                    string cCell1; string cCell2; string cCell3; string cCell4; string cCell5; string cCell6;
                    foreach (XmlNode node in messageNodeList)
                    {
                        cCell1 = node.Attributes[0].Value;
                        cCell2 = node.Attributes[1].Value;
                        cCell3 = node.Attributes[2].Value;
                        cCell4 = node.Attributes[3].Value;
                        cCell5 = node.Attributes[4].Value;
                        cCell6 = node.Attributes[5].Value;
                        dataView2.Rows.Add(cCell1, cCell2, cCell3, cCell4, cCell5, cCell6);
                    }
                    XmlNodeList parameterNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + newForm.kadreName + "']/Описание_параметров");
                    string pCell1; string pCell2; string pCell3; string pCell4; string pCell5; string pCell6; string pCell7; string pCell8;
                    foreach (XmlNode node in parameterNodeList)
                    {
                        pCell1 = node.Attributes[0].Value;
                        pCell2 = node.Attributes[1].Value;
                        pCell3 = node.Attributes[2].Value;
                        pCell4 = node.Attributes[3].Value;
                        pCell5 = node.Attributes[4].Value;
                        pCell6 = node.Attributes[5].Value;
                        pCell7 = node.Attributes[6].Value;
                        pCell8 = node.Attributes[7].Value;
                        dataView3.Rows.Add(pCell1, pCell2, pCell3, pCell4, pCell5, pCell6, pCell7, pCell8);
                    }
                    XmlNodeList textNodeList = xDoc.SelectNodes("//Кадр[@Имя_кадра = '" + newForm.kadreName + "']/Описание_текстов");
                    string tCell1; string tCell2; string tCell3; string tCell4; string tCell5; string tCell6; string tCell7;
                    foreach (XmlNode node in textNodeList)
                    {
                        tCell1 = node.Attributes[0].Value;
                        tCell2 = node.Attributes[1].Value;
                        tCell3 = node.Attributes[2].Value;
                        tCell4 = node.Attributes[3].Value;
                        tCell5 = node.Attributes[4].Value;
                        tCell6 = node.Attributes[5].Value;
                        tCell7 = node.Attributes[6].Value;
                        dataView4.Rows.Add(tCell1, tCell2, tCell3, tCell4, tCell5, tCell6, tCell7);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обновление описания кадров аннимации
        /// </summary>  
        private void updateKadre_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(VisualData);
                XmlNode xNode = doc.DocumentElement;
                string nodePath = "//Кадр[@Имя_кадра = '" + nameKadre.Text + "']";
                XmlNode node = doc.SelectSingleNode(nodePath);
                node.RemoveAll();
                XmlNode parentnode = node.ParentNode;
                parentnode.RemoveChild(node);
                XmlNode element1 = doc.CreateElement("Кадр");
                doc.DocumentElement.AppendChild(element1);
                XmlAttribute atr1 = doc.CreateAttribute("Имя_кадра");
                atr1.Value = nameKadre.Text.ToString();
                element1.Attributes.Append(atr1);
                XmlAttribute atr2 = doc.CreateAttribute("Путь_к_фоновой_картинке");
                atr2.Value = pathToImage.Text.ToString();
                element1.Attributes.Append(atr2);
                XmlAttribute atr3 = doc.CreateAttribute("Цвет_фона");
                atr3.Value = colorCombo.Text.ToString();
                element1.Attributes.Append(atr3);
                for (int i = 0; i < dataView1.RowCount; i++)
                {
                    XmlNode subelement1 = doc.CreateElement("Описание_изображений");
                    element1.AppendChild(subelement1);
                    XmlAttribute atr11 = doc.CreateAttribute("Имя_изображения");
                    atr11.Value = dataView1.Rows[i].Cells[0].Value.ToString();
                    subelement1.Attributes.Append(atr11);
                    XmlAttribute atr12 = doc.CreateAttribute("Путь_к_изображению");
                    atr12.Value = dataView1.Rows[i].Cells[1].Value.ToString();
                    subelement1.Attributes.Append(atr12);
                    XmlAttribute atr13 = doc.CreateAttribute("Ширина");
                    atr13.Value = dataView1.Rows[i].Cells[2].Value.ToString();
                    subelement1.Attributes.Append(atr13);
                    XmlAttribute atr14 = doc.CreateAttribute("Высота");
                    atr14.Value = dataView1.Rows[i].Cells[3].Value.ToString();
                    subelement1.Attributes.Append(atr14);
                }
                for (int j = 0; j < dataView2.RowCount; j++)
                {
                    XmlNode subelement2 = doc.CreateElement("Описание_комментарий");
                    element1.AppendChild(subelement2);
                    XmlAttribute atr21 = doc.CreateAttribute("Имя_комментария");
                    atr21.Value = dataView2.Rows[j].Cells[0].Value.ToString();
                    subelement2.Attributes.Append(atr21);
                    XmlAttribute atr22 = doc.CreateAttribute("Описание");
                    atr22.Value = dataView2.Rows[j].Cells[1].Value.ToString();
                    subelement2.Attributes.Append(atr22);
                    XmlAttribute atr23 = doc.CreateAttribute("Цвет_фона");
                    atr23.Value = dataView2.Rows[j].Cells[2].Value.ToString();
                    subelement2.Attributes.Append(atr23);
                    XmlAttribute atr24 = doc.CreateAttribute("Цвет_шрифта");
                    atr24.Value = dataView2.Rows[j].Cells[3].Value.ToString();
                    subelement2.Attributes.Append(atr24);
                    XmlAttribute atr25 = doc.CreateAttribute("Ширина");
                    atr25.Value = dataView2.Rows[j].Cells[4].Value.ToString();
                    subelement2.Attributes.Append(atr25);
                    XmlAttribute atr26 = doc.CreateAttribute("Высота");
                    atr26.Value = dataView2.Rows[j].Cells[5].Value.ToString();
                    subelement2.Attributes.Append(atr26);
                }
                for (int k = 0; k < dataView3.RowCount; k++)
                {
                    XmlNode subelement3 = doc.CreateElement("Описание_параметров");
                    element1.AppendChild(subelement3);
                    XmlAttribute atr31 = doc.CreateAttribute("Имя_ресурса");
                    atr31.Value = dataView3.Rows[k].Cells[0].Value.ToString();
                    subelement3.Attributes.Append(atr31);
                    XmlAttribute atr32 = doc.CreateAttribute("Имя_параметра");
                    atr32.Value = dataView3.Rows[k].Cells[1].Value.ToString();
                    subelement3.Attributes.Append(atr32);
                    XmlAttribute atr33 = doc.CreateAttribute("Цвет_фона");
                    atr33.Value = dataView3.Rows[k].Cells[2].Value.ToString();
                    subelement3.Attributes.Append(atr33);
                    XmlAttribute atr34 = doc.CreateAttribute("Цвет_шрифта");
                    atr34.Value = dataView3.Rows[k].Cells[3].Value.ToString();
                    subelement3.Attributes.Append(atr34);
                    XmlAttribute atr35 = doc.CreateAttribute("Ширина");
                    atr35.Value = dataView3.Rows[k].Cells[4].Value.ToString();
                    subelement3.Attributes.Append(atr35);
                    XmlAttribute atr36 = doc.CreateAttribute("Высота");
                    atr36.Value = dataView3.Rows[k].Cells[5].Value.ToString();
                    subelement3.Attributes.Append(atr36);
                    XmlAttribute atr37 = doc.CreateAttribute("X-координация");
                    atr37.Value = dataView3.Rows[k].Cells[6].Value.ToString();
                    subelement3.Attributes.Append(atr37);
                    XmlAttribute atr38 = doc.CreateAttribute("Y-координация");
                    atr38.Value = dataView3.Rows[k].Cells[7].Value.ToString();
                    subelement3.Attributes.Append(atr38);
                }
                for (int l = 0; l < dataView4.RowCount; l++)
                {
                    XmlNode subelement4 = doc.CreateElement("Описание_текстов");
                    element1.AppendChild(subelement4);
                    XmlAttribute atr41 = doc.CreateAttribute("Описание_текста");
                    atr41.Value = dataView4.Rows[l].Cells[0].Value.ToString();
                    subelement4.Attributes.Append(atr41);
                    XmlAttribute atr42 = doc.CreateAttribute("Цвет_фона");
                    atr42.Value = dataView4.Rows[l].Cells[1].Value.ToString();
                    subelement4.Attributes.Append(atr42);
                    XmlAttribute atr43 = doc.CreateAttribute("Цвет_шрифта");
                    atr43.Value = dataView4.Rows[l].Cells[2].Value.ToString();
                    subelement4.Attributes.Append(atr43);
                    XmlAttribute atr44 = doc.CreateAttribute("Ширина");
                    atr44.Value = dataView4.Rows[l].Cells[3].Value.ToString();
                    subelement4.Attributes.Append(atr44);
                    XmlAttribute atr45 = doc.CreateAttribute("Высота");
                    atr45.Value = dataView4.Rows[l].Cells[4].Value.ToString();
                    subelement4.Attributes.Append(atr45);
                    XmlAttribute atr46 = doc.CreateAttribute("X-координация");
                    atr46.Value = dataView4.Rows[l].Cells[5].Value.ToString();
                    subelement4.Attributes.Append(atr46);
                    XmlAttribute atr47 = doc.CreateAttribute("Y-координация");
                    atr47.Value = dataView4.Rows[l].Cells[6].Value.ToString();
                    subelement4.Attributes.Append(atr47);
                }
                doc.Save(VisualData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Добавление изображений в кадр анниации
        /// </summary>  
        private void createImage_Click(object sender, EventArgs e)
        {
            try
            {
                Images newForm = new Images();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    string str1 = newForm.imageName;
                    string str2 = newForm.imagePath;
                    string str3 = newForm.imageWidth;
                    string str4 = newForm.imageHeight;
                    dataView1.Rows.Add(str1, str2, str3, str4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Удаление изображений из кадра аннимации
        /// </summary>  
        private void delImage_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataView1.SelectedRows)
            {
                dataView1.Rows.RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// Добавление сообщений в кадр аннимации
        /// </summary>  

        private void createMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Messages newForm = new Messages();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    string str1 = newForm.messageName;
                    string str2 = newForm.messageDiscription;
                    string str3 = newForm.messageBackColor;
                    string str4 = newForm.messageTextColor;
                    string str5 = newForm.messageWidth;
                    string str6 = newForm.messageHeight;
                    dataView2.Rows.Add(str1, str2, str3, str4, str5, str6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Удаление сообщений из кадра аннимации
        /// </summary>  

        private void delMessage_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataView2.SelectedRows)
            {
                dataView2.Rows.RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// Добавление параметров ресурсов в кадр аннимации
        /// </summary>  
        private void createParameter_Click(object sender, EventArgs e)
        {
            try
            {
                Parameters newForm = new Parameters();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    string str1 = newForm.resourceName;
                    string str2 = newForm.parameterName;
                    string str3 = newForm.parameterBackColor;
                    string str4 = newForm.parameterTextColor;
                    string str5 = newForm.paramterWidth;
                    string str6 = newForm.paramterHeight;
                    string str7 = newForm.paramterXCor;
                    string str8 = newForm.paramterYCor;
                    dataView3.Rows.Add(str1, str2, str3, str4, str5, str6, str7, str8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Удаление параметров ресурсов из кадра аннимации
        /// </summary>  
        private void deleteParameter_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataView3.SelectedRows)
            {
                dataView3.Rows.RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// Добавление свободных текстов в кадр аннимации
        /// </summary>  
        private void createFreeText_Click(object sender, EventArgs e)
        {
            try
            {
                FreeText newForm = new FreeText();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    string str1 = newForm.textDescription;
                    string str2 = newForm.textBackColor;
                    string str3 = newForm.textColor;
                    string str4 = newForm.textWidth;
                    string str5 = newForm.textHeight;
                    string str6 = newForm.textXCor;
                    string str7 = newForm.textYCor;
                    dataView4.Rows.Add(str1, str2, str3, str4, str5, str6, str7);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Удаление свободных текстов из кадра аннимации
        /// </summary>  
        private void deleteFreeText_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataView4.SelectedRows)
            {
                dataView4.Rows.RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// Удаление кадров аннмации
        /// </summary>  
        private void deleteKadre_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(VisualData);
                XmlNode xNode = xDoc.SelectSingleNode("//Кадр[@Имя_кадра = '" + nameKadre.Text + "']");
                xDoc.DocumentElement.RemoveChild(xNode);
                xDoc.Save(VisualData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Изменение имени правил отображения
        /// </summary>  
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RuleName newForm = new RuleName();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    TreeNode newNode = treeView1.SelectedNode;
                    newNode.Text = newForm.nameRule;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        { }
        private void groupBox3_Enter(object sender, EventArgs e)
        { }
        
    }
}