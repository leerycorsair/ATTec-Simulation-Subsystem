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
    /// Логика взаимодействия для ResourceTypeWindow.xaml
    /// </summary>
    public partial class ResourceTypeWindow : Window
    {
        /// <summary>
        /// Создание нового типа ресурсов
        /// </summary>
        public ResourceTypeWindow()
        {
            
            InitializeComponent();
            
            dataGrid1.ItemsSource = resourceTypeParameterList;

        }
        /// <summary>
        /// Просмотр типа ресурсов
        /// </summary>
        /// <param name="res">Выбранный тип ресурсов</param>
        public ResourceTypeWindow(ResourceType res)
        {
            InitializeComponent();
            dataGrid1.ItemsSource = res.Param;
            nameTextBox.Text = res.Name;
            typeComboBox.SelectedIndex = res.Type=="Постоянные" ? 0 : 1;
            nameTextBox.IsReadOnly = true;
            typeComboBox.IsReadOnly = true;
            dataGrid1.IsReadOnly = false;
            saveButton.Visibility = System.Windows.Visibility.Hidden;
            EditButton.Visibility = System.Windows.Visibility.Visible;

        }
        public ObservableCollection<ResourceTypeParameter> resourceTypeParameterList = new ObservableCollection<ResourceTypeParameter>();
        /// <summary>
        /// Сохраняем тип ресурса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            EditWindow parent = (EditWindow)this.Owner;
            if (parent != null)
            {
                ResourceType type = new ResourceType();
                if (nameTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Введите имя типа ресурса");
                    return;
                }
                type.Name = nameTextBox.Text;
                try
                {
                    type.Type = ((ComboBoxItem)typeComboBox.SelectedValue).Content.ToString();
                }
                catch
                {
                    MessageBox.Show("Выберите вид ресурсов");
                    return;
                }
                type.Param = new List<ResourceTypeParameter>();
                if (resourceTypeParameterList.Count == 0)
                {
                    MessageBox.Show("Введите параметр типа ресурсов");
                    return;
                }
                else
                {
                    for (int i = 0; i < resourceTypeParameterList.Count; i++)
                    {
                        ResourceTypeParameter param = new ResourceTypeParameter();
                        if (resourceTypeParameterList.ElementAt(i).Name == null)
                        {
                            MessageBox.Show("Введите имя параметра");
                            return;
                        }
                        param.Name = resourceTypeParameterList.ElementAt(i).Name;
                        if (resourceTypeParameterList.ElementAt(i).Type == null)
                        {
                            MessageBox.Show("Выберите тип параметра");
                            return;
                        }
                        else
                        {
                            param.FKName = "1";
                            param.Type = resourceTypeParameterList.ElementAt(i).Type;
                            if (param.Type.Equals("int") && resourceTypeParameterList.ElementAt(i).Default!=null)
                            {
                                try
                                {
                                    int temp = int.Parse(resourceTypeParameterList.ElementAt(i).Default);
                                    param.Default = temp.ToString();
                                }
                                catch
                                {
                                    MessageBox.Show("Недопустимое начальное значение для типа int");
                                    return;
                                }
                            }
                            if (param.Type.Equals("double") && resourceTypeParameterList.ElementAt(i).Default != null)
                            {
                                try
                                {
                                    double temp = double.Parse(resourceTypeParameterList.ElementAt(i).Default);
                                    param.Default = temp.ToString();
                                }
                                catch
                                {
                                    MessageBox.Show("Недопустимое начальное значение для типа double");
                                    return;
                                }
                            }
                            if (param.Type.Equals("bool") && resourceTypeParameterList.ElementAt(i).Default != null)
                            {
                                try
                                {
                                    bool temp = bool.Parse(resourceTypeParameterList.ElementAt(i).Default);
                                    param.Default = temp.ToString();
                                }
                                catch
                                {
                                    MessageBox.Show("Недопустимое начальное значение для типа bool");
                                    return;
                                }
                            }
                            if (param.Type.Equals("Enum") && resourceTypeParameterList.ElementAt(i).Default != null)
                            {
                                try
                                {
                                    bool temp = bool.Parse(resourceTypeParameterList.ElementAt(i).Default);
                                    param.Default = temp.ToString();
                                }
                                catch
                                {
                                    MessageBox.Show("Недопустимое начальное значение для типа bool");
                                    return;
                                }
                            }
                        }
                        type.Param.Add(param);
                    }
                }
                
                parent.resourceTypeList.Add(type);
            }


            this.Close();
        }
        /// <summary>
        /// Выходим без сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
