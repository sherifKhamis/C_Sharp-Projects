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
                ListBox_Accounts.ItemsSource = AccountTable.DefaultView;
            }

        }
    }
}
