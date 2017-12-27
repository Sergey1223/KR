namespace SCTT
{
    partial class PreviewTest
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
            this.TableDataGridView = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TableDataGridView
            // 
            this.TableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Question});
            this.TableDataGridView.Location = new System.Drawing.Point(12, 12);
            this.TableDataGridView.Name = "TableDataGridView";
            this.TableDataGridView.Size = new System.Drawing.Size(910, 576);
            this.TableDataGridView.TabIndex = 0;
            // 
            // Number
            // 
            this.Number.HeaderText = "№";
            this.Number.Name = "Number";
            // 
            // Question
            // 
            this.Question.HeaderText = "Вопрос";
            this.Question.Name = "Question";
            // 
            // PreviewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 600);
            this.Controls.Add(this.TableDataGridView);
            this.Name = "PreviewTest";
            this.Text = "Предпросмотр теста";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewTest_FormClosingEventHandler);
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Question;
    }
}