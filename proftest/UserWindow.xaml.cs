using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using proftest.Model;
using System.IO;



using System.Xml.Serialization;
namespace proftest
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            testing.Visibility = Visibility.Hidden;
            select.Visibility = Visibility.Visible;
            finish.IsEnabled = false;
            start.IsEnabled = true;
            XmlSerializer formatter = new XmlSerializer(typeof(Admin));
            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                Admin adm = (Admin)formatter.Deserialize(fs);


                // не виходить Name із Test добути.

                tests.ItemsSource = adm.Tests;
            }

          
        }

  // не виходить дані привязати навіть до textBlock, не те що до radiobutton
  // не знаю,як вививести List< Question> у форму; у MVC,я як робив, то там List-ову властивість у foreach -і шаблоном displayforModel можна вивести.
        private void start_Click(object sender, RoutedEventArgs e)
        {
            
          Test selectItem = (Test) tests.SelectedItem;

            if (selectItem != null)
            {
                select.Visibility = Visibility.Hidden;
                testing.Visibility = Visibility.Visible;
                finish.IsEnabled = true;
                List<Question> listQuestions = selectItem.Questions;

                this.DataContext = listQuestions;
            }
            else MessageBox.Show("select test");
          
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            testing.Visibility = Visibility.Hidden;
            select.Visibility = Visibility.Visible;
            finish.IsEnabled = false;
            start.IsEnabled = true;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
