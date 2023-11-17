using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Visualization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        public List<string> ObjectNameList = new List<string>(); //Это список всех имен объектов, получаемый из файла
        public List<Object> ObjectList = new List<Object>(); //Это список объектов
        Object obj;
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
          //удаляем старые данные из списка 
            ObjectNameList.Clear();
            listBox1.Items.Refresh();
            //считываем файл, генерируем объекты, добавляем объекты и их имена в списки, добавляем список в текстбокс
            StreamReader read = new StreamReader(FiletextBox.Text);
            String line;
            while ((line = read.ReadLine()) != null)
            {
                obj = new Object();
                obj.Name = line;
                ObjectList.Add(obj);
                ObjectNameList.Add(obj.Name);
            }
            listBox1.ItemsSource = ObjectNameList;
            
            EditButton.IsEnabled = true;
        }

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            //открываем окно с диалогом выбора файлов. Показываются только файлы txt
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            dlg.Filter = "Файл txt|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
                FiletextBox.Text = dlg.FileName; //Прописываем имя и путь файла в текстбоксе
            LoadButton.IsEnabled = true;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            obj=ObjectList.ElementAt(listBox1.SelectedIndex);
            //открываем новое окно для редактирования, где заголовок окна - Редактирование для объекта и имя объекта
            EditWindow editwindow = new EditWindow();
            editwindow.Owner = this;
            editwindow.Title = "Редактирование для объекта " + ObjectNameList.ElementAt(listBox1.SelectedIndex);
            if (obj.Image != null) editwindow.canvas = obj.Image;
            editwindow.Show();
            
            button1.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ImitationWindow window = new ImitationWindow();
            window.Owner = this;
            window.Show();
            window.objectListBox.ItemsSource = ObjectNameList;
        }

    }
}
