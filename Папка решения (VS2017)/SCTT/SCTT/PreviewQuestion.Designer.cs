namespace SCTT
{
    partial class PreviewQuestion
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
            this.NumberOFQuestionLabel = new System.Windows.Forms.Label();
            this.QuestionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NumberOFQuestionLabel
            // 
            this.NumberOFQuestionLabel.AutoSize = true;
            this.NumberOFQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOFQuestionLabel.Location = new System.Drawing.Point(30, 30);
            this.NumberOFQuestionLabel.Name = "NumberOFQuestionLabel";
            this.NumberOFQuestionLabel.Size = new System.Drawing.Size(41, 13);
            this.NumberOFQuestionLabel.TabIndex = 0;
            this.NumberOFQuestionLabel.Text = "label1";
            // 
            // QuestionRichTextBox
            // 
            this.QuestionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuestionRichTextBox.Location = new System.Drawing.Point(21, 46);
            this.QuestionRichTextBox.Name = "QuestionRichTextBox";
            this.QuestionRichTextBox.ReadOnly = true;
            this.QuestionRichTextBox.Size = new System.Drawing.Size(1214, 96);
            this.QuestionRichTextBox.TabIndex = 3;
            this.QuestionRichTextBox.Text = "";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(161, 19);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.TypeComboBox.TabIndex = 4;
            this.TypeComboBox.Visible = false;
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // PreviewQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 574);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.QuestionRichTextBox);
            this.Controls.Add(this.NumberOFQuestionLabel);
            this.Name = "PreviewQuestion";
            this.Text = "Предпросмотр вопроса";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewQuestion_FormClosingEventHandler);
            this.Load += new System.EventHandler(this.PreviewQuestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumberOFQuestionLabel;
        private System.Windows.Forms.RichTextBox QuestionRichTextBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
    }
}