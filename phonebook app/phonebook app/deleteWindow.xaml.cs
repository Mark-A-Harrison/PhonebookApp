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
    /// Interaction logic for deleteWindow.xaml
    /// </summary>
    public partial class deleteWindow : Window
    {
            SimpleDataSource dataSource;
            string server = "";
            string database = "";
            int port = 3306;
            string user = "";
            string password = "";


            public deleteWindow()
        {
            InitializeComponent();

            DataTable dataGrid1 = new DataTable();
            dataSource = new SimpleDataSource(server, database, port, user, password);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            string a = "StaffID";
            string b = "First Name";
            string c = "Last Name";

            //check if StaffIDBox contains only numeric value or string StaffID
            if (StaffIDBox.Text != a && !System.Text.RegularExpressions.Regex.IsMatch(StaffIDBox.Text, "^[0-9]"))
            {
                MessageBox.Show("Incorrect Input, Numeric Characters only");
            }
            
            //check if only alphabetic characters are in fnameBox
            else if (!System.Text.RegularExpressions.Regex.IsMatch(fNameBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Incorrect Input, Alphabetical Characters only");
            }

            //check if only alphabetic characters are in lNameBox
            else if (!System.Text.RegularExpressions.Regex.IsMatch(lNameBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Incorrect Input, Alphabetical Characters only");
            }

            //delete using staff ID, reset textbox for new input.
            else if (StaffIDBox.Text != a && StaffIDBox.Text != "")
            {
                string sqlQuery = "DELETE FROM CompanyPhonebook WHERE StaffID =('" + StaffIDBox.Text + "');";
                dataSource.Update(sqlQuery);
                MessageBox.Show("Contact Removed");
                StaffIDBox.Text = a;
            }

            //delete using First Name, reset textbox for new input.
            else if (fNameBox.Text != b && fNameBox.Text != "")
            {
                string sqlQuery2 = "DELETE FROM CompanyPhonebook WHERE fName =('" + fNameBox.Text + "');";
                dataSource.Update(sqlQuery2);
                MessageBox.Show("Contact Removed");
                fNameBox.Text = b;
            }

            //delete using Last Name, reset textbox for new input.
            else if (lNameBox.Text != c && lNameBox.Text != "")
            {
                string sqlQuery3 = "DELETE FROM CompanyPhonebook WHERE lName =('" + lNameBox.Text + "');";
                dataSource.Update(sqlQuery3);
                MessageBox.Show("Contact Removed");
                lNameBox.Text = c;
            }

            //display error message if no field have been entered
            else if (StaffIDBox.Text == a || StaffIDBox.Text == "" && fNameBox.Text == b || fNameBox.Text == "" && lNameBox.Text == c || lNameBox.Text == "")
            {
                MessageBox.Show("Error : Fill in one of the Fields");
            }
        }

        private void lNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
