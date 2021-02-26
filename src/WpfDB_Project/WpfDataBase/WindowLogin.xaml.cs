using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfDataBase
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; private set; }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adam\source\repos\WpfDataBase\WpfDataBase\DatabaseEmployees.mdf;Integrated Security=True;";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;

            try
            {
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                String query = "SELECT COUNT(1) FROM Logins WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, conn);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow board = new MainWindow();
                    board.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong credentials");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
