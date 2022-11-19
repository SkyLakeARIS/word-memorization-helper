namespace WordMemory
{
    partial class AddWordForm
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
            this.Word = new System.Windows.Forms.TextBox();
            this.Memo = new System.Windows.Forms.TextBox();
            this.MeanListView = new System.Windows.Forms.ListView();
            this.LabelWord = new System.Windows.Forms.Label();
            this.LabelMean = new System.Windows.Forms.Label();
            this.LabelMemo = new System.Windows.Forms.Label();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.btnAddMean = new System.Windows.Forms.Button();
            this.InputMean = new System.Windows.Forms.TextBox();
            this.WordClassCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Word
            // 
            this.Word.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Word.Location = new System.Drawing.Point(101, 74);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(233, 26);
            this.Word.TabIndex = 0;
            // 
            // Memo
            // 
            this.Memo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Memo.Location = new System.Drawing.Point(101, 330);
            this.Memo.Multiline = true;
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(233, 72);
            this.Memo.TabIndex = 1;
            // 
            // MeanListView
            // 
            this.MeanListView.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MeanListView.HideSelection = false;
            this.MeanListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.MeanListView.Location = new System.Drawing.Point(101, 149);
            this.MeanListView.MultiSelect = false;
            this.MeanListView.Name = "MeanListView";
            this.MeanListView.Size = new System.Drawing.Size(233, 97);
            this.MeanListView.TabIndex = 2;
            this.MeanListView.TabStop = false;
            this.MeanListView.UseCompatibleStateImageBehavior = false;
            this.MeanListView.View = System.Windows.Forms.View.List;
            this.MeanListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MeanListView_MouseDoubleClick);
            // 
            // LabelWord
            // 
            this.LabelWord.AutoSize = true;
            this.LabelWord.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelWord.Location = new System.Drawing.Point(97, 52);
            this.LabelWord.Name = "LabelWord";
            this.LabelWord.Size = new System.Drawing.Size(49, 19);
            this.LabelWord.TabIndex = 3;
            this.LabelWord.Text = "단어";
            // 
            // LabelMean
            // 
            this.LabelMean.AutoSize = true;
            this.LabelMean.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMean.Location = new System.Drawing.Point(97, 127);
            this.LabelMean.Name = "LabelMean";
            this.LabelMean.Size = new System.Drawing.Size(29, 19);
            this.LabelMean.TabIndex = 4;
            this.LabelMean.Text = "뜻";
            // 
            // LabelMemo
            // 
            this.LabelMemo.AutoSize = true;
            this.LabelMemo.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMemo.Location = new System.Drawing.Point(97, 308);
            this.LabelMemo.Name = "LabelMemo";
            this.LabelMemo.Size = new System.Drawing.Size(49, 19);
            this.LabelMemo.TabIndex = 5;
            this.LabelMemo.Text = "메모";
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(101, 479);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(97, 36);
            this.btnAddWord.TabIndex = 6;
            this.btnAddWord.Text = "추가";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(237, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 36);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Menu;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MessageBox.Location = new System.Drawing.Point(101, 408);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.Size = new System.Drawing.Size(233, 65);
            this.MessageBox.TabIndex = 8;
            this.MessageBox.TabStop = false;
            // 
            // btnAddMean
            // 
            this.btnAddMean.Location = new System.Drawing.Point(340, 252);
            this.btnAddMean.Name = "btnAddMean";
            this.btnAddMean.Size = new System.Drawing.Size(64, 28);
            this.btnAddMean.TabIndex = 9;
            this.btnAddMean.Text = "추가";
            this.btnAddMean.UseVisualStyleBackColor = true;
            this.btnAddMean.Click += new System.EventHandler(this.btnAddMean_Click);
            // 
            // InputMean
            // 
            this.InputMean.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InputMean.Location = new System.Drawing.Point(179, 252);
            this.InputMean.Name = "InputMean";
            this.InputMean.Size = new System.Drawing.Size(155, 26);
            this.InputMean.TabIndex = 10;
            this.InputMean.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputMean_KeyPress);
            // 
            // WordClassCombo
            // 
            this.WordClassCombo.FormattingEnabled = true;
            this.WordClassCombo.Items.AddRange(new object[] {
            "NULL",
            "형용사",
            "동사",
            "명사"});
            this.WordClassCombo.Location = new System.Drawing.Point(101, 256);
            this.WordClassCombo.Name = "WordClassCombo";
            this.WordClassCombo.Size = new System.Drawing.Size(72, 20);
            this.WordClassCombo.TabIndex = 11;
            this.WordClassCombo.SelectedIndexChanged += new System.EventHandler(this.WordClassCombo_SelectedIndexChanged);
            // 
            // AddWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 527);
            this.Controls.Add(this.WordClassCombo);
            this.Controls.Add(this.InputMean);
            this.Controls.Add(this.btnAddMean);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.LabelMemo);
            this.Controls.Add(this.LabelMean);
            this.Controls.Add(this.LabelWord);
            this.Controls.Add(this.MeanListView);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.Word);
            this.Name = "AddWordForm";
            this.Text = "단어 추가";
            this.Load += new System.EventHandler(this.AddWordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Word;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.ListView MeanListView;
        private System.Windows.Forms.Label LabelWord;
        private System.Windows.Forms.Label LabelMean;
        private System.Windows.Forms.Label LabelMemo;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button btnAddMean;
        private System.Windows.Forms.TextBox InputMean;
        private System.Windows.Forms.ComboBox WordClassCombo;
    }
}