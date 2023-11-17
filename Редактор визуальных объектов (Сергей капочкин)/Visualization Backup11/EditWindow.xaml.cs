using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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
using System.Globalization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows.Media.Animation;



namespace Visualization
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml

    public partial class EditWindow : Window
    {
        public static List<ResourceType> resourceTypeList3 = new List<ResourceType>();
        public static List<Resource> resourceList3 = new List<Resource>();
        public static List<PatternOperations> operationTemplateList = new List<PatternOperations>();
        public static List<Operation> operationList = new List<Operation>();
        public static List<Functionizer> functionList = new List<Functionizer>();
        public ObservableCollection<Functionizer> FunctionizerParameterList = new ObservableCollection<Functionizer>();
        public ObservableCollection<Resource> resourceList = new ObservableCollection<Resource>();
        public ObservableCollection<ResourceType> resourceTypeList = new ObservableCollection<ResourceType>();
        public ObservableCollection<RelevantResource> RRlist = new ObservableCollection<RelevantResource>();

        public ObservableCollection<ResourceTypeParameter> resourceTypeParameterList =
            new ObservableCollection<ResourceTypeParameter>();

        public ObservableCollection<PatternBody> PBList = new ObservableCollection<PatternBody>();
        public ObservableCollection<PatternBodyParameter> RBPlist = new ObservableCollection<PatternBodyParameter>();
        public ObservableCollection<PatternBodyParameter> RBP2list = new ObservableCollection<PatternBodyParameter>();
        public ObservableCollection<PatternOperations> POList = new ObservableCollection<PatternOperations>();
        public ObservableCollection<Operation> OperList = new ObservableCollection<Operation>();
        public ObservableCollection<Time> TimeList = new ObservableCollection<Time>();

        public ObservableCollection<FunctionizerParameter> FunctionizerParameter2List =
            new ObservableCollection<FunctionizerParameter>();

        public ObservableCollection<RelevantResourcerParam> RRPlist = new ObservableCollection<RelevantResourcerParam>();
        public ObservableCollection<XElement> XmlList = new ObservableCollection<XElement>();
        public ObservableCollection<RulesUsed> RulesList = new ObservableCollection<RulesUsed>();
        public ObservableCollection<XElement> PBXmlList = new ObservableCollection<XElement>();
        private ContextMenu OperationContext;

        public EditWindow()
        {
            InitializeComponent();
            lstw.ItemsSource = resourceTypeList;
            resourceLstw.ItemsSource = resourceList;
            funcview.ItemsSource = FunctionizerParameterList;
            RelReslistView.ItemsSource = RRlist;
            PattOperView.ItemsSource = POList;
            operLstView.ItemsSource = OperList;
        }

        #region Вспомогательный функционал окна

        /// <summary>
        /// Что делать при загрузке страницы?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyCanvas = new Canvas();
            /* OperationContext = new ContextMenu();
             MenuItem viewFunc = new MenuItem();
             viewFunc.Header = "Посмотреть";
             viewFunc.Click += new RoutedEventHandler(MenuItem_Click);
             OperationContext.Items.Add(viewFunc);
             MenuItem deleteFunc = new MenuItem();
             viewFunc.Header = "Удалить";
             viewFunc.Click += new RoutedEventHandler(MenuItem_Click);
             OperationContext.Items.Add(viewFunc);
             MenuItem clone2 = new MenuItem();
             clone2.Header = "Создать дубликат";
             clone2.Click += new RoutedEventHandler(cloneResourceType_Click);
             OperationContext.Items.Add(clone2);*/
            resourceTypeContext = new ContextMenu();
            MenuItem viewContext = new MenuItem();
            viewContext.Header = "Посмотреть";
            viewContext.Click += new RoutedEventHandler(showResourceType_Click);
            resourceTypeContext.Items.Add(viewContext);

            MenuItem delete = new MenuItem();
            delete.Header = "Удалить";
            delete.Click += new RoutedEventHandler(deleteResourceType_Click);
            resourceTypeContext.Items.Add(delete);

            MenuItem clone = new MenuItem();
            clone.Header = "Создать дубликат";
            clone.Click += new RoutedEventHandler(cloneResourceType_Click);
            resourceTypeContext.Items.Add(clone);

            MenuItem add = new MenuItem();
            add.Header = "Создать ресурс";
            add.Click += new RoutedEventHandler(addResource_Click);
            resourceTypeContext.Items.Add(add);

            MyCanvas.PreviewMouseLeftButtonDown +=
                new System.Windows.Input.MouseButtonEventHandler(MyCanvas_PreviewMouseLeftButtonDown);
            MyCanvas.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(MyCanvas_PreviewMouseMove);
            MyCanvas.PreviewMouseLeftButtonUp +=
                new System.Windows.Input.MouseButtonEventHandler(MyCanvas_PreviewMouseLeftButtonUp);
            this.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(window1_PreviewKeyDown);

            canvas.Children.Add(MyCanvas);
            var cvo = new RelevantResourcerParam
                {
                    Converter_begin = "Keep",
                    Converter_end = "Erase",
                    statusOfConverter = "Save",
                    FKRelevantName = "Res"

                };
            var cvo2 = new RelevantResourcerParam
                {
                    Converter_begin = "Save",
                    Converter_end = "Keep",
                    statusOfConverter = "Save",
                    FKRelevantName = "sar"
                };

        }

        /// <summary>
        /// Нажатие на "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение выхода",
                                                   MessageBoxButton.YesNo);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    {
                        this.Close();
                        break;
                    }
                case MessageBoxResult.No:
                    return;
            }
        }

        /// <summary>
        /// О программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Редактор моделей для подсистемы имитационного моделирования комплекса АТ-ТЕХНОЛОГИЯ. \r\nЛаборатория \"Системы искусственного интеллекта\".\r\nНИЯУ МИФИ. \r\n2012 ",
                "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Справка по РДО
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void help_Click(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/RAO-language.chm");
        }

        #endregion

        #region Тип ресурсов

        /// <summary>
        /// Добавление типа ресурсов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addResourceType_Click(object sender, RoutedEventArgs e)
        {
            ResourceType v = new ResourceType();
            ResourceTypeWindow createWindow = new ResourceTypeWindow();
            int i = resourceTypeList.Count;
            createWindow.Owner = this;
            createWindow.ShowDialog();
            if (i < resourceTypeList.Count)
            {
                v.Visuals(resourceTypeList, resourceTypeContext, lstw, TextAlignment.Center, MyCanvas, ResourceTypeClick);


            }


        }


        /// <summary>
        /// Просмотр типа ресурсов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showResourceType_Click(object sender, RoutedEventArgs e)
        {
            if (resourceTypeList.Count == 0) return;
            if (lstw.SelectedIndex == -1)
            {
                for (int i = 0; i < resourceTypeList.Count; i++)
                {
                    if (resourceTypeList.ElementAt(i).Name == activeBlock.Text)
                    {
                        ResourceTypeWindow editWindow = new ResourceTypeWindow(resourceTypeList.ElementAt(i));
                        editWindow.Owner = this;
                        editWindow.ShowDialog();
                        lstw.SelectedIndex = -1;
                    }

                }
            }
            else
            {
                ResourceTypeWindow editWindow = new ResourceTypeWindow(resourceTypeList.ElementAt(lstw.SelectedIndex));
                editWindow.Owner = this;
                editWindow.ShowDialog();
                lstw.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Удаление типа ресурсов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteResourceType_Click(object sender, RoutedEventArgs e)
        {
            if (resourceTypeList.Count == 0) return;
            ResourceType element = new ResourceType();
            if (lstw.SelectedIndex == -1)
            {
                for (int i = 0; i < resourceTypeList.Count; i++)
                {
                    if (resourceTypeList.ElementAt(i).Name == activeBlock.Text)
                    {
                        element = resourceTypeList.ElementAt(i);
                    }

                }
            }
            else
            {
                element = resourceTypeList.ElementAt(lstw.SelectedIndex);
            }
            HashSet<Resource> set = new HashSet<Resource>();
            String result = "";
            bool found = false;
            for (int i = 0; i < resourceList.Count; i++)
            {
                if (resourceList.ElementAt(i).Type == element)
                {
                    set.Add(resourceList.ElementAt(i));
                    result += "\r\n" + resourceList.ElementAt(i).Name;
                    found = true;
                }
            }

            if (found)
            {
                MessageBoxResult res =
                    MessageBox.Show(
                        "Вы действительно хотите удалить выбранный тип ресурса? Также будут удалены следующие ресурсы:" +
                        result, "Подтверждение удаления", MessageBoxButton.YesNo);
                switch (res)
                {
                    case MessageBoxResult.Yes:
                        {
                            MyCanvas.Children.Remove(element.Visual);
                            resourceTypeList.Remove(element);
                            for (int i = 0; i < set.Count; i++)
                            {
                                MyCanvas.Children.Remove(set.ElementAt(i).Visual);
                                MyCanvas.Children.Remove(set.ElementAt(i).Line);
                                resourceList.Remove(set.ElementAt(i));
                            }
                            return;
                        }
                    case MessageBoxResult.No:
                        return;
                }
            }
            else
            {
                MyCanvas.Children.Remove(element.Visual);
                resourceTypeList.Remove(element);
            }

            lstw.SelectedIndex = -1;

        }

        /// <summary>
        /// Копирование типа ресурсов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cloneResourceType_Click(object sender, RoutedEventArgs e)
        {
            if (resourceTypeList.Count == 0) return;
            ResourceType cloneType = new ResourceType();
            if (lstw.SelectedIndex == -1)
            {
                for (int i = 0; i < resourceTypeList.Count; i++)
                {
                    if (resourceTypeList.ElementAt(i).Name == activeBlock.Text)
                    {
                        cloneType = resourceTypeList.ElementAt(i);
                    }

                }
            }
            else
            {
                cloneType = resourceTypeList.ElementAt(lstw.SelectedIndex);
            }


            lstw.SelectedIndex = -1;
            TextBlock test = new TextBlock();

            Canvas.SetTop(test, 10);
            Canvas.SetLeft(test, 10);
            test.Foreground = Brushes.Blue;
            test.FontSize = 22;
            test.Width = 200;
            test.Height = 60;
            test.TextWrapping = TextWrapping.Wrap;
            test.ContextMenu = resourceTypeContext;

            test.Text = cloneType.Name;
            test.Background = Brushes.Yellow;
            test.TextAlignment = TextAlignment.Center;
            cloneType.Visual = test;
            resourceTypeList.Add(cloneType);
            MyCanvas.Children.Add(test);
        }

        #endregion


        #region Ресурс

        /// <summary>
        /// Добавление ресурса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addResource_Click(object sender, RoutedEventArgs e)
        {
            if (resourceTypeList.Count == 0)
            {
                MessageBox.Show("Для добавления ресурса необходимо наличие типа ресурсов!");
                return;
            }
            ResourceWindow createWindow;

            ResourceType element = new ResourceType();
            if (lstw.SelectedIndex == -1)
            {
                for (int q = 0; q < resourceTypeList.Count; q++)
                {
                    if (activeBlock != null && resourceTypeList.ElementAt(q).Name == activeBlock.Text)
                    {
                        element = resourceTypeList.ElementAt(q);
                    }

                }
            }
            else
            {
                element = resourceTypeList.ElementAt(lstw.SelectedIndex);
            }

            if (activeBlock == null && lstw.SelectedIndex == -1)
            {
                createWindow = new ResourceWindow(resourceTypeList);
            }
            else
            {
                createWindow = new ResourceWindow(element);
            }

            int i = resourceList.Count;
            createWindow.Owner = this;
            createWindow.ShowDialog();
            lstw.SelectedIndex = -1;
            if (i < resourceList.Count)
            {

                TextBlock test = new TextBlock();

                Canvas.SetTop(test, 10);
                Canvas.SetLeft(test, 10);
                test.Foreground = Brushes.Yellow;
                test.FontSize = 22;
                test.Width = 200;
                test.Height = 60;
                test.TextWrapping = TextWrapping.Wrap;
                // test.ContextMenu = resourceTypeContext;
                // TODO: Сделать контекстное меню для тектсблока ресурса
                test.Text = resourceList.ElementAt(resourceList.Count - 1).Name;
                test.Background = Brushes.Blue;
                test.TextAlignment = TextAlignment.Center;
                resourceList.ElementAt(resourceList.Count - 1).Visual = test;
                MyCanvas.Children.Add(test);

                Binding x1 = new Binding();

                x1.Path = new PropertyPath(Canvas.LeftProperty);
                x1.Source = resourceList.ElementAt(resourceList.Count - 1).Visual;
                Binding y1 = new Binding();

                y1.Path = new PropertyPath(Canvas.TopProperty);
                y1.Source = resourceList.ElementAt(resourceList.Count - 1).Visual;
                Binding x2 = new Binding();

                x2.Path = new PropertyPath(Canvas.LeftProperty);
                x2.Source = resourceList.ElementAt(resourceList.Count - 1).Type.Visual;
                Binding y2 = new Binding();

                y2.Path = new PropertyPath(Canvas.TopProperty);
                y2.Source = resourceList.ElementAt(resourceList.Count - 1).Type.Visual;

                Line con = new Line();
                con.SetBinding(Line.X1Property, x1);
                con.SetBinding(Line.Y1Property, y1);
                con.SetBinding(Line.X2Property, x2);
                con.SetBinding(Line.Y2Property, y2);
                con.Stroke = Brushes.Blue;
                resourceList.ElementAt(resourceList.Count - 1).Line = con;
                MyCanvas.Children.Add(con);
            }

        }

        /// <summary>
        /// Просмотр ресурса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showResource_Click(object sender, RoutedEventArgs e)
        {
            if (resourceList.Count == 0) return;
            ResourceWindow editWindow = new ResourceWindow(resourceList.ElementAt(resourceLstw.SelectedIndex));
            editWindow.Owner = this;
            editWindow.ShowDialog();
            resourceLstw.SelectedIndex = -1;
        }

        /// <summary>
        /// Удаление ресурса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteResource_Click(object sender, RoutedEventArgs e)
        {
            if (resourceList.Count == 0) return;
            MyCanvas.Children.Remove(resourceList.ElementAt(resourceLstw.SelectedIndex).Visual);
            MyCanvas.Children.Remove(resourceList.ElementAt(resourceLstw.SelectedIndex).Line);
            resourceList.Remove(resourceList.ElementAt(resourceLstw.SelectedIndex));
            resourceLstw.SelectedIndex = -1;

        }

        #endregion

        #region Drag&Drop

        private void window1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape && _isDragging)
            {
                DragFinished(true);
            }
        }

        private void MyCanvas_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_isDown)
            {
                DragFinished(false);
                e.Handled = true;
            }
        }

        private void ResourceTypeClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            activeBlock = e.Source as TextBlock;

        }

        private void FunctionTypeClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            funActiveBlock = e.Source as TextBlock;

        }

        private void PatternBOdyTypeClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            funActiveBlock = e.Source as TextBlock;

        }

        private void ReleveantResourceClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            funActiveBlock = e.Source as TextBlock;

        }

        private void DragFinished(bool cancelled)
        {
            System.Windows.Input.Mouse.Capture(null);
            if (_isDragging)
            {
                AdornerLayer.GetAdornerLayer(_overlayElement.AdornedElement).Remove(_overlayElement);

                if (cancelled == false)
                {
                    Canvas.SetTop(_originalElement, _originalTop + _overlayElement.TopOffset);
                    Canvas.SetLeft(_originalElement, _originalLeft + _overlayElement.LeftOffset);
                }
                _overlayElement = null;

            }
            _isDragging = false;
            _isDown = false;
        }

        private void MyCanvas_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDown)
            {
                if ((_isDragging == false) &&
                    ((Math.Abs(e.GetPosition(MyCanvas).X - _startPoint.X) >
                      SystemParameters.MinimumHorizontalDragDistance) ||
                     (Math.Abs(e.GetPosition(MyCanvas).Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)))
                {
                    DragStarted();
                }
                if (_isDragging)
                {
                    DragMoved();
                }
            }
        }

        private void DragStarted()
        {
            _isDragging = true;
            _originalLeft = Canvas.GetLeft(_originalElement);
            _originalTop = Canvas.GetTop(_originalElement);

            _overlayElement = new SimpleCircleAdorner(_originalElement);
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(_originalElement);
            layer.Add(_overlayElement);

        }

        private void DragMoved()
        {
            Point CurrentPosition = System.Windows.Input.Mouse.GetPosition(MyCanvas);

            _overlayElement.LeftOffset = CurrentPosition.X - _startPoint.X;
            _overlayElement.TopOffset = CurrentPosition.Y - _startPoint.Y;

        }

        private void MyCanvas_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.Source == MyCanvas)
            {
            }
            else
            {
                _isDown = true;
                _startPoint = e.GetPosition(MyCanvas);
                _originalElement = e.Source as UIElement;
                MyCanvas.CaptureMouse();
                e.Handled = true;
            }
        }

        private Point _startPoint;
        private double _originalLeft;
        private double _originalTop;
        private bool _isDown;
        private bool _isDragging;
        private UIElement _originalElement;
        private SimpleCircleAdorner _overlayElement;
        private TextBlock activeBlock;
        private TextBlock funActiveBlock;
        private ContextMenu resourceTypeContext;
        private Canvas MyCanvas;

        private void addMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void functionMenu_Click(object sender, RoutedEventArgs e)
        {
            FunctionWindow createWindow = new FunctionWindow();
            int i = FunctionizerParameterList.Count;
            createWindow.Owner = this;
            createWindow.ShowDialog();
            Functionizer funci = new Functionizer();

            if (i < FunctionizerParameterList.Count)
            {


                funci.Visuals(FunctionizerParameterList, funcview, TextAlignment.Center, MyCanvas, FunctionTypeClick);
            }


            /*
                     MenuItem delete = new MenuItem();
           delete.Header = "Удалить";
           delete.Click += new RoutedEventHandler(deleteResourceType_Click);
           resourceTypeContext.Items.Add(delete);

           MenuItem clone = new MenuItem();
           clone.Header = "Создать дубликат";
           clone.Click += new RoutedEventHandler(cloneResourceType_Click);
           resourceTypeContext.Items.Add(clone);
            
           */
            /*   TextBlock test = new TextBlock();

                    Canvas.SetTop(test, 10);
                    Canvas.SetLeft(test, 10);
                    test.Foreground = Brushes.Red;
                    test.FontSize = 22;
                    test.Width = 200;
                    test.Height = 60;
                    test.TextWrapping = TextWrapping.Wrap;
                    // test.ContextMenu = resourceTypeContext;
                    // TODO: Сделать контекстное меню для тектсблока ресурса
                    test.Text = FunctionizerParameterList.ElementAt(FunctionizerParameterList.Count - 1).Body;
                    test.Background = Brushes.Blue;
                    test.MouseRightButtonDown += new MouseButtonEventHandler(FunctionTypeClick);
                    test.TextAlignment = TextAlignment.Center;
 
                    MyCanvas.Children.Add(test);*/

            /*                Binding x1 = new Binding();

                            x1.Path = new PropertyPath(Canvas.LeftProperty);
                            x1.Source = FunctionizerParameterList.ElementAt(FunctionizerParameterList.Count - 1).Vitual;
                            Binding y1 = new Binding();

                            y1.Path = new PropertyPath(Canvas.TopProperty);
                            y1.Source = FunctionizerParameterList.ElementAt(FunctionizerParameterList.Count - 1).Vitual;
                            Binding x2 = new Binding();

                            x2.Path = new PropertyPath(Canvas.LeftProperty);
                            x2.Source = FunctionizerParameterList.ElementAt(FunctionizerParameterList.Count - 1).Vitual;
                            Binding y2 = new Binding();

                            y2.Path = new PropertyPath(Canvas.TopProperty);
                            y2.Source = FunctionizerParameterList.ElementAt(FunctionizerParameterList.Count - 1).Vitual;

                            Line con = new Line();
                            con.SetBinding(Line.X1Property, x1);
                            con.SetBinding(Line.Y1Property, y1);
                            con.SetBinding(Line.X2Property, x2);
                            con.SetBinding(Line.Y2Property, y2);
                            con.Stroke = Brushes.Blue;
                            FunctionizerParameterList.ElementAt(FunctionizerParameterList.Count - 1).Line = con;
                            MyCanvas.Children.Add(con);
                            */

        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (FunctionizerParameterList.Count == 0) return;
            if (funcview.SelectedIndex == -1)
            {
                for (int i = 0; i < FunctionizerParameterList.Count; i++)
                {
                    if (resourceTypeList.ElementAt(i).Name == activeBlock.Text)
                    {
                        FunctionWindow feditWindow = new FunctionWindow(FunctionizerParameterList.ElementAt(i));
                        feditWindow.Owner = this;
                        feditWindow.ShowDialog();
                        lstw.SelectedIndex = -1;
                    }

                }
            }
            else
            {
                FunctionWindow feditWindow =
                    new FunctionWindow(FunctionizerParameterList.ElementAt(funcview.SelectedIndex));
                feditWindow.Owner = this;
                feditWindow.ShowDialog();
                funcview.SelectedIndex = -1;
            }
        }

        private void saveMenu_Click(object sender, RoutedEventArgs e)
        {
            /* XElement res = new XElement(
                 "Модель",
                
                 RRlist.Join(RRPlist,
                 rrl=>rrl.RRName, rrpl=>rrpl.FKRelevantName,
                 (rrl, rrpl) => new { rrl, rrpl }).Select(sc =>
                 new XElement("Релевантный_ресурс", 
                     new XAttribute("Имя_релавантного_ресурса",sc.rrl.RRName),
                     new XAttribute("Статус_конвертера_начала", sc.rrpl.Converter_begin))));
             testTextBox.Text = res.ToString();*/

            /*     XElement  xmodel = 
                   new XElement("Модель",
                                                  
                                                                          resourceTypeList.Select(sc => 
                                                                     
                                                                              new XElement("Тип_ресурсов",
                                                                                  new XAttribute("Имя_типа_ресурсов",sc.Name),
                                                                                  new XAttribute("Вид_типа_ресурсов", sc.Type),
                                                                                  new XElement("Параметр_типа_ресурсов",

                                                                              new XAttribute("Имя_параметра",sc.Param.ElementAt(0).Name),
                                                                              new XAttribute("Тип_параметра", sc.Param.ElementAt(0).Type),
                                                                              new XAttribute("Значние", sc.Param.ElementAt(0).Default))
                                                                  
                                                                                  )),
                                                                                  resourceList.Select(resLis=>
                                                                                  new XElement("Ресурсы",
                                                                                      new XAttribute("Имя_ресурсов", resLis.Name),
                                                                                      new XAttribute("Имя_типа_ресурсов",resLis.Type.Name),
                                                                                      new XAttribute("Трассировка",resLis.isTrace)))
                                                                               
                                                                                     );*/
            /*   textBox222.Text = xmodel.ToString();*/
            /*XElement xmodle2 = new XElement(
                   "Модель",
                   PBList.Select(pB =>
                                 new XElement("Образец_операции",
                                              new XAttribute("Имя_образца", pB.POName),
                                              new XAttribute("Тип_образца", pB.POType),
                                              new XAttribute("Трассировка", pB.POisTrace),
                                              new XElement("Релевантный_ресурс",
                                                                         new XAttribute("Имя_релевантного_ресурса",
                                                                                        RRlist.Last().RRName),
                                                                         new XAttribute("Описатель", RRlist.ElementAt(0).RRDeclarator),
                                                                         new XAttribute("Статус_конвертера",RRPlist.ElementAt(0).statusOfConverter),
                                                                         new XAttribute("Статус_конвертера_начала",RRPlist.ElementAt(0).Converter_begin),
                                                                         new XAttribute("Статус_конвертера_конца",RRPlist.ElementAt(0).Converter_end)),
                                                                         TimeList.Select(timers3=>
                                                           new XElement("Время",
                                                               new XAttribute("Тип_времени", timers3.TType),
                                                                   new XAttribute("Закон_времени", timers3.TLaw),
                                                                   new XAttribute("Значение", timers3.TValue),
                                                                   new XAttribute("Начало_интервала_времени", timers3.TBeginI),
                                                                   new XAttribute("Конец_интервала_времени", timers3.TEndI))),
                                                                   new XElement("Тело_образца",
                                                                       new XElement ("Релевантный_ресурс",
                                                                           new XAttribute("Имя_релевантного_ресурса", RRlist.ElementAt(0).RRName),
                                                                           RBPlist.Select(rbpdf=>
                                                                           new XElement("Правило_использования",
                                                                 new XAttribute("Предусловие",
                                                                                         rbpdf.precondition),
                                                                          new XAttribute("Событие_конвертера",
                                                                                         rbpdf.ConvertEvent),
                                                                          new XAttribute("Правило_конвертера",
                                                                                         rbpdf.ConvertRule),
                                                                          new XAttribute("Начало_конца", rbpdf.ConvertBegin),
                                                                          new XAttribute("Конвертер_конца", rbpdf.ConvertEnd))))))));*/

            /*  res.Save("132.xml");
              XElement xmodel =
                  new XElement("Модель",
                               resourceTypeList.Select(rpt =>
                                                       new XElement("Тип_ресурсов",
                                                                    new XAttribute("Имя_типа_ресурсов", rpt.Name),
                                                                    new XAttribute("Вид_типа_ресурсов", rpt.Type),
                                                                    resourceTypeParameterList.Select(rptp =>
                                                                                                     new XElement(
                                                                                                         "Параметр_типа_ресурсов",
                                                                                                         new XAttribute(
                                                                                                             "Имя_параметра",
                                                                                                             rptp.Name),
                                                                                                         new XAttribute(
                                                                                                             "Тип_параметра",
                                                                                                             rptp.Type),
                                                                                                         new XAttribute(
                                                                                                             "Умолчание",
                                                                                                             rptp.Default))))))
                                                     
                               ;
                      
                         */
            Writer.beginOutput(resourceTypeList, resourceList, OperList, FunctionizerParameterList, POList);

            /*    RRlist.Select(p =>
                                 new XElement("Релевантный_ресурс",
                                 new XAttribute("Имя_релевантного_ресурса", p.RRName),
                                 new XAttribute("Описатель", p.RRDeclarator))),
                RBPlist.Select(p =>
                               new XElement("Правило_использования",
                                            new XAttribute("Предусловие", p.precondition = "a"),
                                            new XAttribute("Событие_конвертера", p.ConvertEvent),
                                            new XAttribute("Правило_конвертера", p.ConvertRule),
                                            new XAttribute("Начало_конца", p.ConvertBegin),
                                            new XAttribute("Конвертер_конца", p.ConvertEnd))));*/

            /*   s.Join(lefterList,
               s => s.FKLeftName, c => c.LeftName,
               (s, c) => new { s, c }).Select(sc =>

                   new XElement("Образец_операции",
                       new XElement("Тело_образца",

                   new XAttribute("Right", sc.c.LeftName),
                   new XAttribute("RightPar", sc.c.LeftParam),
                   new XAttribute("Righte", sc.c.LeftType)),
                   new XElement("Рел_ресурс",
                       new XAttribute("имя", sc.s.FKLeftName),
                       new XAttribute("RightThings", sc.s.RightThings),
                       new XAttribute("RightType", sc.s.RightType)))

                       )));
res.Save("132.xml"); */


        }

        private void patternOperationMenu_Click(object sender, RoutedEventArgs e)
        {


            PatternOperationWindow createWindow = new PatternOperationWindow();

            createWindow.Owner = this;
            createWindow.ShowDialog();
        }


        private void startMenu_Click(object sender, RoutedEventArgs e)
        {


            StartProject createWindow = new StartProject();

            createWindow.Owner = this;
            createWindow.ShowDialog();
        }

        private void RevelantResoursesMenu_Click(object sender, RoutedEventArgs e)
        {
            if (resourceTypeList.Count == 0)
            {
                MessageBox.Show("Для добавления ресурса необходимо наличие типа ресурсов!");
                return;
            }
            RevelantResourceWindow createWindow;

            ResourceType element = new ResourceType();
            if (lstw.SelectedIndex == -1)
            {
                for (int q = 0; q < resourceTypeList.Count; q++)
                {
                    if (activeBlock != null && resourceTypeList.ElementAt(q).Name == activeBlock.Text)
                    {
                        element = resourceTypeList.ElementAt(q);
                    }

                }
            }
            else
            {
                element = resourceTypeList.ElementAt(lstw.SelectedIndex);
            }

            if (activeBlock == null && lstw.SelectedIndex == -1)
            {
                createWindow = new RevelantResourceWindow(resourceTypeList);
            }
            else
            {
                createWindow = new RevelantResourceWindow(element);
            }

            int i = resourceList.Count;
            createWindow.Owner = this;
            createWindow.ShowDialog();
            lstw.SelectedIndex = -1;
            if (i < RRlist.Count)
            {
                TextBlock test = new TextBlock();

                Canvas.SetTop(test, 10);
                Canvas.SetLeft(test, 10);
                test.Foreground = Brushes.Black;
                test.FontSize = 22;
                test.Width = 300;
                test.Height = 90;
                test.TextWrapping = TextWrapping.Wrap;
                RelReslistView.SelectedIndex = -1;

                test.Text = "Релевантный ресурс " +
                            " " + RRlist.ElementAt<RelevantResource>(RRlist.Count - 1).RRName;
                test.Background = Brushes.Azure;
                test.TextAlignment = TextAlignment.Center;
                test.MouseRightButtonDown += new MouseButtonEventHandler(ReleveantResourceClick);
                RRlist.ElementAt(RRlist.Count - 1).RRVisual = test;
                MyCanvas.Children.Add(test);
                ToolTip terra = new ToolTip();
                test.ToolTip = (RRlist.ElementAt<RelevantResource>(RRlist.Count - 1).RRName);
            }
        }




        public class SimpleCircleAdorner : Adorner
        {
            // Be sure to call the base class constructor.
            public SimpleCircleAdorner(UIElement adornedElement)
                : base(adornedElement)
            {
                VisualBrush _brush = new VisualBrush(adornedElement);

                _child = new Rectangle();
                _child.Width = adornedElement.RenderSize.Width;
                _child.Height = adornedElement.RenderSize.Height;


                DoubleAnimation animation = new DoubleAnimation(0.3, 1, new Duration(TimeSpan.FromSeconds(1)));
                animation.AutoReverse = true;
                animation.RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever;
                _brush.BeginAnimation(System.Windows.Media.Brush.OpacityProperty, animation);

                _child.Fill = _brush;
            }

            // A common way to implement an adorner's rendering behavior is to override the OnRender
            // method, which is called by the layout subsystem as part of a rendering pass.
            protected override void OnRender(DrawingContext drawingContext)
            {
                // Get a rectangle that represents the desired size of the rendered element
                // after the rendering pass.  This will be used to draw at the corners of the 
                // adorned element.
                Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

                // Some arbitrary drawing implements.
                SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
                renderBrush.Opacity = 0.2;
                Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
                double renderRadius = 5.0;

                // Just draw a circle at each corner.
                drawingContext.DrawRectangle(renderBrush, renderPen, adornedElementRect);
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius,
                                           renderRadius);
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius,
                                           renderRadius);
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius,
                                           renderRadius);
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius,
                                           renderRadius);
            }

            protected override Size MeasureOverride(Size constraint)
            {
                _child.Measure(constraint);
                return _child.DesiredSize;
            }

            protected override Size ArrangeOverride(Size finalSize)
            {
                _child.Arrange(new Rect(finalSize));
                return finalSize;
            }

            protected override Visual GetVisualChild(int index)
            {
                return _child;
            }

            protected override int VisualChildrenCount
            {
                get { return 1; }
            }

            public double LeftOffset
            {
                get { return _leftOffset; }
                set
                {
                    _leftOffset = value;
                    UpdatePosition();
                }
            }

            public double TopOffset
            {
                get { return _topOffset; }
                set
                {
                    _topOffset = value;
                    UpdatePosition();

                }
            }

            private void UpdatePosition()
            {
                AdornerLayer adornerLayer = this.Parent as AdornerLayer;
                if (adornerLayer != null)
                {
                    adornerLayer.Update(AdornedElement);
                }
            }

            public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
            {
                GeneralTransformGroup result = new GeneralTransformGroup();
                result.Children.Add(base.GetDesiredTransform(transform));
                result.Children.Add(new TranslateTransform(_leftOffset, _topOffset));
                return result;
            }

            private Rectangle _child = null;
            private double _leftOffset = 0;
            private double _topOffset = 0;
        }

        #endregion

        private void patternBodyMenu_Click(object sender, RoutedEventArgs e)
        {
            if (resourceTypeList.Count == 0)
            {
                MessageBox.Show("Для добавления ресурса необходимо наличие типа ресурсов!");
                return;
            }
            PatternBodyWindower createWindow;

            ResourceType RRelement = new ResourceType();
            if (lstw.SelectedIndex == -1)
            {
                for (int q = 0; q < RRlist.Count; q++)
                {
                    if (activeBlock != null && RRlist.ElementAt(q).RRName == activeBlock.Text)
                    {
                        RRelement = resourceTypeList.ElementAt(q);
                    }

                }
            }
            else
            {
                RRelement = resourceTypeList.ElementAt(lstw.SelectedIndex);
            }

            if (activeBlock == null && lstw.SelectedIndex == -1)
            {
                createWindow = new PatternBodyWindower(RRelement);
            }
            else
            {
                createWindow = new PatternBodyWindower(RRelement);
            }

            int i = 0;
            createWindow.Owner = this;
            createWindow.ShowDialog();
            lstw.SelectedIndex = -1;
            PatternOperations newPB = new PatternOperations();
            if (i < POList.Count)
            {
                newPB.times2 = new List<Time>();
                TextBlock test = new TextBlock();

                Canvas.SetTop(test, 10);
                Canvas.SetLeft(test, 10);
                test.Foreground = Brushes.Black;
                test.FontSize = 22;
                test.Width = 300;
                test.Height = 90;
                test.TextWrapping = TextWrapping.Wrap;
                PattOperView.SelectedIndex = -1;
                test.FontStyle = FontStyles.Oblique;
                test.Text = "Тело образца: " + POList.ElementAt<PatternOperations>(POList.Count - 1).POName;


                test.Background = Brushes.Azure;
                test.TextAlignment = TextAlignment.Center;
                test.MouseRightButtonDown += new MouseButtonEventHandler(PatternBOdyTypeClick);
                POList.ElementAt(POList.Count - 1).Virtual = test;
                MyCanvas.Children.Add(test);
                ToolTip terra = new ToolTip();
                /* test.ToolTip = "Тип образца операции: " + PBList.ElementAt<PatternBody>(PBList.Count - 1).POType +
                                 "Тип времени:  " + TimeList.ElementAt(PBList.Count-1).TType ;*/
            }
        }

        private void OperationMenu_Click(object sender, RoutedEventArgs e)
        {
            if (POList.Count == 0)
            {
                MessageBox.Show("Для добавления Операции необходимо наличие образца операции!");
                return;
            }
            OperationWindow createWindow;

            PatternOperations Pelement = new PatternOperations();
            if (PattOperView.SelectedIndex == -1)
            {
                for (int q = 0; q < POList.Count; q++)
                {
                    if (activeBlock != null && POList.ElementAt(q).POName == activeBlock.Text)
                    {
                        Pelement = POList.ElementAt(q);
                    }

                }
            }
            else
            {
                Pelement = POList.ElementAt(PattOperView.SelectedIndex);
            }

            if (activeBlock == null && PattOperView.SelectedIndex == -1)
            {
                createWindow = new OperationWindow(POList);
            }
            else
            {
                createWindow = new OperationWindow(Pelement);
            }

            int i = 0;
            createWindow.Owner = this;
            createWindow.ShowDialog();
            PattOperView.SelectedIndex = -1;
            if (i < OperList.Count)
            {

                TextBlock test = new TextBlock();

                Canvas.SetTop(test, 10);
                Canvas.SetLeft(test, 10);
                test.Foreground = Brushes.Yellow;
                test.FontSize = 22;
                test.Width = 200;
                test.Height = 60;
                test.TextWrapping = TextWrapping.Wrap;
                // test.ContextMenu = resourceTypeContext;
                // TODO: Сделать контекстное меню для тектсблока ресурса
                test.Text = OperList.ElementAt(OperList.Count - 1).OPName;
                test.Background = Brushes.DeepPink;
                test.TextAlignment = TextAlignment.Center;
                ToolTip re = new ToolTip();


                OperList.ElementAt(OperList.Count - 1).Visual = test;
                MyCanvas.Children.Add(test);

                Binding x1 = new Binding();

                x1.Path = new PropertyPath(Canvas.LeftProperty);
                x1.Source = OperList.ElementAt(OperList.Count - 1).Visual;
                Binding y1 = new Binding();

                y1.Path = new PropertyPath(Canvas.TopProperty);
                y1.Source = OperList.ElementAt(OperList.Count - 1).Visual;
                Binding x2 = new Binding();

                x2.Path = new PropertyPath(Canvas.LeftProperty);
                x2.Source = POList.ElementAt(OperList.ElementAt(OperList.Count - 1).OPIndex).Virtual;
                // Индекс записывается Selected Index с комбобокса для выбора соответствующего 
                Binding y2 = new Binding();

                y2.Path = new PropertyPath(Canvas.TopProperty);
                y2.Source = POList.ElementAt(OperList.ElementAt(OperList.Count - 1).OPIndex).Virtual;

                Line con = new Line();
                con.SetBinding(Line.X1Property, x1);
                con.SetBinding(Line.Y1Property, y1);
                con.SetBinding(Line.X2Property, x2);
                con.SetBinding(Line.Y2Property, y2);
                con.Stroke = Brushes.DeepPink;
                OperList.ElementAt(OperList.Count - 1).Line = con;
                MyCanvas.Children.Add(con);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (RRlist.Count == 0) return;
            RevelantResourceWindow rreditWindow =
                new RevelantResourceWindow(RRlist.ElementAt(RelReslistView.SelectedIndex));
            rreditWindow.Owner = this;
            rreditWindow.ShowDialog();
            resourceLstw.SelectedIndex = 0;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {


        }

        private void loadMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Описание модели(*.XML)|*.xml; ";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {


                XElement xDoc = XElement.Load(myDialog.FileName);
                int ar = 0;
                int funcCounter = 0;
                int RRCounter = 0;
                int PBCounter = 0;
                int RelRevCOunter = 0;
                int OperCounter = 0;

                int resourceTypeCounter = 0;

                while (OperCounter < xDoc.Elements("Операция").Count())
                {

                    {

                        if (xDoc.Elements("Операция").ElementAt(OperCounter).Attribute("Имя_образца").Value.Any())
                        {
                            var OperEx = new Operation
                                {
                                    OPPatName =
                                        xDoc.Elements("Операция").ElementAt(OperCounter).Attribute("Имя_образца").Value,
                                    OPName =
                                        xDoc.Elements("Операция").ElementAt(OperCounter).Attribute("Имя_операции").Value,
                                    OPBody =
                                        xDoc.Elements("Операция")
                                            .ElementAt(OperCounter)
                                            .Attribute("Тело_операции")
                                            .Value
                                };

                            OperCounter++;
                            OperList.Add(OperEx);
                        }
                    }
                }



                while (resourceTypeCounter < xDoc.Elements("Тип_ресурсов").Count())
                {
                    var restype = new ResourceType
                        {
                            Name =
                                xDoc.Elements("Тип_ресурсов")
                                    .ElementAt(resourceTypeCounter)
                                    .Attribute("Имя_типа_ресурсов")
                                    .Value,
                            Type =
                                xDoc.Elements("Тип_ресурсов")
                                    .ElementAt(resourceTypeCounter)
                                    .Attribute("Вид_типа_ресурсов")
                                    .Value

                        };
                    int restp = 0;
                    restype.Param = new List<ResourceTypeParameter>();
                    while (restp <
                           xDoc.Elements("Тип_ресурсов")
                               .ElementAt(resourceTypeCounter)
                               .Elements("Параметр_типа")
                               .Count())
                    {

                        var restypeParam = new ResourceTypeParameter
                            {
                                Name = xDoc.Elements("Тип_ресурсов").
                                            ElementAt(resourceTypeCounter).Elements("Параметр_типа").
                                            ElementAt(restp).Attribute("Имя_параметра").Value,
                                Type = xDoc.Elements("Тип_ресурсов").
                                            ElementAt(resourceTypeCounter).Elements("Параметр_типа").
                                            ElementAt(restp).Attribute("Тип_параметра").Value,
                                Default = xDoc.Elements("Тип_ресурсов").
                                               ElementAt(resourceTypeCounter).Elements("Параметр_типа").
                                               ElementAt(restp).Attribute("Умолчание").Value

                            };

                        restp++;
                        restype.Param.Add(restypeParam);
                        resourceTypeParameterList.Add(restypeParam);

                    }
                    resourceTypeList.Add(restype);
                    resourceTypeCounter++;

                }

                while (RRCounter < xDoc.Elements("Образец_операции").Count())
                {

                    var pa = new PatternOperations
                        {
                            POName =
                                xDoc.Elements("Образец_операции")
                                    .ElementAt(RRCounter)
                                    .Attribute("Имя_образца")
                                    .Value,
                            POType =
                                xDoc.Elements("Образец_операции")
                                    .ElementAt(RRCounter)
                                    .Attribute("Тип_образца")
                                    .Value,
                            isTrace =
                                xDoc.Elements("Образец_операции")
                                    .ElementAt(RRCounter)
                                    .Attribute("Трассировка")
                                    .Value


                        };

                    if (pa.isTrace == "Да")
                    {
                        pa.boolisTrace = true;
                    }
                    else
                    {
                        pa.boolisTrace = false;
                    }
                    pa.times2 = new List<Time>();

                    {
                        if (xDoc.Elements("Образец_операции")
                                .ElementAt(RRCounter)
                                .Elements("Время").Any())
                        {
                            var timers = new Time
                                {
                                    TType = xDoc.Elements("Образец_операции")
                                                .ElementAt(RRCounter)
                                                .Elements("Время")
                                                .ElementAt(0).Attribute("Тип").Value,
                                    TEndI = xDoc.Elements("Образец_операции")
                                                .ElementAt(RRCounter)
                                                .Elements("Время")
                                                .ElementAt(0).Attribute("Конец_интервала").Value,
                                    TLaw = xDoc.Elements("Образец_операции")
                                               .ElementAt(RRCounter)
                                               .Elements("Время")
                                               .ElementAt(0).Attribute("Закон").Value,
                                    TBeginI = xDoc.Elements("Образец_операции")
                                                  .ElementAt(RRCounter)
                                                  .Elements("Время")
                                                  .ElementAt(0).Attribute("Начало_интервала").Value,
                                    TValue = xDoc.Elements("Образец_операции")
                                                 .ElementAt(RRCounter)
                                                 .Elements("Время")
                                                 .ElementAt(0).Attribute("Значение").Value,
                                };


                            pa.times2.Add(timers);
                            TimeList.Add(timers);
                        }
                        else
                        {
                            MessageBox.Show("NEXT!");
                        }
                    }



                    int PBRelRevCounter = 0;
                    while (PBRelRevCounter <
                           xDoc.Elements("Образец_операции")
                               .ElementAt(RRCounter)
                               .Elements("Релевантный_ресурс")
                               .Count())
                    {
                        pa.PORevRes = new List<RelevantResource>();
                        var relres = new RelevantResource
                            {
                                RRName =
                                    xDoc.Elements("Образец_операции")
                                        .ElementAt(RRCounter)
                                        .Elements("Релевантный_ресурс")
                                        .ElementAt(PBRelRevCounter)
                                        .Attribute("Имя_релевантного_ресурса")
                                        .Value,
                                RRDeclarator = xDoc.Elements("Образец_операции")
                                                   .ElementAt(RRCounter)
                                                   .Elements("Релевантный_ресурс")
                                                   .ElementAt(PBRelRevCounter)
                                                   .Attribute("Описатель")
                                                   .Value,
                                statusOfConverter = xDoc.Elements("Образец_операции")
                                                        .ElementAt(RRCounter)
                                                        .Elements("Релевантный_ресурс")
                                                        .ElementAt(PBRelRevCounter)
                                                        .Attribute("Статус_конвертора")
                                                        .Value,
                                Converter_begin = xDoc.Elements("Образец_операции")
                                                      .ElementAt(RRCounter)
                                                      .Elements("Релевантный_ресурс")
                                                      .ElementAt(PBRelRevCounter)
                                                      .Attribute("Статус_конвертора_начала")
                                                      .Value,
                                Converter_end = xDoc.Elements("Образец_операции")
                                                    .ElementAt(RRCounter)
                                                    .Elements("Релевантный_ресурс")
                                                    .ElementAt(PBRelRevCounter)
                                                    .Attribute("Статус_конвертора_конца")
                                                    .Value

                            };
                        RRlist.Add(relres);
                        pa.POPatBod = new List<PatternBody>();
                        PatternBody PBvar = new PatternBody();
                        pa.PORevRes = new List<RelevantResource>();
                        PBvar.RevList = new List<RelevantResource>();
                        var xElement =
                            xDoc.Elements("Образец_операции").ElementAt(RRCounter).Element("Тело_образца");
                        if (xElement != null)
                        {
                            var PBRev = new RelevantResource
                                {
                                    RRName =
                                        xElement
                                            .Elements("Релевантный_ресурс")
                                            .ElementAt(PBRelRevCounter)
                                            .Attribute("Имя_релевантного_ресурса")
                                            .Value
                                };
                            PBRev.RulesUs = new List<RulesUsed>();
                            var element =
                                xElement.Elements("Релевантный_ресурс")
                                        .ElementAt(PBRelRevCounter)
                                        .Element("Правило_использования");
                            if (element != null)
                            {
                                var RevRUle = new RulesUsed

                                    {
                                        preCondition = element
                                            .Attribute("Предусловие")
                                            .Value,
                                        ConvertEvent = element
                                            .Attribute("Convert_event")
                                            .Value,
                                        ConvertRule = element
                                            .Attribute("Convert_rule")
                                            .Value,
                                        ConvertBegin = element
                                            .Attribute("Convert_begin")
                                            .Value,
                                        ConvertEnd = element
                                            .Attribute("Convert_end")
                                            .Value

                                    };
                                PBRev.RulesUs.Add(RevRUle);
                                RulesList.Add(RevRUle);
                            }
                            PBvar.RevList.Add(PBRev);
                        }
                        PBList.Add(PBvar);
                        pa.PORevRes.Add(relres);
                        RRlist.Add(relres);
                        PBRelRevCounter++;
                        pa.POPatBod.Add(PBvar);
                    }
                    /*  pa.times2.Add(timers);
                TimeList.Add(timers);*/

                    POList.Add(pa);
                    int i = resourceList.Count;

                    lstw.SelectedIndex = -1;
                    PatternOperations newPB = new PatternOperations();
                    if (i < PBList.Count)
                    {
                        newPB.times2 = new List<Time>();
                        TextBlock test = new TextBlock();

                        Canvas.SetTop(test, 10);
                        Canvas.SetLeft(test, 10);
                        test.Foreground = Brushes.Black;
                        test.FontSize = 22;
                        test.Width = 300;
                        test.Height = 90;
                        test.TextWrapping = TextWrapping.Wrap;
                        PattOperView.SelectedIndex = -1;
                        test.FontStyle = FontStyles.Oblique;
                        test.Text = "Тело образца: " + POList.ElementAt<PatternOperations>(POList.Count - 1).POName;


                        test.Background = Brushes.Azure;
                        test.TextAlignment = TextAlignment.Center;
                        test.MouseRightButtonDown += new MouseButtonEventHandler(PatternBOdyTypeClick);
                        POList.ElementAt(POList.Count - 1).Virtual = test;
                        MyCanvas.Children.Add(test);
                        ToolTip terra = new ToolTip();
                        /* test.ToolTip = "Тип образца операции: " + PBList.ElementAt<PatternBody>(PBList.Count - 1).POType +
                                       "Тип времени:  " + TimeList.ElementAt(PBList.Count-1).TType ;*/
                    }
                    XmlList.Add(xDoc.Elements("Образец_операции").ElementAt(RRCounter));
                    RRCounter++;

                }

                int PBCounter2 = 0;




                while (funcCounter < xDoc.Elements("Функция").Count())
                {
                    int funcParamCounter = 0;
                    try
                    {
                        var funcVar = new Functionizer
                            {
                                Name = xDoc.Elements("Функция").ElementAt(funcCounter).Attribute("Имя_функции").Value,
                                Body = xDoc.Elements("Функция").ElementAt(funcCounter).Attribute("Тело_функции").Value,
                                Type =
                                    xDoc.Elements("Функция").ElementAt(funcCounter).Attribute("Возвращаемый_тип").Value
                            };

                        FunctionizerParameterList.Add(funcVar);

                        funcVar.Param = new List<FunctionizerParameter>();
                        while (funcParamCounter <
                               xDoc.Elements("Функция").ElementAt(funcCounter).Elements("Параметр_функции").Count())
                        {

                            try
                            {
                                var funcParamVar = new FunctionizerParameter()
                                    {
                                        Name =
                                            xDoc.Elements("Функция")
                                                .ElementAt(funcCounter)
                                                .Elements("Параметр_функции")
                                                .ElementAt(funcCounter)
                                                .Attribute("Имя_параметра_функции")
                                                .Value,
                                        Type =
                                            xDoc.Elements("Функция")
                                                .ElementAt(funcCounter)
                                                .Elements("Параметр_функции")
                                                .ElementAt(funcCounter)
                                                .Attribute("Тип_параметра_функции")
                                                .Value
                                    };

                                funcVar.Param.Add(funcParamVar);
                                FunctionizerParameter2List.Add(funcParamVar);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                MessageBox.Show("f**k");
                            }

                            funcParamCounter++;
                        }

                        funcVar.Visuals(FunctionizerParameterList, funcview, TextAlignment.Center, MyCanvas,
                                        FunctionTypeClick);
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Ошибка в теге функция");
                    }
                    funcCounter++;
                }

                while (ar < xDoc.Elements("Ресурс").Count())
                {
                    var c = new Resource
                        {
                            Name = xDoc.Elements("Ресурс").ElementAt(ar).Attribute("Имя_ресурса").Value,
                            RType = xDoc.Elements("Ресурс").ElementAt(ar).Attribute("Имя_типа_ресурсов").Value,
                            isTrace =
                                (xDoc.Elements("Ресурс").ElementAt(ar).Attribute("Трассировка").Value)

                        };
                    c.Type = new ResourceType();
                    var sdf = new ResourceType

                        {
                            Name = xDoc.Elements("Ресурс").ElementAt(ar).Attribute("Имя_типа_ресурсов").Value
                        };
                    c.Type.Name = sdf.Name;
                    resourceList.Add(c);
                    resourceList.ElementAt(resourceList.Count - 1).Type = new ResourceType();
                    c.Param = new List<ResourceTypeParameter>();
                    var rp = new ResourceTypeParameter()
                        {
                            Value = xDoc.Elements("Ресурс").ElementAt(ar).Attribute("Начальные_значения").Value
                        };
                    c.Param.Add(rp);
                    resourceTypeParameterList.Add(rp);



                    /* if (ix >= xDoc.Elements("Тип_ресурсов").Count() &
                      ar < xDoc.Elements("Тип_ресурсов").Elements("Параметр_типа").Count())
                  {
                      ix = 0;
                      ar++;
                  }*/
                    TextBlock test = new TextBlock();

                    Canvas.SetTop(test, 10);
                    Canvas.SetLeft(test, 10);
                    test.Foreground = Brushes.Yellow;
                    test.FontSize = 22;
                    test.Width = 200;
                    test.Height = 60;
                    test.TextWrapping = TextWrapping.Wrap;
                    // test.ContextMenu = resourceTypeContext;
                    // TODO: Сделать контекстное меню для тектсблока ресурса
                    test.Text = resourceList.ElementAt(resourceList.Count - 1).Name;
                    test.Background = Brushes.Blue;
                    test.TextAlignment = TextAlignment.Center;
                    resourceList.ElementAt(resourceList.Count - 1).Visual = test;
                    MyCanvas.Children.Add(test);

                    Binding x1 = new Binding();

                    x1.Path = new PropertyPath(Canvas.LeftProperty);
                    x1.Source = resourceList.ElementAt(resourceList.Count - 1).Visual;
                    Binding y1 = new Binding();

                    y1.Path = new PropertyPath(Canvas.TopProperty);
                    y1.Source = resourceList.ElementAt(resourceList.Count - 1).Visual;
                    Binding x2 = new Binding();

                    x2.Path = new PropertyPath(Canvas.LeftProperty);
                    x2.Source = resourceTypeList.ElementAt(resourceTypeList.Count - 1).Visual;
                    Binding y2 = new Binding();

                    y2.Path = new PropertyPath(Canvas.TopProperty);
                    y2.Source = resourceTypeList.ElementAt(resourceTypeList.Count - 1).Visual;

                    Line con = new Line();
                    con.SetBinding(Line.X1Property, x1);
                    con.SetBinding(Line.Y1Property, y1);
                    con.SetBinding(Line.X2Property, x2);
                    con.SetBinding(Line.Y2Property, y2);
                    con.Stroke = Brushes.Blue;
                    resourceList.ElementAt(resourceList.Count - 1).Line = con;
                    MyCanvas.Children.Add(con);
                    ar++;
                }
            }
        }

        private void savePatternMenu_Click(object sender, RoutedEventArgs e)
        {

            /*  int pbcount = 0;

            var pattern = from p in PBList
                          where PBList.ElementAt(0).POName == "2"
                          select p;
            var RRL = RRlist.Join(RRPlist,
                                  rrl => rrl.RRName, rrpl => rrpl.FKRelevantName,
                                  (rrl, rrpl) => new {rrl, rrpl});
          ;
            var times2 = TimeList.Join(POList,
                                       tl => tl.TFKPatternName, pol => pol.POName,
                                       (tl, pol) => new {tl, pol});
            var PBPvar = RRlist.Join(RBPlist,
                                     rrl => rrl.RRName,
                                     pbp => pbp.FKRevResName,
                                     (rrl, pbp) => new {rrl, pbp}).Where(p=>p.pbp.FKPOName.Equals(POList.ElementAt(1).POName));
          
            int rrrlistcounter = 0;
          
         
          
                XDocument res = new XDocument(
                          PBList.Join(TimeList,
                                rrl => rrl.POName, rrpl => rrpl.TFKPatternName,
                                (rrl, rrpl) => new { rrl, rrpl }).Select(patt =>
                    new XElement("Образец_операции",
              
                                                           new XAttribute("Имя_образца",
                                                                          patt.rrl.POName),
                                                           new XAttribute("Тип_образца",
                                                                         patt.rrl.POType),
                                                           new XAttribute("Трассировка",
                                                                        patt.rrl.POisTrace)
                                                           ,
                                                           RRlist.Join(RRPlist,
                                  rrl => rrl.RRName, rrpl => rrpl.FKRelevantName,
                                  (rrl, rrpl) => new {rrl, rrpl}).Select(revel=>
                                                          new XElement("Релевантный_ресурс",
                                                                                                                   new XAttribute
                                                                                                                       ("Имя_релавантного_ресурса",
                                                                                                                        revel.rrl.RRName),
                                                                                                                   new XAttribute
                                                                                                                       ("Описатель",
                                                                                                                        revel
                                                                                                                            .rrl
                                                                                                                            .RRDeclarator),
                                                                                                                   new XAttribute
                                                                                                                       ("Статус_конвертера",
                                                                                                                        revel
                                                                                                                            .rrpl
                                                                                                                            .statusOfConverter),
                                                                                                                   new XAttribute
                                                                                                                       ("Статус_конвертера_начала",
                                                                                                                       revel
                                                                                                                            .rrpl
                                                                                                                            .Converter_begin),
                                                                                                                   new XAttribute
                                                                                                                       ("Статус_конвертера_конца",
                                                                                                                        revel.rrpl
                                                                                                                            .Converter_end))),
                                                         
                                                                            TimeList.Join(POList,
                                       tl => tl.TFKPatternName, pol => pol.POName,
                                       (tl, pol) => new {tl, pol}).Select(times23=>
                                                                             new XElement("Время",
                                                                                          new XAttribute("Тип_времени",
                                                                                                         times23.tl
                                                                                                                .TType),
                                                                                          new XAttribute(
                                                                                              "Закон_времени",
                                                                                              times23.tl.TLaw),
                                                                                          new XAttribute("Значение",
                                                                                                        times23.tl
                                                                                                                .TValue),
                                                                                          new XAttribute(
                                                                                              "Начало_интервала_времени",
                                                                                             times23.tl.TBeginI),
                                                                                          new XAttribute(
                                                                                              "Конец_интервала_времени",
                                                                                              times23.tl.TEndI))),

                                                                                              RRlist.Join(RBPlist,
                                     rrl => rrl.RRName,
                                     pbp => pbp.FKRevResName,
                                     (rrl, pbp) => new {rrl, pbp}).Select(patternb=>
                                                           new XElement("Тело_образца",
                                                                       new XElement("Релевантный_ресурс",
                                                                                                   new XAttribute(
                                                                                                       "Имя_релевантного_ресурса",
                                                                                                       PBPvar.ElementAt(rrrlistcounter).rrl
                                                                                                              .RRName),
                                                                                                   new XElement(
                                                                                                       "Правило_использования",
                                                                                                       new XAttribute(
                                                                                                           "Предусловие",
                                                                                                            PBPvar.ElementAt(rrrlistcounter).pbp
                                                                                                                  .precondition),
                                                                                                       new XAttribute(
                                                                                                           "Событие_конвертера",
                                                                                                            PBPvar.ElementAt(rrrlistcounter).pbp
                                                                                                                  .ConvertEvent),
                                                                                                       new XAttribute(
                                                                                                           "Правило_конвертера",
                                                                                                            PBPvar.ElementAt(rrrlistcounter).pbp
                                                                                                                  .ConvertRule),
                                                                                                       new XAttribute(
                                                                                                           "Начало_конца",
                                                                                                            PBPvar.ElementAt(rrrlistcounter).pbp
                                                                                                                  .ConvertBegin),
                                                                                                       new XAttribute(
                                                                                                           "Конвертер_конца",
                                                                                                            PBPvar.ElementAt(rrrlistcounter).pbp
                                                                                                                  .ConvertEnd))))))));
                pbcount++;
                if (pbcount >= PBList.Count())
                {
                    res.Save("PatternOperation2.xml");
                }
            res.AddFirst("Образец_операции");
                                                       */

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {



        }

        private void loadMenu2_Click(object sender, RoutedEventArgs e)
        {

        }

       

      
    }
}


