using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    static public class MyConDB
    {
        static public SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-9N46EPK\DANIIL_BANK1230;Initial Catalog=data_boxing;Integrated Security=True");

        static public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();
        }

        static public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }
        static public SqlConnection GetConnection()
        {
            return Connection;
        }
    }
}
