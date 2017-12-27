namespace SCTT
{
    partial class Result
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
            this.NamePersonLabel = new System.Windows.Forms.Label();
            this.CastPersonLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.RSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.RatingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NamePersonLabel
            // 
            this.NamePersonLabel.AutoSize = true;
            this.NamePersonLabel.Location = new System.Drawing.Point(51, 60);
            this.NamePersonLabel.Name = "NamePersonLabel";
            this.NamePersonLabel.Size = new System.Drawing.Size(29, 13);
            this.NamePersonLabel.TabIndex = 0;
            this.NamePersonLabel.Text = "Имя";
            // 
            // CastPersonLabel
            // 
            this.CastPersonLabel.AutoSize = true;
            this.CastPersonLabel.Location = new System.Drawing.Point(51, 86);
            this.CastPersonLabel.Name = "CastPersonLabel";
            this.CastPersonLabel.Size = new System.Drawing.Size(42, 13);
            this.CastPersonLabel.TabIndex = 1;
            this.CastPersonLabel.Text = "Группа";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(54, 286);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Сохранить результат";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(395, 286);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RSaveFileDialog
            // 
            this.RSaveFileDialog.Filter = ".txt | *.txt";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(51, 108);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(35, 13);
            this.ResultLabel.TabIndex = 4;
            this.ResultLabel.Text = "label1";
            // 
            // RatingLabel
            // 
            this.RatingLabel.AutoSize = true;
            this.RatingLabel.Location = new System.Drawing.Point(51, 134);
            this.RatingLabel.Name = "RatingLabel";
            this.RatingLabel.Size = new System.Drawing.Size(35, 13);
            this.RatingLabel.TabIndex = 5;
            this.RatingLabel.Text = "label1";
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 347);
            this.Controls.Add(this.RatingLabel);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CastPersonLabel);
            this.Controls.Add(this.NamePersonLabel);
            this.Name = "Result";
            this.Text = "Результат тестирования";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NamePersonLabel;
        private System.Windows.Forms.Label CastPersonLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.SaveFileDialog RSaveFileDialog;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label RatingLabel;
    }
}