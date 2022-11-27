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
    public partial class AddPara : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();

        string s1;
        string s2;
        int i1;
        int i2;

        public AddPara()
        {
            InitializeComponent();
            command.Connection = MyConDB.Connection;
        }
        private void AddPara_Load(object sender, EventArgs e)
        {
            command.CommandText = "SELECT * FROM ПАРЫ";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectAll();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                s1 = textBoxNAME.Text.ToString();
                s2 = textBoxFAMILY.Text.ToString();
                i1 = int.Parse(s1);
                i2 = int.Parse(s2);
                command.CommandText = "INSERT INTO ПАРЫ VALUES(@A, @A1)";
                command.Parameters.Add("@A", SqlDbType.Int).Value = i1;
                command.Parameters.Add("@A1", SqlDbType.Int).Value = i2;

                command.ExecuteNonQuery();

                MessageBox.Show("Пара успешно добавлена!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            { 
                    MessageBox.Show("Ошибка: запись не была добавлена", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddPara_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyConDB.CloseConnection();
        }
    }
}
