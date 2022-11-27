using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    static public class MyElements
    {
        static public SqlDataAdapter adapter = new SqlDataAdapter();
        static public SqlCommand command = new SqlCommand();
        static public bool Lock_log = false;
        static public bool trener = false;
        static public bool spotman = false;
        static public bool admin = false;
        static public string NameUser = null;
        static public string LogName = null;
        static public DataTable GroupTable = new DataTable();
        static public DataTable ZalsTablePON = new DataTable();
        static public DataTable ZalsTableVTOR = new DataTable();
        static public DataTable ZalsTableSREDA = new DataTable();
        static public DataTable ZalsTableCHETV = new DataTable();
        static public DataTable ZalsTablePYAT = new DataTable();
        static public DataTable ZalsTableSUBB = new DataTable();
        static public DataTable PonTable = new DataTable();
        static public DataTable VtorTable = new DataTable();
        static public DataTable SredTable = new DataTable();
        static public DataTable ChetTable = new DataTable();
        static public DataTable PyatTable = new DataTable();
        static public DataTable SubbTable = new DataTable();
        static public DataTable AllZals = new DataTable();
        static public DataTable AllTreners = new DataTable();
        static public DataTable AlltRENIROVKI = new DataTable();
        static public DataTable NAMEGROUP = new DataTable();
        static public DataTable IFGROUP = new DataTable();
        static public DataTable TableRaspisanie = new DataTable();

        static public void Group()
        {
            MyElements.GroupTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_ГРУППЫ_ТРЕНЕР_КАНИКУЛЫ];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.GroupTable);
        }
        static public void GroupIF()
        {
            MyElements.GroupTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = @"SELECT НОМЕР_ГРУППЫ AS [№], НАЗВАНИЕ_ГРУППЫ AS [НАЗВАНИЕ] FROM ГРУППЫ";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.IFGROUP);
        }
    }
}
