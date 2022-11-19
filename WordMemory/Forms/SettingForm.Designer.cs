namespace WordMemory
{
    partial class SettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExportWordData = new System.Windows.Forms.Button();
            this.btnImportWordData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnViewNotRemember = new System.Windows.Forms.RadioButton();
            this.rbtnViewRemember = new System.Windows.Forms.RadioButton();
            this.rbtnViewMixed = new System.Windows.Forms.RadioButton();
            this.rbtnTimerRefresh = new System.Windows.Forms.RadioButton();
            this.rbtnManualRefresh = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ViewModePanel = new System.Windows.Forms.Panel();
            this.RefreshModePanel = new System.Windows.Forms.Panel();
            this.InputTimerCount = new System.Windows.Forms.NumericUpDown();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ViewModePanel.SuspendLayout();
            this.RefreshModePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputTimerCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "보기 모드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(41, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "자동 모드";
            // 
            // btnExportWordData
            // 
            this.btnExportWordData.Location = new System.Drawing.Point(337, 68);
            this.btnExportWordData.Name = "btnExportWordData";
            this.btnExportWordData.Size = new System.Drawing.Size(84, 38);
            this.btnExportWordData.TabIndex = 2;
            this.btnExportWordData.Text = "단어 데이터 내보내기";
            this.btnExportWordData.UseVisualStyleBackColor = true;
            this.btnExportWordData.Click += new System.EventHandler(this.btnExportWordData_Click);
            // 
            // btnImportWordData
            // 
            this.btnImportWordData.Location = new System.Drawing.Point(337, 123);
            this.btnImportWordData.Name = "btnImportWordData";
            this.btnImportWordData.Size = new System.Drawing.Size(84, 38);
            this.btnImportWordData.TabIndex = 3;
            this.btnImportWordData.Text = "단어 데이터 불러오기";
            this.btnImportWordData.UseVisualStyleBackColor = true;
            this.btnImportWordData.Click += new System.EventHandler(this.btnImportWordData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(41, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "타이머 설정";
            // 
            // rbtnViewNotRemember
            // 
            this.rbtnViewNotRemember.AutoSize = true;
            this.rbtnViewNotRemember.Location = new System.Drawing.Point(4, 3);
            this.rbtnViewNotRemember.Name = "rbtnViewNotRemember";
            this.rbtnViewNotRemember.Size = new System.Drawing.Size(99, 16);
            this.rbtnViewNotRemember.TabIndex = 6;
            this.rbtnViewNotRemember.TabStop = true;
            this.rbtnViewNotRemember.Text = "미암기 단어만";
            this.rbtnViewNotRemember.UseVisualStyleBackColor = true;
            // 
            // rbtnViewRemember
            // 
            this.rbtnViewRemember.AutoSize = true;
            this.rbtnViewRemember.Location = new System.Drawing.Point(4, 25);
            this.rbtnViewRemember.Name = "rbtnViewRemember";
            this.rbtnViewRemember.Size = new System.Drawing.Size(87, 16);
            this.rbtnViewRemember.TabIndex = 7;
            this.rbtnViewRemember.TabStop = true;
            this.rbtnViewRemember.Text = "암기 단어만";
            this.rbtnViewRemember.UseVisualStyleBackColor = true;
            // 
            // rbtnViewMixed
            // 
            this.rbtnViewMixed.AutoSize = true;
            this.rbtnViewMixed.Location = new System.Drawing.Point(4, 47);
            this.rbtnViewMixed.Name = "rbtnViewMixed";
            this.rbtnViewMixed.Size = new System.Drawing.Size(73, 16);
            this.rbtnViewMixed.TabIndex = 8;
            this.rbtnViewMixed.TabStop = true;
            this.rbtnViewMixed.Text = "혼합(1:1)";
            this.rbtnViewMixed.UseVisualStyleBackColor = true;
            // 
            // rbtnTimerRefresh
            // 
            this.rbtnTimerRefresh.AutoSize = true;
            this.rbtnTimerRefresh.Location = new System.Drawing.Point(4, 12);
            this.rbtnTimerRefresh.Name = "rbtnTimerRefresh";
            this.rbtnTimerRefresh.Size = new System.Drawing.Size(93, 16);
            this.rbtnTimerRefresh.TabIndex = 9;
            this.rbtnTimerRefresh.TabStop = true;
            this.rbtnTimerRefresh.Text = "자동(타이머)";
            this.rbtnTimerRefresh.UseVisualStyleBackColor = true;
            // 
            // rbtnManualRefresh
            // 
            this.rbtnManualRefresh.AutoSize = true;
            this.rbtnManualRefresh.Location = new System.Drawing.Point(4, 34);
            this.rbtnManualRefresh.Name = "rbtnManualRefresh";
            this.rbtnManualRefresh.Size = new System.Drawing.Size(47, 16);
            this.rbtnManualRefresh.TabIndex = 10;
            this.rbtnManualRefresh.TabStop = true;
            this.rbtnManualRefresh.Text = "수동";
            this.rbtnManualRefresh.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(104, 403);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 38);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "적용하기";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(231, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 38);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewModePanel
            // 
            this.ViewModePanel.Controls.Add(this.rbtnViewNotRemember);
            this.ViewModePanel.Controls.Add(this.rbtnViewRemember);
            this.ViewModePanel.Controls.Add(this.rbtnViewMixed);
            this.ViewModePanel.Location = new System.Drawing.Point(44, 81);
            this.ViewModePanel.Name = "ViewModePanel";
            this.ViewModePanel.Size = new System.Drawing.Size(167, 80);
            this.ViewModePanel.TabIndex = 13;
            // 
            // RefreshModePanel
            // 
            this.RefreshModePanel.Controls.Add(this.rbtnTimerRefresh);
            this.RefreshModePanel.Controls.Add(this.rbtnManualRefresh);
            this.RefreshModePanel.Location = new System.Drawing.Point(44, 197);
            this.RefreshModePanel.Name = "RefreshModePanel";
            this.RefreshModePanel.Size = new System.Drawing.Size(118, 55);
            this.RefreshModePanel.TabIndex = 14;
            // 
            // InputTimerCount
            // 
            this.InputTimerCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.InputTimerCount.Location = new System.Drawing.Point(42, 318);
            this.InputTimerCount.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.InputTimerCount.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.InputTimerCount.Name = "InputTimerCount";
            this.InputTimerCount.Size = new System.Drawing.Size(120, 21);
            this.InputTimerCount.TabIndex = 15;
            this.InputTimerCount.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Menu;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MessageBox.Location = new System.Drawing.Point(95, 345);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.Size = new System.Drawing.Size(255, 52);
            this.MessageBox.TabIndex = 16;
            this.MessageBox.TabStop = false;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 485);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.InputTimerCount);
            this.Controls.Add(this.RefreshModePanel);
            this.Controls.Add(this.ViewModePanel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImportWordData);
            this.Controls.Add(this.btnExportWordData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingForm";
            this.Text = "환경설정";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ViewModePanel.ResumeLayout(false);
            this.ViewModePanel.PerformLayout();
            this.RefreshModePanel.ResumeLayout(false);
            this.RefreshModePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputTimerCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExportWordData;
        private System.Windows.Forms.Button btnImportWordData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnViewNotRemember;
        private System.Windows.Forms.RadioButton rbtnViewRemember;
        private System.Windows.Forms.RadioButton rbtnViewMixed;
        private System.Windows.Forms.RadioButton rbtnTimerRefresh;
        private System.Windows.Forms.RadioButton rbtnManualRefresh;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel ViewModePanel;
        private System.Windows.Forms.Panel RefreshModePanel;
        private System.Windows.Forms.NumericUpDown InputTimerCount;
        private System.Windows.Forms.TextBox MessageBox;
    }
}