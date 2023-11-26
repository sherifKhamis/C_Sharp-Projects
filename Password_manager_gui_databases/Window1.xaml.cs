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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Password_manager_gui_databases
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection sqlConnection;
        public Window1()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Password_manager_gui_databases.Properties.Settings.PASSWORD_MANAGER_DBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            showAccounts();
        }

        private void showAccounts()
        {
            string query = "select * from Accounts";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            using(sqlDataAdapter)
            {
                DataTable AccountTable = new DataTable();

                sqlDataAdapter.Fill(AccountTable);

                ListBox_Accounts.DisplayMemberPath = "Account";
                ListBox_Accounts.SelectedValuePath = "Id";
                ListBox_Accounts.ItemsSource = AccountTable.DefaultView;
            }

        }

        private void showPasswords()
        {
            string query = "select * from Passwords p inner join Password_Manager pm on p.Id = pm.PasswordID where pm.AccountID = @AccountID";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);   
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            using (sqlDataAdapter)
            {
                sqlCommand.Parameters.AddWithValue("@AccountID", ListBox_Accounts.SelectedValue);
                DataTable PasswordTable = new DataTable();

                sqlDataAdapter.Fill(PasswordTable);

                ListBox_Passwords.DisplayMemberPath = "Password";
                ListBox_Passwords.SelectedValuePath = "Id";
                ListBox_Passwords.ItemsSource = PasswordTable.DefaultView;
            }

        }

        void ListBox_Accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showPasswords();
        }

        private void Dlt_Account_Btn_clicked(object sender, RoutedEventArgs e)
        {
            string query = "delete from Accounts where id = @AccountID";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("@AccountID", ListBox_Accounts.SelectedValue);
            sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            ListBox_Accounts.UnselectAll();
            ListBox_Accounts.Items.Clear();
        }

        private void Add_Account_Btn_clicked(object sender, RoutedEventArgs e)
        {
            string query = "insert into Accounts values (@Account)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("@Account", TextBox.Text);
            sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            showAccounts();
        }

        private void Add_Password_Btn_clicked(object sender, RoutedEventArgs e)
        {
            string query = "insert into Passwords values (@Password, @Id)";
            //string query2 = "insert into Password_Manager values (@AccountID)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //SqlCommand sqlCommand2 = new SqlCommand(query2, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("@Password", TextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Id", ListBox_Accounts.SelectedValuePath);
            //sqlCommand2.Parameters.AddWithValue("AccountID", ListBox_Accounts.SelectedValue);
            sqlCommand.ExecuteScalar();
            //sqlCommand2.ExecuteScalar();
            sqlConnection.Close();
            
        }

        private void Dlt_Password_Btn_clicked(object sender, RoutedEventArgs e)
        {
            string query = "delete from Passwords where id = @PasswordID";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("@PasswordID", ListBox_Passwords.SelectedValue);
            sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            showPasswords();
        }
    }
}
