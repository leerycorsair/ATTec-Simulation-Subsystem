using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ATTranslation
{
    /// <summary>
    /// Семантический анализ
    /// </summary>
    class SemanticAnalysis : MainWindow
    {
        public static int start(XElement tree, List<ResourceType> resourceTypeList, List<Resource> resourceList, List<OperationTemplate> operationTemplateList, List<Operation> operationList, List<Function> functionList)
        {
            //замена первого пробела на подчеркивание. Модификация:
            //TODO: автозамена пробела на _ для всех элементов всех списков
            //TODO: Модифицировать автозамену - чтобы цикл прогонялся несколько раз
            foreach (XElement elem in tree.Descendants())
            {
                foreach (XAttribute attr in elem.Attributes())
                {
                    attr.Value = attr.Value.Replace(" ", "_");
                   
                }
            }
            
            
            // Проверка: Начальные значения ресурсов совпадали с количеством параметров
            foreach (Resource res in resourceList)
            {
                foreach (ResourceType type in resourceTypeList) 
                {
                    if (res.resource == type.name) { 
                        
                        if (!(res.defaul.Split().Length == type.param.Count)) return 14;
                    }
                }
            }

            //В теле образца и в самом образце релевантные ресурсы должны совпадать
            bool eq = false;
            foreach (OperationTemplate temp in operationTemplateList)
            {
                foreach (RelevantResource res in temp.relevantResource)
                {
                    eq = false; 
                    foreach (Rule rule in temp.rule)
                    {
                        if (res.name == rule.resource && !eq) eq = true;
                    }
                    if (!eq) return 15;
                }


                //Если образец - событие, то только convert_event, правило - convert_rule, событие - Convert_begin и convert_end
                foreach (Rule rule in temp.rule)
                {
                    switch (temp.type)
                    {
                        case "Нерегулярное событие":
                            if (!(rule.convertBegin.Length == 0 && rule.convertEnd.Length == 0 && rule.convertEvent.Length > 0 && rule.convertRule.Length == 0)) return 16;
                            break;
                        case "Правило":
                            //if (!(rule.convertBegin.Length == 0 && rule.convertEnd.Length == 0 && rule.convertEvent.Length == 0 && rule.convertRule.Length > 0)) return 16;
                            if (!(rule.convertBegin.Length == 0 && rule.convertEnd.Length == 0 && rule.convertEvent.Length == 0)) return 16;
                            break;
                        case "Операция":
                            //if (!(rule.convertBegin.Length > 0 && rule.convertEnd.Length > 0 && rule.convertEvent.Length == 0 && rule.convertRule.Length == 0)) return 16;
                            if (!(rule.convertEvent.Length == 0 && rule.convertRule.Length == 0)) return 16;
                            break;
                    }
                    //Проверка, что в предусловии стоят правильные имена релевантных ресурсов
                    //if (temp.type != "Нерегулярное событие" && rule.precondition.Split().First().Remove(rule.precondition.Split().First().IndexOf(".")) != rule.resource) return 17;

                }

            }
            //В теле функции правильные значения стоят.
            foreach (Function func in functionList)
            {
                var list = func.tale.Split().ToList(); int i = 0;
                foreach (string elem in list)
                {
                    string nextString = "";
                    switch (elem)
                    {
                        case "if":
                        case "while":

                            nextString = list.Skip(i).ElementAt(list.Skip(i).ToList().IndexOf(elem) + 1).Substring(1);
                            string checkString = nextString.Remove(nextString.IndexOf("."));
                            if (!resourceList.Exists(element => element.name == checkString)) return 18;
                            break;
                        case "@and@":
                        case "@or@":
                            nextString = list.Skip(i).ElementAt(list.Skip(i).ToList().IndexOf(elem) + 1);
                            checkString = nextString.Remove(nextString.IndexOf("."));
                            if (!resourceList.Exists(element => element.name == checkString)) return 18;
                            break;
                    }

                    i++;
                }

            }
            
            return 0;
        }
       
    }
}
