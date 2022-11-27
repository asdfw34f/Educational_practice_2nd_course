using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormMain : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        public FormMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            if (this.WindowState == FormWindowState.Normal)
            {
                плавающаяОбластьToolStripMenuItem.Enabled = false;
            }
            else
            {
                плавающаяОбластьToolStripMenuItem.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MyConDB.OpenConnection();
            }
            catch (Exception)
            {
                var result = MessageBox.Show("Ошибка: Подключение отсутствует!\nПопробовать снова?", "Подключение к серверу", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                switch (result)
                {
                    case DialogResult.Yes:
                        Application.Restart();
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                }
                Application.Exit();
            }
            Monday();
            tuesday();
            wednesday();
            thursday();
            friday();
            saturday();
            Group();
            ZalsPON();
            ZalsVtor();
            ZalsSred();
            ZalsChet();
            ZalsPyat();
            ZalsSubb();
            if (MyElements.Lock_log == false)
            {
                выйтиToolStripMenuItem.Enabled = false;
                оСебеToolStripMenuItem.Enabled = false;
                войтиToolStripMenuItem.Enabled = true;
                редактироватьToolStripMenuItem.Visible = false;
            }
            else
            {
                войтиToolStripMenuItem.Enabled = false;
                выйтиToolStripMenuItem.Enabled = true;
                оСебеToolStripMenuItem.Enabled = true;
                редактироватьToolStripMenuItem.Visible = true;

            }
        }
        //расписание общее на понедельник
        private void Monday()
        {
            MyElements.PonTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_РАСПИСАНИЕ_ОБЩЕЕ_ПОНЕДЕЛЬНИК];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.PonTable);
            dataGridView1ПОНЕДЕЛЬНИК.DataSource = MyElements.PonTable;
            dataGridView1ПОНЕДЕЛЬНИК.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1ПОНЕДЕЛЬНИК.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1ПОНЕДЕЛЬНИК.ForeColor = Color.FromArgb(43, 86, 130);
            dataGridView1ПОНЕДЕЛЬНИК.ClearSelection();
        }
        //расписание общее на вторник
        private void tuesday()
        {
            MyElements.VtorTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_РАСПИСАНИЕ_ОБЩЕЕ_ВТОРНИК];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.VtorTable);
            dataGridViewВТОРНИК.DataSource = MyElements.VtorTable;
            dataGridViewВТОРНИК.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewВТОРНИК.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewВТОРНИК.ForeColor = Color.FromArgb(43, 86, 130);
            dataGridViewВТОРНИК.ClearSelection();
        }
        //расписание общее на среду
        private void wednesday()
        {
            MyElements.SredTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_РАСПИСАНИЕ_ОБЩЕЕ_СРЕДА];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.SredTable);
            dataGridViewСРЕДА.DataSource = MyElements.SredTable;
            dataGridViewСРЕДА.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewСРЕДА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewСРЕДА.ForeColor = Color.FromArgb(43, 86, 130);
            dataGridViewСРЕДА.ClearSelection();
        }
        //расписание общее на четверг
        private void thursday()
        {
            MyElements.ChetTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_РАСПИСАНИЕ_ОБЩЕЕ_ЧЕТВЕРГ];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.ChetTable);
            dataGridViewЧЕТВЕРГ.DataSource = MyElements.ChetTable;
            dataGridViewЧЕТВЕРГ.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewЧЕТВЕРГ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewЧЕТВЕРГ.ForeColor = Color.FromArgb(43, 86, 130);
            dataGridViewЧЕТВЕРГ.ClearSelection();
        }
        //расписание общее на пятницу
        private void friday()
        {
            MyElements.PyatTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_РАСПИСАНИЕ_ОБЩЕЕ_ПЯТНИЦА];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.PyatTable);
            dataGridViewПЯТНИЦА.DataSource = MyElements.PyatTable;
            dataGridViewПЯТНИЦА.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewПЯТНИЦА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewПЯТНИЦА.ForeColor = Color.FromArgb(43, 86, 130);
            dataGridViewПЯТНИЦА.ClearSelection();
        }
        //расписание общее на субботу
        private void saturday()
        {
            MyElements.SubbTable.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_РАСПИСАНИЕ_ОБЩЕЕ_СУББОТА];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.SubbTable);
            dataGridViewСУББОТА.DataSource = MyElements.SubbTable;
            dataGridViewСУББОТА.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewСУББОТА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewСУББОТА.ForeColor = Color.FromArgb(43, 86, 130);
            dataGridViewСУББОТА.ClearSelection();
        }
        //заполнение тыблицы группы
        private void Group()
        {
            MyElements.Group();
            dataGridView2ГРУППЫ.DataSource = MyElements.GroupTable;
            dataGridView2ГРУППЫ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewГРУППЫВТОРНИК.DataSource = MyElements.GroupTable;
            dataGridViewГРУППЫВТОРНИК.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewГРУППЫСРЕДА.DataSource = MyElements.GroupTable;
            dataGridViewГРУППЫСРЕДА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewГРУППЫЧЕТВЕРГ.DataSource = MyElements.GroupTable;
            dataGridViewГРУППЫЧЕТВЕРГ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewГРУППЫПЯТНИЦА.DataSource = MyElements.GroupTable;
            dataGridViewГРУППЫПЯТНИЦА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewГРУППЫСУББОТА.DataSource = MyElements.GroupTable;
            dataGridViewГРУППЫСУББОТА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2ГРУППЫ.ClearSelection();
            dataGridViewГРУППЫВТОРНИК.ClearSelection();
            dataGridViewГРУППЫСРЕДА.ClearSelection();
            dataGridViewГРУППЫЧЕТВЕРГ.ClearSelection();
            dataGridViewГРУППЫПЯТНИЦА.ClearSelection();
            dataGridViewГРУППЫСУББОТА.ClearSelection();
        }
        //работа залов на понедельник
        private void ZalsPON()
        {
            MyElements.ZalsTablePON.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_ЗАЛЫ_ПОНЕДЕЛЬНИК];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.ZalsTablePON);
            dataGridView3ЗАЛЫ_ПОНЕДЕЛЬНИК.DataSource = MyElements.ZalsTablePON;
            dataGridView3ЗАЛЫ_ПОНЕДЕЛЬНИК.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3ЗАЛЫ_ПОНЕДЕЛЬНИК.ClearSelection();
        }
        //работа залов на вторник
        private void ZalsVtor()
        {
            MyElements.ZalsTableVTOR.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_ЗАЛЫ_ВТОРНИК];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.ZalsTableVTOR);
            dataGridViewЗАЛЫВТОРНИК.DataSource = MyElements.ZalsTableVTOR;
            dataGridViewЗАЛЫВТОРНИК.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewЗАЛЫВТОРНИК.ClearSelection();
        }
        //работа залов на среду
        private void ZalsSred()
        {
            MyElements.ZalsTableSREDA.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_ЗАЛЫ_СРЕДА];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.ZalsTableSREDA);
            dataGridViewЗАЛЫСРЕДА.DataSource = MyElements.ZalsTableSREDA;
            dataGridViewЗАЛЫСРЕДА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewЗАЛЫСРЕДА.ClearSelection();
        }
        //работа залов на четверг
        private void ZalsChet()
        {
            MyElements.ZalsTableCHETV.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_ЗАЛЫ_ЧЕТВЕРГ];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.ZalsTableCHETV);
            dataGridViewЗАЛЫЧЕТВЕРГ.DataSource = MyElements.ZalsTableCHETV;
            dataGridViewЗАЛЫЧЕТВЕРГ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewЗАЛЫЧЕТВЕРГ.ClearSelection();
        }
        //работа залов на пятницу
        private void ZalsPyat()
        {
            MyElements.ZalsTablePYAT.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_ЗАЛЫ_ПЯТНИЦА];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.ZalsTablePYAT);
            dataGridView10ЗАЛЫПЯТНИЦА.DataSource = MyElements.ZalsTablePYAT;
            dataGridView10ЗАЛЫПЯТНИЦА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView10ЗАЛЫПЯТНИЦА.ClearSelection();
        }
        //работа залов на субботу
        private void ZalsSubb()
        {
            MyElements.ZalsTableSUBB.Clear();
            command.CommandText = null;
            adapter.SelectCommand = null;
            command.Connection = MyConDB.GetConnection();
            command.CommandText = "SELECT * from [View_ЗАЛЫ_СУББОТА];";
            adapter.SelectCommand = command;
            adapter.Fill(MyElements.ZalsTableSUBB);
            dataGridViewЗАЛЫСУББОТА.DataSource = MyElements.ZalsTableSUBB;
            dataGridViewЗАЛЫСУББОТА.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewЗАЛЫСУББОТА.ClearSelection();
        }
        //форма авторизации
        private void войтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form LogForm = new FormLogin();
            LogForm.ShowDialog();
            LogForm.FormClosing += LogForm_FormClosing;
        }
        private void tabPageПонедельник_Click(object sender, EventArgs e)
        {
            dataGridView1ПОНЕДЕЛЬНИК.ClearSelection();
            dataGridView2ГРУППЫ.ClearSelection();
            dataGridView3ЗАЛЫ_ПОНЕДЕЛЬНИК.ClearSelection();
        }
        private void tabPageВторник_Click(object sender, EventArgs e)
        {
            dataGridViewГРУППЫВТОРНИК.ClearSelection();
            dataGridViewВТОРНИК.ClearSelection();
            dataGridViewЗАЛЫВТОРНИК.ClearSelection();
        }
        private void tabPageСреда_Click(object sender, EventArgs e)
        {
            dataGridViewГРУППЫСРЕДА.ClearSelection();
            dataGridViewЗАЛЫСРЕДА.ClearSelection();
            dataGridViewСРЕДА.ClearSelection();
        }
        private void tabPageЧетверг_Click(object sender, EventArgs e)
        {
            dataGridViewГРУППЫЧЕТВЕРГ.ClearSelection();
            dataGridViewЗАЛЫЧЕТВЕРГ.ClearSelection();
            dataGridViewЧЕТВЕРГ.ClearSelection();
        }
        private void tabPageПятница_Click(object sender, EventArgs e)
        {
            dataGridView10ЗАЛЫПЯТНИЦА.ClearSelection();
            dataGridViewГРУППЫПЯТНИЦА.ClearSelection();
            dataGridViewПЯТНИЦА.ClearSelection();
        }
        private void tabPagСуббота_Click(object sender, EventArgs e)
        {
            dataGridViewГРУППЫСУББОТА.ClearSelection();
            dataGridViewЗАЛЫСУББОТА.ClearSelection();
            dataGridViewСУББОТА.ClearSelection();
        }
        private void tabControl1ГРУППЫ_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewГРУППЫСУББОТА.ClearSelection();
            dataGridViewЗАЛЫСУББОТА.ClearSelection();
            dataGridViewСУББОТА.ClearSelection();
            dataGridView10ЗАЛЫПЯТНИЦА.ClearSelection();
            dataGridViewГРУППЫПЯТНИЦА.ClearSelection();
            dataGridViewПЯТНИЦА.ClearSelection();
            dataGridViewГРУППЫЧЕТВЕРГ.ClearSelection();
            dataGridViewЗАЛЫЧЕТВЕРГ.ClearSelection();
            dataGridViewЧЕТВЕРГ.ClearSelection();
            dataGridViewГРУППЫСРЕДА.ClearSelection();
            dataGridViewЗАЛЫСРЕДА.ClearSelection();
            dataGridViewСРЕДА.ClearSelection();
            dataGridViewГРУППЫВТОРНИК.ClearSelection();
            dataGridViewВТОРНИК.ClearSelection();
            dataGridViewЗАЛЫВТОРНИК.ClearSelection();
            dataGridView1ПОНЕДЕЛЬНИК.ClearSelection();
            dataGridView2ГРУППЫ.ClearSelection();
            dataGridView3ЗАЛЫ_ПОНЕДЕЛЬНИК.ClearSelection();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MyConDB.Connection.Close();
            } catch { }
            редактироватьToolStripMenuItem.Visible = true;

        }
        private void свернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void плавающаяОбластьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void полныйЭкранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                плавающаяОбластьToolStripMenuItem.Enabled = false;
            }
            else
            {
                плавающаяОбластьToolStripMenuItem.Enabled = true;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                полныйЭкранToolStripMenuItem.Enabled = false;
            }
            else
            {
                полныйЭкранToolStripMenuItem.Enabled = true;
            }
        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (MyElements.Lock_log == true && MyElements.admin == true)
            {
                редактироватьToolStripMenuItem.Visible = true;
                оСебеToolStripMenuItem.Visible = false;
            }
            if (MyElements.Lock_log == false)
            {
                выйтиToolStripMenuItem.Enabled = false;
                оСебеToolStripMenuItem.Enabled = false;
                войтиToolStripMenuItem.Enabled = true;
            }
            else
            {
                войтиToolStripMenuItem.Enabled = false;
                выйтиToolStripMenuItem.Enabled = true;
                оСебеToolStripMenuItem.Enabled = true;
            }
        }
        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyElements.Lock_log == false)
            {
                выйтиToolStripMenuItem.Enabled = false;
                оСебеToolStripMenuItem.Enabled = false;
                войтиToolStripMenuItem.Enabled = true;
                редактироватьToolStripMenuItem.Visible = false;
                входToolStripMenuItem.Text = "Аккаунт";
                if (MyElements.trener == true || MyElements.spotman == true)
                {
                    оСебеToolStripMenuItem.Enabled = true;
                    оСебеToolStripMenuItem.Visible = true;
                }
            }
            else
            {
                войтиToolStripMenuItem.Enabled = false;
                выйтиToolStripMenuItem.Enabled = true;
                оСебеToolStripMenuItem.Enabled = true;
                редактироватьToolStripMenuItem.Visible = true;
                if (MyElements.trener == true || MyElements.spotman == true)
                {
                    оСебеToolStripMenuItem.Enabled = true;
                    оСебеToolStripMenuItem.Visible = true;
                    входToolStripMenuItem.Text = MyElements.NameUser;
                }
            }
        }
        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Выход из системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
            MyConDB.Connection.Close();
        }
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyElements.spotman = false;
            MyElements.trener = false;
            MyElements.admin = false;
            MyElements.Lock_log = false;
            войтиToolStripMenuItem.Enabled = true;
            выйтиToolStripMenuItem.Enabled = false;
            редактироватьToolStripMenuItem.Visible = false;
        }
        private void залыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView3ЗАЛЫ_ПОНЕДЕЛЬНИК.Visible = true;
            залыToolStripMenuItem.Enabled = false;
        }
        private void спорсменовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UpdateForms.UPDATE_SPORTSMAN();
            form.ShowDialog();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form form = new ADDSPORTMEN();
            form.ShowDialog();
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form form = new AddForms.ADDTRENER();
            form.ShowDialog();
            form.Load += Form_Load;
            form.FormClosed += Form1_FormClosed;
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form form = new AddForms.ADDZAL();
            form.ShowDialog();
        }

        private void оСебеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Myself();
            form.ShowDialog();
        }

        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form form = new AddForms.ADDGROUP();
            form.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form form = new AddForms.ADDRASPISANIE();
            form.ShowDialog();
        }
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Monday();
            tuesday();
            wednesday();
            thursday();
            friday();
            saturday();
            Group();
            ZalsPON();
            ZalsVtor();
            ZalsSred();
            ZalsChet();
            ZalsPyat();
            ZalsSubb();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Form form = new AddForms.AddPara();
            form.ShowDialog();
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form form = new DeleteForms.DELETE_SPORTSMAN();
            form.ShowDialog();
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Form form = new DeleteForms.DELETE_GROUP();
            form.ShowDialog();
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Form form = new DeleteForms.DELETE_TRENER();
            form.ShowDialog();
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Form form = new DeleteForms.DELETE_ZAL();
            form.ShowDialog();
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Form form = new DeleteForms.DELETE_RASPISANIE();
            form.ShowDialog();
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Form form = new DeleteForms.Delete_Para();
            form.ShowDialog();
            form.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
