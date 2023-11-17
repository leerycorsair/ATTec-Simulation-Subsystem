using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows;

namespace ATTranslation
{
    /// <summary>
    /// Синтаксический анализ
    /// </summary>
    class SyntaxAnalysis:MainWindow
    {
        public static Tuple<int, XElement> start()
        {
            //Строим дерево. Типы ресурсов - корень
            int resFind = 0, operFind = 0, operTemplFind = 0;
            XElement tree = new XElement("Типы_ресурсов");
            foreach (ResourceType resType in resourceTypeList)

            {

                       //Добавляем тип ресурса и дочерний узел - ресурсы
                XElement resTypeElem = new XElement("Тип_ресурсов", new XAttribute("Имя_типа_ресурсов", resType.name));
               // XElement parNode = new XElement("Параметры_ресурса");
               // ResourceType rType = new ResourceType();

                List<ResourceTypeParameter> rtParameter = resType.param;
                foreach (ResourceTypeParameter rtp in rtParameter)
                {
                    XElement resTypeParamElem = new XElement("Параметр_типа", new XAttribute("Имя_параметра", rtp.name), new XAttribute("Тип_параметра", rtp.type), new XAttribute("Умолчание", rtp.defaul));
                    // parNode.Add(resTypeParamElem);
                    resTypeElem.Add(resTypeParamElem);
                }

                XElement resNode = new XElement("Ресурсы");
                //Для каждого связанного ресурса, добавляем его в дерево
                foreach (Resource res in resourceList)
                {
                    
                    if (res.resource == resType.name)
                    {
                        XElement resElem = new XElement("Ресурс", new XAttribute("Имя_ресурса", res.name), new XAttribute("Параметр_ресурса", res.defaul));
                        resNode.Add(resElem);
                        resFind++;
                    }

                }
               
                resTypeElem.Add(resNode);
                //Далее все аналогично для образцов операций
                XElement operTemplNode = new XElement("Образцы_операций");
                
                
                foreach (OperationTemplate operTemp in operationTemplateList)
                {
                    if (operTemp.relevantResource.Exists(element => element.descriptor==resType.name))
                    {
                        XElement operTemplElem = new XElement("Образец_операции", new XAttribute("Имя_образца", operTemp.name));
                        XElement operNode = new XElement("Операции");
                        
                        //Добавим операции, связанные с образцом
                        foreach (Operation oper in operationList)
                        {
                            if (oper.template == operTemp.name)
                            {
                                XElement operElem = new XElement("Операция", new XAttribute("Имя_операции", oper.name));

                                if (tree.Nodes().ToList().Count == 0 || operTemp.relevantResource.Count == 1) operFind++;
                                operNode.Add(operElem);
                            }
                        }
                       
                        operTemplElem.Add(operNode);
                        operTemplNode.Add(operTemplElem);
                        if (tree.Nodes().ToList().Count==0 || operTemp.relevantResource.Count==1)
                        operTemplFind++;
                    }
                }
                resTypeElem.Add(operTemplNode);
                tree.Add(resTypeElem);
            }


           //Проверки - на несоответствие элементов в дереве и количесвту элементов в списках
            //if (resFind != resourceList.Count) return Tuple.Create<int, XElement>(8, null);
            //if (operTemplFind != operationTemplateList.Count) return Tuple.Create<int, XElement>(10, null);
            //if (operFind != operationList.Count) return Tuple.Create<int, XElement>(9, null);;
            //Проверка на пустые дочерние элементы
            foreach (XElement elem in tree.Elements("Тип_ресурсов"))
            {
                //if (!elem.Element("Ресурсы").HasElements) return Tuple.Create<int, XElement>(11, null);;
                //if (!elem.Element("Образцы_операций").HasElements) return Tuple.Create<int, XElement>(12, null);;
                //foreach (XElement child in elem.Element("Образцы_операций").Elements())
                //if (!child.Element("Операции").HasElements) return Tuple.Create<int, XElement>(13, null);;
            }

            MessageBox.Show(tree.ToString());
            return Tuple.Create<int, XElement>(0, tree);
        }
    }
}
