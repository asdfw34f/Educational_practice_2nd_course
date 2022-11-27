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
    public partial class DELETE_GROUP : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();

        string del;
        int delInt;
        public DELETE_GROUP()
        {
            InitializeComponent();
            command.Connection = MyConDB.Connection;
        }
        private void DELETE_GROUP_Load(object sender, EventArgs e)
        {
            command.CommandText = "SELECT * FROM ГРУППЫ";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectAll();
        }
        private void DELETE_GROUP_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            MyConDB.CloseConnection();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                del = textBox.Text.ToString();
                delInt = int.Parse(del);

                command.CommandText = "DELETE FROM ГРУППЫ WHERE НОМЕР_ГРУППЫ = @D";
                command.Parameters.Add("@D", SqlDbType.Int).Value = delInt;

                command.ExecuteNonQuery();

                MessageBox.Show("Группа успешно удалёна!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка: запись не была удалена", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
