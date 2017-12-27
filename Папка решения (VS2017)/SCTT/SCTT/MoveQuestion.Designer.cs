namespace SCTT
{
    partial class MoveQuestion
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
            this.CurrentNumberLabel = new System.Windows.Forms.Label();
            this.NewNumberLabel = new System.Windows.Forms.Label();
            this.NewNumberTextBox = new System.Windows.Forms.TextBox();
            this.MoveQuestionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentNumberLabel
            // 
            this.CurrentNumberLabel.AutoSize = true;
            this.CurrentNumberLabel.Location = new System.Drawing.Point(25, 40);
            this.CurrentNumberLabel.Name = "CurrentNumberLabel";
            this.CurrentNumberLabel.Size = new System.Drawing.Size(135, 13);
            this.CurrentNumberLabel.TabIndex = 0;
            this.CurrentNumberLabel.Text = "Tекущий номер вопроса:";
            // 
            // NewNumberLabel
            // 
            this.NewNumberLabel.AutoSize = true;
            this.NewNumberLabel.Location = new System.Drawing.Point(25, 61);
            this.NewNumberLabel.Name = "NewNumberLabel";
            this.NewNumberLabel.Size = new System.Drawing.Size(79, 13);
            this.NewNumberLabel.TabIndex = 1;
            this.NewNumberLabel.Text = "Новый номер:";
            // 
            // NewNumberTextBox
            // 
            this.NewNumberTextBox.Location = new System.Drawing.Point(110, 58);
            this.NewNumberTextBox.Name = "NewNumberTextBox";
            this.NewNumberTextBox.Size = new System.Drawing.Size(50, 20);
            this.NewNumberTextBox.TabIndex = 2;
            // 
            // MoveQuestionButton
            // 
            this.MoveQuestionButton.Location = new System.Drawing.Point(160, 95);
            this.MoveQuestionButton.Name = "MoveQuestionButton";
            this.MoveQuestionButton.Size = new System.Drawing.Size(75, 23);
            this.MoveQuestionButton.TabIndex = 3;
            this.MoveQuestionButton.Text = "Изменить";
            this.MoveQuestionButton.UseVisualStyleBackColor = true;
            this.MoveQuestionButton.Click += new System.EventHandler(this.MoveQuestionButton_Click);
            // 
            // MoveQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 130);
            this.Controls.Add(this.MoveQuestionButton);
            this.Controls.Add(this.NewNumberTextBox);
            this.Controls.Add(this.NewNumberLabel);
            this.Controls.Add(this.CurrentNumberLabel);
            this.Name = "MoveQuestion";
            this.Text = "Смена номера вопроса";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoveQuestion_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentNumberLabel;
        private System.Windows.Forms.Label NewNumberLabel;
        private System.Windows.Forms.TextBox NewNumberTextBox;
        private System.Windows.Forms.Button MoveQuestionButton;
    }
}