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
    /// <summary>
    /// Тип ресурса
    /// </summary>
    public class ResourceType
    {
        /// <summary>
        /// Имя типа
        /// </summary>
        public string Name
    {
        get; 
        set;
    }
       /// <summary>
       /// Вид ресурсов
       /// </summary>
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Описание параметра
        /// </summary>
        public List<ResourceTypeParameter> Param
        {
            get;
            set;
        }
        /// <summary>
        /// Визуализация
        /// </summary>
        public TextBlock Visual
        {
            get;
            set;
        }
        public void Visuals(ObservableCollection<ResourceType> res, ContextMenu resuble, ListView resview, TextAlignment ce, Canvas rek, MouseButtonEventHandler reka)
        {
            TextBlock test = new TextBlock();

            Canvas.SetTop(test, 10);
            Canvas.SetLeft(test, 10);
            test.Foreground = Brushes.Blue;
            test.FontSize = 22;
            test.Width = 200;
            test.Height = 60;
            test.TextWrapping = TextWrapping.Wrap;
            test.ContextMenu = resuble;
            resview.SelectedIndex = -1;
            test.Text = res.ElementAt<ResourceType>(res.Count - 1).Name;
            test.Background = Brushes.Red;
            test.TextAlignment = ce;
            test.MouseRightButtonDown += new MouseButtonEventHandler(reka);
            res.ElementAt(res.Count - 1).Visual = test;
            rek.Children.Add(test);
        }
    }
  
}
