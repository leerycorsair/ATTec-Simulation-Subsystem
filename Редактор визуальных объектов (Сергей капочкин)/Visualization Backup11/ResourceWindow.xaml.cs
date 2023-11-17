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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Visualization
{
    /// <summary>
    /// Логика взаимодействия для ResourceWindow.xaml
    /// </summary>
    public partial class ResourceWindow : Window
    {
        /// <summary>
        /// Создание нового ресурса из меню
        /// </summary>
        /// <param name="resTypeList">Список типов ресурсов</param>
        /// 
        public ResourceWindow(ObservableCollection<ResourceType> resTypeList)
        {
            InitializeComponent();

            for (int i = 0; i < resTypeList.Count; i++)
            {
                typeComboBox.Items.Add(resTypeList.ElementAt(i).Name);
            }
            resourceTypeList = resTypeList;
            typeComboBox.SelectionChanged += new SelectionChangedEventHandler(typeComboBox_SelectionChanged);
        }
        public struct Resourcer
        {
            public string  pricer;
            public string title;
          
        }

        /// <summary>
        /// Заполнение датагрида по выбору из комбобокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            result = Resource.createResource(resourceTypeList.ElementAt(typeComboBox.SelectedIndex));
            dataGrid1.ItemsSource = result.Param;

            isComboSelect = true;
        }

        /// <summary>
        /// Создание ресурса из контекстного меню типа ресурсов
        /// </summary>
        /// <param name="res">Выбранный тип ресурсов</param>
        public ResourceWindow(ResourceType res)
        {
            InitializeComponent();

            result = Resource.createResource(res);
            dataGrid1.ItemsSource = result.Param;

            typeComboBox.Items.Add(res.Name);
            typeComboBox.SelectedIndex = 0;
            typeComboBox.IsReadOnly = true;
            isComboSelect = true;

        }

        /// <summary>
        /// Просмотр ресурса
        /// </summary>
        /// <param name="res">Выбранный ресурс</param>
        public ResourceWindow(Resource res)
        {
            InitializeComponent();
            result = res;
            dataGrid1.ItemsSource = result.Param;
            isTrace.IsChecked = res.boolisTrace;
            isTrace.IsEnabled = false;
            nameTextBox.Text = res.Name;
            typeComboBox.Items.Add(res.Type.Name);
            typeComboBox.SelectedIndex = 0;
            typeComboBox.IsEnabled = false;
            isComboSelect = true;
            dataGrid1.IsEnabled = false;
            nameTextBox.IsEnabled = false;
            saveButton.Visibility = System.Windows.Visibility.Hidden;
        }

        private Resource result;
        private bool isComboSelect = false;

        public ObservableCollection<ResourceType> resourceTypeList = new ObservableCollection<ResourceType>();
        public ObservableCollection<Resource> resourceList = new ObservableCollection<Resource>();

        /// <summary>
        /// Сохраняем ресурс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            EditWindow parent = (EditWindow) this.Owner;
            if (parent != null)
            {

                if (nameTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Введите имя ресурса");
                    return;
                }
                result.Name = nameTextBox.Text;
                if (!isComboSelect)
                {
                    MessageBox.Show("Выберите тип ресурса");
                    return;
                }
                Resourcer mer = new Resourcer();
                mer.pricer = nameTextBox.Text;
                mer.title = typeComboBox.Text;
                result.merd(mer.pricer, mer.title);
                result.boolisTrace = isTrace.IsChecked.Value;
          if (isTrace.IsChecked.Value)
          {
              result.isTrace = "Да";
          }
          else
          {
              result.isTrace = "Нет";
          }
                for (int i = 0; i < result.Param.Count; i++)
                {
                    if (result.Param.ElementAt(i).Value == null)
                    {
                        MessageBox.Show("Введите начальное значение для параметра " + result.Param.ElementAt(i).Name);
                        return;
                    }
                    if (result.Param.ElementAt(i).Type.Equals("int"))
                    {
                        try
                        {
                            int temp = int.Parse(result.Param.ElementAt(i).Value);
                            result.Param.ElementAt(i).Value = temp.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Недопустимое начальное значение для типа int");
                            return;
                        }
                    }
                    if (result.Param.ElementAt(i).Type.Equals("double"))
                    {
                        try
                        {
                            double temp = double.Parse(result.Param.ElementAt(i).Value);
                            result.Param.ElementAt(i).Value = temp.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Недопустимое начальное значение для типа double");
                            return;
                        }
                    }
                    if (result.Param.ElementAt(i).Type.Equals("bool"))
                    {
                        try
                        {
                            bool temp = bool.Parse(result.Param.ElementAt(i).Value);
                            result.Param.ElementAt(i).Value = temp.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Недопустимое начальное значение для типа bool");
                            return;
                        }
                    }
                    if (result.Param.ElementAt(i).Type.Equals("Enum"))
                    {
                        try
                        {
                            result.Param.ElementAt(i).Value =  "{" + result.Param.ElementAt(i).Value + "}";
                        }
                        catch
                        {
                            MessageBox.Show("Недопустимое начальное значение для типа Enum");
                            return;
                        }
                    }



                }


                parent.resourceList.Add(result);
            }


            this.Close();
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}