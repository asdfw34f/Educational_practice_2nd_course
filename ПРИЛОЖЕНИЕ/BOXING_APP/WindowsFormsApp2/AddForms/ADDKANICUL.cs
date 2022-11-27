using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2.AddForms
{
    public partial class ADDKANICUL : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();
        public ADDKANICUL()
        {
            InitializeComponent();
            command.Connection = MyConDB.Connection;
        }
        private void Selectss()
        {
            table.Clear();
            command.CommandText = "SELECT * FROM КАНИКУЛЫ";
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }
        private void Add()
        {
            Selectss();
            int gg = table.Rows.Count + 1;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@START";
            parameter1.SqlDbType = SqlDbType.Date;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = dateTimePicker1.Value.ToString();

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@FINISH";
            parameter2.SqlDbType = SqlDbType.Date;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = dateTimePicker2.Value.ToString();

            command.CommandText = "INSERT INTO КАНИКУЛЫ(НОМЕР_КАНИКУЛ, НАЧАЛО_КАНИКУЛ, КОНЕЦ_КАНИКУЛ) VALUES(@NUM,  @START, @FINISH)";
            command.Parameters.Add("@NUM", SqlDbType.Int).Value = gg;
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);

            MyConDB.OpenConnection();
            command.ExecuteNonQuery();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void ADDKANICUL_Load(object sender, EventArgs e)
        {
            Selectss();
            string start = dateTimePicker1.Value.ToString();
            string finish = dateTimePicker2.Value.ToString();
            button1.Text = start;
        }
    }
}
