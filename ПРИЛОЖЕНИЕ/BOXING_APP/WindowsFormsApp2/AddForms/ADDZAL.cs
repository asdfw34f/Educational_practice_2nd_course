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
    public partial class ADDZAL : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable tableZAL = new DataTable();
        DataTable TABLEPA = new DataTable();

        public ADDZAL()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            command.Connection = MyConDB.Connection;
        }
        private void SelectsRa()
        {
            TABLEPA.Clear();
            command.CommandText = "SELECT * FROM РАСПИСАНИЕ_ЗАЛОВ";
            adapter.SelectCommand = command;
            adapter.Fill(TABLEPA);
            tableZAL.Select();
        }

        private void Add()
        {
            command.CommandText = "INSERT INTO ЗАЛЫ(НАЗВАНИЕ_ЗАЛА) VALUES(@NAME)";
            command.Parameters.Add("@NAME", SqlDbType.VarChar).Value = textBox1.Text;
            MyConDB.OpenConnection();
            command.ExecuteNonQuery();

            tableZAL.Clear();
            command.CommandText = "SELECT НОМЕР_ЗАЛА FROM ЗАЛЫ WHERE [НАЗВАНИЕ_ЗАЛА] = @NAME";
            adapter.SelectCommand = command;
            adapter.Fill(tableZAL);
            string gg = tableZAL.Rows[0][0].ToString();

            SelectsRa();

            //понедельник
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO РАСПИСАНИЕ_ЗАЛОВ(ДЕНЬ_НЕДЕЛИ, ВРЕМЯ_ОТКРЫТИЯ, ВРЕМЯ_ЗАКРЫТИЯ, НОМЕР_ЗАЛА) VALUES(@DAY, @START, @FINISH, @NUMZAL)";
            //@DAY, @START, @FINISH, @NUMZAL, @NUMRASPISANIA
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = label14.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = textBoxSTARTPONEDELNIK.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = textBoxFINISHPONEDELNIK.Text;
            command.Parameters.Add("@NUMZAL", SqlDbType.VarChar).Value = gg;
            command.ExecuteNonQuery();

            //вторник
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO РАСПИСАНИЕ_ЗАЛОВ(ДЕНЬ_НЕДЕЛИ, ВРЕМЯ_ОТКРЫТИЯ, ВРЕМЯ_ЗАКРЫТИЯ, НОМЕР_ЗАЛА) VALUES(@DAY, @START, @FINISH, @NUMZAL)";
            //@DAY, @START, @FINISH, @NUMZAL, @NUMRASPISANIA
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = label13.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = textBoxSTARTVTORNIK.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = textBoxFINISHVTORNIK.Text;
            command.Parameters.Add("@NUMZAL", SqlDbType.Int).Value = gg;
            command.ExecuteNonQuery();

            //среда
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO РАСПИСАНИЕ_ЗАЛОВ(ДЕНЬ_НЕДЕЛИ, ВРЕМЯ_ОТКРЫТИЯ, ВРЕМЯ_ЗАКРЫТИЯ, НОМЕР_ЗАЛА) VALUES(@DAY, @START, @FINISH, @NUMZAL)";
            //@DAY, @START, @FINISH, @NUMZAL, @NUMRASPISANIA
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = label15.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = textBoxSTARTSREDA.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = textBoxFINISHSREDA.Text;
            command.Parameters.Add("@NUMZAL", SqlDbType.Int).Value = gg;
            command.ExecuteNonQuery();

            //четверг
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO РАСПИСАНИЕ_ЗАЛОВ(ДЕНЬ_НЕДЕЛИ, ВРЕМЯ_ОТКРЫТИЯ, ВРЕМЯ_ЗАКРЫТИЯ, НОМЕР_ЗАЛА) VALUES(@DAY, @START, @FINISH, @NUMZAL)";
            //@DAY, @START, @FINISH, @NUMZAL, @NUMRASPISANIA
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = label16.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = textBoxSTARTCHETV.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = textBoxFINISHCHETVERG.Text;
            command.Parameters.Add("@NUMZAL", SqlDbType.Int).Value = gg;
            command.ExecuteNonQuery();

            //пятница
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO РАСПИСАНИЕ_ЗАЛОВ(ДЕНЬ_НЕДЕЛИ, ВРЕМЯ_ОТКРЫТИЯ, ВРЕМЯ_ЗАКРЫТИЯ, НОМЕР_ЗАЛА) VALUES(@DAY, @START, @FINISH, @NUMZAL)";
            //@DAY, @START, @FINISH, @NUMZAL, @NUMRASPISANIA
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = label17.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = textBoxSTARTPYATNICA.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = textBoxFINISHCHETVERG.Text;
            command.Parameters.Add("@NUMZAL", SqlDbType.Int).Value = gg;
            command.ExecuteNonQuery();

            //суббота
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO РАСПИСАНИЕ_ЗАЛОВ(ДЕНЬ_НЕДЕЛИ, ВРЕМЯ_ОТКРЫТИЯ, ВРЕМЯ_ЗАКРЫТИЯ, НОМЕР_ЗАЛА) VALUES(@DAY, @START, @FINISH, @NUMZAL)";
            //@DAY, @START, @FINISH, @NUMZAL, @NUMRASPISANIA
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = label18.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = textBoxSTARTSUBBOTA.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = textBoxFINISHSUBBOTA.Text;
            command.Parameters.Add("@NUMZAL", SqlDbType.Int).Value = gg;
            command.ExecuteNonQuery();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                MessageBox.Show("Зал и его расписание на неделю успешно добавлены!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            { 
                MessageBox.Show("Ошибка: Запись не добавлена!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ADDZAL_Load(object sender, EventArgs e)
        {
            SelectsRa();
        }
    }
}
