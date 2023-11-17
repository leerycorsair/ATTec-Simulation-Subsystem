using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Visualization
{
    public class PatternOperations
    {
        public string POName { get; set; }

        /// <summary>
        /// Вид ресурсов
        /// </summary>
        public string POType { get; set; }
        public bool boolisTrace { get; set; }
        public string isTrace { get; set; }
        public int state { get; set; }
        public string Event { get; set; }
       public void PatternTypeNotEmpty(string PatName, string PatType)
       {
           PatternOperations patEx = new PatternOperations();
           patEx.POName = PatName;
           patEx.POType = PatType;
           if (PatType.Length == 0)
           {
               state = 3;
               Event = "Ошибка образца операций";
           }
       }
       
        public List<PatternBodyParameter> sam { get; set; }

    /// <summary>
        /// Описание параметра
        /// </summary>
        /// 
        public List<PatternBody> POPatBod
        {
            get;
            set;
        }
        public List<RelevantResource> PORevRes
        {
            get;
            set;
        }
        public List<Time> times2 { get; set; }
        /// <summary>
        /// Визуализация
        /// </summary>
        /// 
        public TextBlock Virtual
        {
            get;
            set;
        }
          public void Visuals(ObservableCollection<PatternOperations> PBunc, ListView funcerit, TextAlignment typeOfAlign, Canvas nameOfCanvas, MouseButtonEventHandler entityNameClick)
        {
            TextBlock test = new TextBlock();

            Canvas.SetTop(test, 10);
            Canvas.SetLeft(test, 10);
            test.Foreground = Brushes.Black;
            test.FontSize = 22;
            test.Width = 300;
            test.Height = 90;
            test.TextWrapping = TextWrapping.Wrap;
            funcerit.SelectedIndex = -1;

            test.Text ="Pattern Operation " + PBunc.ElementAt<PatternOperations>(PBunc.Count - 1).POName;
            test.Background = Brushes.LightGreen;
            test.TextAlignment = typeOfAlign;
            test.MouseRightButtonDown += new MouseButtonEventHandler(entityNameClick);
            PBunc.ElementAt(PBunc.Count - 1).Virtual = test;
            nameOfCanvas.Children.Add(test);
        }
    }
    }
