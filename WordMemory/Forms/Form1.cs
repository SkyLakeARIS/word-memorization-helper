using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordMemory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 초기 설정
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            AddWordForm addWordForm = new AddWordForm();
            if(DialogResult.Cancel == addWordForm.ShowDialog() || DialogResult.OK == addWordForm.ShowDialog())
            {
                addWordForm.Close();
            }
        }

        private void btnFindWord_Click(object sender, EventArgs e)
        {
            FindWordForm findWordForm = new FindWordForm();
            if (DialogResult.Cancel == findWordForm.ShowDialog() || DialogResult.OK == findWordForm.ShowDialog())
            {
                findWordForm.Close();
            }
        }

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            RemoveWordForm removeWordForm = new RemoveWordForm();
            if (DialogResult.Cancel == removeWordForm.ShowDialog() || DialogResult.OK == removeWordForm.ShowDialog())
            {
                removeWordForm.Close();
            }
        }

        private void btnTestWord_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            if (DialogResult.Cancel == testForm.ShowDialog() || DialogResult.OK == testForm.ShowDialog())
            {
                testForm.Close();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            if (DialogResult.Cancel == settingForm.ShowDialog() || DialogResult.OK == settingForm.ShowDialog())
            {
                settingForm.Close();
            }
        }

        private void btnRefreshWord_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
