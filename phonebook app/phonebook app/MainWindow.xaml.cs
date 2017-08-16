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
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace phonebook_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleDataSource dataSource;
        string server = "";
        string database = "";
        int port = 3306;
        string user = "";
        string password = "";


        public MainWindow()
        {
            InitializeComponent();
            DataTable dataGrid = new DataTable();
            dataSource = new SimpleDataSource(server, database, port, user, password);
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            searchWindow sWindow = new searchWindow();
            sWindow.Show();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            addWindow aWindow = new addWindow();
            aWindow.Show();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            editWindow eWindow = new editWindow();
            eWindow.Show();
        }
    }
}
