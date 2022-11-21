namespace WordMemory.Forms
{
    partial class CheckImportDataSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnUseOriginalData = new System.Windows.Forms.RadioButton();
            this.rbtnUseImportData = new System.Windows.Forms.RadioButton();
            this.rbtnUseMerged = new System.Windows.Forms.RadioButton();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.btnSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnUseOriginalData
            // 
            this.rbtnUseOriginalData.AutoSize = true;
            this.rbtnUseOriginalData.Location = new System.Drawing.Point(71, 86);
            this.rbtnUseOriginalData.Name = "rbtnUseOriginalData";
            this.rbtnUseOriginalData.Size = new System.Drawing.Size(115, 16);
            this.rbtnUseOriginalData.TabIndex = 0;
            this.rbtnUseOriginalData.TabStop = true;
            this.rbtnUseOriginalData.Text = "기존 데이터 사용";
            this.rbtnUseOriginalData.UseVisualStyleBackColor = true;
            this.rbtnUseOriginalData.CheckedChanged += new System.EventHandler(this.rbtnUseOriginalData_CheckedChanged);
            // 
            // rbtnUseImportData
            // 
            this.rbtnUseImportData.AutoSize = true;
            this.rbtnUseImportData.Location = new System.Drawing.Point(71, 135);
            this.rbtnUseImportData.Name = "rbtnUseImportData";
            this.rbtnUseImportData.Size = new System.Drawing.Size(139, 16);
            this.rbtnUseImportData.TabIndex = 1;
            this.rbtnUseImportData.TabStop = true;
            this.rbtnUseImportData.Text = "임포트된 데이터 사용";
            this.rbtnUseImportData.UseVisualStyleBackColor = true;
            this.rbtnUseImportData.CheckedChanged += new System.EventHandler(this.rbtnUseImportData_CheckedChanged);
            // 
            // rbtnUseMerged
            // 
            this.rbtnUseMerged.AutoSize = true;
            this.rbtnUseMerged.Location = new System.Drawing.Point(71, 184);
            this.rbtnUseMerged.Name = "rbtnUseMerged";
            this.rbtnUseMerged.Size = new System.Drawing.Size(47, 16);
            this.rbtnUseMerged.TabIndex = 2;
            this.rbtnUseMerged.TabStop = true;
            this.rbtnUseMerged.Text = "합병";
            this.rbtnUseMerged.UseVisualStyleBackColor = true;
            this.rbtnUseMerged.CheckedChanged += new System.EventHandler(this.rbtnUseMerged_CheckedChanged);
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Menu;
            this.MessageBox.Location = new System.Drawing.Point(60, 250);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(207, 89);
            this.MessageBox.TabIndex = 3;
            // 
            // btnSelection
            // 
            this.btnSelection.Location = new System.Drawing.Point(120, 381);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(75, 23);
            this.btnSelection.TabIndex = 4;
            this.btnSelection.Text = "결정";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // CheckImportDataSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 430);
            this.Controls.Add(this.btnSelection);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.rbtnUseMerged);
            this.Controls.Add(this.rbtnUseImportData);
            this.Controls.Add(this.rbtnUseOriginalData);
            this.Name = "CheckImportDataSetting";
            this.Text = "데이터 임포트 설정";
            this.Load += new System.EventHandler(this.CheckImportDataSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnUseOriginalData;
        private System.Windows.Forms.RadioButton rbtnUseImportData;
        private System.Windows.Forms.RadioButton rbtnUseMerged;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button btnSelection;
    }
}