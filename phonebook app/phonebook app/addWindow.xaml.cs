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
    /// Interaction logic for addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {

        SimpleDataSource dataSource;
        string server = "";
        string database = "";
        int port = 3306;
        string user = "";
        string password = "";

        public addWindow()
        {
            InitializeComponent();

            dataSource = new SimpleDataSource(server, database, port, user, password);
        }

        //Add new contact making sure that all fields have been filled.

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string a = "First Name";
            string b = "Last Name";
            string c = "Position";
            string d = "Email";
            string f = "Telephone No";

            //check whether name,position boxes have only alphabetical characters
            if (!System.Text.RegularExpressions.Regex.IsMatch(fNameBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Only alphabetical characters can be used in the first name box.");
                fNameBox.Text = a;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(lNameBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Only alphabetical characters can be used in the last name box.");
                lNameBox.Text = b;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(posBox.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Only alphabetical characters can be used in the position box.");
                posBox.Text = c;
            }

            //test for numbres only in telephone no box or tel No string.
            else if (!System.Text.RegularExpressions.Regex.IsMatch(telBox.Text, "^[0-9]"))
            {
                MessageBox.Show("Numbers Only in the Telephone Box");
            }


            //show messagebox if a field has been left with default content
            else if (fNameBox.Text.Equals(a) || lNameBox.Text.Equals(b) || posBox.Text.Equals(c) || emailBox.Text.Equals(d) || telBox.Text.Equals(f))
            {
                MessageBox.Show("Error : Contact Not Added, Fill in all Fields");
            }

            //test email address format
            else if (!System.Text.RegularExpressions.Regex.IsMatch(emailBox.Text, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
            {
                MessageBox.Show("Email has Incorrect format.");
                emailBox.Text = d;
            }

            //insert details into database if proper input has been added. reset textbox for new input.
            else if (fNameBox.Text != a && lNameBox.Text != b && posBox.Text != c && emailBox.Text != d && telBox.Text != f)
            {
                string sqlQuery = "INSERT INTO CompanyPhonebook (fName, lName, position, email, telNo) VALUES('" + fNameBox.Text + "', '" + lNameBox.Text + "', '" + posBox.Text + "', '" + emailBox.Text + "', '" + telBox.Text + "');";
                dataSource.Update(sqlQuery);
                MessageBox.Show("Contact Added");
                fNameBox.Text = a;
                lNameBox.Text = b;
                posBox.Text = c;
                emailBox.Text = d;
                telBox.Text = f;
            }                   
        }
    }
}
