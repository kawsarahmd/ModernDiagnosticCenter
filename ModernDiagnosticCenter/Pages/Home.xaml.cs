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
using System.Data.SQLite;

namespace ModernDiagnosticCenter.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    /// 
    
    public partial class Home : UserControl
    {
        
       
        public Home()
        {
            InitializeComponent();
            home_datepicker.SelectedDate = DateTime.Today;
            fill_combobox();

            
        }

        private void fill_combobox()
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select * from test_name order by test_name.test_name asc";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                //create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();

                while(dr.Read())
                {
                    string name = dr.GetString(1);
                    combo_box.Items.Add(name);
                }

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
               // PrintPage obj = print_page();
                PrintPage obj = new PrintPage();

                obj.print_name.Text = name_textfield.Text;
                obj.print_age.Text = age_textbox.Text;
                obj.print_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                obj.print_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
                obj.print_refd_by.Text = doctor_textfield.Text;
                obj.print_delivery_date.Text = home_datepicker.Text;
                obj.print_phone_no.Text = phone_textbox.Text;
                obj.print_dayofweek.Text = DateTime.Today.DayOfWeek.ToString();
               //obj.print_test_textblock.Text = name_textfield.Text;
                obj.print_sex_textblock.Text = home_sex_combobox.Text;


               // PrinterWithScaling(obj);
                obj.Show();
                obj.Close();
                printPage2(obj);
                SaveInDatabase();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            //string s = name_textfield.Text;
            //age_textbox.Text = s;
            //string s1 = combo_box.Text;
            //age_textbox.Text = s1;
           // PrintDialog pd = new PrintDialog();
           // if (pd.ShowDialog() != true) return;
           // pd.PrintVisual(printPanel, "Printing StackPanel...");
           //ModernWindow1 m = new ModernWindow1();
           //m.Show();

            //SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

           // try
           // {
             //   sqlite_connection.Open();
              //  string query = "select "
           // }
          ///  catch(Exception e)

          /*  string time = DateTime.Now.ToString("hh:mm:ss tt"); // includes leading zeros
            string date = DateTime.Now.ToString("dd/MM/yyyy"); // includes leading zeros
            MessageBox.Show(date);*/

          /*  PrintDialog prnt = new PrintDialog();
            if (prnt.ShowDialog() == true)
            {
                Size pageSize = new Size(prnt.PrintableAreaWidth - 30, prnt.PrintableAreaHeight - 30);
                printPanel.Measure(pageSize);
                printPanel.Arrange(new Rect(15, 15, pageSize.Width, pageSize.Height));
                prnt.PrintVisual(printPanel, "Work Request");
            }
            
            */






            



            
        }

        private static void printPage2(PrintPage obj)
        {
            PrintDialog prnt = new PrintDialog();
            if (prnt.ShowDialog() == true)
            {
                Size pageSize = new Size(prnt.PrintableAreaWidth - 30, prnt.PrintableAreaHeight - 30);

                obj.print_form.Measure(pageSize);
                obj.print_form.Arrange(new Rect(15, 15, pageSize.Width, pageSize.Height));
                prnt.PrintVisual(obj.print_form, "Work Request");
            }
        }

        private static void PrinterWithScaling(PrintPage obj)
        {

            PrintDialog printDlg = new System.Windows.Controls.PrintDialog();

            if (printDlg.ShowDialog() == true)
            {

                //get selected printer capabilities

                System.Printing.PrintCapabilities capabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);



                //get scale of the print wrt to screen of WPF visual

                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / obj.print_form.ActualWidth, capabilities.PageImageableArea.ExtentHeight /

                               obj.print_form.ActualHeight);



                //Transform the Visual to scale

                obj.print_form.LayoutTransform = new ScaleTransform(scale, scale);



                //get the size of the printer page

                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);



                //update the layout of the visual to the printer page size.

                obj.print_form.Measure(sz);

                obj.print_form.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));



                //now print the visual to printer to fit on the one page.

                printDlg.PrintVisual(obj.print_form, "First Fit to Page WPF Print");



            }
        }

        /*private PrintPage print_page()
        {
            PrintPage obj = new PrintPage();
            //obj.print.Text = name_textfield.Text;
           // obj.print_age_textblock.Text = age_textbox.Text;
           // obj.print_phone_textblock.Text = phone_textbox.Text;
            //obj.print_date_textblock.Text = DateTime.Now.ToString("dd/MM/yyyy");
            obj.Show();

            obj.print_name.Text = name_textfield.Text;
            obj.print_age.Text = age_textbox.Text;
            obj.print_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            obj.print_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
            obj.print_refd_by.Text = doctor_textfield.Text;
            obj.print_delivery_date.Text = home_datepicker.Text;
            obj.print_sex_textblock.Text = home_sex_combobox.Text;
            

            return obj;
        }
        */

        private void SaveInDatabase()
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "INSERT INTO patient_table (name,age,phone,cost,due,paid,sex,delivery_date,time,date,doctor)   VALUES('" + this.name_textfield.Text + "','" + this.age_textbox.Text + "','" + this.phone_textbox.Text + "','" + this.test_cost_textfield.Text + "','" + this.due_textfield.Text + "','"  + this.paid_textbox.Text + "','" + this.home_sex_combobox.Text + "','" + this.home_datepicker.Text + "','" + DateTime.Now.ToString("hh:mm:ss tt") + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + this.doctor_textfield.Text + "')";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                create_command.ExecuteNonQuery();
                /*SQLiteDataReader dr = create_command.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr.GetString(1);
                    combo_box.Items.Add(name);
                }*/

                sqlite_connection.Close();
                MessageBox.Show("Successfully saved in database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

      private void combo_box_Loaded(object sender, RoutedEventArgs e)
        {
          /*  List<string> list = new List<string>();
            list.Add("Blood test");
            list.Add("Sugar test");

            var combobox = sender as ComboBox;
            combo_box.ItemsSource = list;
            combo_box.SelectedIndex = 0;*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] contents = new string[3]
            {
               name_textfield.Text,
                //age_textbox.Text,
                //phone_textbox.Text,
                combo_box.Text,
                ""
                
            };

            /*
            foreach (string content in contents)
            {
                //home_listbox
               /* bool isValid = true;
                foreach (string item in home_listbox.Items)
                {
                    if (item == content)
                    {
                        MessageBox.Show("Already in the list.");
                        isValid = false;
                    }
                }

                if (isValid)
                    home_listbox.Items.Add(content);
            } */

           // home_datagrid.Items.Add(contents);

        }

        private void combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select * from test_name where test_name='"+combo_box.Text +"'";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                //create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();

                while (dr.Read())
                {
                    //string name = dr.GetString(2);
                    int price = dr.GetInt32(2);
                    test_cost_textfield.Text = price.ToString();
                }

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_box_GotFocus(object sender, RoutedEventArgs e)
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select * from test_name where test_name='" + combo_box.Text + "'";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                //create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();

                while (dr.Read())
                {
                    //string name = dr.GetString(2);
                    int price = dr.GetInt32(2);
                    test_cost_textfield.Text = price.ToString();
                }

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void home_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void home_sex_combobox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Female");
            list.Add("Male");


            //var combobox = sender as ComboBox;
            
            home_sex_combobox.ItemsSource = list;
            //home_sex_combobox.SelectedIndex = 0;
        }



       
    }
}
