namespace WordMemory
{
    partial class TestWordForm
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
            this.LabelMean = new System.Windows.Forms.Label();
            this.LabelWord = new System.Windows.Forms.Label();
            this.MeanListView = new System.Windows.Forms.ListView();
            this.Word = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelMean
            // 
            this.LabelMean.AutoSize = true;
            this.LabelMean.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMean.Location = new System.Drawing.Point(78, 167);
            this.LabelMean.Name = "LabelMean";
            this.LabelMean.Size = new System.Drawing.Size(29, 19);
            this.LabelMean.TabIndex = 45;
            this.LabelMean.Text = "뜻";
            // 
            // LabelWord
            // 
            this.LabelWord.AutoSize = true;
            this.LabelWord.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelWord.Location = new System.Drawing.Point(78, 92);
            this.LabelWord.Name = "LabelWord";
            this.LabelWord.Size = new System.Drawing.Size(49, 19);
            this.LabelWord.TabIndex = 44;
            this.LabelWord.Text = "단어";
            // 
            // MeanListView
            // 
            this.MeanListView.BackColor = System.Drawing.SystemColors.Menu;
            this.MeanListView.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MeanListView.HideSelection = false;
            this.MeanListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.MeanListView.Location = new System.Drawing.Point(82, 189);
            this.MeanListView.Name = "MeanListView";
            this.MeanListView.Size = new System.Drawing.Size(233, 97);
            this.MeanListView.TabIndex = 43;
            this.MeanListView.TabStop = false;
            this.MeanListView.UseCompatibleStateImageBehavior = false;
            this.MeanListView.View = System.Windows.Forms.View.List;
            // 
            // Word
            // 
            this.Word.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Word.Location = new System.Drawing.Point(82, 114);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(233, 26);
            this.Word.TabIndex = 41;
            this.Word.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Word_KeyPress);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(82, 413);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(104, 44);
            this.btnSubmit.TabIndex = 48;
            this.btnSubmit.Text = "제출";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(211, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 44);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Menu;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MessageBox.Location = new System.Drawing.Point(82, 309);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(233, 98);
            this.MessageBox.TabIndex = 50;
            this.MessageBox.TabStop = false;
            // 
            // TestWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 527);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.LabelMean);
            this.Controls.Add(this.LabelWord);
            this.Controls.Add(this.MeanListView);
            this.Controls.Add(this.Word);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TestWordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "단어 맞추기 시험";
            this.Load += new System.EventHandler(this.TestWordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelMean;
        private System.Windows.Forms.Label LabelWord;
        private System.Windows.Forms.ListView MeanListView;
        private System.Windows.Forms.TextBox Word;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox MessageBox;
    }
}