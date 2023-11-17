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
    /// Логика взаимодействия для OperationWindow.xaml
    /// </summary>
    public partial class OperationWindow : Window
    {
        public OperationWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<PatternBody> PBList = new ObservableCollection<PatternBody>();
        public ObservableCollection<Operation> OperList = new ObservableCollection<Operation>();

        public ObservableCollection<PatternOperations> POList = new ObservableCollection<PatternOperations>();
      
        public OperationContext OContext = new OperationContext();

        public OperationWindow(ObservableCollection<PatternOperations> PaBList)
        {
            InitializeComponent();

            for (int i = 0; i < PaBList.Count; i++)
            {
                PattOperComboBox.Items.Add(PaBList.ElementAt(i).POName);
            }
            POList = PaBList;
            PattOperComboBox.SelectionChanged += new SelectionChangedEventHandler(PattOperComboBox_SelectionChanged);
        }

        public OperationWindow(PatternOperations PB)
        {
            InitializeComponent();
            OResult = Operation.createOperation(PB);
            PattOperComboBox.SelectedIndex = 0;
            PattOperComboBox.IsReadOnly = true;


        }

        public Operation OResult;
        private Operation operationEx = new Operation();

        private void PattOperComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*   int integerCount = 0;
            OResult = Operation.createOperation(PBList.ElementAt(PattOperComboBox.SelectedIndex));*/

        }

        public int ir = 0;

        private void ONextButton_Click(object sender, RoutedEventArgs e)
        {
            int ix = 0;

            EditWindow parent = (EditWindow) this.Owner;
            if (parent != null)
            {
                if (OperationTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Введите имя операции");
                    return;
                }

                operationEx.OPName = OperationTextBox.Text;

                try
                {
                    operationEx.OPPatName = Convert.ToString(PattOperComboBox.Text);

                }
                catch
                {
                    MessageBox.Show("Выберите Образец операции");
                    return;
                }
                operationEx.OPIndex = PattOperComboBox.SelectedIndex;
                var c = new Operation {OPName = OperationTextBox.Text, OPPatName = PattOperComboBox.Text, OPIndex = PattOperComboBox.SelectedIndex,OPBody = OperationBodyTextBox.Text};

                OperList.Add(c);
                parent.OperList.Add(c);

            }


            /*   ir++;
                string patnam = "OperationTextBox" + Convert.ToString(ir);
                sem.Name = patnam;
                /*sem.Margin = 0,0,0,0;*/

            OperationTextBox.Clear();
            PattOperComboBox.SelectedValue = "0";
          

         
            ix++;

        }


        private void OpTest_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void OSaveButton_Click(object sender, RoutedEventArgs e)
        {
             EditWindow parent = (EditWindow) this.Owner;
            if (parent != null)
            {
                if (OperationTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Введите имя операции");
                    return;
                }

                operationEx.OPName = OperationTextBox.Text;

                try
                {
                    operationEx.OPPatName = Convert.ToString(PattOperComboBox.Text);

                }
                catch
                {
                    MessageBox.Show("Выберите Образец операции");
                    return;
                }
                operationEx.OPIndex = PattOperComboBox.SelectedIndex;
                var c = new Operation
                    {
                        OPName = OperationTextBox.Text,
                        OPPatName = PattOperComboBox.Text,
                        OPIndex = PattOperComboBox.SelectedIndex
                    };

                OperList.Add(c);
                parent.OperList.Add(c);
            }
            this.Close();
        }

        private void OCancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    
    

}
}
