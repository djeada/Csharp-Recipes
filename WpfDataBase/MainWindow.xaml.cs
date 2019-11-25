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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection();

        public MainWindow()
        {
            InitializeComponent();
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adam\source\repos\WpfDataBase\WpfDataBase\DatabaseEmployees.mdf;Integrated Security=True;";
            conn.ConnectionString = connString;
            conn.Open();
            updateTable();
        }

        void updateTable()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Persons", conn);
            command.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Persons");
            dataAdp.Fill(dt);
            tableGrid.ItemsSource = dt.DefaultView;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            string name = "'" + nameText.Text + "'";
            string surname = "'" + surnameText.Text + "'";
            string phone = "'" + phoneText.Text + "'";
            string query = String.Format("INSERT INTO Persons(Name, Surname, Number) VALUES ({0},{1},{2})", name, surname, phone);
            SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string name = "'" + nameText.Text + "'";
            string surname = "'" + surnameText.Text + "'";
            string phone = "'" + phoneText.Text + "'";
            string query = String.Format("DELETE FROM Persons Where Name={0} AND Surname={1} AND Number={2}", name, surname, phone);
            SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            updateTable();
        }
    }
}
