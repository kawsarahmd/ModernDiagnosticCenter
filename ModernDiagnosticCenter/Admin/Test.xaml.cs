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
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select age,name,phone from patient_table";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                create_command.ExecuteNonQuery();
                //SQLiteDataReader dr = create_command.ExecuteReader();

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
        }
    }
}
