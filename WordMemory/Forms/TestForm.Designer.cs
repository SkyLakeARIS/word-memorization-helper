namespace WordMemory
{
    partial class TestForm
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
            this.btnStartWordTest = new System.Windows.Forms.Button();
            this.btnStartMeanTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartWordTest
            // 
            this.btnStartWordTest.Location = new System.Drawing.Point(71, 104);
            this.btnStartWordTest.Name = "btnStartWordTest";
            this.btnStartWordTest.Size = new System.Drawing.Size(155, 44);
            this.btnStartWordTest.TabIndex = 0;
            this.btnStartWordTest.Text = "단어 맞추기 모드";
            this.btnStartWordTest.UseVisualStyleBackColor = true;
            this.btnStartWordTest.Click += new System.EventHandler(this.btnStartWordTest_Click);
            // 
            // btnStartMeanTest
            // 
            this.btnStartMeanTest.Location = new System.Drawing.Point(71, 198);
            this.btnStartMeanTest.Name = "btnStartMeanTest";
            this.btnStartMeanTest.Size = new System.Drawing.Size(155, 44);
            this.btnStartMeanTest.TabIndex = 1;
            this.btnStartMeanTest.Text = "뜻 맞추기 모드";
            this.btnStartMeanTest.UseVisualStyleBackColor = true;
            this.btnStartMeanTest.Click += new System.EventHandler(this.btnStartMeanTest_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(147, 398);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 44);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 527);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartMeanTest);
            this.Controls.Add(this.btnStartWordTest);
            this.Name = "TestForm";
            this.Text = "테스트 모드 선택";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartWordTest;
        private System.Windows.Forms.Button btnStartMeanTest;
        private System.Windows.Forms.Button btnClose;
    }
}