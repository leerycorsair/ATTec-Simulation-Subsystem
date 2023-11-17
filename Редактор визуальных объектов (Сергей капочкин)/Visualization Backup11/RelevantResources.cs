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
  public  class RelevantResource
    {

        public string RRName
        {
            get;
            set;
        }

      /// <summary>
      /// Признак трассировки
      /// </summary>

       

         public string RRDeclarator
        {
            get;
            set;
        }
      
         public string FKPatternName 
         {
             get; set; 
         }
         public int RRIndex
         {
             get; set; 
         }
         public string FKPatternIndex { get; set; }
      /// <summary>
        /// Соответствующий тип ресурса
        /// </summary>
    
        /// <summary>
        /// Описание параметра
        /// </summary>
        public List<RulesUsed> RulesUs
        {
            get;
            set;
        }
        public string statusOfConverter
        {
            get;
            set;
        }
        public string Converter_begin
        {
            get;
            set;
        }
        public string Converter_end
        {
            get;
            set;
        }
        public string preCondition { get; set; }

        public string ConvertEvent { get; set; }

        public string ConvertRule { get; set; }

        public string ConvertBegin { get; set; }
        public string ConvertEnd { get; set; }
      public List<RelevantResourcerParam> RRparam;
        /// <summary>
        /// Визуализация
        /// </summary>
        public TextBlock RRVisual
        {
            get;
            set;
        }
        /// <summary>
        /// Линия для соединения с соответсвующим образцом операции
        /// </summary>
        public Line RRLine
        {
            get;
            set;
        }
        public static RelevantResource createResourcr(ResourceType res2Type )
        {
            RelevantResource res = new RelevantResource();
            res.RRparam = new List<RelevantResourcerParam>();
            
            res.RRDeclarator =  Convert.ToString(res2Type);
            for (int i = 0; i < res.RRparam.Count; i++)
            {
                RelevantResourcerParam t = new RelevantResourcerParam();
                t.statusOfConverter = res.RRparam.ElementAt(i).statusOfConverter;
                t.Converter_begin = res.RRparam.ElementAt(i).Converter_begin;
                t.Converter_end = res.RRparam.ElementAt(i).Converter_end;
            
                res.RRparam.Add(t);
            }
            
           
          

            return res;
        }
        public void relVisuals(ObservableCollection<RelevantResource> relres, ListView rellist, TextAlignment typeOfAlign, Canvas nameOfCanvas, MouseButtonEventHandler entityNameClick)
        {
            TextBlock test = new TextBlock();

            Canvas.SetTop(test, 10);
            Canvas.SetLeft(test, 10);
            test.Foreground = Brushes.Black;
            test.FontSize = 22;
            test.Width = 300;
            test.Height = 90;
            test.TextWrapping = TextWrapping.Wrap;
            rellist.SelectedIndex = -1;

            test.Text ="Релевантный ресурс: " + relres.ElementAt<RelevantResource>(relres.Count - 1).RRName;
            test.Background = Brushes.Azure;
            test.TextAlignment = typeOfAlign;
            test.MouseRightButtonDown += new MouseButtonEventHandler(entityNameClick);
            relres.ElementAt(relres.Count - 1).RRVisual = test;
            nameOfCanvas.Children.Add(test);
        }
    }
}
