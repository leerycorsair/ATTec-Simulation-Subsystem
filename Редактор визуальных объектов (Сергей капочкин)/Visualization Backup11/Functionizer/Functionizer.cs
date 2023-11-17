using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Visualization
{
   public class Functionizer
    {
        public string Name
        {
            get;
            set;
        }
        /// <summary>
       
        /// </summary>
        public string Type
        {
            get;
            set;
        }
        public string Body
        {
            get;
            set;
        }
        /// <summary>
      
        /// </summary>
        ///
         public TextBlock Vitual
        {
            get;
            set;
        }
        public List<FunctionizerParameter> Param
        {
            get;
            set;
        }
        public Line Line
        {
            get;
            set;
        }
        public void Visuals(ObservableCollection<Functionizer> func, ListView funcerit, TextAlignment typeOfAlign, Canvas nameOfCanvas, MouseButtonEventHandler entityNameClick)
        {
            TextBlock test = new TextBlock();
            
            Canvas.SetTop(test, 10);
            Canvas.SetLeft(test, 10);
            test.Foreground = Brushes.Black;
            test.FontSize = 22;
            test.Width = 100;
            test.Height = 100;
            test.TextWrapping = TextWrapping.WrapWithOverflow;
            funcerit.SelectedIndex = -1;
            
            test.Text = func.ElementAt<Functionizer>(func.Count - 1).Body;
            test.Background = Brushes.Azure;
            test.TextAlignment = typeOfAlign;
            test.MouseRightButtonDown += new MouseButtonEventHandler(entityNameClick);
            test.ToolTip = "Тип функции: " + func.ElementAt<Functionizer>(func.Count - 1).Type + "Тело_функции: " + func.ElementAt<Functionizer>(func.Count - 1).Body;
                             
            nameOfCanvas.Children.Add(test);
        }
    }
}
