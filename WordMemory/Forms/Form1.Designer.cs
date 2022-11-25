namespace WordMemory
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.WordFirst = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MemoFirst = new System.Windows.Forms.TextBox();
            this.MemoSecond = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.WordSecond = new System.Windows.Forms.TextBox();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnFindWord = new System.Windows.Forms.Button();
            this.btnRemoveWord = new System.Windows.Forms.Button();
            this.btnTestWord = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnRefreshWord = new System.Windows.Forms.Button();
            this.btnSaveAndExit = new System.Windows.Forms.Button();
            this.MeanListViewFirst = new System.Windows.Forms.ListView();
            this.MeanListViewSecond = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnNotRememberFirst = new System.Windows.Forms.RadioButton();
            this.rbtnRememberFirst = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnNotRememberSecond = new System.Windows.Forms.RadioButton();
            this.rbtnRememberSecond = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPronounceWordFirst = new System.Windows.Forms.Button();
            this.btnPronounceWordSecond = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // WordFirst
            // 
            this.WordFirst.BackColor = System.Drawing.SystemColors.Menu;
            this.WordFirst.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WordFirst.Location = new System.Drawing.Point(22, 66);
            this.WordFirst.Name = "WordFirst";
            this.WordFirst.ReadOnly = true;
            this.WordFirst.Size = new System.Drawing.Size(274, 29);
            this.WordFirst.TabIndex = 0;
            this.WordFirst.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "단어";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(18, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "뜻";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(18, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "메모";
            // 
            // MemoFirst
            // 
            this.MemoFirst.BackColor = System.Drawing.SystemColors.Menu;
            this.MemoFirst.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MemoFirst.Location = new System.Drawing.Point(22, 257);
            this.MemoFirst.Multiline = true;
            this.MemoFirst.Name = "MemoFirst";
            this.MemoFirst.ReadOnly = true;
            this.MemoFirst.Size = new System.Drawing.Size(274, 62);
            this.MemoFirst.TabIndex = 4;
            this.MemoFirst.TabStop = false;
            // 
            // MemoSecond
            // 
            this.MemoSecond.BackColor = System.Drawing.SystemColors.Menu;
            this.MemoSecond.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MemoSecond.Location = new System.Drawing.Point(22, 586);
            this.MemoSecond.Multiline = true;
            this.MemoSecond.Name = "MemoSecond";
            this.MemoSecond.ReadOnly = true;
            this.MemoSecond.Size = new System.Drawing.Size(274, 62);
            this.MemoSecond.TabIndex = 10;
            this.MemoSecond.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(18, 559);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "메모";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(18, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "뜻";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(18, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "단어";
            // 
            // WordSecond
            // 
            this.WordSecond.BackColor = System.Drawing.SystemColors.Menu;
            this.WordSecond.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WordSecond.Location = new System.Drawing.Point(22, 411);
            this.WordSecond.Name = "WordSecond";
            this.WordSecond.ReadOnly = true;
            this.WordSecond.Size = new System.Drawing.Size(274, 29);
            this.WordSecond.TabIndex = 6;
            this.WordSecond.TabStop = false;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(357, 66);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(138, 36);
            this.btnAddWord.TabIndex = 12;
            this.btnAddWord.Text = "단어 추가";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnFindWord
            // 
            this.btnFindWord.Location = new System.Drawing.Point(357, 122);
            this.btnFindWord.Name = "btnFindWord";
            this.btnFindWord.Size = new System.Drawing.Size(138, 36);
            this.btnFindWord.TabIndex = 13;
            this.btnFindWord.Text = "단어 검색";
            this.btnFindWord.UseVisualStyleBackColor = true;
            this.btnFindWord.Click += new System.EventHandler(this.btnFindWord_Click);
            // 
            // btnRemoveWord
            // 
            this.btnRemoveWord.Location = new System.Drawing.Point(357, 178);
            this.btnRemoveWord.Name = "btnRemoveWord";
            this.btnRemoveWord.Size = new System.Drawing.Size(138, 36);
            this.btnRemoveWord.TabIndex = 14;
            this.btnRemoveWord.Text = "단어 삭제";
            this.btnRemoveWord.UseVisualStyleBackColor = true;
            this.btnRemoveWord.Click += new System.EventHandler(this.btnRemoveWord_Click);
            // 
            // btnTestWord
            // 
            this.btnTestWord.Location = new System.Drawing.Point(357, 238);
            this.btnTestWord.Name = "btnTestWord";
            this.btnTestWord.Size = new System.Drawing.Size(138, 36);
            this.btnTestWord.TabIndex = 15;
            this.btnTestWord.Text = "테스트";
            this.btnTestWord.UseVisualStyleBackColor = true;
            this.btnTestWord.Click += new System.EventHandler(this.btnTestWord_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(357, 294);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(138, 36);
            this.btnSetting.TabIndex = 16;
            this.btnSetting.Text = "환경설정";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnRefreshWord
            // 
            this.btnRefreshWord.Location = new System.Drawing.Point(357, 470);
            this.btnRefreshWord.Name = "btnRefreshWord";
            this.btnRefreshWord.Size = new System.Drawing.Size(138, 36);
            this.btnRefreshWord.TabIndex = 17;
            this.btnRefreshWord.Text = "단어 갱신";
            this.btnRefreshWord.UseVisualStyleBackColor = true;
            this.btnRefreshWord.Click += new System.EventHandler(this.btnRefreshWord_Click);
            // 
            // btnSaveAndExit
            // 
            this.btnSaveAndExit.Location = new System.Drawing.Point(357, 655);
            this.btnSaveAndExit.Name = "btnSaveAndExit";
            this.btnSaveAndExit.Size = new System.Drawing.Size(138, 36);
            this.btnSaveAndExit.TabIndex = 18;
            this.btnSaveAndExit.Text = "저장 후 종료";
            this.btnSaveAndExit.UseVisualStyleBackColor = true;
            this.btnSaveAndExit.Click += new System.EventHandler(this.btnSaveAndExit_Click);
            // 
            // MeanListViewFirst
            // 
            this.MeanListViewFirst.BackColor = System.Drawing.SystemColors.Menu;
            this.MeanListViewFirst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.MeanListViewFirst.HideSelection = false;
            this.MeanListViewFirst.Location = new System.Drawing.Point(22, 133);
            this.MeanListViewFirst.Name = "MeanListViewFirst";
            this.MeanListViewFirst.Size = new System.Drawing.Size(274, 93);
            this.MeanListViewFirst.TabIndex = 19;
            this.MeanListViewFirst.TabStop = false;
            this.MeanListViewFirst.UseCompatibleStateImageBehavior = false;
            // 
            // MeanListViewSecond
            // 
            this.MeanListViewSecond.BackColor = System.Drawing.SystemColors.Menu;
            this.MeanListViewSecond.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.MeanListViewSecond.HideSelection = false;
            this.MeanListViewSecond.Location = new System.Drawing.Point(22, 470);
            this.MeanListViewSecond.Name = "MeanListViewSecond";
            this.MeanListViewSecond.Size = new System.Drawing.Size(274, 86);
            this.MeanListViewSecond.TabIndex = 20;
            this.MeanListViewSecond.TabStop = false;
            this.MeanListViewSecond.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnNotRememberFirst);
            this.panel1.Controls.Add(this.rbtnRememberFirst);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(22, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 37);
            this.panel1.TabIndex = 21;
            // 
            // rbtnNotRememberFirst
            // 
            this.rbtnNotRememberFirst.AutoSize = true;
            this.rbtnNotRememberFirst.Location = new System.Drawing.Point(132, 3);
            this.rbtnNotRememberFirst.Name = "rbtnNotRememberFirst";
            this.rbtnNotRememberFirst.Size = new System.Drawing.Size(59, 16);
            this.rbtnNotRememberFirst.TabIndex = 24;
            this.rbtnNotRememberFirst.TabStop = true;
            this.rbtnNotRememberFirst.Text = "미암기";
            this.rbtnNotRememberFirst.UseVisualStyleBackColor = true;
            this.rbtnNotRememberFirst.CheckedChanged += new System.EventHandler(this.rbtnNotRememberFirst_CheckedChanged);
            // 
            // rbtnRememberFirst
            // 
            this.rbtnRememberFirst.AutoSize = true;
            this.rbtnRememberFirst.Location = new System.Drawing.Point(23, 4);
            this.rbtnRememberFirst.Name = "rbtnRememberFirst";
            this.rbtnRememberFirst.Size = new System.Drawing.Size(47, 16);
            this.rbtnRememberFirst.TabIndex = 23;
            this.rbtnRememberFirst.TabStop = true;
            this.rbtnRememberFirst.Text = "암기";
            this.rbtnRememberFirst.UseVisualStyleBackColor = true;
            this.rbtnRememberFirst.CheckedChanged += new System.EventHandler(this.rbtnRememberFirst_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 24);
            this.label7.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnNotRememberSecond);
            this.panel2.Controls.Add(this.rbtnRememberSecond);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(22, 655);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 37);
            this.panel2.TabIndex = 25;
            // 
            // rbtnNotRememberSecond
            // 
            this.rbtnNotRememberSecond.AutoSize = true;
            this.rbtnNotRememberSecond.Location = new System.Drawing.Point(132, 3);
            this.rbtnNotRememberSecond.Name = "rbtnNotRememberSecond";
            this.rbtnNotRememberSecond.Size = new System.Drawing.Size(59, 16);
            this.rbtnNotRememberSecond.TabIndex = 24;
            this.rbtnNotRememberSecond.TabStop = true;
            this.rbtnNotRememberSecond.Text = "미암기";
            this.rbtnNotRememberSecond.UseVisualStyleBackColor = true;
            this.rbtnNotRememberSecond.CheckedChanged += new System.EventHandler(this.rbtnNotRememberSecond_CheckedChanged);
            // 
            // rbtnRememberSecond
            // 
            this.rbtnRememberSecond.AutoSize = true;
            this.rbtnRememberSecond.Location = new System.Drawing.Point(23, 4);
            this.rbtnRememberSecond.Name = "rbtnRememberSecond";
            this.rbtnRememberSecond.Size = new System.Drawing.Size(47, 16);
            this.rbtnRememberSecond.TabIndex = 23;
            this.rbtnRememberSecond.TabStop = true;
            this.rbtnRememberSecond.Text = "암기";
            this.rbtnRememberSecond.UseVisualStyleBackColor = true;
            this.rbtnRememberSecond.CheckedChanged += new System.EventHandler(this.rbtnRememberSecond_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 24);
            this.label8.TabIndex = 22;
            // 
            // btnPronounceWordFirst
            // 
            this.btnPronounceWordFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnPronounceWordFirst.Image")));
            this.btnPronounceWordFirst.Location = new System.Drawing.Point(84, 40);
            this.btnPronounceWordFirst.Name = "btnPronounceWordFirst";
            this.btnPronounceWordFirst.Size = new System.Drawing.Size(37, 23);
            this.btnPronounceWordFirst.TabIndex = 26;
            this.btnPronounceWordFirst.UseVisualStyleBackColor = true;
            this.btnPronounceWordFirst.Click += new System.EventHandler(this.btnPronounceWordFirst_Click);
            // 
            // btnPronounceWordSecond
            // 
            this.btnPronounceWordSecond.Image = ((System.Drawing.Image)(resources.GetObject("btnPronounceWordSecond.Image")));
            this.btnPronounceWordSecond.Location = new System.Drawing.Point(81, 381);
            this.btnPronounceWordSecond.Name = "btnPronounceWordSecond";
            this.btnPronounceWordSecond.Size = new System.Drawing.Size(40, 24);
            this.btnPronounceWordSecond.TabIndex = 27;
            this.btnPronounceWordSecond.UseVisualStyleBackColor = true;
            this.btnPronounceWordSecond.Click += new System.EventHandler(this.btnPronounceWordSecond_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 703);
            this.Controls.Add(this.btnPronounceWordSecond);
            this.Controls.Add(this.btnPronounceWordFirst);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MeanListViewSecond);
            this.Controls.Add(this.MeanListViewFirst);
            this.Controls.Add(this.btnSaveAndExit);
            this.Controls.Add(this.btnRefreshWord);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnTestWord);
            this.Controls.Add(this.btnRemoveWord);
            this.Controls.Add(this.btnFindWord);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.MemoSecond);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.WordSecond);
            this.Controls.Add(this.MemoFirst);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WordFirst);
            this.Name = "MainForm";
            this.Text = "단어 암기 도우미";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WordFirst;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MemoFirst;
        private System.Windows.Forms.TextBox MemoSecond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox WordSecond;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnFindWord;
        private System.Windows.Forms.Button btnRemoveWord;
        private System.Windows.Forms.Button btnTestWord;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnRefreshWord;
        private System.Windows.Forms.Button btnSaveAndExit;
        private System.Windows.Forms.ListView MeanListViewFirst;
        private System.Windows.Forms.ListView MeanListViewSecond;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbtnNotRememberFirst;
        private System.Windows.Forms.RadioButton rbtnRememberFirst;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnNotRememberSecond;
        private System.Windows.Forms.RadioButton rbtnRememberSecond;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPronounceWordFirst;
        private System.Windows.Forms.Button btnPronounceWordSecond;
    }
}

