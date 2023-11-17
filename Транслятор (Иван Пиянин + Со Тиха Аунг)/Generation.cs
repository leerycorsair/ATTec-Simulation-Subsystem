using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace ATTranslation
{
    /// <summary>
    /// Генерация кода модели
    /// </summary>
    class Generation : MainWindow
    {
        static StringBuilder resourceBuilder;
        static StringBuilder resourceTypeBuilder;
        static StringBuilder operationTemplateBuilder;
        static StringBuilder operationBuilder;
        static StringBuilder functionBuilder;
        static StringBuilder formingOutParamBuilder;
        static StringBuilder operationCallBuilder;
        static StringBuilder randGenerateBuilder;
        static StringBuilder staticParamBuilder;        
        public void GenerateModelRunTime()
        {
            StaticParamBuild();
            ResourceBuild();
            ResourceTypeBuild();
            OperationTemplateBuild();
            OperationBuild();
            FunctionBuild();
            FormingOutParamRunTime();
            OperationCallBuild();
            RandGenerateBuild();
            MainCodeGenerate();
            //ResultShow();            
        }

        public void GenerateModelDesignTime()
        {
            StaticParamBuild();
            ResourceBuild();
            ResourceTypeBuild();
            OperationTemplateBuild();
            OperationBuild();
            FunctionBuild();
            FormingOutParamDesignTime();
            OperationCallBuild();
            RandGenerateBuild();
            MainCodeGenerate();
            //ResultShow();            
        }
        private void StaticParamBuild()
        {
            staticParamBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(staticParamBuilder);
            for (int i = 0; i < resourceList.Count; i++)
            {
                if (resourceList[i].name != "")
                { sw.WriteLine("static " + resourceList[i].resource + " " + resourceList[i].name + ";"); }
            }
            sw.WriteLine("static int Номер_текущего_такта = 0;"); 
            sw.Close();
        }

        private void ResourceBuild()
        {
            resourceBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(resourceBuilder);
            foreach (Resource res in resourceList)
            {
                foreach (ResourceType resType in resourceTypeList)
                {
                    if (resType.name == res.resource)
                    {
                        sw.WriteLine(res.name + " = " + "new " + res.resource + "();");
                        List<ResourceTypeParameter> rtParameter = resType.param;
                        foreach (ResourceTypeParameter rtp in rtParameter)
                        {
                            if (rtp.name != "")
                            {
                                if (rtp.type != "int" & rtp.type != "double")
                                {
                                    if (rtp.defaul != "")
                                    {
                                        sw.WriteLine(res.name + "." + rtp.name + " = " + resType.name + "." + "Enum_" + rtp.name + "." + rtp.defaul + ";");
                                    }
                                    else
                                    {
                                        sw.WriteLine(res.name + "." + rtp.name + " = " + resType.name + "." + "Enum_" + rtp.name + "." + checkParam(res.defaul, rtParameter.IndexOf(rtp)) + ";");
                                    }
                                }

                                else
                                {
                                    if (rtp.defaul != "")
                                    {
                                        sw.WriteLine(res.name + "." + rtp.name + " = " + rtp.defaul + ";");
                                    }
                                    else
                                    {
                                        sw.WriteLine(res.name + "." + rtp.name + " = " + checkParam(res.defaul, rtParameter.IndexOf(rtp)) + ";");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sw.Close();
        }

        private void ResourceTypeBuild()
        {
            resourceTypeBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(resourceTypeBuilder);
            foreach (ResourceType resType in resourceTypeList)
            {
                if (resType.name != "")
                {
                    sw.WriteLine("class " + resType.name);
                    sw.WriteLine("{");
                    List<ResourceTypeParameter> rtParameter = resType.param;
                    foreach (ResourceTypeParameter rtp in rtParameter)
                    {
                        if (rtp.name != "")
                        {
                            if (rtp.type != "int" & rtp.type != "double")
                            {
                                sw.WriteLine("public enum " + "Enum_" + rtp.name + " " + rtp.type.Remove(0, 4) + ";");
                                sw.WriteLine("public Enum_" + rtp.name + " " + rtp.name + " " + "{ get; set; }");
                            }

                            else
                            {
                                sw.WriteLine("public " + rtp.type + " " + rtp.name + " " + "{ get; set; }");
                            }
                        }
                    }
                    sw.WriteLine("}");
                }
            }
            sw.Close();
        }

        private void OperationTemplateBuild()
        {
            operationTemplateBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(operationTemplateBuilder);
            foreach (OperationTemplate oprTemplate in operationTemplateList)
            {
                sw.Write("private static void " + oprTemplate.name);
                sw.Write("(");
                List<RelevantResource> relvResourceList = oprTemplate.relevantResource;
                foreach (RelevantResource relvResource in relvResourceList)
                {
                    if (relvResource.name != "")
                    {
                        sw.Write(relvResource.descriptor + " " + relvResource.name);
                        if (relvResourceList.IndexOf(relvResource) == relvResourceList.Count - 1)
                        {
                            sw.WriteLine(")");
                        }
                        else
                        {
                            sw.Write(", ");
                        }
                    }
                }
                sw.WriteLine("{");

                List<Rule> ruleList = oprTemplate.rule;
                foreach (Rule rul in ruleList)
                {
                    if (oprTemplate.type == "Правило" && rul.convertRule != "")
                    {
                        sw.WriteLine("if (" + extraCondRule(ruleList) + replaceKeySymbol(rul.precondition) + ")");
                        sw.WriteLine("{" + "\n" + rul.convertRule + "\n" + "}");
                    }
                    if (oprTemplate.type == "Операция" && (rul.convertBegin != "" || rul.convertEnd != ""))
                    {
                        sw.WriteLine("if (" + extraCondOpr(ruleList) + replaceKeySymbol(rul.precondition) + ")");
                        sw.WriteLine("{" + "\n" + rul.convertBegin + "\n" + "System.Threading.Thread.Sleep(" + Convert.ToInt32(oprTemplate.time.value) * 10 + ");" + "\n" + rul.convertEnd + "\n" + "}");
                    }
                    if (oprTemplate.type == "Нерегулярное событие")
                    {
                        sw.WriteLine(rul.convertEvent);
                    }
                }
                sw.WriteLine("}");

            }
             sw.Close();
        }


        private void OperationBuild()
        {
            operationBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(operationBuilder);
            foreach (Operation opr in operationList)
            {
                foreach (OperationTemplate oprTemplate in operationTemplateList)
                {
                    if (oprTemplate.name == opr.template && oprTemplate.type == "Нерегулярное событие")
                    {
                        if (oprTemplate.time.type == "Точное")
                        {
                            sw.WriteLine("static void " + opr.name + "()");
                            sw.WriteLine("{");
                            sw.WriteLine(opr.tale);
                            sw.WriteLine("}");
                        }
                        else
                        {
                            sw.WriteLine("static void " + opr.name + "_Timer_Elapsed(object sender, ElapsedEventArgs e)");
                            sw.WriteLine("{");
                            sw.WriteLine(opr.tale);
                            sw.WriteLine("}");
                        }
                    }
                    else if (oprTemplate.name == opr.template && (oprTemplate.type == "Правило" || oprTemplate.type == "Операция"))
                    {
                        sw.WriteLine("static void " + opr.name + "()");
                        sw.WriteLine("{");
                        sw.WriteLine(opr.tale);
                        sw.WriteLine("}");
                    }
                }
            }
            sw.Close();
        }

        private void FunctionBuild()
        {
            functionBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(functionBuilder);
            foreach (Function func in functionList)
            {
                if (func.name != "" && func.type != "" && func.tale != "")
                {
                    if (func.type == "int")
                    {
                        sw.Write("private static" + " " + func.type + " " + func.name);
                        sw.Write("(");
                        List<FuncParam> funcParamList = func.param;
                        foreach (FuncParam fParam in funcParamList)
                        {
                            if (fParam.name != "" && fParam.type != "")
                            {
                                sw.Write(fParam.type + " " + fParam.name);
                                if (funcParamList.IndexOf(fParam) == funcParamList.Count - 1)
                                {
                                    sw.WriteLine(")");
                                }
                                else
                                {
                                    sw.Write(", ");
                                }
                            }
                            else
                            {
                                sw.WriteLine(")");
                            }
                        }
                        sw.WriteLine("{");
                        sw.WriteLine(replaceKeySymbol(func.tale));
                        sw.WriteLine("else return 0;");
                        sw.WriteLine("}");
                    }
                    else if (func.type == "double")
                    {
                        sw.Write("private static" + " " + func.type + " " + func.name);
                        sw.Write("(");
                        List<FuncParam> funcParamList = func.param;
                        foreach (FuncParam fParam in funcParamList)
                        {
                            if (fParam.name != "" && fParam.type != "")
                            {
                                sw.Write(fParam.type + " " + fParam.name);
                                if (funcParamList.IndexOf(fParam) == funcParamList.Count - 1)
                                {
                                    sw.WriteLine(")");
                                }
                                else
                                {
                                    sw.Write(", ");
                                }
                            }
                            else
                            {
                                sw.WriteLine(")");
                            }
                        }
                        sw.WriteLine("{");
                        sw.WriteLine(replaceKeySymbol(func.tale));
                        sw.WriteLine("return 0.0;");
                        sw.WriteLine("}");
                    }
                    else
                    {
                        sw.Write("private static" + " " + func.type + " " + func.name);
                        sw.Write("(");
                        List<FuncParam> funcParamList = func.param;
                        foreach (FuncParam fParam in funcParamList)
                        {
                            if (fParam.name != "" && fParam.type != "")
                            {
                                sw.Write(fParam.type + " " + fParam.name);
                                if (funcParamList.IndexOf(fParam) == funcParamList.Count - 1)
                                {
                                    sw.WriteLine(")");
                                }
                                else
                                {
                                    sw.Write(", ");
                                }
                            }
                            else
                            {
                                sw.WriteLine(")");
                            }
                        }
                        sw.WriteLine("{");
                        sw.WriteLine(replaceKeySymbol(func.tale));
                        sw.WriteLine("return null;");
                        sw.WriteLine("}");
                    }
                }
                else if (func.name != "" && func.type == "" && func.tale != "")
                {
                    sw.WriteLine("private static void" + " " + func.name + "()");
                    sw.WriteLine("{");
                    sw.WriteLine(replaceKeySymbol(func.tale));
                    sw.WriteLine("}");
                }
            }
            sw.Close();
        }

        private void OperationCallBuild()
        {
            operationCallBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(operationCallBuilder);
            for (int i = 0; i < operationList.Count; i++)
            {
                for (int j = 0; j < operationTemplateList.Count; j++)
                {
                    if (operationTemplateList[j].name == operationList[i].template && operationTemplateList[j].type == "Нерегулярное событие" && operationTemplateList[j].time.type == "Точное")
                    {
                        sw.WriteLine("if (Номер_текущего_такта %"+Convert.ToInt32(operationTemplateList[j].time.value)+"== 0)"+"\n"+
                                     "{"+"\n"+
                                     operationList[i].name + "();" + "\n" +  
                                     "}");
                    }
                    else if (operationTemplateList[j].name == operationList[i].template && operationTemplateList[j].type == "Нерегулярное событие" && operationTemplateList[j].time.type == "Случайное")
                    {
                        sw.WriteLine("if (Номер_текущего_такта %" + Convert.ToInt32(operationTemplateList[j].time.start) + "== 0)" + "\n" +
                                     "{" + "\n" +                              
                                     "System.Timers.Timer " + operationList[i].name + "_Timer = new System.Timers.Timer(rnd.Next(" + Convert.ToDouble(operationTemplateList[j].time.end) * 1000 + "-" + Convert.ToDouble(operationTemplateList[j].time.start) * 1000 + "));" + "\n" +
                                     operationList[i].name + "_Timer.Elapsed += new ElapsedEventHandler(" + operationList[i].name + "_Timer_Elapsed);" + "\n" +
                                     operationList[i].name + "_Timer.Start();"+"\n"+
                                     "}");
                    }
                    else if (operationTemplateList[j].name == operationList[i].template && operationTemplateList[j].type != "Нерегулярное событие")
                    {
                        sw.WriteLine(operationList[i].name + "();");
                    }
                }
            }
            sw.Close();
        }

        private void RandGenerateBuild()
        {
            randGenerateBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(randGenerateBuilder);
            sw.WriteLine("static int Случайное_число(int inputNumber1, int inputNumber2 )" + "\n" +
                        "{" + "\n" +
                        "Random rnd = new Random();" + "\n" +
                        "return rnd.Next(inputNumber1,inputNumber2);" + "\n" +
                        "}");
            sw.Close();
        }

        private void ResultShow()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            StreamReader sr = new StreamReader("C:/file.cs");
            sw.Write(sr.ReadToEnd());
            sr.Close();
            sw.Close();
            MessageBox.Show(sb.ToString());
        }

        private void FormingOutParamDesignTime()
        {
            formingOutParamBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(formingOutParamBuilder);

            sw.WriteLine("static void formingOutParam(string tactNum)" + "\n" +
                          "{" + "\n" +
                          "XmlDocument doc = new XmlDocument();" + "\n" +
                          "doc.Load(" + '"' + "ResourceParameters.xml" + '"' + ");");

            foreach (Resource res in resourceList)
            {
                if (res.name != "")
                {
                    sw.WriteLine("XmlNode " + res.name + "_Node = doc.CreateElement(" + '"' + "Ресурс" + '"' + ");" + "\n" +
                                 "doc.DocumentElement.AppendChild(" + res.name + "_Node);" + "\n" +
                                 "XmlAttribute " + res.name + "_atr = doc.CreateAttribute(" + '"' + "Имя_ресурса" + '"' + ");" + "\n" +
                                 res.name + "_atr.Value = " + '"' + res.name + '"' + ";" + "\n" +
                                 res.name + "_Node.Attributes.Append(" + res.name + "_atr);" + "\n" +
                                 "XmlAttribute " + res.name + "_atr2 = doc.CreateAttribute(" + '"' + "Имя_типа_ресурса" + '"' + ");" + "\n" +
                                 res.name + "_atr2.Value = " + '"' + res.resource + '"' + ";" + "\n" +
                                 res.name + "_Node.Attributes.Append(" + res.name + "_atr2);" + "\n" +
                                 "XmlAttribute " + res.name + "_atr3 = doc.CreateAttribute(" + '"' + "Трассировка" + '"' + ");" + "\n" +
                                 res.name + "_atr3.Value = " + '"' + res.trace + '"' + ";" + "\n" +
                                 res.name + "_Node.Attributes.Append(" + res.name + "_atr3);" + "\n" +
                                 "XmlAttribute " + res.name + "_atr4 = doc.CreateAttribute(" + '"' + "Номер_такта" + '"' + ");" + "\n" +
                                 res.name + "_atr4.Value = tactNum;" + "\n" +
                                 res.name + "_Node.Attributes.Append(" + res.name + "_atr4);");
                }
                foreach (ResourceType resType in resourceTypeList)
                {
                    if (resType.name == res.resource)
                    {
                        List<ResourceTypeParameter> rtParameter = resType.param;
                        foreach (ResourceTypeParameter rtp in rtParameter)
                        {
                            if (rtp.name != "")
                            {

                                sw.WriteLine("XmlNode " + res.name + "_" + rtp.name + " = doc.CreateElement(" + '"' + "Параметр_ресурса" + '"' + ");");
                                sw.WriteLine("XmlAttribute " + res.name + "_" + rtp.name + "Atr = doc.CreateAttribute(" + '"' + "Имя_параметра" + '"' + ");");
                                sw.WriteLine(res.name + "_" + rtp.name + "Atr.Value = " + '"' + rtp.name + '"' + ";");
                                sw.WriteLine(res.name + "_" + rtp.name + ".Attributes.Append(" + res.name + "_" + rtp.name + "Atr);");
                                sw.WriteLine(res.name + "_" + rtp.name + ".InnerText = " + res.name + "." + rtp.name + ".ToString();");
                                sw.WriteLine(res.name + "_Node.AppendChild(" + res.name + "_" + rtp.name + ");");
                            }
                        }
                    }
                }
            }
            sw.WriteLine("doc.Save(" + '"' + "ResourceParameters.xml" + '"' + ");");
            sw.WriteLine("}");
            sw.Close();
        }

        private void FormingOutParamRunTime()
        {
            formingOutParamBuilder = new StringBuilder();
            StringWriter sw = new StringWriter(formingOutParamBuilder);

            sw.WriteLine("static void formingOutParam(string tactNum)" + "\n" +
                          "{" + "\n" +
                          "XmlDocument doc = new XmlDocument();" + "\n" +
                          "doc.Load(@" + '"' + "bb2.xml" + '"' + ");" + "\n" +
                          "XmlNode factlist = doc.SelectSingleNode(" + '"' + "//facts" + '"' + ");" + "\n" +
                          "factlist.RemoveAll();");

            foreach (Resource res in resourceList)
            {
                foreach (ResourceType resType in resourceTypeList)
                {
                    if (resType.name == res.resource)
                    {
                        List<ResourceTypeParameter> rtParameter = resType.param;
                        foreach (ResourceTypeParameter rtp in rtParameter)
                        {
                            if (rtp.name != "")
                            {

                                sw.WriteLine("XmlNode " + res.name + "_" + rtp.name + " = doc.CreateElement(" + '"' + "fact" + '"' + ");");


                                sw.WriteLine("XmlAttribute " + res.name + "_" + rtp.name + "_atr = doc.CreateAttribute(" + '"' + "AttrPath" + '"' + ");");
                                sw.WriteLine(res.name + "_" + rtp.name + "_atr.Value = " + '"' + res.name + "." + rtp.name + '"' + ";");
                                sw.WriteLine(res.name + "_" + rtp.name + ".Attributes.Append(" + res.name + "_" + rtp.name + "_atr);");

                                sw.WriteLine("XmlAttribute " + res.name + "_" + rtp.name + "_atr2 = doc.CreateAttribute(" + '"' + "Value" + '"' + ");");
                                sw.WriteLine(res.name + "_" + rtp.name + "_atr2.Value = " + res.name + "." + rtp.name + ".ToString();");
                                sw.WriteLine(res.name + "_" + rtp.name + ".Attributes.Append(" + res.name + "_" + rtp.name + "_atr2);");

                                sw.WriteLine("XmlAttribute " + res.name + "_" + rtp.name + "_atr3 = doc.CreateAttribute(" + '"' + "Belief" + '"' + ");");
                                sw.WriteLine(res.name + "_" + rtp.name + "_atr3.Value = " + '"' + "50" + '"' + ";");
                                sw.WriteLine(res.name + "_" + rtp.name + ".Attributes.Append(" + res.name + "_" + rtp.name + "_atr3);");

                                sw.WriteLine("XmlAttribute " + res.name + "_" + rtp.name + "_atr4 = doc.CreateAttribute(" + '"' + "MaxBelief" + '"' + ");");
                                sw.WriteLine(res.name + "_" + rtp.name + "_atr4.Value = " + '"' + "100" + '"' + ";");
                                sw.WriteLine(res.name + "_" + rtp.name + ".Attributes.Append(" + res.name + "_" + rtp.name + "_atr4);");

                                sw.WriteLine("XmlAttribute " + res.name + "_" + rtp.name + "_atr5 = doc.CreateAttribute(" + '"' + "Accuracy" + '"' + ");");
                                sw.WriteLine(res.name + "_" + rtp.name + "_atr5.Value = " + '"' + "0" + '"' + ";");
                                sw.WriteLine(res.name + "_" + rtp.name + ".Attributes.Append(" + res.name + "_" + rtp.name + "_atr5);");


                                sw.WriteLine("factlist.AppendChild(" + res.name + "_" + rtp.name + ");");
                            }
                        }
                    }
                }
            }
            sw.WriteLine("doc.Save(@" + '"' + "bb2.xml" + '"' + ");");
            sw.WriteLine("}");
            sw.Close();
        }
        

        private void MainCodeGenerate()
        {
            StreamWriter sw = new StreamWriter("C:/file.cs");
            sw.WriteLine("using System;" + "\n" + "using System.Collections.Generic;" + "\n" + "using System.Linq;" + "\n" + "using System.Text;" + "\n" + "using System.Timers;" + "\n" + "using System.Diagnostics;" + "\n" + "using System.Threading;" + "\n" + "using System.Collections;" + "\n" + "using System.Reflection;" + "\n" + "using System.ComponentModel;" + "\n" + "using System.Data;" + "\n" + "using System.Runtime.InteropServices;" + "\n" + "using System.IO;" + "\n" + "using System.Xml;");
            sw.WriteLine("namespace " + "Model");
            sw.WriteLine("{");
            sw.WriteLine("[assembly: AssemblyKeyFile(" + '"' + "SimModel.snk" + '"' + ")]" + "\n" +
                         "[Guid(" + '"' + "FDE2C8D0-E950-2654-9AE9-516221AFAC31" + '"' + ")]" + "\n" +
                         "[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]" + "\n" +
                         "[ComVisible(true)]");
            sw.WriteLine(" public interface IModel" + "\n" +
                            "{" + "\n" +
                            "[DispId(1)]" + "\n" +
                            "String Name { get; set; }" + "\n" +
                            "[DispId(2)]" + "\n" +
                            "System.Object Broker { get; set; }" + "\n" +
                            "[DispId(3)]" + "\n" +
                            "System.Object Get_Broker();" + "\n" +
                            "[DispId(4)]" + "\n" +
                            "string Get_Name();" + "\n" +
                            "[DispId(5)]" + "\n" +
                            "void Set_Broker(System.Object Value);" + "\n" +
                            "[DispId(6)]" + "\n" +
                            "void Set_Name(string Value);" + "\n" +
                            "[DispId(7)]" + "\n" +
                            "void Configurate(string Config);" + "\n" +
                            "[DispId(8)]" + "\n" +
                            "void ProcessMessage(string SenderName, string MessageText, System.Object OleVariant);" + "\n" +
                            "[DispId(9)]" + "\n" +
                            "void Stop();" + "\n" +
                            "}");

            sw.WriteLine("[Guid(" + '"' + "CBAEA8CE-0FA0-2324-97BA-5E204DD791F9" + '"' + ")]" + "\n" +
                         "[ClassInterface(ClassInterfaceType.None)]" + "\n" +
                         "[ComVisible(true)]");
            sw.WriteLine("public class ATModel : IModel" + "\n" +
                            "{");

            sw.Write(staticParamBuilder.ToString());

            sw.WriteLine("System.Object m_broker;" + "\n" +
                         "string m_name;" + "\n" +

                         "public string Name" + "\n" +
                         "{" + "\n" +
                               "get" + "\n" +
                               "{" + "\n" +
                                   "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                                   "{ sw.WriteLine(" + '"' + "get Name" + '"' + "); }" + "\n" +
                                   "return m_name;" + "\n" +
                               "}" + "\n" +
                               "set" + "\n" +
                               "{" + "\n" +
                                   "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                                   "{ sw.WriteLine(" + '"' + "set Name" + '"' + " + value); }" + "\n" +
                                   "m_name = value;" + "\n" +
                               "}" + "\n" +
                         "}" + "\n" +

                         "public System.Object Broker" + "\n" +
                         "{" + "\n" +
                               "get" + "\n" +
                               "{" + "\n" +
                                   "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                                   "{ sw.WriteLine(" + '"' + "get broker" + '"' + "); }" + "\n" +
                                   "return m_broker;" + "\n" +
                               "}" + "\n" +
                               "set" + "\n" +
                               "{" + "\n" +
                                   "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                                   "{ sw.WriteLine(" + '"' + "1set broker" + '"' + " + value); }" + "\n" +
                                   "m_broker = value;" + "\n" +
                                   "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                                   "{ sw.WriteLine(" + '"' + "2set broker" + '"' + " + m_broker.ToString()); }" + "\n" +
                               "}" + "\n" +
                         "}" + "\n" +

                         "public System.Object Get_Broker()" + "\n" +
                         "{" + "\n" +
                               "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                               "{ sw.WriteLine(" + '"' + "get broker wrong" + '"' + "); }" + "\n" +
                               "return Broker;" + "\n" +
                         "}" + "\n" +

                         "public string Get_Name()" + "\n" +
                         "{" + "\n" +
                               "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                               "{ sw.WriteLine(" + '"' + "get Name wrong" + '"' + "); }" + "\n" +
                               "return Name;" + "\n" +
                         "}" + "\n" +

                         "public void Set_Broker(System.Object Value)" + "\n" +
                         "{" + "\n" +
                               "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                               "{ sw.WriteLine(" + '"' + "set broker wrong" + '"' + "); }" + "\n" +
                               "Broker = Value;" + "\n" +
                         "}" + "\n" +

                         "public void Set_Name(string Value)" + "\n" +
                         "{" + "\n" +
                               "using (StreamWriter sw = File.AppendText(" + '"' + "Log.txt" + '"' + "))" + "\n" +
                               "{ sw.WriteLine(" + '"' + "set name wrong" + '"' + "); }" + "\n" +
                               "Name = Value;" + "\n" +
                         "}" + "\n" +

                         "public void Configurate(string Config)" + "\n" +
                         "{}");

            sw.WriteLine("public void ProcessMessage(string SenderName, string MessageText, System.Object OleVariant)"+ "\n" + 
                         "{"+"\n"+
                         "Номер_текущего_такта = Номер_текущего_такта +1;");
            sw.WriteLine("if (Номер_текущего_такта == 1)" + "\n" + "{");

            sw.Write(resourceBuilder.ToString());
            sw.WriteLine("formingOutParam(MessageText);");
            sw.WriteLine("Random rnd = new Random();");           
            sw.Write(operationCallBuilder.ToString());
            sw.WriteLine("}");
            sw.WriteLine("else" + "\n" + "{");
            sw.WriteLine("formingOutParam(MessageText);");
            sw.WriteLine("Random rnd = new Random();");
            sw.Write(operationCallBuilder.ToString());
            sw.WriteLine("}" + "\n" + "}");

            sw.WriteLine("public void Stop()"+ "\n" +
                         "{"+ "\n" +
                         "Environment.Exit(0);"+ "\n" +
                         "}");

            sw.Write(operationBuilder.ToString());
            sw.Write(operationTemplateBuilder.ToString());
            sw.Write(functionBuilder.ToString());
            sw.Write(randGenerateBuilder.ToString());
            sw.Write(formingOutParamBuilder.ToString());
            sw.WriteLine("}");
            sw.Write(resourceTypeBuilder.ToString());   
            sw.WriteLine("}");
            sw.Close();
        }

        private string extraCondOpr(List<Rule> ruleList)
        {

            string[] temp = new string[ruleList.Count - 1];
            for (int i = 0; i < ruleList.Count; i++)
            {
                if (ruleList[i].convertBegin == "" && ruleList[i].convertEnd == "")
                {
                    temp[i] = ruleList[i].precondition + " && ";
                }
            }
            string output = String.Join(" ", temp);

            return replaceKeySymbol(output);
        }

        private string extraCondRule(List<Rule> ruleList)
        {

            string[] temp = new string[ruleList.Count - 1];
            for (int i = 0; i < ruleList.Count; i++)
            {
                if (ruleList[i].convertRule == "")
                {
                    temp[i] = ruleList[i].precondition + " && ";
                }
            }
            string output = String.Join(" ", temp);

            return replaceKeySymbol(output);
        }

        private string replaceKeySymbol(string conRule)
        {
            var list = conRule.Split().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                var elem = list.ElementAt(i);
                //string nextString = "";
                switch (elem)
                {
                    case "@and@": elem = "&&";
                        break;
                    case "@or@": elem = "||";
                        break;
                    case "@less@": elem = "<";
                        break;
                    case "@more@": elem = ">";
                        break;
                    case "@lessequal@": elem = "<=";
                        break;
                    case "@moreequal@": elem = ">=";
                        break;
                }
                list[i] = elem;
                //i++;
            }
            conRule = string.Join(" ", list);
            return conRule;
        }

        private string checkParam(string param, int paramIndex)
        {
            string paramValues = param.Trim(new Char[] { '{', '}' });
            string[] split = paramValues.Split(new Char[] { ',' });

            return split[paramIndex];
        }
    }
}