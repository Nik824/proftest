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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Controls.Primitives;


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


            string path = @"test.xml";
            FileInfo fileNew = new FileInfo(path);
            if (fileNew.Exists)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Admin));
                using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
                {
                    Admin adm = (Admin)formatter.Deserialize(fs);   
                    tests.ItemsSource = adm.Tests;
                  
                }
            }
            else
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Admin));
                using (FileStream fs = new FileStream("base.xml", FileMode.OpenOrCreate))
                {
                    Admin adm = (Admin)formatter.Deserialize(fs);

                    tests.ItemsSource = adm.Tests;

                }
            }
            
        }



public Test currentTest { get; set; }
 public bool result { get; set; } = true;
public bool selectObj { get; set; } = false;
        // початок тесту
        private void start_Click(object sender, RoutedEventArgs e)
        {
            
            Test selectItem = (Test) tests.SelectedItem;
            currentTest = selectItem;
            // якщо вибраний певний тест
            if (selectItem != null)
            {
                select.Visibility = Visibility.Hidden;
                testing.Visibility = Visibility.Visible;
                finish.IsEnabled = true;

                //записуєм список запитання
                List<Question> listQuestions = selectItem.Questions;

               
                int i = 0;

                Radiobutton1[] rd = new Radiobutton1[4];

                //перебираєм масив запитань
                foreach (var item in listQuestions)
                {
                    
                    var stPanel = new StackPanel();
               
                    var lQuest = new TextBlock();

                    lQuest.Text = item.Quest;
                    int index = 0;
                    int rightIndex = int.Parse(item.Right);

                    //перебираєм масив відповідей та записуємо їх в масив радіобаттонів
                    foreach (var elem in item.answers)
                    {
                      
                        rd[index] = new Radiobutton1();
                        rd[index].Height = 18;
                        rd[index].Content = elem;
                        rd[index].TrueOrNot = false;
                      
                        //якщо відповідь вірна - то записуєм в свойство рд-бна тру.
                        if (index == rightIndex)
                        {
                            rd[index].TrueOrNot = true;
                        }

                        index++;
                    }


                    // додаємо все це в стекпанель
                    stPanel.Children.Add(lQuest);             

                    foreach (var items in rd)
                    {
                       stPanel.Children.Add(items);
                    } 
                       
                        //додаємо панелів грід        
                    answers.Children.Add(stPanel);
                    i++; 
                }            
            }
            else MessageBox.Show("select test");
          
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {          
            testing.Visibility = Visibility.Hidden;
            select.Visibility = Visibility.Visible;
            finish.IsEnabled = false;
            start.IsEnabled = true;

            var st=  answers.Children;

            //список StackPanel, що містить обєкти типу Question(1 поле textblock and 4 fields radiobutton;
            foreach (var item in st)
            {
           StackPanel s = (StackPanel) item;
            var rad =   s.Children;

                // list objects: 1 поле textblock and 4 fields radiobutton
                foreach (var it in rad)
                {
                   // якщо текстблок пропускаєм
                    if (it.GetType() == typeof(TextBlock)) continue;
                    
                    else
                    {
                        Radiobutton1 r = (Radiobutton1)it;

                        if (r.IsChecked == false)
                        
                            continue;
                        else {
                          
                           
                                selectObj = true;

                                if (r.TrueOrNot == false)
                                {
                                    result = false;
                                    goto M;
                                }

                            
                         


                        }
                    }
                }
            }

         M:   if (result == false | selectObj==false)
            {
                MessageBox.Show("your test is wrong");
            }

            else
            MessageBox.Show("your test is right");
         //видаляємо елементи із grid answers;
            answers.Children.Clear();
            exit.IsEnabled = true;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
