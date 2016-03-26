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
using System.Collections;
using System.IO;

namespace ModernDiagnosticCenter.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    /// 

   //private int count = 0;
    
    public partial class Home : UserControl
    {
        private ArrayList data = new ArrayList();
        private int index = 0;
        private int sumTestCost = 0;
        private int sumDiscount = 0;
        private int sumDue = 0;
        private int sumPaid = 0;
       
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
            

            string Name = name_textfield.Text;
            string Age = age_textbox.Text;
            string DocName = doctor_textfield.Text;
            string Phone = phone_textbox.Text;

            if (string.IsNullOrWhiteSpace(Name) || Name.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Name correctly");
                name_textfield.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Age) || !Age.Any( Char.IsDigit))
            {
                MessageBox.Show("Please enter your age correctly");
                age_textbox.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(DocName) || DocName.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Doctor Name correctly");
                doctor_textfield.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(Phone) || !Phone.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Phone No correctly");
                phone_textbox.Focus();
                return;
            }

            try
            {
                

                MessageBoxResult result = MessageBox.Show("Do You want to print?", "MDC", MessageBoxButton.OKCancel);

                if (MessageBoxResult.OK == result)
                { 
                    
                   int flag = printAllInfoAndSaveInDatabase();
                   if (flag == 0)
                       return;
                // to clear Output.txt
                  using (StreamWriter obj = new StreamWriter("output.txt", false)) { }
                  testCount = 0;

                   
                  
                }

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

        private int printAllInfoAndSaveInDatabase()
        {
            

            if(testCount == 0)
            {

                MessageBox.Show("You didn't add any test yet","MDC",MessageBoxButton.OK,MessageBoxImage.Error);
                return 0;
            }

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
            
            //test name and price
            /*obj.print_test_name_1.Text = combo_box.Text;
            obj.print_amount_1.Text = test_cost_textfield.Text;

            obj.print_test_name_2.Text = combo_box.Text;
            obj.print_amount_2.Text = test_cost_textfield.Text;

            obj.print_test_name_3.Text = combo_box.Text;
            obj.print_amount_3.Text = test_cost_textfield.Text;

            obj.print_test_name_4.Text = combo_box.Text;
            obj.print_amount_4.Text = test_cost_textfield.Text;

            obj.print_test_name_5.Text = combo_box.Text;
            obj.print_amount_5.Text = test_cost_textfield.Text;
            */


            //all test information for printing
           
            TextBlock[] printSerialNo = { obj.print_no_1, obj.print_no_2, obj.print_no_3, obj.print_no_4, obj.print_no_5, obj.print_no_6, obj.print_no_7, obj.print_no_8, obj.print_no_9, obj.print_no_10 };
            TextBlock[] printTestName = { obj.print_test_name_1, obj.print_test_name_2, obj.print_test_name_3, obj.print_test_name_4, obj.print_test_name_5, obj.print_test_name_6, obj.print_test_name_7, obj.print_test_name_8, obj.print_test_name_9, obj.print_test_name_10};
            TextBlock[] printTestPrice = { obj.print_amount_1, obj.print_amount_2, obj.print_amount_3, obj.print_amount_4, obj.print_amount_5, obj.print_amount_6, obj.print_amount_7, obj.print_amount_8, obj.print_amount_9, obj.print_amount_10};
            //file read from output.txt
        

            string line;
            using (StreamReader file = new StreamReader("output.txt"))
                //while((line = file.ReadLine()) != null )
                for (int i = 0; i < testCount; i++ )
                {

                    int cost, due, discount, paid;

                    printSerialNo[i].Text = (i + 1).ToString();
                    printTestName[i].Text = file.ReadLine(); // test name read from file
                    
                    //read test cost as string and convert it to int and save it for calculation
                    line = file.ReadLine();// read test cost
                    cost = int.Parse(line);
                    printTestPrice[i].Text = line;

                    //read due cost as string and convert it to int and save it for calculation
                    line = file.ReadLine();
                    due = int.Parse(line);

                    line = file.ReadLine();
                    discount = int.Parse(line);

                    line = file.ReadLine();
                    paid = int.Parse(line);


                    sumTestCost += cost;
                    sumDue += due;
                    sumDiscount += discount;
                    sumPaid += paid;
                    
                    //This is file data serial
                    //combo_box.Text = "";
                    //test_cost_textfield.Text = "";
                    //due_textfield.Text = "";
                    //discount_textfield.Text = "";
                    //paid_textbox.Text = "";

                    //dummy line
                    //line = file.ReadLine();
                    //line = file.ReadLine();
                    //line = file.ReadLine();
                    //index++;
                }

            // PrinterWithScaling(obj);

            obj.print_sub_total.Text = sumTestCost.ToString();
            obj.print_discount.Text = sumDiscount.ToString();

            int netPayable = sumTestCost - sumDiscount;

            obj.print_net_total.Text = netPayable.ToString();
            obj.print_ammount_receive.Text = sumPaid.ToString();
            obj.print_due.Text = sumDue.ToString();

            name_textfield.Text = "";
            age_textbox.Text = "";
            doctor_textfield.Text = "";
            phone_textbox.Text = "";
            home_sex_combobox.Text = "";

            obj.Show();
            obj.Close();
            printPage2(obj);
            SaveInDatabase();

             index = 0;
             sumTestCost = 0;
             sumDiscount = 0;
             sumDue = 0;
             sumPaid = 0;

            return 1;
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

        int testCount = 0;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if(testCount >= 10 )
            {
                MessageBox.Show("Already 10 test has been added\nyou can't add more test", "MDC", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string Name = name_textfield.Text;
            string Age = age_textbox.Text;
            string DocName = doctor_textfield.Text;
            string Phone = phone_textbox.Text;
            
            string ComboBox = combo_box.Text;
            string TestCost = test_cost_textfield.Text;
            string Discount = discount_textfield.Text;
            string Due = due_textfield.Text;
            string Paid = paid_textbox.Text;

            




            if (string.IsNullOrWhiteSpace(Name) || Name.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your test name correctly");
                name_textfield.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Age) || !Age.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your age correctly");
                age_textbox.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(DocName) || DocName.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Doctor Name correctly");
                doctor_textfield.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(Phone) || !Phone.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Phone No correctly");
                phone_textbox.Focus();
                return;
            }





            if (string.IsNullOrWhiteSpace(ComboBox))
            {
                MessageBox.Show("Please enter your Test name correctly");
                //combo_box.Text.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(TestCost) || !TestCost.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Test cost field correctly");
                test_cost_textfield.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Discount) || !Discount.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Discount field correctly");
               
                discount_textfield.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(Due) || !Due.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Due field correctly");
                
                due_textfield.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Paid) || !Paid.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Paid field correctly");
              
                paid_textbox.Focus();
                return;
            }



            //Checking paid = due + discount + test cost
            if (int.Parse(TestCost) != (int.Parse(Due) + int.Parse(Discount) + int.Parse(Paid)))
            {
                MessageBox.Show("Please Input Test Cost, Due cost, Discount Cost and Paid Cost Correctly!!");
                return;
                    
            }

            string s = testCount.ToString();
            MessageBoxResult result =  MessageBox.Show("Do you want to add this test?","MDC",MessageBoxButton.OKCancel);
            //MessageBox.Show(s);

            if (MessageBoxResult.OK == result)
            {
                using (StreamWriter obj = new StreamWriter("output.txt", true))
                {
                    
                    //count++;
                    testCount++;
                    obj.WriteLine(combo_box.Text);
                    obj.WriteLine(test_cost_textfield.Text);
                    obj.WriteLine(due_textfield.Text);
                    obj.WriteLine(discount_textfield.Text);
                    obj.WriteLine(paid_textbox.Text);

                    combo_box.Text = "";
                    test_cost_textfield.Text = "";
                    due_textfield.Text = "";
                    discount_textfield.Text = "";
                    paid_textbox.Text = "";
                  


                }

            }
            

            //foreach (var i in File.ReadAllLines("output.txt"))
               // MessageBox.Show(i);
            
            /*string[] contents = new string[3]
            {
               name_textfield.Text,
                //age_textbox.Text,
                //phone_textbox.Text,
                combo_box.Text,
                ""
                
            };*/


           // data.Add();

            //home_list_view.Items.Add("hello");
            //home_list_view.ItemsSource = data;

           // ArrayList data = new ArrayList();
           /* data.Add("hello");
            data.Add("world");
            home_listbox_for_testname.ItemsSource = data;*/
            
            /*foreach (string content in contents)
            {
                home_listbox;
                bool isValid = true;
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
            } 

            home_datagrid.Items.Add(contents);
             * */

        }

        private void combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int price;
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
                     price = dr.GetInt32(2);
                    test_cost_textfield.Text = price.ToString();
                    
                }

                discount_textfield.Text = "0";
                paid_textbox.Text = test_cost_textfield.Text;
                due_textfield.Text = "0";

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

                discount_textfield.Text = "0";
                paid_textbox.Text = test_cost_textfield.Text;
                due_textfield.Text = "0";


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
