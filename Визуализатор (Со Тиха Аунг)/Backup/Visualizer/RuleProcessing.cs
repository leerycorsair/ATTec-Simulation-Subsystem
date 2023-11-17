using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Visualizer
{
    class RuleProcessing
    {
        /// <summary>
        /// Лексический анализ правил
        /// </summary>
        public static bool CheckRules(XmlNode node, int tactNum)
        {
            if (node.Name != "И" & node.Name != "ИЛИ" & node.ChildNodes[0].Name != "И" & node.ChildNodes[0].Name != "ИЛИ")
            {
                string str1 = node.ChildNodes[0].Name;
                string str2 = node.ChildNodes[0].ChildNodes[0].InnerText;
                string str3 = node.ChildNodes[0].ChildNodes[1].InnerText;
                string str4 = node.ChildNodes[0].ChildNodes[2].InnerText;
                bool result = CheckNodes(str1, str2, str3, str4, tactNum);
                if (result == true)
                {
                    return true;
                }
            }

            else if (node.Name == "И" & node.ChildNodes[0].Name != "И" & node.ChildNodes[0].Name != "ИЛИ")
            {
                bool[] bArray = new bool[node.ChildNodes.Count];
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    if (node.ChildNodes[i].Name != "И" & node.ChildNodes[i].Name != "ИЛИ")
                    {
                        string str1 = node.ChildNodes[i].Name;
                        string str2 = node.ChildNodes[i].ChildNodes[0].InnerText;
                        string str3 = node.ChildNodes[i].ChildNodes[1].InnerText;
                        string str4 = node.ChildNodes[i].ChildNodes[2].InnerText;

                        bArray[i] = CheckNodes(str1, str2, str3, str4, tactNum);
                    }
                    else
                    {
                        bArray[i] = CheckRules(node.ChildNodes[i], tactNum);
                    }
                }
                bool result = bArray.All(x => x == true);
                if (result == true)
                {
                    return true;
                }
            }

            else if (node.Name == "ИЛИ" & node.ChildNodes[0].Name != "И" & node.ChildNodes[0].Name != "ИЛИ")
            {
                bool[] bArray = new bool[node.ChildNodes.Count];
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    if (node.ChildNodes[i].Name != "И" & node.ChildNodes[i].Name != "ИЛИ")
                    {
                        string str1 = node.ChildNodes[i].Name;
                        string str2 = node.ChildNodes[i].ChildNodes[0].InnerText;
                        string str3 = node.ChildNodes[i].ChildNodes[1].InnerText;
                        string str4 = node.ChildNodes[i].ChildNodes[2].InnerText;

                        bArray[i] = CheckNodes(str1, str2, str3, str4, tactNum);
                    }
                    else
                    {
                        bArray[i] = CheckRules(node.ChildNodes[i], tactNum);
                    }
                }
                bool result = bArray.Any(x => x == true);
                if (result == true)
                {
                    return true;
                }
            }
            else if (node.Name != "И" & node.Name != "ИЛИ" & node.ChildNodes[0].Name == "И")
            {
                bool[] bArray = new bool[node.ChildNodes[0].ChildNodes.Count];
                for (int i = 0; i < node.ChildNodes[0].ChildNodes.Count; i++)
                {
                    if (node.ChildNodes[0].ChildNodes[i].Name != "И" & node.ChildNodes[0].ChildNodes[i].Name != "ИЛИ")
                    {
                        string str1 = node.ChildNodes[0].ChildNodes[i].Name;
                        string str2 = node.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                        string str3 = node.ChildNodes[0].ChildNodes[i].ChildNodes[1].InnerText;
                        string str4 = node.ChildNodes[0].ChildNodes[i].ChildNodes[2].InnerText;
                        bArray[i] = CheckNodes(str1, str2, str3, str4, tactNum);
                    }
                    else
                    {
                        bArray[i] = CheckRules(node.ChildNodes[0].ChildNodes[i], tactNum);
                    }
                }
                bool result = bArray.All(x => x == true);
                if (result == true)
                {
                    return true;
                }
            }
            else if (node.Name != "И" & node.Name != "ИЛИ" & node.ChildNodes[0].Name == "ИЛИ")
            {
                bool[] cArray = new bool[node.ChildNodes[0].ChildNodes.Count];
                for (int i = 0; i < node.ChildNodes[0].ChildNodes.Count; i++)
                {
                    if (node.ChildNodes[0].ChildNodes[i].Name != "И" & node.ChildNodes[0].ChildNodes[i].Name != "ИЛИ")
                    {
                        string str1 = node.ChildNodes[0].ChildNodes[i].Name;
                        string str2 = node.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                        string str3 = node.ChildNodes[0].ChildNodes[i].ChildNodes[1].InnerText;
                        string str4 = node.ChildNodes[0].ChildNodes[i].ChildNodes[2].InnerText;
                        cArray[i] = CheckNodes(str1, str2, str3, str4, tactNum);
                    }
                    else
                    {
                        cArray[i] = CheckRules(node.ChildNodes[0].ChildNodes[i], tactNum);
                    }
                }
                bool result = cArray.Any(x => x == true);
                if (result == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка утверждений
        /// </summary>
        static bool CheckNodes(string str1, string str2, string str3, string str4, int tNum)
        {
                string ModelData = "ResourceParameters.xml";
                string temp1 = str1;
                string temp2 = str2.TrimStart('_');
                string temp3 = str3.TrimStart('_');
                string temp4 = str4.TrimStart('_');

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ModelData);
                XmlNode xNode = xDoc.SelectSingleNode("//Ресурс[@Имя_ресурса ='" + temp1 + "' and @Номер_такта = '" + tNum.ToString() + "']/Параметр_ресурса[@Имя_параметра = '" + temp2 + "']");
                switch (temp3)
                {
                    case "Less":
                        int i1 = Int32.Parse(xNode.InnerText);
                        int j1 = Int32.Parse(temp4);
                        if (i1 < j1)
                        { return true; }
                        break;
                    case "Greater":
                        int i2 = Int32.Parse(xNode.InnerText);
                        int j2 = Int32.Parse(temp4);
                        if (i2 > j2)
                        {
                            return true;
                        }
                        break;
                    case "LessOrEqual":
                        int i3 = Int32.Parse(xNode.InnerText);
                        int j3 = Int32.Parse(temp4);
                        if (i3 <= j3)
                        {
                            return true;
                        }
                        break;
                    case "GreaterOrEqual":
                        int i4 = Int32.Parse(xNode.InnerText);
                        int j4 = Int32.Parse(temp4);
                        if (i4 >= j4)
                        {
                            return true;
                        }
                        break;
                    case "EqualNumber":
                        int i5 = Int32.Parse(xNode.InnerText);
                        int j5 = Int32.Parse(temp4);
                        if (i5 == j5)
                        {
                            return true;
                        }
                        break;
                    case "EqualString":
                        if (xNode.InnerText == temp4)
                        {
                            return true;
                        }
                        break;
                    default:
                        break;
                }
                return false;
        }
    }
}