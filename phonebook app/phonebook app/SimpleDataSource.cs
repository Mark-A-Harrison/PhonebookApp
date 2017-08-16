using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

class SimpleDataSource : IDisposable
{
    MySqlConnection conn;
    MySqlCommand command;
    MySqlCommand update;

    /// <summary>
    /// Constructor, calls Connect method with params
    /// </summary>
    /// <param name="server">Server IP or hostname</param>
    /// <param name="database">Database/schema name</param>
    /// <param name="port">Port number</param>
    /// <param name="user">Username</param>
    /// <param name="password">Password</param>
    public SimpleDataSource(string server, string database, int port,
        string user, string password)
    {
        Connect(server, database, port, user, password);
    }

    /// <summary>
    /// Intialises MySqlConnection object with parameters provided.
    /// </summary>
    /// <param name="server">Server IP or hostname</param>
    /// <param name="database">Database/schema name</param>
    /// <param name="port">Port number</param>
    /// <param name="user">Username</param>
    /// <param name="password">Password</param>
    public void Connect(string server, string database, int port,
        string user, string password)
    {
        string connectionString = "server=" + server + ";database=" + database + ";port=" + port + ";user=" + user + ";password=" + password;

        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not connect to the server." + e);
        }
    }

    /// <summary>
    /// Creates an SQL query from the provided string and
    /// executes it.
    /// </summary>
    /// <param name="queryString">A string containing an SQL query</param>
    /// <returns>A MySqlDataReader object with the results 
    /// of the query</returns>
    public MySqlDataReader Query(string queryString)
    {
        // TODO: Declares MySqlDataReader and MySqlCommand objects.
        // When the MySqlCommand object is executed with the query
        // string, the return value will be assigned to the MySqlDataReader
        // object. This object is then returned with the "return" keyword.
        command = new MySqlCommand(queryString, conn);
        MySqlDataReader dReader = command.ExecuteReader();

        return dReader;
    }

    /// <summary>
    /// Creates an SQL statement from the provided string and
    /// executes it. 
    /// </summary>
    /// <param name="updateString">A string containing an SQL non-query</param>
    public void Update(string updateString)
    {
        // TODO: Creates and initialises a MySqlCommand object with
        // the provided string parameter, and executes this update
        // with suitable exception handling.
        update = new MySqlCommand(updateString, conn);

        try
        {
            update.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("unable to update dataset." + e);
        }
    }

    /// <summary>
    /// datatable
    /// </summary>
    /// 
    public DataTable DataTableQuery(string sqlQuery)
    {

        DataTable dataTable = new DataTable();
        MySqlCommand cmd2 = new MySqlCommand(sqlQuery, conn);
        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
        adapter.Fill(dataTable);

        return dataTable;
    }


    /// <summary>
    /// Garbage collection method called by Garbage Collector.
    /// SimpleDataSource implements IDisposable, so the GC will
    /// know to call this method when the object is no longer
    /// needed.
    /// </summary>
    /// 
    public void Dispose()
    {
        if (conn != null)
            conn.Dispose();
    }
}

