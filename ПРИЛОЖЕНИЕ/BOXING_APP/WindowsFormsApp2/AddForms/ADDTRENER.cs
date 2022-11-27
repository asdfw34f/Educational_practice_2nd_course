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
    public partial class ADDTRENER : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();
        public ADDTRENER()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            command.Connection = MyConDB.Connection;
        }
        private void AddTrener()
        {
            command.Parameters.Clear();
            table.Clear();
            command.CommandText = "Select * from [ТРЕНЕРЫ] where [ЛОГИН] = @LOG";
            command.Parameters.Add("@LOG", SqlDbType.VarChar).Value = textBoxLOGIN.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count.ToString() == "0")
            {
                try
                {
                    command.CommandText = "INSERT INTO [dbo].[ТРЕНЕРЫ]([ИМЯ], [ФАМИЛИЯ], [ОТЧЕСТВО], [ПОЛ], [ДАТА_РОЖДЕНИЯ], [НОМЕР_ТЕЛЕФОНА], [ЛОГИН], [ПАРОЛЬ]) VALUES(@NAME, @FAM, @OTCHE, @SEX, @DATE, @PHONE, @LOG, @PASS)";
                    //@NAME, @FAM, @OTCHE, @SEX, @DATE, @PHONE, @LOG, @PASS
                    command.Parameters.Add("@NAME", SqlDbType.VarChar).Value = textBoxNAME.Text;
                    command.Parameters.Add("@FAM", SqlDbType.VarChar).Value = textBoxFAMILY.Text;
                    command.Parameters.Add("@OTCHE", SqlDbType.VarChar).Value = textBoxOTCHE.Text;
                    command.Parameters.Add("@SEX", SqlDbType.Char).Value = textBoxSEX.Text;
                    command.Parameters.Add("@DATE", SqlDbType.Date).Value = dateTimePickerBIRTHDAY.Text;
                    command.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = textBoxNUMBERPHONE.Text;
                    command.Parameters.Add("@PASS", SqlDbType.VarChar).Value = textBoxPASSWORd.Text;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Тренер успешно добавлен!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка: запись не была добавлена", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка: Тренер с таким логином уже существует!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddRa()
        {
            command.CommandText = "SELECT * FROM [ТРЕНЕРЫ] WHERE [ЛОГИН] = @LOG AND [ПАРОЛЬ] = @PASS";
            adapter.SelectCommand = command;    
            adapter.Fill(table);
            string ff = table.Rows[0][0].ToString();
            Convert.ToInt32(ff);
            //понедельник
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_ТРЕНИРОВ]([НОМЕР_ТРЕНЕРА], [ДЕНЬ_НЕДЕЛИ], [ЧАСЫ], [НАЧАЛО_РАБОЧЕГО_ДНЯ], [КОНЕЦ_РАБОЧЕГО_ДНЯ]) VALUES(@TREN, @DAY, @HOURS, @START, @FINISH)";
            //@TREN, @DAY, @HOURS, @START, @FINISH)"
            command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ПОНЕДЕЛЬНИК";
            command.Parameters.Add("@HOURS", SqlDbType.Int).Value = textBox1.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Pon.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Pon.Text;

            command.ExecuteNonQuery();

            //вторник
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_ТРЕНИРОВ]([НОМЕР_ТРЕНЕРА], [ДЕНЬ_НЕДЕЛИ], [ЧАСЫ], [НАЧАЛО_РАБОЧЕГО_ДНЯ], [КОНЕЦ_РАБОЧЕГО_ДНЯ]) VALUES(@TREN, @DAY, @HOURS, @START, @FINISH)";
            //@TREN, @DAY, @HOURS, @START, @FINISH)"
            command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ВТОРНИК";
            command.Parameters.Add("@HOURS", SqlDbType.Int).Value = textBox2.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Vtor.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Vtor.Text;

            command.ExecuteNonQuery();

            //среда
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_ТРЕНИРОВ]([НОМЕР_ТРЕНЕРА], [ДЕНЬ_НЕДЕЛИ], [ЧАСЫ], [НАЧАЛО_РАБОЧЕГО_ДНЯ], [КОНЕЦ_РАБОЧЕГО_ДНЯ]) VALUES(@TREN, @DAY, @HOURS, @START, @FINISH)";
            //@TREN, @DAY, @HOURS, @START, @FINISH)"
            command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "СРЕДА";
            command.Parameters.Add("@HOURS", SqlDbType.Int).Value = textBox3.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Sred.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Sreda.Text;

            command.ExecuteNonQuery();

            //четверг
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_ТРЕНИРОВ]([НОМЕР_ТРЕНЕРА], [ДЕНЬ_НЕДЕЛИ], [ЧАСЫ], [НАЧАЛО_РАБОЧЕГО_ДНЯ], [КОНЕЦ_РАБОЧЕГО_ДНЯ]) VALUES(@TREN, @DAY, @HOURS, @START, @FINISH)";
            //@TREN, @DAY, @HOURS, @START, @FINISH)"
            command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ЧЕТВЕРГ";
            command.Parameters.Add("@HOURS", SqlDbType.Int).Value = textBox4.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Chetv.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Chetv.Text;

            command.ExecuteNonQuery();

            //пятница
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_ТРЕНИРОВ]([НОМЕР_ТРЕНЕРА], [ДЕНЬ_НЕДЕЛИ], [ЧАСЫ], [НАЧАЛО_РАБОЧЕГО_ДНЯ], [КОНЕЦ_РАБОЧЕГО_ДНЯ]) VALUES(@TREN, @DAY, @HOURS, @START, @FINISH)";
            //@TREN, @DAY, @HOURS, @START, @FINISH)"
            command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ПЯТНИЦА";
            command.Parameters.Add("@HOURS", SqlDbType.Int).Value = textBox5.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Pyatn.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Pyatn.Text;

            command.ExecuteNonQuery();

            //суббота
            command.Parameters.Clear();
            command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_ТРЕНИРОВ]([НОМЕР_ТРЕНЕРА], [ДЕНЬ_НЕДЕЛИ], [ЧАСЫ], [НАЧАЛО_РАБОЧЕГО_ДНЯ], [КОНЕЦ_РАБОЧЕГО_ДНЯ]) VALUES(@TREN, @DAY, @HOURS, @START, @FINISH)";
            //@TREN, @DAY, @HOURS, @START, @FINISH)"
            command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
            command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "СУББОТА";
            command.Parameters.Add("@HOURS", SqlDbType.Int).Value = textBox6.Text;
            command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_PonSubb.Text;
            command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Subb.Text;

            command.ExecuteNonQuery();
        }
        private void ADDTRENER_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddTrener();
                AddRa();
            }
            catch
            {
                MessageBox.Show("Ошибка: запись не была добавлена", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ADDTRENER_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyConDB.CloseConnection();
        }
    }
}
