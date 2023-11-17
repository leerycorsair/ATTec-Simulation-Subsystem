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
using System.Data.Entity;

using System.Xml.Linq;


namespace Visualization
{
    /// <summary>
    /// Логика взаимодействия для PatternBodyWindower.xaml
    /// </summary>
    public partial class PatternBodyWindower : Window
    {
        public PatternBodyWindower()
        {
            InitializeComponent();

        }

        private PatternBody PB;
        public ObservableCollection<ResourceType> resourceTypeList = new ObservableCollection<ResourceType>();

        
        public PatternBodyWindower(ResourceType ResRlist)
        {
            InitializeComponent();

            /*     patternBodydataGrid1.ItemsSource = RBPlist;*/
            DataGridUno.AutoGenerateColumns = false;
            
            DataGridUno.ItemsSource = RRlist;
            DataGridUno.RowHeight = 50;
          
    

       


        }
       



        private void RevResCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public ObservableCollection<RelevantResourcerParam> RRPlist = new ObservableCollection<RelevantResourcerParam>();
        public ObservableCollection<Time> TimeList = new ObservableCollection<Time>();
        public ObservableCollection<PatternOperations> POList = new ObservableCollection<PatternOperations>();
        public ObservableCollection<PatternBodyParameter> RBPlist = new ObservableCollection<PatternBodyParameter>();
        public ObservableCollection<RelevantResource> RRlist = new ObservableCollection<RelevantResource>();
        public ObservableCollection<PatternBody> PBList = new ObservableCollection<PatternBody>();
        public ObservableCollection<RulesUsed> RulesList = new ObservableCollection<RulesUsed>();
 
        private TextBlock activeBlock;
        public DbSet<PatternBodyParameter> PBContext { get; set; }
        public int i = 0;
        /*  private PatternBodyDBContext db = new PatternBodyDBContext();*/
        private PatternBody patternEx = new PatternBody();
        private PatternOperations poEX = new PatternOperations();
        private PatternBodyParameter PBP = new PatternBodyParameter();

        private void PBNextButton_Click(object sender, RoutedEventArgs e)
        {
            /* EditWindow parent = (EditWindow) this.Owner;
             if (parent != null)
             {
                 RRlist.ElementAt(RevResCombo.SelectedIndex).FKPatternName = nameTextBox.Text;
                 PBP.ConvertBegin = ConvertBeginTextBox.Text;
                 PBP.ConvertEnd = ConvertEndTextBox.Text;
                 PBP.ConvertEvent = ConvertEventTextBox.Text;
                 PBP.ConvertRule = ConvertRuleTextBox.Text;
                 PBP.precondition = PBWprecond.Text;
                 PBP.FKRevResName = RevResCombo.Text;
                 RBPlist.Add(PBP);

                 patternEx.PBparameter = new List<PatternBodyParameter>();

                 {


                     PatternBodyParameter PBparam = new PatternBodyParameter();


                     if (RBPlist.ElementAt(i).precondition == null)
                     {
                         MessageBox.Show("Введите преусловие");
                         return;
                     }
                     PBparam.ConvertBegin = RBPlist.ElementAt(i).precondition;


                     if (RBPlist.ElementAt(i).ConvertBegin == null)
                     {
                         MessageBox.Show("Введите ConvertBegin");
                         return;
                     }
                     PBparam.ConvertBegin = RBPlist.ElementAt(i).ConvertBegin;

                     if (RBPlist.ElementAt(i).ConvertEnd == null)
                     {
                         MessageBox.Show("Выберите ConvertEnd");
                         return;
                     }
                     PBparam.ConvertEnd = RBPlist.ElementAt(i).ConvertEnd;

                     if (RBPlist.ElementAt(i).ConvertEvent == null)
                     {
                         MessageBox.Show("Выберите ConvertEvent");
                         return;
                     }

                     PBparam.ConvertEvent = RBPlist.ElementAt(i).ConvertEvent;


                     if (RBPlist.ElementAt(i).ConvertRule == null)
                     {
                         MessageBox.Show("Выберите ConvertEvent");
                         return;
                     }

                     PBparam.ConvertRule = RBPlist.ElementAt(i).ConvertRule;
                     PBP.FKRevResName = RBPlist.ElementAt(i).FKRevResName;
                     parent.RBPlist.Add(PBP);
                     patternEx.PBparameter.Add(PBparam);

                 }

                 groupBox1.IsEnabled = false;
                 RevResCombo.SelectedIndex = -1;
                 RevResCombo.SelectedValue = "0";
                 i++;
             }*/

        }

