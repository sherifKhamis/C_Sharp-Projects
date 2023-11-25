using Password_Manager_gui_databases;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace password_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 secondWindow = new Window1();
        public MainWindow()
        {
            InitializeComponent();

        }

        public bool get_passwordEntry()
        {
            string passwordEntry = Enter_pwbox.Password;
            if (passwordEntry == "Passwort")
                return true;
            return false;
        }

        public void enter_btn_clicked(object sender, RoutedEventArgs e)
        {
            if (get_passwordEntry() == false)
                MessageBox.Show("Wrong password, try again!");
            else
            {
                this.Hide();
                secondWindow.Show();
            }
        }
    }
}