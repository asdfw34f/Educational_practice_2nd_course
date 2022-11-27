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
    public partial class ADDRASPISANIE : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        string s1;
        string s2;
        string s3;
        string e1;
        string e2;
        string e3;
        int zal1;
        int zal2;
        int zal3;
        string gg1;
        int gg2;
        TimeSpan timeSpan1 = new TimeSpan();
        TimeSpan timeSpan2 = new TimeSpan();
        TimeSpan timeSpan3 = new TimeSpan();
        TimeSpan timeSpan4 = new TimeSpan();
        TimeSpan timeSpan5 = new TimeSpan();
        TimeSpan timeSpan6 = new TimeSpan();
        int tren1;
        int tren2;
        int tren3;


        public ADDRASPISANIE()
        {
            InitializeComponent();
            command.Connection = MyConDB.Connection;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void dataZal()
        {
            command.CommandText = "Select * from [View_ВСЕ_ЗАЛЫ]";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.AllZals);
            dataGridViewZALS.DataSource = MyElements.AllZals;
            dataGridViewZALS.RowHeadersVisible = false;
            dataGridViewZALS.AllowUserToResizeColumns = false; 
            dataGridViewZALS.AllowUserToResizeRows = false;
            dataGridViewZALS.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewZALS.AllowUserToAddRows = false;
            dataGridViewZALS.DefaultCellStyle.BackColor = Color.FromArgb(37, 65, 93);
            dataGridViewZALS.DefaultCellStyle.ForeColor = Color.Silver;
            dataGridViewZALS.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 65, 93);
            dataGridViewZALS.DefaultCellStyle.SelectionForeColor = Color.Silver;
            dataGridViewZALS.BackgroundColor = Color.FromArgb(37, 65, 93);
            dataGridViewZALS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewZALS.ClearSelection();
        }
        private void dataTrenirovki()
        {
            command.CommandText = @"Select * from [View_ТРЕНИРОВКИ]";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.AlltRENIROVKI);
            dataGridViewTRENIROVKA.DataSource = MyElements.AlltRENIROVKI;
            dataGridViewTRENIROVKA.RowHeadersVisible = false;
            dataGridViewTRENIROVKA.AllowUserToResizeColumns = false;
            dataGridViewTRENIROVKA.AllowUserToResizeRows = false;
            dataGridViewTRENIROVKA.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewTRENIROVKA.AllowUserToAddRows = false;
            dataGridViewTRENIROVKA.DefaultCellStyle.BackColor = Color.FromArgb(37, 65, 93);
            dataGridViewTRENIROVKA.DefaultCellStyle.ForeColor = Color.Silver;
            dataGridViewTRENIROVKA.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 65, 93);
            dataGridViewTRENIROVKA.DefaultCellStyle.SelectionForeColor = Color.Silver;
            dataGridViewTRENIROVKA.BackgroundColor = Color.FromArgb(37, 65, 93);
            dataGridViewTRENIROVKA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewTRENIROVKA.ClearSelection();
        }
        private void Add(int num, string day, TimeSpan start1, TimeSpan stop1,  int group, int zal1, int trenirovka)
        {
            if (start1 != null && stop1 != null)
            {
                MyElements.TableRaspisanie.Clear();
                command.CommandText = "Select * from РАСПИСАНИЕ_ОБЩЕЕ";
                adapter.SelectCommand = command;
                adapter.Fill(MyElements.TableRaspisanie);
                int gg = MyElements.TableRaspisanie.Rows.Count + 1;
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [РАСПИСАНИЕ_ОБЩЕЕ]([НОМЕР_РАСПИСАНИЯ], [ДЕНЬ_НЕДЕЛИ], [НОМЕР_ГРУППЫ], [НОМЕР_ЗАНЯТИЯ], [НАЧАЛО_ЗАНЯТИЯ], [КОНЕЦ_ЗАНЯТИЯ],[НОМЕР_ЗАЛА], [КОД_ТРЕНРОВОК]) VALUES(@RASP, @DAY, @NUMGROUP, @NUMZAN, @START, @STOP, @NUMZAL, @trnorovka )";
                //@RASP, @DAY, @NUMGROUP, @NUMZAN, @START, @STOP, @NUMZAL, @trnorovka
                command.Parameters.Add("@RASP", SqlDbType.Int).Value = gg;
                command.Parameters.Add("@DAY", SqlDbType.VarChar).Value = day;
                command.Parameters.Add("@NUMGROUP", SqlDbType.Int).Value = group;
                command.Parameters.Add("@NUMZAN", SqlDbType.Int).Value = num;
                command.Parameters.Add("@START", SqlDbType.Time).Value = start1;
                command.Parameters.Add("@STOP", SqlDbType.Time).Value = stop1;
                command.Parameters.Add("@NUMZAL", SqlDbType.Int).Value = zal1;
                command.Parameters.Add("@trnorovka", SqlDbType.Int).Value = trenirovka;
                MyConDB.OpenConnection();
                command.ExecuteNonQuery();
                textBoxПОН_1_ЗАЛ.Text = null;
                textBoxПОН_1_КОНЕЦ.Text = null;
                textBoxПОН_1_НАЧАЛО.Text = null;
                textBoxПОН_1_ТРЕНИРОВАКА.Text = null;
                textBoxПОН_2_ЗАЛ.Text = null;
                textBoxПОН_2_КОНЕЦ.Text = null;
                textBoxПОН_2_ТРЕНИРОВАКА.Text = null;
                textBoxПОН_3_ЗАЛ.Text = null;
                textBoxПОН_3_КОНЕЦ.Text = null;
                textBoxПОН_3_НАЧАЛО.Text = null;
            }
        }
        private string ComboGroupTouch(ComboBox box)
        {
            MyElements.IFGROUP.Clear();
            string FF;
            command.CommandText = "SELECT НОМЕР_ГРУППЫ FROM ГРУППЫ WHERE НАЗВАНИЕ_ГРУППЫ = @DNHFUVBGFDSHJIBVLSDIJFVB";
            command.Parameters.Clear();
            command.Parameters.Add("@DNHFUVBGFDSHJIBVLSDIJFVB", SqlDbType.VarChar).Value = box.Text;
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.IFGROUP);
            FF = MyElements.IFGROUP.Rows[0][0].ToString();
            return FF;
        }
        private void ComboGroupSelect(ComboBox box)
        {
            command.CommandText = @"SELECT НАЗВАНИЕ_ГРУППЫ FROM ГРУППЫ";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.NAMEGROUP);
            box.DataSource = MyElements.NAMEGROUP;
            box.ValueMember = "НАЗВАНИЕ_ГРУППЫ";
            box.SelectAll();
        }
        private void CombodaysSelect(ComboBox box)
        {
            string[] array1 = new string[] { "ПОНЕДЕЛЬНИК", "ВТОРНИК", "СРЕДА", "ЧЕТВЕРГ", "ПЯТНИЦА", "СУББОТА" };
            box.DataSource = array1;
            box.SelectAll();
        }
        private void ADDRASPISANIE_Load(object sender, EventArgs e)
        {
            CombodaysSelect(comboBox2);
            ComboGroupSelect(comboBoxПОНЕДЕЛЬНИК);
            dataZal();
            dataTrenirovki();
        }
        private void buttonПОН_Click(object sender, EventArgs e)
        {
            s1 = textBoxПОН_1_КОНЕЦ.Text;
            s2 = textBoxПОН_2_КОНЕЦ.Text;
            s3 = textBoxПОН_3_КОНЕЦ.Text;
            e1 = textBoxПОН_1_КОНЕЦ.Text;
            e2 = textBoxПОН_2_КОНЕЦ.Text;
            e3 = textBoxПОН_3_КОНЕЦ.Text;
            zal1 = Int32.Parse(textBoxПОН_1_ЗАЛ.Text);
            zal2 = Int32.Parse(textBoxПОН_2_ЗАЛ.Text);
            zal3 = Int32.Parse(textBoxПОН_3_ЗАЛ.Text);
            gg1 = ComboGroupTouch(comboBoxПОНЕДЕЛЬНИК);
            gg2 = Int32.Parse(gg1);
            timeSpan1 = TimeSpan.Parse(s1);
            timeSpan2 = TimeSpan.Parse(s2);
            timeSpan3 = TimeSpan.Parse(s3);
            timeSpan4 = TimeSpan.Parse(e1);
            timeSpan5 = TimeSpan.Parse(e2);
            timeSpan6 = TimeSpan.Parse(e3);
            tren1 = int.Parse(textBoxПОН_1_ТРЕНИРОВАКА.Text.ToString());
            tren2 = int.Parse(textBoxПОН_1_ТРЕНИРОВАКА.Text.ToString());
            tren3 = int.Parse(textBoxПОН_1_ТРЕНИРОВАКА.Text.ToString());

            //int num, string day, string start1, string stop1,  int group, string zal1, string trenirovka
            try
            {
                Add(1, comboBox2.Text.ToString(), timeSpan1, timeSpan4, gg2, zal1, tren1);
                Add(2, comboBox2.Text.ToString(), timeSpan2, timeSpan5, gg2, zal2, tren2);
                Add(3, comboBox2.Text.ToString(), timeSpan3, timeSpan6, gg2, zal3, tren3);
                MessageBox.Show("Расписание на понедельник успешно добавлена!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка: Запись не добавлена!", "Статус добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ADDRASPISANIE_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyConDB.CloseConnection();
        }
    }
}
