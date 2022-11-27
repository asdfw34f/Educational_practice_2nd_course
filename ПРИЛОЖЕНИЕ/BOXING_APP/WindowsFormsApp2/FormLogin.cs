using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyModel;
using System.Timers;

namespace WindowsFormsApp2
{
    public partial class FormLogin : Form
    {
        Form f1 = new FormMain();
        Form form = new Form();
        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        DataTable tableadmin = new DataTable();
        DataTable tabletrener = new DataTable();
        DataTable tablesport = new DataTable();

        public FormLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Timee()
        {
            //таймер на логотип и закрытие
            tmr.Tick += delegate
            {
                tmr.Stop();
                tmr.Enabled = false;
                tmr.Dispose();
                this.Close();
                form.Close();
                form.Dispose();
            };
            tmr.Enabled = true;
            tmr.Interval = 4000;
            tmr.Start();
            forLog();
        }
        //Форма приветсвия 
        public void forLog()
        {
            form.Opacity = 0.3;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((sender, e) =>
            {
                if ((form.Opacity += 0.03d) == 1) timer.Stop();
            });
            timer.Interval = 100;
            timer.Start();
            form.Text = null;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(330, 200);
            form.BackColor = Color.FromArgb(22, 44, 77);
            Label label = new Label();
            Panel panel = new Panel();
            form.FormBorderStyle = FormBorderStyle.None;
            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            form.MinimizeBox = false;
            form.Cursor = Cursors.WaitCursor;
            form.MaximizeBox = false;
            Container components = new Container();
            components.Add(panel);
            label.Location = new Point(12, 87);
            label.ForeColor = Color.WhiteSmoke;
            label.BackColor = Color.FromArgb(22, 44, 77);
            label.AutoSize = false;
            label.Size = new Size(306, 32);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.None;
            panel.BackColor = Color.FromArgb(52, 82, 137);
            panel.Size = new Size(306, 53);
            panel.Location = new Point(12, 77);
            form.Controls.Add(label);
            form.Controls.Add(panel);
            form.Visible = true;
            label.Text = "Здравствуйте, " + MyElements.NameUser + "!";
            form.Visible = true;
            form.TopMost = true;
            form.Show();
            label.Focus();
        }
        private string box(DataTable table)
        {
            //взятие занчения первой ячейки таблицы (имени)
            object cellValue = table.Rows[0][0];
            return cellValue.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //проверка на админа
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            command.CommandText = @"select  * FROM [ADMIN_TABLE] WHERE [ЛОГИН_АДМИНА] = @log AND [ПАРОЛЬ_АДМИНА] = @pass; ";
            command.Parameters.Add("@log", SqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox1.Text;
            command.Connection = MyConDB.Connection;
            adapter.SelectCommand = command;
            adapter.Fill(tableadmin);
            if (tableadmin.Rows.Count > 0)
            {
                MyElements.Lock_log = true;
                MyElements.admin = true;
                this.Close();
            }
            else
            {
                //проверка на спортсмена
                command.CommandText = null;
                command.CommandText = @"SELECT ИМЯ FROM [СПОРТСМЕНЫ] where [ЛОГИН] = @logi AND [ПАРОЛЬ] = @passw";
                command.Parameters.Add("@logi", SqlDbType.VarChar).Value = textBox2.Text;
                command.Parameters.Add("@passw", SqlDbType.VarChar).Value = textBox1.Text;
                adapter.SelectCommand = command;
                adapter.Fill(tablesport);
                if (tablesport.Rows.Count > 0)
                {
                    MyElements.spotman = true;
                    MyElements.Lock_log = true;
                    MyElements.LogName = textBox2.Text;
                    MyElements.NameUser = box(tablesport);
                    Timee();
                    Hide();
                }
                else
                {
                    //проверка на тренера
                    command.CommandText = null;
                    command.CommandText = @"SELECT ИМЯ FROM [ТРЕНЕРЫ] where [ЛОГИН] = @login AND [ПАРОЛЬ] = @passwd";
                    command.Parameters.Add("@login", SqlDbType.VarChar).Value = textBox2.Text;
                    command.Parameters.Add("@passwd", SqlDbType.VarChar).Value = textBox1.Text;
                    adapter.SelectCommand = command;
                    adapter.Fill(tabletrener);
                    if (tabletrener.Rows.Count > 0)
                    {

                        MyElements.LogName = textBox2.Text;
                        MyElements.NameUser = box(tabletrener);
                        MyElements.Lock_log = true;
                        MyElements.trener = true;
                        Timee();
                        Hide();
                    }
                    else
                    {
                        //сообщение об ошибке авторизации 
                        MessageBox.Show("Неправильный логин или пароль!\nПопробуйте ещё раз.", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox2.Focus();
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                MyConDB.OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: Подключение отсутствует!" + ex);
            }
            textBox2.Select();
            textBox2.Focus();
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                textBox2.Clear();
                textBox1.Clear();
                textBox2.Focus();
            }
            if (e.KeyCode == Keys.Up) 
            {
                textBox2.Focus();
            }
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                textBox1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                textBox1.Focus();
            }
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            tableadmin.Clear();
            tablesport.Clear();
            tabletrener.Clear();
        }
    }
}
