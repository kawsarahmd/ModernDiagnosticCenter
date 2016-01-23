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

namespace ModernDiagnosticCenter.Pages.Settings
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {

        string dbConnectionString = @"Data Source=patient.db;Version=3;";
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select * from admin where name='"+this.name.Text+"' and password='"+this.password.Password+"'";

                SQLiteCommand create_command = new SQLiteCommand(query,sqlite_connection);
                create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();

                int count = 0;
               // dr.
                

                while(dr.Read())
                {
                    string s = dr.GetString(0);
                    MessageBox.Show("Hello " + s);
                    count++;
                }
                if(count==1)
                { 
                
                  var  m = new ModernWindow1();
                  m.Show();
                    //MessageBox.Show("Password does not match!!!!");
                   // AdminPage obj = new AdminPage();
                    
                    
                   
                    
                    
                }
                else if (count < 1)
                {
                    MessageBox.Show("Password does not match!!!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
