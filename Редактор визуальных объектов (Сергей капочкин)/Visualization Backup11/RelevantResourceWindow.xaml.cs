using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;


namespace Visualization
{
    /// <summary>
    /// Логика взаимодействия для RevelantResourceWindow.xaml
    /// </summary>
    public partial class RevelantResourceWindow : Window
    {


        public RevelantResourceWindow(ObservableCollection<ResourceType> resTypeList)
        {
            InitializeComponent();
          
        }

        /// <summary>
        /// Заполнение датагрида по выбору из комбобокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typer2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

       




        }

        /// <summary>
        /// Создание ресурса из контекстного меню типа ресурсов
        /// </summary>
        /// <param name="res">Выбранный тип ресурсов</param>
        public RevelantResourceWindow(ResourceType res)
        {
            InitializeComponent();

          

        }

        /// <summary>
        /// Просмотр ресурса
        /// </summary>
        /// <param name="res">Выбранный ресурс</param>
        public RevelantResourceWindow(RelevantResource res2)
        {
         
            
        }

        private RelevantResource RResult;
        private bool isComboSelect = false;

        public ObservableCollection<ResourceType> resourceTypeList = new ObservableCollection<ResourceType>();
        public ObservableCollection<RelevantResourcerParam> RRPlist = new ObservableCollection<RelevantResourcerParam>();
        public ObservableCollection<RelevantResource> RRlist = new ObservableCollection<RelevantResource>();
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
         
          
        }

      

    




}
}
