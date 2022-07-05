using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lesson_8
{
    public partial class Form1 : Form
    {
        TrueFalseDatabase database;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия, авторские права и др.).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox abBox = new AboutBox();
            abBox.Show();
        }

        private void menuNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Add("#1 Земля круглая?", true);
                database.Save();
                numNumber.Minimum = 1;
                numNumber.Maximum = 1;
                numNumber.Value = 1;
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Load();
                numNumber.Minimum = 1;
                numNumber.Maximum = database.Count;
                numNumber.Value = 1;
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        /// <summary>
        /// г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных (элемент SaveFileDialog).
        /// Разделяйте логику между классами.В свойствах проектах в качестве запускаемого проекта укажите “Текущий выбор”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database.Save();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив
        /// другие «косметические» улучшения на свое усмотрение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numNumber_ValueChanged(object sender, EventArgs e)
        {
            txtQuestion.Text = database[(int)numNumber.Value - 1].Text;
            checkTrue.Checked = database[(int)numNumber.Value - 1].TrueFalse;
            if (checkTrue.Checked)
                this.txtQuestion.ForeColor = System.Drawing.Color.Green;
            else this.txtQuestion.ForeColor = System.Drawing.Color.Red;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            database.Add($"#{database.Count + 1}", true);
            numNumber.Maximum = database.Count;
            numNumber.Value = database.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            database.Remove((int)numNumber.Value - 1);
            numNumber.Maximum--;
            numNumber.Value--;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            database[(int)numNumber.Value - 1].Text = txtQuestion.Text;
            database[(int)numNumber.Value - 1].TrueFalse = checkTrue.Checked;
        }
    }
}
