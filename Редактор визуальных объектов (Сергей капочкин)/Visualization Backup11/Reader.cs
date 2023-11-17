using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;

namespace Visualization
{
    public class Reader
    {
        private static Reader instance;

        private static XmlTextReader reader;

        public static Reader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Reader();
                }
                return instance;
            }
        }

        private Reader() { }

        private static void initOutput(string Path)
        {
            reader = new XmlTextReader(Path + "123.xml");
           
        }

        private static void addResourceTypeParameter(ResourceTypeParameter resparam)
        {
            reader.ReadStartElement("Параметр_типа");
            reader.ReadStartElement("Имя_параметра", resparam.Name);
            reader.ReadStartElement("Тип_параметра", resparam.Type);
            reader.ReadStartElement("Умолчание", resparam.Default);
            reader.ReadEndElement();
        }

        private static void addResourseType(ResourceType restype, XmlTextWriter writer)
        {
            reader.ReadStartElement("Тип_ресурсов");
            reader.Read();
            reader.ReadAttributeValue();
            foreach (ResourceTypeParameter resparam in restype.Param)
            { addResourceTypeParameter(resparam); }
            writer.WriteEndElement();
        }

        private static void addResourse(Resource res, XmlTextWriter writer)
        {
            writer.WriteStartElement("Ресурс");
            writer.WriteAttributeString("Имя_ресурса", res.Name);
            writer.WriteAttributeString("Имя_типа_ресурсов", res.RType);
            writer.WriteAttributeString("Трассировка", res.isTrace.ToString());
            foreach (ResourceTypeParameter resparam in res.Param)
            {
                writer.WriteAttributeString("Начальные_значения", resparam.Value);
            }
            writer.WriteEndElement();
        }

        private static void addOperation(Operation op, XmlTextWriter writer)
        {
            writer.WriteStartElement("Операция");
            writer.WriteAttributeString("Имя_операции", op.OPName);
            writer.WriteAttributeString("Имя_образца", op.OPPatName);
            writer.WriteAttributeString("Тело_операции", op.OPBody);
            writer.WriteEndElement();
        }

        private static void addFunctionParameter(FunctionizerParameter funpr, XmlTextWriter writer)
        {
            writer.WriteStartElement("Параметр_функции");
            writer.WriteAttributeString("Имя_параметра_функции", funpr.Name);
            writer.WriteAttributeString("Тип_параметра_функции", funpr.Type);
            writer.WriteEndElement();
        }
        private static void addTime(Time funpr, XmlTextWriter writer)
        {
            writer.WriteStartElement("Время");
            writer.WriteAttributeString("Тип", funpr.TType);
            writer.WriteAttributeString("Закон", funpr.TLaw);
            writer.WriteAttributeString("Значение", funpr.TValue);
            writer.WriteAttributeString("Начало_интервала", funpr.TBeginI);
            writer.WriteAttributeString("Конец_интервала", funpr.TEndI);
            writer.WriteEndElement();
        }

        private static void addFunction(Functionizer fun, XmlTextWriter writer)
        {
            writer.WriteStartElement("Функция");
            writer.WriteAttributeString("Имя_функции", fun.Name);
            writer.WriteAttributeString("Возвращаемый_тип", fun.Type);
            writer.WriteAttributeString("Тело_функции", fun.Body);
            foreach (FunctionizerParameter funpr in fun.Param)
            { addFunctionParameter(funpr, writer); }
            writer.WriteEndElement();
        }
        private static void addBodyRR(RelevantResource res2, XmlTextWriter writer)
        {
            writer.WriteStartElement("Релевантный_ресурс");
            writer.WriteAttributeString("Имя_релевантного_ресурса", res2.RRName);
            foreach (RulesUsed rules2 in res2.RulesUs)
            {
                addRulesUse(rules2, writer);
            }
            writer.WriteEndElement();
        }
        private static void addPB(PatternBody fun2, XmlTextWriter writer)
        {
            writer.WriteStartElement("Тело_образца");
            foreach (RelevantResource funpr2 in fun2.RevList)
            { addBodyRR(funpr2, writer); }
            writer.WriteEndElement();
        }


        private static void addRulesUse(RulesUsed rules, XmlTextWriter writer)
        {
            writer.WriteStartElement("Правило_использования");
            writer.WriteAttributeString("Предусловие", rules.preCondition);
            writer.WriteAttributeString("Convert_event", rules.ConvertEvent);
            writer.WriteAttributeString("Convert_rule", rules.ConvertRule);
            writer.WriteAttributeString("Convert_begin", rules.ConvertBegin);
            writer.WriteAttributeString("Convert_end", rules.ConvertEnd);
            writer.WriteEndElement();
        }
        private static void addRevREs(RelevantResource revresw, XmlTextWriter writer)
        {
            writer.WriteStartElement("Релевантный_ресурс");
            writer.WriteAttributeString("Имя_релевантного_ресурса", revresw.RRName);
            writer.WriteAttributeString("Описатель", revresw.RRDeclarator);
            writer.WriteAttributeString("Статус_конвертора", revresw.statusOfConverter);
            writer.WriteAttributeString("Статус_конвертора_начала", revresw.Converter_begin);
            writer.WriteAttributeString("Статус_конвертора_конца", revresw.Converter_end);
            writer.WriteEndElement();

        }



        private static void addPatternOperation(PatternOperations patbd, XmlTextWriter writer)
        {
            writer.WriteStartElement("Образец_операции");
            writer.WriteAttributeString("Имя_образца", patbd.POName);
            writer.WriteAttributeString("Тип_образца", patbd.POType);
            writer.WriteAttributeString("Трассировка", patbd.isTrace.ToString());
            foreach (RelevantResource relparam in patbd.PORevRes)
            { addRevREs(relparam, writer); }
            foreach (Time tims in patbd.times2)
            {
                addTime(tims, writer);
            }
            foreach (PatternBody patt in patbd.POPatBod)
            {
                addPB(patt, writer);
            }
            writer.WriteEndElement();
        }

        public static void beginOutput(ObservableCollection<ResourceType> resourceType, ObservableCollection<Resource> resource, ObservableCollection<Operation> operation, ObservableCollection<Functionizer> functionizer, ObservableCollection<PatternOperations> POList)
        {
          /*  string Path = "D:/";
            initOutput(Path);
            writer.WriteStartElement("Модель");
            foreach (ResourceType wx in resourceType)
            { addResourseType(wx, writer); }
            foreach (Resource wx in resource)
            { addResourse(wx, writer); }

            //foreach (PatternBody wx in PBList)
            //    { addPatternOperation(wx, writer); }   
            foreach (Functionizer wx in functionizer)
            { addFunction(wx, writer); }
            foreach (PatternOperations wx in POList)
            { addPatternOperation(wx, writer); }
            foreach (Operation wx in operation)
            { addOperation(wx, writer); }



            writer.WriteEndElement();
            writer.Close();*/
        }
    }
}