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
    public partial class DELETE_RASPISANIE : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable(); string del;
        int delInt;
        public DELETE_RASPISANIE()
        {
            InitializeComponent();
            command.Connection = MyConDB.Connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                del = textBox.Text.ToString();
                delInt = int.Parse(del);

                command.CommandText = "DELETE FROM РАСПИСАНИЕ_ОБЩЕЕ WHERE НОМЕР_РАСПИСАНИЯ = @D";
                command.Parameters.Add("@D", SqlDbType.Int).Value = delInt;

                command.ExecuteNonQuery();
                ff();

                MessageBox.Show("Расписание успешно удалёно!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка: запись не была удалена", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DELETE_RASPISANIE_Load(object sender, EventArgs e)
        {
            ff();
        }
        private void ff()
        {
            table.Clear();
            command.CommandText = "SELECT * FROM РАСПИСАНИЕ_ОБЩЕЕ";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectAll();
        }
        private void DELETE_RASPISANIE_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyConDB.CloseConnection();

        }
    }
}
