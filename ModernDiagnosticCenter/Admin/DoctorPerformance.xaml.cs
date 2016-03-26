using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

namespace ModernDiagnosticCenter.Admin
{
    /// <summary>
    /// Interaction logic for DoctorPerformance.xaml
    /// </summary>
    public partial class DoctorPerformance : UserControl
    {
        public DoctorPerformance()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                //string query = @"select * from patient_table WHERE date BETWEEN '#25/06/2015#' AND '#26/06/2015#'";
                string query = @"select name,age from patient_table WHERE age BETWEEN 1 AND 20";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                create_command.ExecuteNonQuery();
                //SQLiteDataReader dr = create_command.ExecuteReader();



                SQLiteDataAdapter dataAdapt = new SQLiteDataAdapter(query, sqlite_connection);
                //var ds = new DataSet();

                DataTable dt = new DataTable("patient_table");
                //dataAdapt.Fill(ds,"patient_table");
                dataAdapt.Fill(dt);
                // listView1.DataContext = ds.Tables["patient_table"].DefaultView;
                doctor_performance_datagrid.ItemsSource = dt.DefaultView;
                //admin_daily_accounting_data_grid.ItemsSource = dt.DefaultView;
                dataAdapt.Update(dt);

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
