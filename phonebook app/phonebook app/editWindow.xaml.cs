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
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace phonebook_app
{
    /// <summary>
    /// Interaction logic for editWindow.xaml
    /// </summary>
    public partial class editWindow : Window
    {
        SimpleDataSource dataSource;
        string server = "";
        string database = "";
        int port = 3306;
        string user = "";
        string password = "";


        public editWindow()
        {
            InitializeComponent();

            DataTable dataGrid1 = new DataTable();
            dataSource = new SimpleDataSource(server, database, port, user, password);
        }

        private void popBtn_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "Select * FROM CompanyPhonebook";
            DataTable dTable = dataSource.DataTableQuery(sqlQuery);
            dataGrid1.ItemsSource = dTable.DefaultView;
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            deleteWindow dWindow = new deleteWindow();
            dWindow.Show();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            editContact edWindow = new editContact();
            edWindow.Show();
        }
    }
}
