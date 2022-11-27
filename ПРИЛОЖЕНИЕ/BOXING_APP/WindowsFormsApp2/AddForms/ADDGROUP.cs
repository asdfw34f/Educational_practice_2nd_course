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
    public partial class ADDGROUP : Form
    {
        DataTable table = new DataTable();
        DataTable tablek = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand select = new SqlCommand();
        SqlCommand command = new SqlCommand();
        public ADDGROUP()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void ADDGROUP_Load(object sender, EventArgs e)
        {
            command.CommandText = @" SELECT НОМЕР_КАНИКУЛ FROM КАНИКУЛЫ";
            command.Connection = MyConDB.Connection;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            comboBoxINDEX.DataSource = table;
            comboBoxINDEX.ValueMember = "НОМЕР_КАНИКУЛ";
            command.CommandText = @"SELECT * FROM КАНИКУЛЫ";
            adapter.SelectCommand = command;
            adapter.Fill(tablek);
            tablek.Columns[0].ColumnName = "Индекс";
            tablek.Columns[1].ColumnName = "Начало";
            tablek.Columns[2].ColumnName = "Конец"; 
            dataGridView1.DataSource = tablek;
        }
        private void add()
        {
            command.CommandText = "INSERT INTO ГРУППЫ( НАЗВАНИЕ_ГРУППЫ, НОМЕР_КАНИКУЛ, КОЛ_ЗАНЯТИЙ_НЕД) VALUES( @NAMEG, @IND, @KOL_ZAN)";
            //@NUM, @NAMEG, @IND, @KOL_ZAN
            command.Parameters.Add("@NAMEG", SqlDbType.VarChar).Value = textBoxNAMEGROUP.Text;
            command.Parameters.Add("@IND", SqlDbType.Int).Value = comboBoxINDEX.Text;
            command.Parameters.Add("@KOL_ZAN", SqlDbType.Int).Value = textBoxCOLZAN.Text;
            command.ExecuteNonQuery();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                add();
                MessageBox.Show("Группа успешно добавлена!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { 
                MessageBox.Show("Ошибка: Запись не добавлена!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
