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
    /// Interaction logic for searchWindow.xaml
    /// </summary>
    public partial class searchWindow : Window
    {
        SimpleDataSource dataSource;
        string server = "";
        string database = "";
        int port = 3306;
        string user = "";
        string password = "";


        public searchWindow()
        {
            InitializeComponent();

            DataTable dataGrid1 = new DataTable();
            dataSource = new SimpleDataSource(server, database, port, user, password);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string a = "Last Name";
            string b = "First Name";
            string c = "Position";
            string sqlQuery = "Select * FROM CompanyPhonebook WHERE lName = '" + lNameBox.Text + "'";
            string sqlQuery2 = "Select * FROM CompanyPhonebook WHERE fName = '" + fNameBox.Text + "'";
            string sqlQuery3 = "Select * FROM CompanyPhonebook WHERE position = '" + posBox.Text + "'";

            DataTable dTable = new DataTable();
            dataGrid1.ItemsSource = dTable.DefaultView;

            //test that the last, first name and position fields only contains alphabetic characters
            if (!System.Text.RegularExpressions.Regex.IsMatch(lNameBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Last Name can only be alphabetic characters");
                lNameBox.Text = a;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(fNameBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("First Name can only be alphabetic characters");
                fNameBox.Text = b;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(posBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("The position field can only be alphabetic characters");
                posBox.Text = c;
            }

            //Search using the field where info has been left

            //search using lName, reset textbox for new input.
            else if (lNameBox.Text != a && lNameBox.Text != "")
            {
                dTable = dataSource.DataTableQuery(sqlQuery);
                dataGrid1.ItemsSource = dTable.DefaultView;
                lNameBox.Text = a;
            }

            //search using fName, reset textbox for new input.
            else if (fNameBox.Text != b && fNameBox.Text != "")
            {
                dTable = dataSource.DataTableQuery(sqlQuery2);
                dataGrid1.ItemsSource = dTable.DefaultView;
                fNameBox.Text = b;                
            }

            //search using position, reset textbox for new input.
            else if (posBox.Text != c && posBox.Text != "")
            {
                dTable = dataSource.DataTableQuery(sqlQuery3);
                dataGrid1.ItemsSource = dTable.DefaultView;
                posBox.Text = c;

            }

            //error message if no contacts are found
            else if (dTable.Rows.Count <= 0)
            {
                MessageBox.Show("Error : No contacts Found.");
            }            
        }

        private void popbtn_Click(object sender, RoutedEventArgs e)
        {
            //query to show all contacts
            string sqlQuery = "Select * FROM CompanyPhonebook";
            DataTable dTable = dataSource.DataTableQuery(sqlQuery);
            dataGrid1.ItemsSource = dTable.DefaultView;
        }        
    }
}
