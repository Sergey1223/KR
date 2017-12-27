namespace SCTT
{
    partial class CreateTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTest));
            this.NextButton = new System.Windows.Forms.Button();
            this.NameTestTextBox = new System.Windows.Forms.TextBox();
            this.NumTextBox = new System.Windows.Forms.TextBox();
            this.CreateTestPanel = new System.Windows.Forms.Panel();
            this.ExtandPanel = new System.Windows.Forms.Panel();
            this.NumLabel = new System.Windows.Forms.Label();
            this.TypeOfRatingLabel = new System.Windows.Forms.Label();
            this.TypeOfRatingComboBox = new System.Windows.Forms.ComboBox();
            this.CreateTestButton = new System.Windows.Forms.Button();
            this.ThemeTextBox = new System.Windows.Forms.TextBox();
            this.ThemeLabel = new System.Windows.Forms.Label();
            this.NameTestLabel = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.TypeOfQuestionLabel = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.NumberOFQuestionLabel = new System.Windows.Forms.Label();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.CreateQuestionPanel = new System.Windows.Forms.Panel();
            this.QuestionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.BoldToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ItalicToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.UnderLineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.MoveQuestionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveTestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PreviewQuestionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PreviewTestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsTestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BackButton = new System.Windows.Forms.Button();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.CreateTestPanel.SuspendLayout();
            this.ExtandPanel.SuspendLayout();
            this.CreateQuestionPanel.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Location = new System.Drawing.Point(677, 414);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Далее";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // NameTestTextBox
            // 
            this.NameTestTextBox.Location = new System.Drawing.Point(143, 27);
            this.NameTestTextBox.Name = "NameTestTextBox";
            this.NameTestTextBox.Size = new System.Drawing.Size(630, 20);
            this.NameTestTextBox.TabIndex = 1;
            // 
            // NumTextBox
            // 
            this.NumTextBox.Location = new System.Drawing.Point(137, 0);
            this.NumTextBox.Name = "NumTextBox";
            this.NumTextBox.Size = new System.Drawing.Size(100, 20);
            this.NumTextBox.TabIndex = 4;
            // 
            // CreateTestPanel
            // 
            this.CreateTestPanel.Controls.Add(this.ExtandPanel);
            this.CreateTestPanel.Controls.Add(this.CreateTestButton);
            this.CreateTestPanel.Controls.Add(this.ThemeTextBox);
            this.CreateTestPanel.Controls.Add(this.ThemeLabel);
            this.CreateTestPanel.Controls.Add(this.NameTestLabel);
            this.CreateTestPanel.Controls.Add(this.NameTestTextBox);
            this.CreateTestPanel.Location = new System.Drawing.Point(12, 25);
            this.CreateTestPanel.Name = "CreateTestPanel";
            this.CreateTestPanel.Size = new System.Drawing.Size(780, 255);
            this.CreateTestPanel.TabIndex = 5;
            // 
            // ExtandPanel
            // 
            this.ExtandPanel.Controls.Add(this.NumLabel);
            this.ExtandPanel.Controls.Add(this.TypeOfRatingLabel);
            this.ExtandPanel.Controls.Add(this.NumTextBox);
            this.ExtandPanel.Controls.Add(this.TypeOfRatingComboBox);
            this.ExtandPanel.Location = new System.Drawing.Point(6, 79);
            this.ExtandPanel.Name = "ExtandPanel";
            this.ExtandPanel.Size = new System.Drawing.Size(258, 49);
            this.ExtandPanel.TabIndex = 19;
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.Image = ((System.Drawing.Image)(resources.GetObject("NumLabel.Image")));
            this.NumLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NumLabel.Location = new System.Drawing.Point(-3, 3);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(135, 13);
            this.NumLabel.TabIndex = 3;
            this.NumLabel.Text = "     Количество вопросов:";
            // 
            // TypeOfRatingLabel
            // 
            this.TypeOfRatingLabel.AutoSize = true;
            this.TypeOfRatingLabel.Location = new System.Drawing.Point(-3, 29);
            this.TypeOfRatingLabel.Name = "TypeOfRatingLabel";
            this.TypeOfRatingLabel.Size = new System.Drawing.Size(83, 13);
            this.TypeOfRatingLabel.TabIndex = 20;
            this.TypeOfRatingLabel.Text = "     Тип оценки:";
            // 
            // TypeOfRatingComboBox
            // 
            this.TypeOfRatingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOfRatingComboBox.FormattingEnabled = true;
            this.TypeOfRatingComboBox.Location = new System.Drawing.Point(137, 26);
            this.TypeOfRatingComboBox.Name = "TypeOfRatingComboBox";
            this.TypeOfRatingComboBox.Size = new System.Drawing.Size(121, 21);
            this.TypeOfRatingComboBox.TabIndex = 19;
            this.TypeOfRatingComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeOfRatingComboBox_SelectedIndexChanged);
            // 
            // CreateTestButton
            // 
            this.CreateTestButton.AutoSize = true;
            this.CreateTestButton.Location = new System.Drawing.Point(143, 185);
            this.CreateTestButton.Name = "CreateTestButton";
            this.CreateTestButton.Size = new System.Drawing.Size(84, 23);
            this.CreateTestButton.TabIndex = 18;
            this.CreateTestButton.Text = "Создать тест";
            this.CreateTestButton.UseVisualStyleBackColor = true;
            this.CreateTestButton.Click += new System.EventHandler(this.CreateTestButton_Click);
            // 
            // ThemeTextBox
            // 
            this.ThemeTextBox.Location = new System.Drawing.Point(143, 53);
            this.ThemeTextBox.Name = "ThemeTextBox";
            this.ThemeTextBox.Size = new System.Drawing.Size(630, 20);
            this.ThemeTextBox.TabIndex = 2;
            // 
            // ThemeLabel
            // 
            this.ThemeLabel.AutoSize = true;
            this.ThemeLabel.Image = global::SCTT.Properties.Resources.Theme;
            this.ThemeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThemeLabel.Location = new System.Drawing.Point(3, 56);
            this.ThemeLabel.Name = "ThemeLabel";
            this.ThemeLabel.Size = new System.Drawing.Size(72, 13);
            this.ThemeLabel.TabIndex = 5;
            this.ThemeLabel.Text = "     Тематика";
            // 
            // NameTestLabel
            // 
            this.NameTestLabel.AutoSize = true;
            this.NameTestLabel.Image = SCTT.Properties.Resources.Name;
            this.NameTestLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NameTestLabel.Location = new System.Drawing.Point(3, 30);
            this.NameTestLabel.Name = "NameTestLabel";
            this.NameTestLabel.Size = new System.Drawing.Size(106, 13);
            this.NameTestLabel.TabIndex = 0;
            this.NameTestLabel.Text = "     Название теста:";
            this.NameTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(90, 53);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(354, 21);
            this.TypeComboBox.TabIndex = 15;
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // TypeOfQuestionLabel
            // 
            this.TypeOfQuestionLabel.AutoSize = true;
            this.TypeOfQuestionLabel.Location = new System.Drawing.Point(3, 56);
            this.TypeOfQuestionLabel.Name = "TypeOfQuestionLabel";
            this.TypeOfQuestionLabel.Size = new System.Drawing.Size(74, 13);
            this.TypeOfQuestionLabel.TabIndex = 14;
            this.TypeOfQuestionLabel.Text = "Тип вопроса:";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(3, 82);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(47, 13);
            this.QuestionLabel.TabIndex = 8;
            this.QuestionLabel.Text = "Вопрос:";
            // 
            // NumberOFQuestionLabel
            // 
            this.NumberOFQuestionLabel.AutoSize = true;
            this.NumberOFQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOFQuestionLabel.Location = new System.Drawing.Point(20, 30);
            this.NumberOFQuestionLabel.Name = "NumberOFQuestionLabel";
            this.NumberOFQuestionLabel.Size = new System.Drawing.Size(66, 13);
            this.NumberOFQuestionLabel.TabIndex = 7;
            this.NumberOFQuestionLabel.Text = "Вопрос №";
            // 
            // CreateQuestionPanel
            // 
            this.CreateQuestionPanel.Controls.Add(this.QuestionRichTextBox);
            this.CreateQuestionPanel.Controls.Add(this.ToolStrip);
            this.CreateQuestionPanel.Controls.Add(this.TypeComboBox);
            this.CreateQuestionPanel.Controls.Add(this.TypeOfQuestionLabel);
            this.CreateQuestionPanel.Controls.Add(this.QuestionLabel);
            this.CreateQuestionPanel.Controls.Add(this.NumberOFQuestionLabel);
            this.CreateQuestionPanel.Location = new System.Drawing.Point(798, 25);
            this.CreateQuestionPanel.Name = "CreateQuestionPanel";
            this.CreateQuestionPanel.Size = new System.Drawing.Size(797, 165);
            this.CreateQuestionPanel.TabIndex = 12;
            this.CreateQuestionPanel.Visible = false;
            // 
            // QuestionRichTextBox
            // 
            this.QuestionRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.QuestionRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionRichTextBox.Location = new System.Drawing.Point(90, 79);
            this.QuestionRichTextBox.Name = "QuestionRichTextBox";
            this.QuestionRichTextBox.Size = new System.Drawing.Size(648, 80);
            this.QuestionRichTextBox.TabIndex = 1;
            this.QuestionRichTextBox.Text = "";
            this.QuestionRichTextBox.SelectionIndent = 40;
            this.QuestionRichTextBox.SelectionRightIndent = 10;
            this.QuestionRichTextBox.SelectionHangingIndent = -30;
            //this.QuestionRichTextBox.SelectionIndent = 40;
            //this.QuestionRichTextBox.SelectionRightIndent = 10;
            //this.QuestionRichTextBox.SelectionHangingIndent = -30;
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BoldToolStripButton,
            this.ItalicToolStripButton,
            this.UnderLineToolStripButton,
            this.MoveQuestionToolStripButton,
            this.SaveTestToolStripButton,
            this.PreviewQuestionToolStripButton,
            this.PreviewTestToolStripButton,
            this.SaveAsTestToolStripButton});
            this.ToolStrip.Location = new System.Drawing.Point(141, 18);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(196, 25);
            this.ToolStrip.TabIndex = 16;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // BoldToolStripButton
            // 
            this.BoldToolStripButton.CheckOnClick = true;
            this.BoldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BoldToolStripButton.Image = global::SCTT.Properties.Resources.Bold;
            this.BoldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BoldToolStripButton.Name = "BoldToolStripButton";
            this.BoldToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.BoldToolStripButton.Text = "Полужирный";
            this.BoldToolStripButton.ToolTipText = "Полужирный";
            this.BoldToolStripButton.CheckStateChanged += new System.EventHandler(this.BoldToolStripButton_CheckStateChanged);
            // 
            // ItalicToolStripButton
            // 
            this.ItalicToolStripButton.CheckOnClick = true;
            this.ItalicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItalicToolStripButton.Image = global::SCTT.Properties.Resources.Italic;
            this.ItalicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItalicToolStripButton.Name = "ItalicToolStripButton";
            this.ItalicToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItalicToolStripButton.Text = "Курсив";
            this.ItalicToolStripButton.CheckStateChanged += new System.EventHandler(this.ItalicToolStripButton_CheckStateChanged);
            // 
            // UnderLineToolStripButton
            // 
            this.UnderLineToolStripButton.CheckOnClick = true;
            this.UnderLineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UnderLineToolStripButton.Image = global::SCTT.Properties.Resources.Underline;
            this.UnderLineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UnderLineToolStripButton.Name = "UnderLineToolStripButton";
            this.UnderLineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.UnderLineToolStripButton.Text = "Подчеркнутый";
            this.UnderLineToolStripButton.CheckStateChanged += new System.EventHandler(this.UnderLineToolStripButton_CheckStateChanged);
            // 
            // MoveQuestionToolStripButton
            // 
            this.MoveQuestionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveQuestionToolStripButton.Image = global::SCTT.Properties.Resources.Move;
            this.MoveQuestionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveQuestionToolStripButton.Name = "MoveQuestionToolStripButton";
            this.MoveQuestionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.MoveQuestionToolStripButton.Text = "Изменить номер вопроса";
            this.MoveQuestionToolStripButton.Click += new System.EventHandler(this.MoveQuestionToolStripButton_Click);
            // 
            // SaveTestToolStripButton
            // 
            this.SaveTestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveTestToolStripButton.Image = global::SCTT.Properties.Resources.Save;
            this.SaveTestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveTestToolStripButton.Name = "SaveTestToolStripButton";
            this.SaveTestToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveTestToolStripButton.Text = "Сохранить тест";
            this.SaveTestToolStripButton.Click += new System.EventHandler(this.SaveTestToolStripButton_Click);
            // 
            // PreviewQuestionToolStripButton
            // 
            this.PreviewQuestionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PreviewQuestionToolStripButton.Image = global::SCTT.Properties.Resources.Preview;
            this.PreviewQuestionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviewQuestionToolStripButton.Name = "PreviewQuestionToolStripButton";
            this.PreviewQuestionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.PreviewQuestionToolStripButton.Text = "Предпросмотр вопроса";
            this.PreviewQuestionToolStripButton.Click += new System.EventHandler(this.PreviewQuestionToolStripButton_Click);
            // 
            // PreviewTestToolStripButton
            // 
            this.PreviewTestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PreviewTestToolStripButton.Image = global::SCTT.Properties.Resources.Preview;
            this.PreviewTestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviewTestToolStripButton.Name = "PreviewTestToolStripButton";
            this.PreviewTestToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.PreviewTestToolStripButton.Text = "Предпросмотр теста";
            this.PreviewTestToolStripButton.Click += new System.EventHandler(this.PreviewTestToolStripButton_Click);
            // 
            // SaveAsTestToolStripButton
            // 
            this.SaveAsTestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsTestToolStripButton.Image = global::SCTT.Properties.Resources.SaveAs;
            this.SaveAsTestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsTestToolStripButton.Name = "SaveAsTestToolStripButton";
            this.SaveAsTestToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveAsTestToolStripButton.Text = "Сохранить как...";
            this.SaveAsTestToolStripButton.Click += new System.EventHandler(this.SaveAsTestToolStripButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Location = new System.Drawing.Point(23, 414);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 18;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "Файл теста|*.SCTT";
            // 
            // EndTestButton
            // 
            this.EndTestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EndTestButton.Location = new System.Drawing.Point(342, 414);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Size = new System.Drawing.Size(148, 23);
            this.EndTestButton.TabIndex = 19;
            this.EndTestButton.Text = "Завершить тестирование";
            this.EndTestButton.UseVisualStyleBackColor = true;
            this.EndTestButton.Visible = false;
            this.EndTestButton.Click += new System.EventHandler(this.EndTestButton_Click);
            // 
            // CreateTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 486);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CreateQuestionPanel);
            this.Controls.Add(this.CreateTestPanel);
            this.Controls.Add(this.NextButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(810, 525);
            this.Name = "CreateTest";
            this.Text = "Составление теста";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateTest_FormClosing);
            this.Load += new System.EventHandler(this.CreateTest_Load);
            this.SizeChanged += new System.EventHandler(this.CreateTest_SizeChanged);
            this.CreateTestPanel.ResumeLayout(false);
            this.CreateTestPanel.PerformLayout();
            this.ExtandPanel.ResumeLayout(false);
            this.ExtandPanel.PerformLayout();
            this.CreateQuestionPanel.ResumeLayout(false);
            this.CreateQuestionPanel.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label NumLabel;
        private System.Windows.Forms.TextBox NameTestTextBox;
        private System.Windows.Forms.TextBox NumTextBox;
        private System.Windows.Forms.Label NameTestLabel;
        private System.Windows.Forms.Panel CreateTestPanel;
        private System.Windows.Forms.TextBox ThemeTextBox;
        private System.Windows.Forms.Label ThemeLabel;
        private System.Windows.Forms.Label NumberOFQuestionLabel;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label TypeOfQuestionLabel;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Button CreateTestButton;
        private System.Windows.Forms.Panel CreateQuestionPanel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton BoldToolStripButton;
        private System.Windows.Forms.ToolStripButton ItalicToolStripButton;
        private System.Windows.Forms.ToolStripButton UnderLineToolStripButton;
        private System.Windows.Forms.RichTextBox QuestionRichTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ToolStripButton MoveQuestionToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveTestToolStripButton;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.ToolStripButton PreviewQuestionToolStripButton;
        private System.Windows.Forms.ToolStripButton PreviewTestToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveAsTestToolStripButton;
        private System.Windows.Forms.Label TypeOfRatingLabel;
        private System.Windows.Forms.ComboBox TypeOfRatingComboBox;
        private System.Windows.Forms.Panel ExtandPanel;
        private System.Windows.Forms.Button EndTestButton;
    }
}