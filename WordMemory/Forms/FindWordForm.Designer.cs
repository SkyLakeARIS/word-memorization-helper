namespace WordMemory
{
    partial class FindWordForm
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            ""}, -1);
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFindWord = new System.Windows.Forms.Button();
            this.LabelMemo = new System.Windows.Forms.Label();
            this.LabelMean = new System.Windows.Forms.Label();
            this.LabelWord = new System.Windows.Forms.Label();
            this.MeanListView = new System.Windows.Forms.ListView();
            this.Memo = new System.Windows.Forms.TextBox();
            this.Word = new System.Windows.Forms.TextBox();
            this.WordClassCombo = new System.Windows.Forms.ComboBox();
            this.InputMean = new System.Windows.Forms.TextBox();
            this.btnAddMean = new System.Windows.Forms.Button();
            this.btnModifyWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Menu;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MessageBox.Location = new System.Drawing.Point(117, 375);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.Size = new System.Drawing.Size(233, 98);
            this.MessageBox.TabIndex = 29;
            this.MessageBox.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(305, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 36);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFindWord
            // 
            this.btnFindWord.Location = new System.Drawing.Point(168, 479);
            this.btnFindWord.Name = "btnFindWord";
            this.btnFindWord.Size = new System.Drawing.Size(97, 36);
            this.btnFindWord.TabIndex = 27;
            this.btnFindWord.Text = "검색";
            this.btnFindWord.UseVisualStyleBackColor = true;
            this.btnFindWord.Click += new System.EventHandler(this.btnFindWord_Click);
            // 
            // LabelMemo
            // 
            this.LabelMemo.AutoSize = true;
            this.LabelMemo.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMemo.Location = new System.Drawing.Point(113, 275);
            this.LabelMemo.Name = "LabelMemo";
            this.LabelMemo.Size = new System.Drawing.Size(49, 19);
            this.LabelMemo.TabIndex = 26;
            this.LabelMemo.Text = "메모";
            // 
            // LabelMean
            // 
            this.LabelMean.AutoSize = true;
            this.LabelMean.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMean.Location = new System.Drawing.Point(113, 107);
            this.LabelMean.Name = "LabelMean";
            this.LabelMean.Size = new System.Drawing.Size(29, 19);
            this.LabelMean.TabIndex = 25;
            this.LabelMean.Text = "뜻";
            // 
            // LabelWord
            // 
            this.LabelWord.AutoSize = true;
            this.LabelWord.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelWord.Location = new System.Drawing.Point(113, 32);
            this.LabelWord.Name = "LabelWord";
            this.LabelWord.Size = new System.Drawing.Size(49, 19);
            this.LabelWord.TabIndex = 24;
            this.LabelWord.Text = "단어";
            // 
            // MeanListView
            // 
            this.MeanListView.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MeanListView.HideSelection = false;
            this.MeanListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.MeanListView.Location = new System.Drawing.Point(117, 129);
            this.MeanListView.MultiSelect = false;
            this.MeanListView.Name = "MeanListView";
            this.MeanListView.Size = new System.Drawing.Size(233, 97);
            this.MeanListView.TabIndex = 23;
            this.MeanListView.TabStop = false;
            this.MeanListView.UseCompatibleStateImageBehavior = false;
            this.MeanListView.View = System.Windows.Forms.View.List;
            this.MeanListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MeanListView_MouseDoubleClick);
            // 
            // Memo
            // 
            this.Memo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Memo.Location = new System.Drawing.Point(117, 297);
            this.Memo.Multiline = true;
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(233, 72);
            this.Memo.TabIndex = 22;
            // 
            // Word
            // 
            this.Word.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Word.Location = new System.Drawing.Point(117, 54);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(233, 26);
            this.Word.TabIndex = 21;
            this.Word.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Word_KeyPress);
            // 
            // WordClassCombo
            // 
            this.WordClassCombo.FormattingEnabled = true;
            this.WordClassCombo.Items.AddRange(new object[] {
            "NULL",
            "형용사",
            "동사",
            "명사"});
            this.WordClassCombo.Location = new System.Drawing.Point(117, 232);
            this.WordClassCombo.Name = "WordClassCombo";
            this.WordClassCombo.Size = new System.Drawing.Size(72, 20);
            this.WordClassCombo.TabIndex = 32;
            // 
            // InputMean
            // 
            this.InputMean.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InputMean.Location = new System.Drawing.Point(195, 228);
            this.InputMean.Name = "InputMean";
            this.InputMean.Size = new System.Drawing.Size(155, 26);
            this.InputMean.TabIndex = 31;
            this.InputMean.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputMean_KeyPress);
            // 
            // btnAddMean
            // 
            this.btnAddMean.Location = new System.Drawing.Point(356, 228);
            this.btnAddMean.Name = "btnAddMean";
            this.btnAddMean.Size = new System.Drawing.Size(64, 28);
            this.btnAddMean.TabIndex = 30;
            this.btnAddMean.Text = "추가";
            this.btnAddMean.UseVisualStyleBackColor = true;
            this.btnAddMean.Click += new System.EventHandler(this.btnAddMean_Click);
            // 
            // btnModifyWord
            // 
            this.btnModifyWord.Location = new System.Drawing.Point(45, 479);
            this.btnModifyWord.Name = "btnModifyWord";
            this.btnModifyWord.Size = new System.Drawing.Size(97, 36);
            this.btnModifyWord.TabIndex = 33;
            this.btnModifyWord.Text = "적용";
            this.btnModifyWord.UseVisualStyleBackColor = true;
            this.btnModifyWord.Click += new System.EventHandler(this.btnModifyWord_Click);
            // 
            // FindWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 527);
            this.Controls.Add(this.btnModifyWord);
            this.Controls.Add(this.WordClassCombo);
            this.Controls.Add(this.InputMean);
            this.Controls.Add(this.btnAddMean);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFindWord);
            this.Controls.Add(this.LabelMemo);
            this.Controls.Add(this.LabelMean);
            this.Controls.Add(this.LabelWord);
            this.Controls.Add(this.MeanListView);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.Word);
            this.Name = "FindWordForm";
            this.Text = "단어 찾기";
            this.Load += new System.EventHandler(this.FindWordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFindWord;
        private System.Windows.Forms.Label LabelMemo;
        private System.Windows.Forms.Label LabelMean;
        private System.Windows.Forms.Label LabelWord;
        private System.Windows.Forms.ListView MeanListView;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.TextBox Word;
        private System.Windows.Forms.ComboBox WordClassCombo;
        private System.Windows.Forms.TextBox InputMean;
        private System.Windows.Forms.Button btnAddMean;
        private System.Windows.Forms.Button btnModifyWord;
    }
}