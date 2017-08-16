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
    /// Interaction logic for editContact.xaml
    /// </summary>
    public partial class editContact : Window
    {
        SimpleDataSource dataSource;
        string server = "";
        string database = "";
        int port = 3306;
        string user = "";
        string password = "";

        public editContact()
        {
            InitializeComponent();
            DataTable dataGrid1 = new DataTable();
            dataSource = new SimpleDataSource(server, database, port, user, password);
        }

        private void staffIdBtn_Click(object sender, RoutedEventArgs e)
        {
            EditForm eform = new EditForm();
            eform.Show();
            eform.passValue = staffIdBox.Text;                             
        }
    }
}
