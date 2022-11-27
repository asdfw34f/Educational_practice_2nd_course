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

namespace WindowsFormsApp2.DeleteForms
{
    public partial class Delete_Para : Form
    {
        public Delete_Para()
        {
            InitializeComponent();
            command.Connection = MyConDB.Connection;
        }
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();

        string del;
        int delInt;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                del = textBox.Text.ToString();
                delInt = int.Parse(del);

                command.CommandText = "DELETE FROM ПАРЫ WHERE НОМЕР_ПАРЫ = @D";
                command.Parameters.Add("@D", SqlDbType.Int).Value = delInt;

                command.ExecuteNonQuery();

                MessageBox.Show("Пары успешно удалёна!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка: запись не была удалена", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_Para_Load_1(object sender, EventArgs e)
        {
            command.CommandText = "SELECT * FROM ПАРЫ";
                adapter.SelectCommand = command;
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.SelectAll();
        }
        private void Delete_Para_FormClosing(object sender, FormClosingEventArgs e)
        {
                MyConDB.CloseConnection();
        }
    }
}
