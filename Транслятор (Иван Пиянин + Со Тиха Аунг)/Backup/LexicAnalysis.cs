using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ATTranslation
{
    /// <summary>
    /// Лексический анализ
    /// </summary>
    partial class LexicAnalysis : MainWindow
    {
        /// <summary>
        /// Запуск лексического анализа
        /// </summary>
        /// <param name="filename">имя файла с моделью</param>
        /// <returns>код ошибки</returns>
        public static int start(string filename)
        {
            
            bool resType = false, res = false, oper = false, obr = false, func = false;
            XDocument model;
            try
            {
                //Пытаемся открыть документ
                model = XDocument.Load(filename);

            } 
            catch (XmlException)
            {

                return 1;
            }
            if (model.Root.IsEmpty == true) return 1;
            //с документом все ок, парсим его
            foreach (XElement el in model.Root.Elements())
            {
                switch (el.Name.ToString())
                {
                    case "Тип_ресурсов":
                        //Тип ресурса. Смотрим наличие всех атрибутов
                        ResourceType rType = new ResourceType();
                        rType.param = new List<ResourceTypeParameter>();
                        bool name = false, type = false, param = false;
                        foreach (XAttribute attr in el.Attributes())
                        {
                            if (attr.Name == "Имя_типа_ресурсов")
                            {
                                if (name == true)
                                {
                                    return 3;
                                }
                                else { name = true; rType.name = attr.Value; }
                            }
                            else if (attr.Name == "Вид_типа_ресурсов")
                            {
                                if (type == true)
                                {
                                    return 3;
                                }
                                else { type = true; rType.type = attr.Value; }
                            }
                            else return 3;
                        }
                        foreach (XElement element in el.Elements())
                        {
                            if (element.Name == "Параметр_типа")
                            {
                                bool parName = false, parType = false, parDef = false;
                               
                                ResourceTypeParameter rtPar = new ResourceTypeParameter();
                                foreach (XAttribute eletr in element.Attributes())
                                {
                                    
                                    if (eletr.Name == "Имя_параметра")
                                    {
                                        if (parName == true)
                                        {
                                            return 3;
                                        }
                                        else { parName = true; rtPar.name = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Тип_параметра")
                                    {
                                        if (parType == true)
                                        {
                                            return 3;
                                        }
                                        else { parType = true; rtPar.type = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Умолчание")
                                    {
                                        if (parDef == true)
                                        {
                                            return 3;
                                        }
                                        else { parDef = true; rtPar.defaul = eletr.Value; }
                                    }
                                    else return 3;
                                    if (parName == true && parType == true && parDef == true) { param = true; rType.param.Add(rtPar); }
                                    else param = false;
                                }
                            }
                        }
                        //если все ок, добавляем в список
                        if (name == true && type == true && param == true) { resType = true; resourceTypeList.Add(rType); } else return 3;
                        break;
                    case "Ресурс":
                        //ресурс - смотрим, все ли атрибуты на месте
                        Resource rsource = new Resource();
                        bool resName = false, resNameType = false, resTrace = false, resDef = false;
                        foreach (XAttribute attr in el.Attributes())
                        {
                            if (attr.Name == "Имя_ресурса")
                            {
                                if (resName == true)
                                {
                                    return 4;
                                }
                                else { resName = true; rsource.name = attr.Value; }
                            }
                            else if (attr.Name == "Имя_типа_ресурсов")
                            {
                                if (resNameType == true)
                                {
                                    return 4;
                                }
                                else { resNameType = true; rsource.resource = attr.Value; }
                            }
                            else if (attr.Name == "Трассировка")
                            {
                                if (resTrace == true)
                                {
                                    return 4;
                                }
                                else { resTrace = true; rsource.trace = attr.Value; }
                            }
                            else if (attr.Name == "Начальные_значения")
                            {
                                if (resDef == true)
                                {
                                    return 4;
                                }
                                else { resDef = true; rsource.defaul = attr.Value; }
                            }
                            else return 4;
                        }
                        //все ок - добавляем в список
                        if (resName == true && resNameType == true && resTrace == true && resDef == true) { res = true; resourceList.Add(rsource); } else return 4;
                        break;
                    case "Образец_операции":
                        //Образец операции - проверяем атрибуты
                        OperationTemplate operTemp = new OperationTemplate();
                        operTemp.relevantResource = new List<RelevantResource>();
                        operTemp.rule = new List<Rule>();
                        operTemp.time = new Time();
                        bool obrName = false, obrType = false, obrTrace = false, obrRelev = false, obrTime = false, obrTale = false;
                        foreach (XAttribute attr in el.Attributes())
                        {
                            if (attr.Name == "Имя_образца")
                            {
                                if (obrName == true)
                                {
                                    return 5;
                                }
                                else { obrName = true; operTemp.name = attr.Value; }
                            }
                            else if (attr.Name == "Тип_образца")
                            {
                                if (obrType == true)
                                {
                                    return 5;
                                }
                                else { obrType = true; operTemp.type = attr.Value; }
                            }
                            else if (attr.Name == "Трассировка")
                            {
                                if (obrTrace == true)
                                {
                                    return 5;
                                }
                                else { obrTrace = true; operTemp.trace = attr.Value; }
                            }
                            else return 5;
                        }
                        foreach (XElement element in el.Elements())
                        {
                            switch (element.Name.ToString())
                            { 
                                case "Релевантный_ресурс":
                                bool relName = false, relOpis = false, relConvert = false, relConvertStart = false, relConvertStop = false;
                                RelevantResource relRes = new RelevantResource();
                                foreach (XAttribute eletr in element.Attributes())
                                {
                                    if (eletr.Name == "Имя_релевантного_ресурса")
                                    {
                                        if (relName == true)
                                        {
                                            Console.WriteLine("Name relev resource wrong");
                                            return 5;
                                        }
                                        else { relName = true; relRes.name = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Описатель")
                                    {
                                        if (relOpis == true)
                                        {
                                            Console.WriteLine("Opisatel wrong");
                                            return 5;
                                        }
                                        else { relOpis = true; relRes.descriptor = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Статус_конвертора")
                                    {
                                        if (relConvert == true)
                                        {
                                            Console.WriteLine("Convert wrong");
                                            return 5;
                                        }
                                        else { relConvert = true; relRes.convertor = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Статус_конвертора_начала")
                                    {
                                        if (relConvertStart == true)
                                        {
                                            Console.WriteLine("Convert start wrong");
                                            return 5;
                                        }
                                        else { relConvertStart = true; relRes.convertorStart = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Статус_конвертора_конца")
                                    {
                                        if (relConvertStop == true)
                                        {
                                            Console.WriteLine("Convert end wrong");
                                            return 5;
                                        }
                                        else { relConvertStop = true; relRes.convertorEnd = eletr.Value; }
                                    }
                                    else return 5;
                                    if (relName == true && relOpis == true && relConvert == true && relConvertStart == true && relConvertStop == true) { obrRelev = true; operTemp.relevantResource.Add(relRes); }
                                    else { obrRelev = false; Console.WriteLine("Relevant wrong"); }
                                }
                                break;
                                case "Время":
                                bool timeType = false, timeLaw = false, timeValue = false, timeStart = false, timeStop = false;
                                foreach (XAttribute eletr in element.Attributes())
                                {
                                    if (eletr.Name == "Тип")
                                    {
                                        if (timeType == true)
                                        {
                                            return 5;
                                        }
                                        else { timeType = true; operTemp.time.type = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Закон")
                                    {
                                        if (timeLaw == true)
                                        {
                                            return 5;
                                        }
                                        else { timeLaw = true; operTemp.time.law = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Значение")
                                    {
                                        if (timeValue == true)
                                        {
                                            return 5;
                                        }
                                        else { timeValue = true; operTemp.time.value = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Начало_интервала")
                                    {
                                        if (timeStart == true)
                                        {
                                            return 5;
                                        }
                                        else { timeStart = true; operTemp.time.start = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Конец_интервала")
                                    {
                                        if (timeStop == true)
                                        {
                                            return 5;
                                        }
                                        else { timeStop = true; operTemp.time.end = eletr.Value; }
                                    }
                                    else return 5;
                                    if (timeType == true && timeLaw == true && timeType == true && timeStart == true && timeStop == true) obrTime = true;
                                    else { obrTime = false; Console.WriteLine("Time wrong"); }
                                }
                                break;  
                                case "Тело_образца":
                                bool taleName = false, talePrecond = false, taleEvent = false, taleRule = false, taleBegin = false, taleEnd = false;
                                
                                foreach (XElement tale in element.Elements())
                                {
                                    Rule rule = new Rule();
                                    foreach (XAttribute attr in tale.Attributes())
                                    {
                                        taleName = false; talePrecond = false; taleEvent = false; taleRule = false; taleBegin = false; taleEnd = false;
                                        if (attr.Name == "Имя_релевантного_ресурса")
                                        {
                                            if (taleName == true)
                                            {
                                                return 5;
                                            }
                                            else { taleName = true; rule.resource = attr.Value; }
                                        }
                                        else return 5;

                                        foreach (XAttribute attr1 in tale.Element("Правило_использования").Attributes())
                                        {
                                            if (attr1.Name == "Предусловие")
                                            {
                                                if (talePrecond == true)
                                                {
                                                    return 5;
                                                }
                                                else { talePrecond = true; rule.precondition = attr1.Value; }
                                            }
                                            else if (attr1.Name == "Convert_event")
                                            {
                                                if (taleEvent == true)
                                                {
                                                    return 5;
                                                }
                                                else { taleEvent = true; rule.convertEvent = attr1.Value; }
                                            }
                                            else if (attr1.Name == "Convert_rule")
                                            {
                                                if (taleRule == true)
                                                {
                                                    return 5;
                                                }
                                                else { taleRule = true; rule.convertRule = attr1.Value; }
                                            }
                                            else if (attr1.Name == "Convert_begin")
                                            {
                                                if (taleBegin == true)
                                                {
                                                    return 5;
                                                }
                                                else { taleBegin = true; rule.convertBegin = attr1.Value; }
                                            }
                                            else if (attr1.Name == "Convert_end")
                                            {
                                                if (taleEnd == true)
                                                {
                                                    return 5;
                                                }
                                                else { taleEnd = true; rule.convertEnd = attr1.Value; }
                                            }
                                            else return 5;
                                        }

                                     }

                                        if (taleName == true && talePrecond == true && taleEvent == true && taleRule == true && taleBegin == true && taleEnd == true) { obrTale = true; operTemp.rule.Add(rule); } else { Console.WriteLine("tale wrong"); return 5; }
                                   
                                }break;
                            }
                        }
                        //если все ок - добавляем в список
                        if (obrName == true && obrRelev == true && obrTale == true && obrTime==true && obrTrace==true && obrType==true) { obr = true; operationTemplateList.Add(operTemp); } else return 5;

                        break;
                    case "Операция":
                        //операция - все аналогично
                        bool operName = false, operTemplName = false; bool oprTele = false;
                        Operation op = new Operation();
                        foreach (XAttribute attr in el.Attributes())
                        {
                            if (attr.Name == "Имя_операции")
                            {
                                if (operName == true)
                                {
                                    return 6;
                                }
                                else { operName = true; op.name = attr.Value; }
                            }
                            else if (attr.Name == "Имя_образца")
                            {
                                if (operTemplName == true)
                                {
                                    return 6;
                                }
                                else { operTemplName = true; op.template = attr.Value; }
                            }
                            else if (attr.Name == "Тело_операции")
                            {
                                if (oprTele == true)
                                {
                                    return 6;
                                }
                                else { oprTele = true; op.tale = attr.Value; }
                            }
                            else return 6;
                        }
                        //добавление в список
                        if (operName == true && operTemplName == true && oprTele == true) { oper = true; operationList.Add(op); } else return 6;
                        break;
                        
                    case "Функция":
                        bool funcName = false, funcType = false, funcTale = false, funcParam = false;
                        Function function = new Function();
                        function.param = new List<FuncParam>();
                        foreach (XAttribute attr in el.Attributes())
                        {
                            if (attr.Name == "Имя_функции")
                            {
                                if (funcName == true)
                                {
                                    return 7;
                                }
                                else { funcName = true; function.name = attr.Value; }
                            }
                            else if (attr.Name == "Возвращаемый_тип")
                            {
                                if (funcType == true)
                                {
                                    return 7;
                                }
                                else { funcType = true; function.type = attr.Value; }
                            }
                            else if (attr.Name == "Тело_функции")
                            {
                                if (funcTale == true)
                                {
                                    return 7;
                                }
                                else { funcTale = true; function.tale = attr.Value; }
                            }
                            else return 7;
                        }
                        foreach (XElement element in el.Elements())
                        {
                            if (element.Name == "Параметр_функции")
                            {
                                bool parName = false, parType = false;
                                FuncParam par = new FuncParam();
                                foreach (XAttribute eletr in element.Attributes())
                                {
                                    if (eletr.Name == "Имя_параметра_функции")
                                    {
                                        if (parName == true)
                                        {
                                            return 7;
                                        }
                                        else { parName = true; par.name = eletr.Value; }
                                    }
                                    else if (eletr.Name == "Тип_параметра_функции")
                                    {
                                        if (parType == true)
                                        {
                                            return 7;
                                        }
                                        else { parType = true; par.type = eletr.Value; }
                                    }
                                    else return 7;
                                    if (parName == true && parType == true) { funcParam = true; function.param.Add(par); }
                                    else param = false;
                                }
                            }
                        }
                        if (funcName == true && funcType == true && funcTale == true && funcParam == true) { func = true; functionList.Add(function); } else return 7;
                        
                        break;
                    default:
                        return 2;

                }

            }
            // если все ок, то возвращаем 0.
            if (resType == true && res == true && obr == true && oper == true && func == true) return 0; else return 2;
        }

        
    }
    
    
    
    
}
