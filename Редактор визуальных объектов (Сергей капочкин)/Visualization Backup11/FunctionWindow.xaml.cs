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


namespace Visualization
{
    /// <summary>
    /// Логика взаимодействия для Function.xaml
    /// </summary>
    public partial class FunctionWindow : Window
    {

        public FunctionWindow()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = FunctionizerParameter2List;
            dataGrid1.ColumnWidth = (dataGrid1.Width)/2;

        }

        public FunctionWindow(Functionizer Funcer)
        {
            InitializeComponent();
            dataGrid1.ItemsSource = Funcer.Param;
            nameOfFuncTextBox.Text = Funcer.Name;
            typeOfReturnStatementComboBox.Text = Funcer.Type;
            bodyTextBox.Text = Funcer.Body;
            nameOfFuncTextBox.IsReadOnly = true;
            typeOfReturnStatementComboBox.IsReadOnly = true;
            dataGrid1.IsReadOnly = true;
            saverButton.Visibility = System.Windows.Visibility.Hidden;


        }

        public ObservableCollection<FunctionizerParameter> FunctionizerParameter2List =
            new ObservableCollection<FunctionizerParameter>();

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            EditWindow parent = (EditWindow) this.Owner;
            if (parent != null)

            {
                Functionizer Funcer = new Functionizer();
                if (nameOfFuncTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Введите имя типа функции");
                    return;
                }
                Funcer.Name = nameOfFuncTextBox.Text;
                try
                {
                    Funcer.Type = Convert.ToString(typeOfReturnStatementComboBox.Text);
                }
                catch
                {
                    MessageBox.Show("Выберите Тип возвращаемого значения");
                    return;
                }
                try
                {
                    Funcer.Body = bodyTextBox.Text;
                }
                catch
                {
                    MessageBox.Show("Введите тело функции");
                    return;
                }
                Funcer.Param = new List<FunctionizerParameter>();
                for (int i = 0; i < FunctionizerParameter2List.Count; i++)
                {
                    FunctionizerParameter fparam = new FunctionizerParameter();
                    if (FunctionizerParameter2List.ElementAt(i).Name == null)
                    {
                        MessageBox.Show("Введите имя параметра");
                        return;
                    }
                    fparam.Name = FunctionizerParameter2List.ElementAt(i).Name;
                    if (FunctionizerParameter2List.ElementAt(i).Type == null)
                    {
                        MessageBox.Show("Выберите тип параметра");
                        return;
                    }
                    else
                    {
                        fparam.Type = FunctionizerParameter2List.ElementAt(i).Type;

                    }
                    Funcer.Param.Add(fparam);

                }
                parent.FunctionizerParameterList.Add(Funcer);
            }
    
     

    
this.Close() ;

}

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        }
    }


