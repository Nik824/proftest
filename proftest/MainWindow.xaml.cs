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
using System.Windows.Navigation;
using System.Windows.Shapes;
using proftest.Model;
using System.IO;



using System.Xml.Serialization;

namespace proftest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Admin admin1 = new Admin();
        Test t = new Test();
        Question q = new Question();
        //TestContext db;
        public MainWindow()
        {
            //Database.SetInitializer(new DbInitializer());
            //var db = new TestContext();
            InitializeComponent();

            //  db.Tests.Load();

            //List<string> t = new List<string> { "iPhone 6S Plus", "Nexus 6P", "Galaxy S7 Edge" };
            //phonesList.ItemsSource = t;

            Main.Visibility = Visibility.Visible;
            Test.Visibility = Visibility.Hidden;
            Quest.Visibility = Visibility.Hidden;
            button.IsEnabled = true;
            button1.IsEnabled = false;

            //  this.Closing += MainWindow_Closing;
        }






        //private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    db.Dispose();
        //}

        private void button_Click(object sender, RoutedEventArgs e)
        {


            Main.Visibility = Visibility.Hidden;
            Test.Visibility = Visibility.Visible;
            Quest.Visibility = Visibility.Hidden;
            button.IsEnabled = false;
            button1.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Test.Visibility = Visibility.Hidden;
            Quest.Visibility = Visibility.Hidden;
            button.IsEnabled = true;
            button1.IsEnabled = false;
        }
      

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Quest.Visibility = Visibility.Visible;
            Main.Visibility = Visibility.Hidden;
            Test.Visibility = Visibility.Hidden;
           
            t.Name = nameTest.Text;
            button1.IsEnabled = true;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            
            q.Quest = textBox.Text;
          
           string a1 = textBox1.Text;
           string a2 = textBox2.Text;
           string a3 = textBox3.Text;
           string a4 = textBox4.Text;
            q.answers = new List<string>() { a1, a4, a2, a3 };

            t.Add(q);
            admin1.Tests.Add(t);
            // t.Questions = new List<Question>() {q };
            //if (q != null & t != null)
            //{
            //    t.Questions.Add(q);
            //}

            XmlSerializer formatter = new XmlSerializer(typeof(Admin));
            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, admin1);
            }
            textBox.Text = "";
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text= "";
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            Test.Visibility = Visibility.Visible;
            Quest.Visibility = Visibility.Hidden;
            button.IsEnabled = false;
            button1.IsEnabled = true;
        }

        private void butuser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
        }
    }
}