        private void PBsaverButton_Click(object sender, RoutedEventArgs e)
        {
            EditWindow parent = (EditWindow) this.Owner;
            if (parent != null)
            {poEX.POPatBod = new List<PatternBody>();
                poEX.PORevRes = new List<RelevantResource>();

                patternEx.RevList = new List<RelevantResource>();
             
                  
                   
                for (int i = 0; i < RRlist.Count; i++)
                {
                    RelevantResource Relever = new RelevantResource();
                    Relever.RulesUs = new List<RulesUsed>();
                    if (RRlist.ElementAt(i).statusOfConverter == null)
                    {
                        MessageBox.Show("Введите статус конвертера   ");
                        return;
                    }
                    Relever.RRName = RRlist.ElementAt(i).RRName;
                    Relever.RRDeclarator = RRlist.ElementAt(i).RRDeclarator;
                    Relever.statusOfConverter = RRlist.ElementAt(i).statusOfConverter;



                    Relever.Converter_begin = RRlist.ElementAt(i).Converter_begin;
                    Relever.Converter_end = RRlist.ElementAt(i).Converter_end;

                   
                    parent.RRlist.Add(Relever);
                    RulesUsed rules2 = new RulesUsed();

                    rules2.ConvertBegin = RRlist.ElementAt(i).ConvertBegin;
                    rules2.ConvertEnd = RRlist.ElementAt(i).ConvertEnd;
                    rules2.ConvertEvent = RRlist.ElementAt(i).ConvertEvent;
                    rules2.ConvertRule = RRlist.ElementAt(i).ConvertRule;
                    rules2.preCondition = RRlist.ElementAt(i).preCondition;
                    Relever.RulesUs.Add(rules2);

                    parent.RulesList.Add(rules2);
                    poEX.PORevRes.Add(Relever);
                    patternEx.RevList.Add(Relever);
                    
                }
                poEX.boolisTrace = POisTrace.IsChecked.Value;
                    if (POisTrace.IsChecked.Value)
                    {
                        poEX.isTrace = "Да";
                    }
                    else
                    {
                        poEX.isTrace = "Нет";
                    }
                poEX.POName = nameTextBox.Text;
                try
                {
                    poEX.POType = Convert.ToString(typeComboBox.Text);
                }
                catch
                {
                    MessageBox.Show("Выберите Тип возвращаемого значения");
                    return;
                }
                    poEX.times2 = new List<Time>();
                    {
                        Time times = new Time();
                      
                        for (int ix = 0; i < 2; i++)
                        {

                            if (TTypeComboBox.Text == "")
                            {
                                MessageBox.Show("Введите тип времени");
                                return;
                            }
                            else
                            {
                                times.TType = TTypeComboBox.Text;
                                if (times.TType.Equals("Точное"))
                                {
                                    TBeginITextBox.Text = "";
                                    TEndITextBox.Text = "";
                                    TLawComboBox.Text = "";
                                    times.TBeginI = "";
                                    times.TEndI = "";
                                    times.TLaw = "";

                                    if (TValueTextBox.Text == "")
                                    {
                                        MessageBox.Show("Введите значение времени");
                                        return;
                                    }
                                    times.TValue = TValueTextBox.Text;
                                }
                                if (times.TType.Equals("Случайное"))
                                {
                                    TValueTextBox.Text = "";
                                    times.TValue = TValueTextBox.Text;
                                    if (TBeginITextBox.Text == "")
                                    {
                                        MessageBox.Show("Введите значение начала интервала");
                                        return;
                                    }
                                    times.TBeginI = TBeginITextBox.Text;
                                    if (TEndITextBox.Text == "")
                                    {
                                        MessageBox.Show("Введите значение конца интервала");
                                        return;
                                    }
                                    times.TEndI = TEndITextBox.Text;
                                    times.TLaw = TLawComboBox.Text;

                                }


                            }

                        }
                        poEX.times2.Add(times);
                        TimeList.Add(times);
                        parent.TimeList.Add(times);

                    }
                  
              

                
               
         
                poEX.POPatBod.Add(patternEx);
                POList.Add(poEX);
                parent.POList.Add(poEX);
                parent.PBList.Add(patternEx);
               }
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EditWindow parent = (EditWindow) this.Owner;
            if (parent != null)
            {
                
                {
                    Time times = new Time();
                    times.TFKPatternName = Convert.ToString(nameTextBox.Text);
                    for (int i = 0; i < 2; i++)
                    {

                        if (TTypeComboBox.Text == "")
                        {
                            MessageBox.Show("Введите тип времени");
                            return;
                        }
                        else
                        {
                            times.TType = TTypeComboBox.Text;
                            if (times.TType.Equals("Точное"))
                            {
                                TBeginITextBox.Text = "";
                                TEndITextBox.Text = "";
                                TLawComboBox.Text = "";
                                times.TBeginI = "";
                                times.TEndI = "";
                                times.TLaw = "";

                                if (TValueTextBox.Text == "")
                                {
                                    MessageBox.Show("Введите значение времени");
                                    return;
                                }
                                times.TValue = TValueTextBox.Text;
                            }
                            if (times.TType.Equals("Случайное"))
                            {
                                TValueTextBox.Text = "";
                                times.TValue = TValueTextBox.Text;
                                if (TBeginITextBox.Text == "")
                                {
                                    MessageBox.Show("Введите значение начала интервала");
                                    return;
                                }
                                times.TBeginI = TBeginITextBox.Text;
                                if (TEndITextBox.Text == "")
                                {
                                    MessageBox.Show("Введите значение конца интервала");
                                    return;
                                }
                                times.TEndI = TEndITextBox.Text;
                                times.TLaw = TLawComboBox.Text;

                            }
                            
                           
                        }

                    }
                    

                }

            }
        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void typeComboBox_DropDownClosed(object sender, EventArgs e)
        {

         
            /*if (typeComboBox.Text == "operation")
            {
                ConvertEventTextBox.Visibility = Visibility.Hidden;
                ConvertEventTextBox.Visibility = Visibility.Hidden;
                ConvertRuleLabel.Visibility = Visibility.Hidden;
                ConvertRuleTextBox.IsReadOnly = true;
               
            }*/
        }

        private void PBcloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RevResCombo_DropDownClosed(object sender, EventArgs e)
        {

        }
       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {




        }
        int int2 = 0;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        { EditWindow parent = (EditWindow) this.Owner;
            if (parent != null)
            {
            RelevantResource Relever = new RelevantResource();
            RulesUsed rules2 = new RulesUsed();


            Relever.RulesUs = new List<RulesUsed>();

            

            Relever.RulesUs.Add(rules2);
            RulesList.Add(rules2);
            parent.RulesList.Add(rules2);
                
            }
            }
        }


    }




