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
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.CSharp;
using System.CodeDom.Compiler;


namespace ATTranslation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        
        public static List<ResourceType> resourceTypeList = new List<ResourceType>();
        public static List<Resource> resourceList = new List<Resource>();
        public static List<OperationTemplate> operationTemplateList = new List<OperationTemplate>();
        public static List<Operation> operationList = new List<Operation>();
        public static List<Function> functionList = new List<Function>();
        static OpenFileDialog ofd;

        public MainWindow()
        {
            InitializeComponent();
            Log = "Запуск транслятора";

        }
        /// <summary>
        /// Запись в лог
        /// </summary>
        public string Log
        {
            set
            {
                LogBlock.Text = value;
            }

        }

        public void StartTranslation()
        {
            RunLexic(@"D:\123.xml");
            GenerateDll();
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            openLabel.Foreground = Brushes.Black;
            openLabel.FontWeight = FontWeights.Bold;
            //открываем диалог выбора файла
            ofd = new OpenFileDialog();
            ofd.Filter = "Файл модели|*.xml";
            ofd.DefaultExt = ".xml";
            ofd.Multiselect = false;
            ofd.Title = "Выберите файл модели на языке РДОАТ";

            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
                openLabel.Foreground = Brushes.Green;
                openLabel.FontWeight = FontWeights.Regular;
                lexicLabel.Foreground = Brushes.Black;
                lexicLabel.FontWeight = FontWeights.Bold;
                // Log.Text += Environment.NewLine+ "Открытие ОК!";
                Log = "Открытие ОК!";

                //запускаем лексический анализ
                RunLexic(ofd.FileName);

            }

        }
        private void RunLexic(string filename)
        {

            int result = LexicAnalysis.start(filename);
            if (result != 0)
            {
                //Ошибка 1 - Ошибка чтения XML (Несколько корневых элементов)
                //Ошибка 2 - Найдена нераспознанная лексема, либо присутствуют не все лексемы
                //Ошибка 3 - Ошибка лексического анализа (Ошибка чтения типа ресурсов)
                //Ошибка 4 - Ошибка лексического анализа (Ошибка чтения ресурса)
                //Ошибка 5 - Ошибка лексического анализа (Ошибка чтения образца операции)
                //Ошибка 6 - Ошибка лексического анализа (Ошибка чтения операции)
                //Ошибка 7 - Ошибка лексического анализа (Ошибка чтения функции)
                MessageBox.Show("Ошибка при работе лексического анализатора. Код ошибки " + result, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                lexicLabel.Foreground = Brushes.Green;
                lexicLabel.FontWeight = FontWeights.Regular;
                RunSyntax();
            }

        }
        private void RunSyntax()
        {
            syntaxLabel.Foreground = Brushes.Black;
            syntaxLabel.FontWeight = FontWeights.Bold;
            Tuple<int, XElement> _res = SyntaxAnalysis.start();
            int result = _res.Item1;

            if (result != 0)
            {
                //Ошибка 8 - Не для всех ресурсов найден тип ресурсов
                //Ошибка 9 - Не для всех операций найден образец операции
                //Ошибка 10 - Не для всех образцов операций найден тип ресурсов
                //Ошибка 11 - У типа ресурсов нет ресурсов
                //Ошибка 12 - У типа ресурсов нет образцов операций
                //Ошибка 13 - У образцов операций нет операций
                MessageBox.Show("Ошибка при работе синтаксического анализатора. Код ошибки " + result, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                syntaxLabel.Foreground = Brushes.Green;
                syntaxLabel.FontWeight = FontWeights.Regular;
                RunSemantic(_res.Item2);
            }
        }
        private void RunSemantic(XElement tree)
        {
            semanticLabel.Foreground = Brushes.Black;
            semanticLabel.FontWeight = FontWeights.Bold;
            int result = SemanticAnalysis.start(tree, resourceTypeList, resourceList, operationTemplateList, operationList, functionList);
            if (result != 0)
            {
                //Ошибка 14 - Начальные значения ресурсов не совпадают с количеством параметров
                //Ошибка 15 - В теле образца и в самом образце релевантные ресурсы не совпадают
                //Ошибка 16 - //Если образец - событие, то только convert_event, правило - convert_rule, событие - Convert_begin и convert_end
                //Ошибка 17 - Проверка, что в предусловии стоят правильные имена релевантных ресурсов
                //Ошибка 18 - В теле функции неправильные ресурсы используются
                MessageBox.Show("Ошибка при работе семантического анализатора. Код ошибки " + result, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                semanticLabel.Foreground = Brushes.Green;
                semanticLabel.FontWeight = FontWeights.Regular;
            }
        }


        private void GenerateDll()
        {
            StreamReader sr = new StreamReader("C:/file.cs");
            StringBuilder sb = new StringBuilder(sr.ReadToEnd());
            sr.Close();
            string program = sb.ToString();
            Dictionary<string, string> providerOptions = new Dictionary<string, string>
        {
          {"CompilerVersion", "v3.5"}
        };
            //string filepath = ofd.FileName;

            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
            // Свойства компилятора - Имя файла, куда записывать. Если писать exe, то надо прописать параметр GenerateExecutable на true
            CompilerParameters compilerParams = new CompilerParameters { OutputAssembly = "123.dll", GenerateExecutable = false };
            //Необходимые импорты
            compilerParams.ReferencedAssemblies.Add("System.Core.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Dll");
            compilerParams.ReferencedAssemblies.Add("System.XML.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.Dll");
            // Компиляция

            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, program);

            // Выводим информацию об ошибках
            Console.WriteLine("Number of Errors: {0}", results.Errors.Count);
            foreach (CompilerError err in results.Errors)
            {
                MessageBox.Show("ERROR {0}", err.ErrorText);
                Console.WriteLine("ERROR {0}", err.ErrorText);
            }
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {}

        private void GenerateForRunTime_Click(object sender, RoutedEventArgs e)
        {

            Generation GenerationInstance = new Generation();
            GenerationInstance.GenerateModelRunTime();

            StreamReader sr = new StreamReader("C:/file.cs");
            StringBuilder sb = new StringBuilder(sr.ReadToEnd());
            sr.Close();
            string program = sb.ToString();
            Dictionary<string, string> providerOptions = new Dictionary<string, string>
        {
          {"CompilerVersion", "v3.5"}
        };
            //string filepath = ofd.FileName;

            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
            // Свойства компилятора - Имя файла, куда записывать. Если писать exe, то надо прописать параметр GenerateExecutable на true
            CompilerParameters compilerParams = new CompilerParameters { OutputAssembly = textBox1.Text.ToString() + ".dll", GenerateExecutable = false };
            //Необходимые импорты
            compilerParams.ReferencedAssemblies.Add("System.Core.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Dll");
            compilerParams.ReferencedAssemblies.Add("System.XML.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.Dll");
            // Компиляция

            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, program);

            // Выводим информацию об ошибках
            Console.WriteLine("Number of Errors: {0}", results.Errors.Count);
            foreach (CompilerError err in results.Errors)
            {
                MessageBox.Show("ERROR {0}", err.ErrorText);
                Console.WriteLine("ERROR {0}", err.ErrorText);
            }
        }

        private void GenerateForDesingTime_Click(object sender, RoutedEventArgs e)
        {
            Generation GenerationInstance = new Generation();
            GenerationInstance.GenerateModelDesignTime();
            StreamReader sr = new StreamReader("C:/file.cs");
            StringBuilder sb = new StringBuilder(sr.ReadToEnd());
            sr.Close();
            string program = sb.ToString();
            Dictionary<string, string> providerOptions = new Dictionary<string, string>
        {
          {"CompilerVersion", "v3.5"}
        };
            //string filepath = ofd.FileName;

            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
            // Свойства компилятора - Имя файла, куда записывать. Если писать exe, то надо прописать параметр GenerateExecutable на true
            CompilerParameters compilerParams = new CompilerParameters { OutputAssembly = textBox1.Text.ToString() + ".dll", GenerateExecutable = false };
            //Необходимые импорты
            compilerParams.ReferencedAssemblies.Add("System.Core.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Dll");
            compilerParams.ReferencedAssemblies.Add("System.XML.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.Dll");
            // Компиляция

            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, program);

            // Выводим информацию об ошибках
            Console.WriteLine("Number of Errors: {0}", results.Errors.Count);
            foreach (CompilerError err in results.Errors)
            {
                MessageBox.Show("ERROR {0}", err.ErrorText);
                Console.WriteLine("ERROR {0}", err.ErrorText);
            }
        }
        
        }
    }
