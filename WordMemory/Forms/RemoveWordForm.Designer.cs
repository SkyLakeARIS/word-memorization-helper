namespace WordMemory
{
    partial class RemoveWordForm
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
            this.btnFindWord = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemoveWord = new System.Windows.Forms.Button();
            this.LabelMemo = new System.Windows.Forms.Label();
            this.LabelMean = new System.Windows.Forms.Label();
            this.LabelWord = new System.Windows.Forms.Label();
            this.MeanListView = new System.Windows.Forms.ListView();
            this.Memo = new System.Windows.Forms.TextBox();
            this.Word = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFindWord
            // 
            this.btnFindWord.Location = new System.Drawing.Point(339, 55);
            this.btnFindWord.Name = "btnFindWord";
            this.btnFindWord.Size = new System.Drawing.Size(63, 26);
            this.btnFindWord.TabIndex = 40;
            this.btnFindWord.Text = "검색";
            this.btnFindWord.UseVisualStyleBackColor = true;
            this.btnFindWord.Click += new System.EventHandler(this.btnFindWord_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Menu;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MessageBox.Location = new System.Drawing.Point(100, 375);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.Size = new System.Drawing.Size(233, 98);
            this.MessageBox.TabIndex = 39;
            this.MessageBox.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(236, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 36);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemoveWord
            // 
            this.btnRemoveWord.Location = new System.Drawing.Point(100, 479);
            this.btnRemoveWord.Name = "btnRemoveWord";
            this.btnRemoveWord.Size = new System.Drawing.Size(97, 36);
            this.btnRemoveWord.TabIndex = 37;
            this.btnRemoveWord.Text = "삭제";
            this.btnRemoveWord.UseVisualStyleBackColor = true;
            this.btnRemoveWord.Click += new System.EventHandler(this.btnRemoveWord_Click);
            // 
            // LabelMemo
            // 
            this.LabelMemo.AutoSize = true;
            this.LabelMemo.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMemo.Location = new System.Drawing.Point(96, 240);
            this.LabelMemo.Name = "LabelMemo";
            this.LabelMemo.Size = new System.Drawing.Size(49, 19);
            this.LabelMemo.TabIndex = 36;
            this.LabelMemo.Text = "메모";
            // 
            // LabelMean
            // 
            this.LabelMean.AutoSize = true;
            this.LabelMean.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMean.Location = new System.Drawing.Point(96, 108);
            this.LabelMean.Name = "LabelMean";
            this.LabelMean.Size = new System.Drawing.Size(29, 19);
            this.LabelMean.TabIndex = 35;
            this.LabelMean.Text = "뜻";
            // 
            // LabelWord
            // 
            this.LabelWord.AutoSize = true;
            this.LabelWord.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelWord.Location = new System.Drawing.Point(96, 33);
            this.LabelWord.Name = "LabelWord";
            this.LabelWord.Size = new System.Drawing.Size(49, 19);
            this.LabelWord.TabIndex = 34;
            this.LabelWord.Text = "단어";
            // 
            // MeanListView
            // 
            this.MeanListView.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MeanListView.HideSelection = false;
            this.MeanListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.MeanListView.Location = new System.Drawing.Point(100, 130);
            this.MeanListView.MultiSelect = false;
            this.MeanListView.Name = "MeanListView";
            this.MeanListView.Size = new System.Drawing.Size(233, 97);
            this.MeanListView.TabIndex = 33;
            this.MeanListView.TabStop = false;
            this.MeanListView.UseCompatibleStateImageBehavior = false;
            this.MeanListView.View = System.Windows.Forms.View.List;
            // 
            // Memo
            // 
            this.Memo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Memo.Location = new System.Drawing.Point(100, 262);
            this.Memo.Multiline = true;
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.Size = new System.Drawing.Size(233, 72);
            this.Memo.TabIndex = 32;
            this.Memo.TabStop = false;
            // 
            // Word
            // 
            this.Word.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Word.Location = new System.Drawing.Point(100, 55);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(233, 26);
            this.Word.TabIndex = 31;
            this.Word.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Word_KeyPress);
            // 
            // RemoveWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 527);
            this.Controls.Add(this.btnFindWord);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveWord);
            this.Controls.Add(this.LabelMemo);
            this.Controls.Add(this.LabelMean);
            this.Controls.Add(this.LabelWord);
            this.Controls.Add(this.MeanListView);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.Word);
            this.Name = "RemoveWordForm";
            this.Text = "단어 삭제";
            this.Load += new System.EventHandler(this.RemoveWordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindWord;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemoveWord;
        private System.Windows.Forms.Label LabelMemo;
        private System.Windows.Forms.Label LabelMean;
        private System.Windows.Forms.Label LabelWord;
        private System.Windows.Forms.ListView MeanListView;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.TextBox Word;
    }
}