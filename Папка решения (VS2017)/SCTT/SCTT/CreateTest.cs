using ClassLibrarySCTT;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SCTT
{
    public partial class CreateTest : Form
    {
#region Поля
        private Test _TestObject;
        private MoveQuestion MoveQuestionForm;
        private PreviewQuestion PreviewQuestionForm;
        private PreviewTest PreviewTestForm;
        private Form StartForm;
        private Result ResultForm;
        private bool _FlagOfTesting;
#endregion

        /// <summary>
        /// Возвращает или задает экземпляр класса Test.
        /// </summary>
        public Test TestObject
        {
            set { _TestObject = value; }
            get { return _TestObject; }
        }
        /// <summary>
        /// Задает значение, определяющее режим тестирования.
        /// </summary>
        public bool FlagOfTesting
        {
            set { _FlagOfTesting = value; }
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса SCTT.CreateForm.
        /// </summary>
        /// <param name="StartForm"> Форма главного меню. </param>
        public CreateTest(Form StartForm)
        {
            this.StartForm = StartForm;
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик события Form.Load.
        /// </summary>
        private void CreateTest_Load(object sender, EventArgs e)
        {
            TypeComboBox.Items.Add("стандартный вопрос с одним ответом.");
            TypeComboBox.Items.Add("стандартный вопрос с несколькими ответами.");
            TypeComboBox.Items.Add("вопрос-сопоставление.");
            TypeComboBox.Items.Add("вопрос-сортировка.");
            TypeComboBox.Items.Add("");
            TypeOfRatingComboBox.Items.Add("оценка.");
            TypeOfRatingComboBox.Items.Add("зачет/не зачет");
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку создания теста.
        /// </summary>
        private void CreateTestButton_Click(object sender, EventArgs e)
        {
            if (!_FlagOfTesting)
            {
                try
                {
                    _TestObject = new Test(this, NameTestTextBox, ThemeTextBox, NumTextBox, TypeOfRatingComboBox);
                    Text += " [" + _TestObject.Name + "]";
                    CreateTestPanel.Dispose();
                    CreateQuestionPanel.Location = new Point(3, 8);
                    CreateQuestionPanel.Visible = true;
                    _TestObject.Reconstitute(this, _TestObject.GetQuestion(_TestObject._Counter), false);
                    BackButton.Enabled = false;
                    BackButton.Visible = true;
                    NextButton.Visible = true;
                    if (_TestObject.NumOfQuestions == 1) NextButton.Visible = false;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Внимание!");
                }
            }
            else
            {
                _TestObject.ParamOfPerson = new string[2];
                _TestObject.ParamOfPerson[0] = NameTestTextBox.Text;
                _TestObject.ParamOfPerson[1] = ThemeTextBox.Text;
                _TestObject.Answers = new string[_TestObject.NumOfQuestions];
                _TestObject.ParamOfPerson = new string[2];
                try
                {
                    if (NameTestTextBox.Text == "") throw new FormatException("Введите Ф.И.О.");
                    else _TestObject.ParamOfPerson[0] = NameTestTextBox.Text;
                    if (ThemeTextBox.Text == "") throw new FormatException("Введите группу/класс.");
                    else _TestObject.ParamOfPerson[1] = ThemeTextBox.Text;
                    CreateQuestionPanel.Visible = true;
                    CreateTestPanel.Dispose();
                    BackButton.Visible = true;
                    NextButton.Visible = true;
                    EndTestButton.Visible = true;
                    if (_TestObject.NumOfQuestions == 1) NextButton.Visible = false;
                    _TestObject._Counter = 1;
                    _TestObject.Reconstitute(this, _TestObject.GetQuestion(1), true);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Внимание!");
                } 
            }
        }
        /// <summary>
        /// Обработчик события изменения размеров окна.
        /// </summary>
        private void CreateTest_SizeChanged(object sender, EventArgs e)
        {
            if (CreateTestPanel.Visible)
            {
                CreateTestPanel.Width = Size.Width - 40;
                NameTestTextBox.Width = CreateTestPanel.Width - 160;
                ThemeTextBox.Width = CreateTestPanel.Width - 160;
            }
            else
            {
                if (_FlagOfTesting) _TestObject.PreviewPanel.Size = new Size(Size.Width - 40, Size.Height - 320);
                else _TestObject.Panel.Size = new Size(Size.Width - 40, Size.Height - 320);
                CreateQuestionPanel.Width = Size.Width - 40;
                foreach (RichTextBox elem in _TestObject.Controls)
                {
                    if(_FlagOfTesting) elem.Width = _TestObject.PreviewPanel.Width - 100;
                    else elem.Width = _TestObject.Panel.Width - 100;
                }
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку "Далее".
        /// </summary>
        private void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                _TestObject.SaveAndGo(this, NextButton, _TestObject.GetQuestion(_TestObject._Counter), _FlagOfTesting);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
        }
        /// <summary>
        /// Обработчик события изменения индекса переключателя типа вопроса.
        /// </summary>
        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _TestObject.SettingType(this, _TestObject.GetQuestion(_TestObject._Counter));
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку "Назад".
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                _TestObject.SaveAndGo(this, BackButton, _TestObject.GetQuestion(_TestObject._Counter), _FlagOfTesting);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
            
        }
        /// <summary>
        /// Обработчик события закрытия формы.
        /// </summary>
        private void CreateTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_FlagOfTesting)
            {
                if (EndTestButton.Enabled)
                {
                    if (_TestObject.ParamOfPerson != null)
                    {
                        DialogResult Result = MessageBox.Show(
                                "Завершить тестирование?",
                                "Внимание!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button2);
                        if (Result == DialogResult.Yes)
                        {
                            _TestObject.CalculateResult(StartForm, ResultForm);
                            StartForm.Visible = true;
                        }
                        else e.Cancel = true;
                    }
                }
            }
            else
            {
                try
                {
                    DialogResult Result = MessageBox.Show(
                            "Закрыть редактор теста?",
                            "Внимание!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button2);
                    if (Result == DialogResult.No) e.Cancel = true;
                    else
                    {
                        if (_TestObject != null) _TestObject.SaveTest(this, _TestObject, TestObject.FileName);
                        StartForm.Visible = true;
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Внимание!");
                    e.Cancel = true;
                }
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку установки полужирного шрифта.
        /// </summary>
        private void BoldToolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            _TestObject.SetFontStyleRichtextBox(BoldToolStripButton);
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку установки курсива.
        /// </summary>
        private void ItalicToolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            _TestObject.SetFontStyleRichtextBox(ItalicToolStripButton);
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку установки подчеркнутого шрифта.
        /// </summary>
        private void UnderLineToolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            _TestObject.SetFontStyleRichtextBox(UnderLineToolStripButton);
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку смены номера вопроса.
        /// </summary>
        private void MoveQuestionToolStripButton_Click(object sender, EventArgs e)
        {
            MoveQuestionForm = new MoveQuestion(_TestObject, this);
            Enabled = false;
            MoveQuestionForm.Show();
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку сохранения теста.
        /// </summary>
        private void SaveTestToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _TestObject.SaveTest(this, _TestObject, TestObject.FileName);
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку предпросмотра вопроса.
        /// </summary>
        private void PreviewQuestionToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                PreviewQuestionForm = new PreviewQuestion(this, _TestObject.GetQuestion(_TestObject._Counter));
                PreviewQuestionForm.Show();
                PreviewQuestionForm.Size = Size;
                Enabled = false;
                _TestObject.SaveQuestion(this, _TestObject.GetQuestion(_TestObject._Counter), false);
                _TestObject.PreviewQuestion(PreviewQuestionForm);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку предпросмотра теста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewTestToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                PreviewTestForm = new PreviewTest(this);
                PreviewTestForm.Show();
                Enabled = false;
                _TestObject.SaveQuestion(this, _TestObject.GetQuestion(_TestObject._Counter), false);
                _TestObject.PreviewTest(PreviewTestForm);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку "Сохранить как...".
        /// </summary>
        /// <param name="sender"></param>
        private void SaveAsTestToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _TestObject.FileName = SaveFileDialog.FileName;
                    _TestObject.SaveTest(this, _TestObject, TestObject.FileName);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
        }
        /// <summary>
        /// Обработчик события изменения индекса переключателя типа оценки тестируемого.
        /// </summary>
        private void TypeOfRatingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Num = Int32.Parse(NumTextBox.Text);
                if (Controls.Find("TypeOfRatingPanel", true).Length != 0) Controls.Find("TypeOfRatingPanel", true)[0].Dispose();
                Panel TypeOfRatingPanel = new Panel();
                TypeOfRatingPanel.SuspendLayout();
                TypeOfRatingPanel.Location = new Point(3, 134);
                TypeOfRatingPanel.Name = "TypeOfRatingPanel";
                TypeOfRatingPanel.Size = new Size(500, 70);
                switch (TypeOfRatingComboBox.SelectedIndex)
                {
                    case 0:
                        Label _LabelM = new Label();
                        _LabelM.AutoSize = true;
                        _LabelM.Location = new Point(0, 4);
                        _LabelM.Name = "RatingLabel";
                        _LabelM.Text = "Баллов для оценки:";
                        TypeOfRatingPanel.Controls.Add(_LabelM);
                        for (int i = 1; i <= 3; i++)
                        {
                            Label _Label = new Label();
                            _Label.AutoSize = true;
                            _Label.Location = new Point(143 + (i - 1) * 60, 4);
                            _Label.Name = "RatingLabel" + i;
                            _Label.Text = (6 - i) + ".";
                            TypeOfRatingPanel.Controls.Add(_Label);

                            ComboBox _ComboBoxTemp = new ComboBox();
                            _ComboBoxTemp.FormattingEnabled = true;
                            _ComboBoxTemp.Location = new Point(163 + (i - 1) * 60, 0);
                            _ComboBoxTemp.Name = "ComboBox" + i;
                            _ComboBoxTemp.Size = new Size(35, 21);
                            _ComboBoxTemp.DropDownStyle = ComboBoxStyle.DropDownList;
                            for (int j = 1; j <= Num; j++)
                            {
                                _ComboBoxTemp.Items.Add(j);
                            }
                            TypeOfRatingPanel.Controls.Add(_ComboBoxTemp);
                        }
                        CreateTestPanel.Controls.Add(TypeOfRatingPanel);
                        TypeOfRatingPanel.ResumeLayout(false);
                        TypeOfRatingPanel.PerformLayout();
                        break;
                    case 1:
                        Label _LabelMT = new Label();
                        _LabelMT.AutoSize = true;
                        _LabelMT.Location = new Point(0, 4);
                        _LabelMT.Name = "RatingLabel";
                        _LabelMT.Text = "Баллов для зачета:";
                        TypeOfRatingPanel.Controls.Add(_LabelMT);

                        ComboBox _ComboBoxTempT = new ComboBox();
                        _ComboBoxTempT.FormattingEnabled = true;
                        _ComboBoxTempT.Location = new Point(143, 4);
                        _ComboBoxTempT.Name = "_ComboBox";
                        _ComboBoxTempT.Size = new Size(35, 21);
                        _ComboBoxTempT.DropDownStyle = ComboBoxStyle.DropDownList;
                        for (int j = 1; j <= Num; j++)
                        {
                            _ComboBoxTempT.Items.Add(j);
                        }
                        TypeOfRatingPanel.Controls.Add(_ComboBoxTempT);
                        CreateTestPanel.Controls.Add(TypeOfRatingPanel);
                        TypeOfRatingPanel.ResumeLayout(false);
                        TypeOfRatingPanel.PerformLayout();
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Не установлено количесто вопросов.", "Внимание!");
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку зваршения тестирования.
        /// </summary>
        private void EndTestButton_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show(
                            "Завершить тестирование?",
                            "Внимание!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button2);
            if (Result == DialogResult.Yes)
            {
                try
                {
                    _TestObject.SaveQuestion(this, _TestObject.GetQuestion(_TestObject._Counter), true);
                    EndTestButton.Enabled = false;
                    Close();
                    _TestObject.CalculateResult(StartForm, new Result(StartForm));
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Внимание!");
                }
            }
        }
    }
}
