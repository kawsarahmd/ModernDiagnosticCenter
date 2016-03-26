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
    
    public partial class Update : UserControl
    {
        
       
        public Update()
        {
            InitializeComponent();
           // home_datepicker.SelectedDate = DateTime.Today;
           // fill_combobox();
            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //update_name_textfield.Text = "Hello World";

           clearTextFieldData();
        }

        private void clearTextFieldData()
        {
            update_name_textfield.Text = "";
            update_age_textbox.Text = "";
            update_phone_textbox.Text = "";

            update_test_cost_textfield.Text = "";
          //  update_due_textfield.Text = "";
           // update_paid_textbox.Text = "";
            update_sex_textfield.Text = "";
            update_delivery_date.Text = "";
            update_date.Text = "";
            update_time.Text = "";
            update_doctor_textfield.Text = "";
            update_discount_textfield.Text = "";
            update_due_textbox.Text = "";
            update_paid_textfield.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            findBillId();

            //after database search query it will focus on DUE filed
            //update_due_textfield.Focus();
            update_paid_textfield.Focus();
            
        }

        private void findBillId()
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                //string query = "select * from test_name order by test_name.test_name asc";
                string query = "select * from patient_table where _id = '" + update_bill_no_textbox.Text + "'";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                //create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();

                if (dr.Read())
                {
                    //string name = dr.GetString(1);
                    update_name_textfield.Text = dr.GetString(1);
                    update_age_textbox.Text = dr.GetInt16(2).ToString();
                    update_phone_textbox.Text = dr.GetString(3);

                    update_test_cost_textfield.Text = dr.GetInt32(4).ToString();
                    update_due_textbox.Text = dr.GetInt32(5).ToString();
                    //update_due_textfield.Text = dr.GetInt32(5).ToString();
                    //update_paid_textbox.Text = dr.GetInt32(6).ToString();
                    update_paid_textfield.Text = dr.GetInt32(6).ToString();
                    update_sex_textfield.Text = dr.GetString(7);
                    update_delivery_date.Text = dr.GetString(8);
                    update_date.Text = dr.GetString(10)  ;
                    update_time.Text = dr.GetString(9);
                    update_doctor_textfield.Text = dr.GetString(11);
                    update_discount_textfield.Text = dr.GetInt32(12).ToString();
                }
                else { MessageBox.Show("No Data Found!!!"); }

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printPanel_Loaded(object sender, RoutedEventArgs e)
        {
            update_bill_no_textbox.Focus();
        }

        private void update_due_textfield_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            // your event handler here
            e.Handled = true;
            update_doctor_textfield.Text = "Mr XYZ";
            MessageBox.Show("Enter pressed");
        }

        

        

       
    }
}
