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
using System.Data.SqlClient;
using System.Data;
namespace ModernDiagnosticCenter.Admin
{
    /// <summary>
       /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : UserControl
    {
        public Test()
        {
            //InitializeComponent();
        }

      /* private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                //string query = "select * from patient_table";
               // string query = "select MAX(_id) as max_id from patient_table";
               //  string query = "select COUNT(DISTINCT sex) as max_id from patient_table";
                string query = "select * from patient_table WHERE date BETWEEN '20/01/2016'  AND '21/01/2016' ";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();
                

                //*******here we determine max value id
                //MessageBox.Show(dr["max_id"].ToString());


                SQLiteDataAdapter dataAdapt = new SQLiteDataAdapter(query, sqlite_connection);
                var ds = new DataSet();


               dataAdapt.Fill(ds,"patient_table");
                listView1.DataContext = ds.Tables["patient_table"].DefaultView;

               sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    


            
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                //string query = @"select * from patient_table WHERE date BETWEEN '#25/06/2015#' AND '#26/06/2015#'";
                string query = @"select * from patient_table WHERE age BETWEEN 1 AND 20";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                create_command.ExecuteNonQuery();
                //SQLiteDataReader dr = create_command.ExecuteReader();

              

                SQLiteDataAdapter dataAdapt = new SQLiteDataAdapter(query, sqlite_connection);
                //var ds = new DataSet();

                DataTable dt = new DataTable("patient_table");
                //dataAdapt.Fill(ds,"patient_table");
                dataAdapt.Fill(dt);
                // listView1.DataContext = ds.Tables["patient_table"].DefaultView;
                admin_daily_accounting_data_grid.ItemsSource = dt.DefaultView;
                dataAdapt.Update(dt);

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
