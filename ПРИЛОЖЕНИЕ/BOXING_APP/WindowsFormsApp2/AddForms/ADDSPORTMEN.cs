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

namespace WindowsFormsApp2
{
    public partial class ADDSPORTMEN : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();
        DataTable table1 = new DataTable();
        public ADDSPORTMEN()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void selecttrener()
        {
            command.Parameters.Clear();
            table.Clear();
            command.CommandText = "Select * from [ТРЕНЕРЫ]";
            command.Parameters.Add("@LOG", SqlDbType.VarChar).Value = textBoxLOGIN.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table1);
            dataGridViewTRENERA.DataSource = table1;
            dataGridViewTRENERA.SelectAll();
        }
        private void ADDSPORTMEN_Load(object sender, EventArgs e)
        {
            MyElements.GroupIF();
            dataGridView1.DataSource = MyElements.IFGROUP;
            dataGridViewTRENERA.DataSource = MyElements.AllTreners;
            command.Connection = MyConDB.Connection;
            selecttrener();
        }
        private void ADDSPORTMEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyConDB.CloseConnection();
        }
        private void AddSportMan()
        {
            command.Parameters.Clear();
            table.Clear();
            command.CommandText = "Select * from СПОРСМЕНЫ where [ЛОГИН] = @LOG";
            command.Parameters.Add("@LOG", SqlDbType.VarChar).Value = textBoxLOGIN.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count.ToString() == "0")
            {
                try
                {
                    /*НОМЕР_СПОРТСМЕНА                                                          
                    ФАМИЛИЯ
                    ИМЯ
                    ОТЧЕСТВО
                    ДАТА_РОЖДЕНИЯ
                    ПОЛ
                    КАТЕГОРИЯ_ВЕСА
                    НОМЕР_ГРУППЫ
                    НОМЕР_ТРЕНЕРА, МИН_КОЛ_ЧАС, ПРИОРИТЕТ, НОМЕР_ПАРЫ
                    */
                    int para = int.Parse(textBoxNUNPARA.Text.ToString());
                    int tren = int.Parse(textBoxTRENER.Text.ToString());
                    int Hours = int.Parse(textBoxMIN_HOURS_WEEK.Text.ToString());
                    int gr = int.Parse(textBoxGROUP.Text.ToString());
                    DateTime date = DateTime.Parse(dateTimePickerBIRTHDAY.Text).Date;
                    char pol = Char.Parse(textBoxSEX.Text.ToString());
                    command.CommandText = "INSERT INTO [dbo].[СПОРТСМЕНЫ]([ИМЯ], [ФАМИЛИЯ], [ОТЧЕСТВО], [ПОЛ], [ДАТА_РОЖДЕНИЯ], [НОМЕР_ТЕЛЕФОНА], [ЛОГИН], [ПАРОЛЬ], [КАТЕГОРИЯ_ВЕСА], [НОМЕР_ГРУППЫ], НОМЕР_ТРЕНЕРА, МИН_КОЛ_ЧАС, ПРИОРИТЕТ, НОМЕР_ПАРЫ) VALUES(@NAME, @FAM, @OTCHE, @SEX, @DATE, @PHONE, @LOG, @PASS, @VES, @NUMGROUP, @TRENER, @HOURS, @PRIORETET, @NUMPARU)";
                    //@NAME, @FAM, @OTCHE, @SEX, @DATE, @PHONE, @LOG, @PASS, @VES, @NUMGROUP, @TRENER, @HOURS, @PRIORETET, @NUMPARU
                    command.Parameters.Add("@NAME", SqlDbType.VarChar).Value = textBoxNAME.Text;
                    command.Parameters.Add("@FAM", SqlDbType.VarChar).Value = textBoxFAMILY.Text;
                    command.Parameters.Add("@OTCHE", SqlDbType.VarChar).Value = textBoxOTCHE.Text;
                    command.Parameters.Add("@SEX", SqlDbType.Char).Value = pol;
                    command.Parameters.Add("@DATE", SqlDbType.Date).Value = date;
                    command.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = textBoxNUMBERPHONE.Text;
                    command.Parameters.Add("@PASS", SqlDbType.VarChar).Value = textBoxPASSWORD.Text;
                    command.Parameters.Add("@VES", SqlDbType.VarChar).Value = textBoxVES.Text;
                    command.Parameters.Add("@NUMGROUP", SqlDbType.Int).Value = gr;
                    command.Parameters.Add("@TRENER", SqlDbType.Int).Value = tren;
                    command.Parameters.Add("@HOURS", SqlDbType.Int).Value = Hours;
                    command.Parameters.Add("@PRIORETET", SqlDbType.VarChar).Value = textBoxPRIORETET.Text;
                    command.Parameters.Add("@NUMPARU", SqlDbType.Int).Value = para;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Спортсмен успешно добавлен!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка: запись не была добавлена", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка: Спортсмен с таким логином уже существует!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddRa()
        {
            try
            {
                DataGridView dataGrid = new DataGridView();
                table.Clear();
                command.CommandText = "SELECT * FROM [СПОРТСМЕНЫ] WHERE [ЛОГИН] = @LOG AND [ПАРОЛЬ] = @PASS";
                adapter.SelectCommand = command;
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                string ff = table.Rows[0][9].ToString();
                int.Parse(ff);

                //понедельник
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_СПОРТСМЕНОВ]([НОМЕР_СПОРТСМЕНА], [ДЕНЬ_НЕДЕЛИ], [НАЧАЛО_ЗАНЯТИЙ], [КОНЕЦ_ЗАНЯТИЯ]) VALUES(@TREN, @DAY, @START, @FINISH)";
                //@TREN, @DAY, @HOURS, @START, @FINISH)"
                command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
                command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ПОНЕДЕЛЬНИК";
                command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Pon.Text;
                command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Pon.Text;

                command.ExecuteNonQuery();

                //вторник
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_СПОРТСМЕНОВ]([НОМЕР_СПОРТСМЕНА], [ДЕНЬ_НЕДЕЛИ], [НАЧАЛО_ЗАНЯТИЙ], [КОНЕЦ_ЗАНЯТИЯ]) VALUES(@TREN, @DAY, @START, @FINISH)";
                //@TREN, @DAY, @HOURS, @START, @FINISH)"
                command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
                command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ВТОРНИК";
                command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Vtor.Text;
                command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Vtor.Text;

                command.ExecuteNonQuery();

                //среда
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_СПОРТСМЕНОВ]([НОМЕР_СПОРТСМЕНА], [ДЕНЬ_НЕДЕЛИ], [НАЧАЛО_ЗАНЯТИЙ], [КОНЕЦ_ЗАНЯТИЯ]) VALUES(@TREN, @DAY, @START, @FINISH)";
                //@TREN, @DAY, @HOURS, @START, @FINISH)"
                command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
                command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "СРЕДА";
                command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Sred.Text;
                command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Sreda.Text;

                command.ExecuteNonQuery();

                //четверг
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_СПОРТСМЕНОВ]([НОМЕР_СПОРТСМЕНА], [ДЕНЬ_НЕДЕЛИ], [НАЧАЛО_ЗАНЯТИЙ], [КОНЕЦ_ЗАНЯТИЯ]) VALUES(@TREN, @DAY, @START, @FINISH)";
                //@TREN, @DAY, @HOURS, @START, @FINISH)"
                command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
                command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ЧЕТВЕРГ";
                command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Chetv.Text;
                command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Chetv.Text;

                command.ExecuteNonQuery();

                //пятница
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_СПОРТСМЕНОВ]([НОМЕР_СПОРТСМЕНА], [ДЕНЬ_НЕДЕЛИ], [НАЧАЛО_ЗАНЯТИЙ], [КОНЕЦ_ЗАНЯТИЯ]) VALUES(@TREN, @DAY, @START, @FINISH)";
                //@TREN, @DAY, @HOURS, @START, @FINISH)"
                command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
                command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "ПЯТНИЦА";
                command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_Pyatn.Text;
                command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Pyatn.Text;

                command.ExecuteNonQuery();

                //суббота
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [dbo].[РАСПИСАНИЕ_СПОРТСМЕНОВ]([НОМЕР_СПОРТСМЕНА], [ДЕНЬ_НЕДЕЛИ], [НАЧАЛО_ЗАНЯТИЙ], [КОНЕЦ_ЗАНЯТИЯ]) VALUES(@TREN, @DAY, @START, @FINISH)";
                //@TREN, @DAY, @HOURS, @START, @FINISH)"
                command.Parameters.Add("@TREN", SqlDbType.Int).Value = ff;
                command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = "СУББОТА";
                command.Parameters.Add("@START", SqlDbType.Time).Value = dateTimePicker_Start_PonSubb.Text;
                command.Parameters.Add("@FINISH", SqlDbType.Time).Value = dateTimePicker_End_Subb.Text;
            }
            catch
            {
                MessageBox.Show("Ошибка: расписание не было добавлено", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            command.ExecuteNonQuery();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddSportMan();
            AddRa();
        }
    }
}
