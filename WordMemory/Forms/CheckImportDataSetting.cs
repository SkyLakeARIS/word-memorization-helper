using System;
using System.Drawing;
using System.Windows.Forms;

namespace WordMemory.Forms
{
	public enum EImportOption
	{
        USE_ORIGINAL_DATA,
        USE_IMPORTED_DATA,
        USE_MERGED_DATA
	}

    public partial class CheckImportDataSetting : Form
    {
	    public string WordName
	    {
		    private get;
		    set;
	    }

        public CheckImportDataSetting()
        {
            InitializeComponent();
        }

        private void CheckImportDataSetting_Load(object sender, EventArgs e)
        {
            rbtnUseOriginalData.Checked = true;

            Word.Text = WordName;

            MessageBox.Text = "세가지 중 하나를 선택하여 데이터를 임포트합니다.";
            MessageBox.ForeColor = Color.Green;
        }

        private void rbtnUseOriginalData_CheckedChanged(object sender, EventArgs e)
        {
	        MessageBox.Text = "기존 데이터를 그대로 유지하여 사용합니다.";
	        MessageBox.ForeColor = Color.Green;
        }

        private void rbtnUseImportData_CheckedChanged(object sender, EventArgs e)
        {
	        MessageBox.Text = "임포트된 데이터로 교체합니다.\n 기존 데이터는 사라집니다.";
	        MessageBox.ForeColor = Color.Green;
        }

        private void rbtnUseMerged_CheckedChanged(object sender, EventArgs e)
        {
	        MessageBox.Text = "기존 데이터를 기본으로 임포트된 데이터를 합칩니다.\n뜻은 최대 16개까지 합쳐집니다.\n 메모는 덧붙여집니다.(접두로 'imported'가 붙습니다.)\n 암기여부는 제외됩니다.";
	        MessageBox.ForeColor = Color.Green;
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
	        EImportOption option;
	        if (rbtnUseOriginalData.Checked)
	        {
		        option = EImportOption.USE_ORIGINAL_DATA;
	        }
	        else if(rbtnUseImportData.Checked)
	        {
		        option = EImportOption.USE_IMPORTED_DATA;
	        }
            else
	        {
		        option = EImportOption.USE_MERGED_DATA;
	        }

            WordManager.SetImportOption(option);

            DialogResult = DialogResult.OK;
        }

    }
}
