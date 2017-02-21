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
              
              
               

                tests.ItemsSource = adm.Tests;
            }

          
        }

        
        private void start_Click(object sender, RoutedEventArgs e)
        {
            select.Visibility = Visibility.Hidden;
            testing.Visibility = Visibility.Visible;
            finish.IsEnabled = true;
          Test selectItem = (Test) tests.SelectedItem;
         List<Question> listQuestions =   selectItem.Questions;

            this.DataContext = listQuestions;
          
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            testing.Visibility = Visibility.Hidden;
            select.Visibility = Visibility.Visible;
            finish.IsEnabled = false;
            start.IsEnabled = true;
        }
    }
}
