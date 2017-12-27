using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ClassLibrarySCTT
{
    [Serializable]
    public enum TypeOfRating { Rating, Test }

    [Serializable]
    public class Test
    {
        #region Поля
        private const int NumOfElements = 10;
        private string _Name;
        private string Theme;
        private string _FileName;
        private string[] _Answers;
        private string[] _ParamOfPerson;
        private TypeOfRating _TypeOfRating;
        private int _NumOfQuestions;
        [NonSerialized]
        private int OldIndexOfNumericUpDown;
        [NonSerialized]
        private int OldIndexOfComboBox;
        [NonSerialized]
        private int Counter = 1;
        private int[] Ratings;
        [NonSerialized]
        private bool FlagOfCancel;
        [NonSerialized]
        private bool FlagReadOnly;
        private LinkedList<Question> _Questions;
        public ArrayList _Controls;
        [NonSerialized]
        private Panel TempPanel;
        [NonSerialized]
        private Panel _PreviewPanel;
#endregion

#region Свойства
        /// <summary>
        /// Возвращает или задает путь файла теста.
        /// </summary>
        public string FileName
        {
            set { _FileName = value; }
            get { return _FileName; }
        }
        /// <summary>
        /// Возвращает имя теста
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }
        /// <summary>
        /// Устанавливает массив ответов пользователя при тестировании.
        /// </summary>
        public string[] Answers
        {
            set { _Answers = value; }
        }
        /// <summary>
        /// Возвращает или задает массив данных пользователя при тестировании.
        /// </summary>
        public string[] ParamOfPerson
        {
            set { _ParamOfPerson = value; }
            get { return _ParamOfPerson; }
        }
        /// <summary>
        /// Возвращает или задает указатель на вопрос.
        /// </summary>
        public int _Counter
        {
            set { Counter = value; }
            get { return Counter; }
        }
        /// <summary>
        /// Возвращает общее число вопросов в тесте.
        /// </summary>
        public int NumOfQuestions
        {
            get { return _NumOfQuestions; }
        }
        /// <summary>
        /// Возвращает или задает коллекцию элементов, размеры которых следует изменить при изменении размеров окна.
        /// </summary>
        public ArrayList Controls
        {
            set { _Controls = value; }
            get { return _Controls; }
        }
        /// <summary>
        /// Возвращает панель Panel.
        /// </summary>
        public Panel Panel
        {
            get { return TempPanel; }
        }
        /// <summary>
        /// Возвращает панель PreviewPanel.
        /// </summary>
        public Panel PreviewPanel
        {
            get { return _PreviewPanel; }
        }
        #endregion

        /// <summary>
        /// Инициализирует новый эеземпляр класса ClassLibrarySCTT.Test.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        /// <param name="Name"> Название теста. </param>
        /// <param name="Theme"> Тематика теста. </param>
        /// <param name="NumOfQuestions"> Число вопросов в тесте. </param>
        /// <param name="TypeOfRating"> Тип оценки тестируемого. </param>
        public Test(Form InputForm, TextBox Name, TextBox Theme, TextBox NumOfQuestions, ComboBox TypeOfRating)
        {
            _Name = Name.Text;
            _FileName = _Name;
            this.Theme = Theme.Text;
            try
            {
                _NumOfQuestions = Int32.Parse(NumOfQuestions.Text);
            }
            catch (FormatException)
            {
                throw new FormatException("Количество вопросов должно быть числом.");
            }
            if (TypeOfRating.SelectedIndex == 0)
            {
                _TypeOfRating = ClassLibrarySCTT.TypeOfRating.Rating;
                Ratings = new int[3];
                for (int i = 1; i <= 3; i++)
                {
                    ComboBox _ComboBox = (ComboBox)InputForm.Controls.Find("ComboBox" + i, true)[0];
                    if (_ComboBox.SelectedItem == null) throw new FormatException("Не выбрано количество баллов для оценки.");
                    Ratings[i - 1] = _ComboBox.SelectedIndex + 1;
                }
            }
            else if (TypeOfRating.SelectedIndex == 1)
            {
                ComboBox _ComboBox = (ComboBox)InputForm.Controls.Find("_ComboBox", true)[0];
                if (_ComboBox.SelectedItem == null) throw new FormatException("Не выбрано количество баллов для зачета.");
                _TypeOfRating = ClassLibrarySCTT.TypeOfRating.Test;
                Ratings = new int[1] { _ComboBox.SelectedIndex + 1 };
            }
            else throw new FormatException("Не выбран тип оценки тестируемого.");
            _Questions = new LinkedList<Question>();
            for (int i = 0; i < _NumOfQuestions; i++) _Questions.AddLast(new Question((i + 1)));
            _Controls = new ArrayList();
        }
        /// <summary>
        /// Возвращает элемент списка по индексу.
        /// </summary>
        /// <param name="Index"> Индекс. </param>
        /// <returns> Элемент типа Question колллекции. </returns>
        public Question GetQuestion(int Index)
        {
            LinkedList<Question>.Enumerator _Enumerator = _Questions.GetEnumerator();
            for (int i = 0; i < Index; i++) _Enumerator.MoveNext();
            return _Enumerator.Current;
        }
        /// <summary>
        /// Воссоздает вопрос.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        /// <param name="_Question"> Воссоздаваемый вопрос. </param>
        /// <param name="ReadOnly"> Флаг "только для чтения", запрещает редактирование вопроса после воссоздания. </param>
        public void Reconstitute(Form InputForm, Question _Question, bool ReadOnly)
        {
            Label NumberOFQuestionLabel = (Label)InputForm.Controls.Find("NumberOFQuestionLabel", true)[0];
            RichTextBox QuestionRichTextBox = (RichTextBox)InputForm.Controls.Find("QuestionRichTextBox", true)[0];
            ComboBox TypeComboBox = (ComboBox)InputForm.Controls.Find("TypeComboBox", true)[0];
            TypeComboBox.SelectedIndex = 4;
            _Controls.Add(QuestionRichTextBox);
            if (ReadOnly) FlagReadOnly = true;
            else FlagReadOnly = false;
            NumberOFQuestionLabel.Text = "Вопрос №" + _Question.Number;
            QuestionRichTextBox.Rtf = _Question.Text;
            switch (_Question.Type)
            {
                case Type.Standart:
                    TypeComboBox.SelectedIndex = 0;
                    break;
                case Type.StandartM:
                    TypeComboBox.SelectedIndex = 1;
                    break;
                case Type.Comparison:
                    TypeComboBox.SelectedIndex = 2;
                    break;
                case Type.Sequence:
                    TypeComboBox.SelectedIndex = 3;
                    break;
            }
            OldIndexOfComboBox = TypeComboBox.SelectedIndex;
        }
        /// <summary>
        /// Устанавливает необходимые элементы на форме, в зависимости от типа вопроса.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        /// <param name="_Question"> Вопрос, тип которого необходимо изменить. </param>
        public void SettingType(Form InputForm, Question _Question)
        {
            ComboBox _Type = (ComboBox)InputForm.Controls.Find("TypeComboBox", true)[0];
            if (_Type.SelectedIndex == 4) ;
            else
            {
                if (!FlagOfCancel)
                {
                    if (_Type.FindForm().Controls.Find("SetChoicePanel", false).Length != 0)
                    {
                        DialogResult Result = MessageBox.Show(
                                "Вы уверены, что хотите сменить тип вопроса, введенные данные будут утеряны.",
                                "Внимание!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button2);
                        if (Result == DialogResult.No)
                        {
                            FlagOfCancel = true;
                            _Type.SelectedIndex = OldIndexOfComboBox;
                        }
                        else
                        {
                            _Type.FindForm().MinimumSize = new Size(810, 525);
                            _Type.FindForm().Controls.Find("SetChoicePanel", false)[0].Dispose();
                            _Controls.Clear();
                            OldIndexOfComboBox = _Type.SelectedIndex;
                            _Type.SelectedIndex = 4;
                            _Type.SelectedIndex = OldIndexOfComboBox;
                        }
                    }
                    else
                    {
                        _Type.FindForm().MinimumSize = new Size(810, 525);

                        Panel _Panel = new Panel();
                        _Panel.SuspendLayout();
                        _Panel.Location = new Point(3, 196);
                        _Panel.Name = "SetChoicePanel";
                        _Panel.Size = new Size(InputForm.Width - 40, InputForm.Height - 320);
                        _Panel.TabIndex = 20;
                        if (FlagReadOnly) _PreviewPanel = _Panel;
                        else TempPanel = _Panel;

                        Label _NumOfCoicesLabel = new Label();
                        _NumOfCoicesLabel.AutoSize = true;
                        _NumOfCoicesLabel.Location = new Point(6, 22);
                        _NumOfCoicesLabel.Name = "NumOfChoicesLabel";
                        _NumOfCoicesLabel.Size = new Size(98, 13);
                        _NumOfCoicesLabel.TabIndex = 20;
                        _NumOfCoicesLabel.Text = "Число вариантов:";
                        if (FlagReadOnly) _NumOfCoicesLabel.Visible = false;

                        NumericUpDown _NumericUpDown = new NumericUpDown();
                        _NumericUpDown.Location = new Point(110, 19);
                        _NumericUpDown.Name = "NumOfCoicesNumericUpDown";
                        _NumericUpDown.Size = new Size(40, 22);
                        _NumericUpDown.TabIndex = 19;
                        _NumericUpDown.ReadOnly = true;
                        _NumericUpDown.ValueChanged += NumOfCoicesNumericUpDown_ValueChanged;
                        if (FlagReadOnly) _NumericUpDown.Visible = false;

                        _Panel.Controls.Add(_NumOfCoicesLabel);
                        _Panel.Controls.Add(_NumericUpDown);
                        InputForm.Controls.Add(_Panel);
                        OldIndexOfNumericUpDown = (int)_NumericUpDown.Value;
                        int j = GetQuestion(Counter).Choices.Count;
                        for (int i = 0; i < j; i++)
                        {
                            OldIndexOfNumericUpDown = (int)_NumericUpDown.Value;
                            _NumericUpDown.Value = i + 1;
                        }
                        _Panel.ResumeLayout(false);
                        _Panel.PerformLayout();
                    }  
                }
                else FlagOfCancel = false;
            }
        }
        /// <summary>
        /// Метод, обрабатывающий событие нажатия на перключатель установки числа вариантов в вопросе.
        /// </summary>
        private void NumOfCoicesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!FlagOfCancel)
            {
                NumericUpDown _NumericUpDown = (FlagReadOnly) ? (NumericUpDown)_PreviewPanel.Controls.Find("NumOfCoicesNumericUpDown", false)[0] : (NumericUpDown)TempPanel.Controls.Find("NumOfCoicesNumericUpDown", false)[0];
                ComboBox _ComboBox = (FlagReadOnly) ? (ComboBox)_PreviewPanel.FindForm().Controls.Find("TypeComboBox", true)[0] : (ComboBox)TempPanel.FindForm().Controls.Find("TypeComboBox", true)[0];
                if (_NumericUpDown.Value < OldIndexOfNumericUpDown)
                {
                    if (TempPanel.Controls.Find("RichTextBox" + OldIndexOfNumericUpDown, false)[0].Text == "")
                    {
                        TempPanel.SuspendLayout();
                        switch (_ComboBox.SelectedIndex)
                        {
                            case 0:
                                if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 26);
                                TempPanel.Controls.Find("RadioButton" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                break;
                            case 1:
                                TempPanel.Controls.Find("CheckBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 26);
                                break;
                            case 2:
                                TempPanel.Controls.Find("ComboBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                TempPanel.Controls.Find("RichTextBox" + OldIndexOfNumericUpDown + OldIndexOfNumericUpDown, false)[0].Dispose();
                                _Controls.RemoveAt(_Controls.Count - 1);
                                TempPanel.Controls.Find("Label" + OldIndexOfNumericUpDown + OldIndexOfNumericUpDown, false)[0].Dispose();
                                if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 52);
                                if (_NumericUpDown.Value != 0)
                                {
                                    for (int i = 1; i < OldIndexOfNumericUpDown; i++)
                                    {
                                        TempPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location = new Point(90, TempPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location.Y - 26);
                                        TempPanel.Controls.Find("Label" + i + i, false)[0].Location = new Point(30, TempPanel.Controls.Find("Label" + i + i, false)[0].Location.Y - 26);
                                        ComboBox Temp = (ComboBox)TempPanel.Controls.Find("ComboBox" + i, false)[0];
                                        Temp.Items.Clear();
                                        for (int j = 1; j <= _NumericUpDown.Value; j++) Temp.Items.Add(j);
                                    }
                                }
                                break;
                            case 3:
                                TempPanel.Controls.Find("ComboBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 26);
                                break;
                        }
                        TempPanel.Controls.Find("Label" + OldIndexOfNumericUpDown, false)[0].Dispose();
                        TempPanel.Controls.Find("RichTextBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                        _Controls.RemoveAt(_Controls.Count - 1);
                        GetQuestion(Counter).Choices.Remove(GetQuestion(Counter).Choices[GetQuestion(Counter).Choices.Count - 1]);
                        OldIndexOfNumericUpDown = (int)_NumericUpDown.Value;
                        TempPanel.ResumeLayout(false);
                        TempPanel.PerformLayout();
                    }
                    else
                    {
                        DialogResult Result = MessageBox.Show(
                        "Вы уверены, что хотите уменьшить количество вариантов, введенные данные будут утеряны.",
                        "Внимание!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2);
                        if (Result == DialogResult.No)
                        {
                            FlagOfCancel = true;
                            _NumericUpDown.Value = OldIndexOfNumericUpDown;
                        }
                        else
                        {
                            TempPanel.SuspendLayout();
                            switch (_ComboBox.SelectedIndex)
                            {
                                case 0:
                                    if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 26);
                                    TempPanel.Controls.Find("RadioButton" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                    break;
                                case 1:
                                    if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 26);
                                    TempPanel.Controls.Find("CheckBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                    break;
                                case 2:
                                    TempPanel.Controls.Find("ComboBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                    TempPanel.Controls.Find("RichTextBox" + OldIndexOfNumericUpDown + OldIndexOfNumericUpDown, false)[0].Dispose();
                                    if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 52);
                                    _Controls.RemoveAt(_Controls.Count - 1);
                                    TempPanel.Controls.Find("Label" + OldIndexOfNumericUpDown + OldIndexOfNumericUpDown, false)[0].Dispose();
                                    if (_NumericUpDown.Value != 0)
                                    {
                                        for (int i = 1; i < OldIndexOfNumericUpDown; i++)
                                        {
                                            TempPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location = new Point(90, TempPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location.Y - 26);
                                            TempPanel.Controls.Find("Label" + i + i, false)[0].Location = new Point(30, TempPanel.Controls.Find("Label" + i + i, false)[0].Location.Y - 26);
                                        }
                                    }
                                    break;
                                case 3:
                                    TempPanel.Controls.Find("ComboBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                                    if (OldIndexOfNumericUpDown != 1) _NumericUpDown.FindForm().MinimumSize = new Size(810, _NumericUpDown.FindForm().MinimumSize.Height - 26);
                                    break;
                            }
                            TempPanel.Controls.Find("Label" + OldIndexOfNumericUpDown, false)[0].Dispose();
                            TempPanel.Controls.Find("RichTextBox" + OldIndexOfNumericUpDown, false)[0].Dispose();
                            _Controls.RemoveAt(_Controls.Count - 1);
                            GetQuestion(Counter).Choices.Remove(GetQuestion(Counter).Choices[GetQuestion(Counter).Choices.Count - 1]);
                            OldIndexOfNumericUpDown = (int)_NumericUpDown.Value;
                            TempPanel.ResumeLayout(false);
                            TempPanel.PerformLayout();
                        }
                    }
                }
                else
                {
                    if (_NumericUpDown.Value <= NumOfElements)
                    {
                        if (GetQuestion(Counter).Choices.Count < (int)_NumericUpDown.Value)
                        {
                            GetQuestion(Counter).Choices.Add(new List<string>());
                            GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1].Add("");
                            GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1].Add("");
                        }
                        switch (_ComboBox.SelectedIndex)
                        {
                            case 0:
                                RadioButton _RadioButton = new RadioButton();
                                _RadioButton.AutoSize = true;
                                _RadioButton.Location = new Point(10, (55 + OldIndexOfNumericUpDown * 26));
                                _RadioButton.Name = "RadioButton" + _NumericUpDown.Value;
                                _RadioButton.Size = new Size(14, 13);
                                _RadioButton.TabIndex = 18;
                                _RadioButton.TabStop = true;
                                _RadioButton.UseVisualStyleBackColor = true;
                                if (FlagReadOnly)
                                {
                                    _PreviewPanel.Controls.Add(_RadioButton);
                                    if (_Answers != null && _Answers[Counter - 1] == _NumericUpDown.Value.ToString()) _RadioButton.Checked = true;
                                }
                                else
                                {
                                    TempPanel.Controls.Add(_RadioButton);
                                    if (GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1][0] == "True") _RadioButton.Checked = true;
                                }
                                break;
                            case 1:
                                CheckBox _CheckBox = new CheckBox();
                                _CheckBox.AutoSize = true;
                                _CheckBox.Location = new Point(10, (55 + OldIndexOfNumericUpDown * 26));
                                _CheckBox.Name = "CheckBox" + _NumericUpDown.Value;
                                _CheckBox.UseVisualStyleBackColor = true;

                                if (FlagReadOnly)
                                {
                                    _PreviewPanel.Controls.Add(_CheckBox);
                                    if (_Answers != null && _Answers[Counter - 1] == _NumericUpDown.Value.ToString()) _CheckBox.Checked = true;
                                }
                                else
                                {
                                    TempPanel.Controls.Add(_CheckBox);
                                    if (GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1][0] == "True") _CheckBox.Checked = true;
                                }
                                break;
                            case 2:
                                if (GetQuestion(Counter).ExtendChoices == null) GetQuestion(Counter).ExtendChoices = new List<int>();
                                if (GetQuestion(Counter).ExtendChoices.Count < (int)_NumericUpDown.Value) GetQuestion(Counter).ExtendChoices.Add(1);
                                ComboBox _ComboBoxTemp = new ComboBox();
                                _ComboBoxTemp.FormattingEnabled = true;
                                _ComboBoxTemp.Location = new Point(48, (55 + OldIndexOfNumericUpDown * 26));
                                _ComboBoxTemp.Name = "ComboBox" + _NumericUpDown.Value;
                                _ComboBoxTemp.Size = new Size(35, 21);
                                _ComboBoxTemp.DropDownStyle = ComboBoxStyle.DropDownList;
                                if (FlagReadOnly) _PreviewPanel.Controls.Add(_ComboBoxTemp);
                                else TempPanel.Controls.Add(_ComboBoxTemp);
                                _ComboBoxTemp.Items.Add(1);
                                if (_NumericUpDown.Value == GetQuestion(Counter).ExtendChoices.Count)
                                {
                                    for (int i = 1; i <= _NumericUpDown.Value; i++)
                                    {
                                        ComboBox Temp = (FlagReadOnly) ? (ComboBox)_PreviewPanel.Controls.Find("ComboBox" + i, false)[0] : (ComboBox)TempPanel.Controls.Find("ComboBox" + i, false)[0];
                                        Temp.Items.Clear();
                                        for (int j = 1; j <= _NumericUpDown.Value; j++)
                                        {
                                            Temp.Items.Add(j);
                                        }
                                        if (!FlagReadOnly) Temp.SelectedIndex = GetQuestion(Counter).ExtendChoices[i - 1] - 1;
                                    }
                                }
                                if (_NumericUpDown.Value != 1)
                                {
                                    for (int i = 1; i <= OldIndexOfNumericUpDown; i++)
                                    {
                                        if (FlagReadOnly)
                                        {
                                            _PreviewPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location = new Point(90, _PreviewPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location.Y + 26);
                                            _PreviewPanel.Controls.Find("Label" + i + i, false)[0].Location = new Point(30, _PreviewPanel.Controls.Find("Label" + i + i, false)[0].Location.Y + 26);
                                        }
                                        else
                                        {
                                            TempPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location = new Point(90, TempPanel.Controls.Find("RichTextBox" + i + i, false)[0].Location.Y + 26);
                                            TempPanel.Controls.Find("Label" + i + i, false)[0].Location = new Point(30, TempPanel.Controls.Find("Label" + i + i, false)[0].Location.Y + 26);
                                        }
                                    }
                                }

                                Label _LabelTemp = new Label();
                                _LabelTemp.AutoSize = true;
                                _LabelTemp.Location = new Point(30, (55 + 26 * ((int)_NumericUpDown.Value * 2 - 1)));
                                _LabelTemp.Name = "Label" + _NumericUpDown.Value + _NumericUpDown.Value;
                                _LabelTemp.Size = new Size(22, 13);
                                _LabelTemp.TabIndex = 20;
                                _LabelTemp.Text = _NumericUpDown.Value + ".";
                                if (FlagReadOnly) _PreviewPanel.Controls.Add(_LabelTemp);
                                else TempPanel.Controls.Add(_LabelTemp);

                                RichTextBox _RichTextBoxTemp = new RichTextBox();
                                _Controls.Add(_RichTextBoxTemp);
                                _RichTextBoxTemp.Location = new Point(90, (55 + 26 * ((int)_NumericUpDown.Value * 2 - 1)));
                                _NumericUpDown.FindForm().MinimumSize = new Size(810, _RichTextBoxTemp.Location.Y + 347);
                                _RichTextBoxTemp.Name = "RichTextBox" + _NumericUpDown.Value + _NumericUpDown.Value;
                                if (FlagReadOnly) _RichTextBoxTemp.Size = new Size(_PreviewPanel.Width - 100, 20);
                                else _RichTextBoxTemp.Size = new Size(TempPanel.Width - 100, 20);
                                if (GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1][0] == "True" ||
                                   GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1][0] == "False") GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1][0] = "";
                                try
                                {
                                    _RichTextBoxTemp.Rtf = GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1][0];
                                }
                                catch { }
                                if (FlagReadOnly)
                                {
                                    _RichTextBoxTemp.ReadOnly = true;
                                    _RichTextBoxTemp.BorderStyle = BorderStyle.None;
                                    _PreviewPanel.Controls.Add(_RichTextBoxTemp);
                                }
                                else TempPanel.Controls.Add(_RichTextBoxTemp);
                                break;
                            case 3:
                                ComboBox _ComboBoxTempT = new ComboBox();
                                _ComboBoxTempT.FormattingEnabled = true;
                                _ComboBoxTempT.Location = new Point(48, (55 + OldIndexOfNumericUpDown * 26));
                                _ComboBoxTempT.Name = "ComboBox" + _NumericUpDown.Value;
                                _ComboBoxTempT.Size = new Size(35, 21);
                                _ComboBoxTempT.DropDownStyle = ComboBoxStyle.DropDownList;
                                if (FlagReadOnly) _PreviewPanel.Controls.Add(_ComboBoxTempT);
                                else TempPanel.Controls.Add(_ComboBoxTempT);
                                if (_NumericUpDown.Value == GetQuestion(Counter).Choices.Count)
                                {
                                    for (int i = 1; i <= _NumericUpDown.Value; i++)
                                    {
                                        ComboBox Temp = (FlagReadOnly) ? (ComboBox)_PreviewPanel.Controls.Find("ComboBox" + i, false)[0] : (ComboBox)TempPanel.Controls.Find("ComboBox" + i, false)[0];
                                        Temp.Items.Clear();
                                        for (int j = 1; j <= _NumericUpDown.Value; j++)
                                        {
                                            Temp.Items.Add(j);
                                        }
                                        if (GetQuestion(Counter).Choices[i - 1][0] == "") GetQuestion(Counter).Choices[i - 1][0] = "1";
                                        if (!FlagReadOnly)
                                        {
                                            try
                                            {
                                                Temp.SelectedIndex = Int32.Parse(GetQuestion(Counter).Choices[i - 1][0]) - 1;
                                            }
                                            catch
                                            {
                                                GetQuestion(Counter).Choices[i - 1][0] = "1";
                                                Temp.SelectedIndex = Int32.Parse(GetQuestion(Counter).Choices[i - 1][0]) - 1;
                                            }
                                        }
                                    }
                                }
                                break;
                        }

                        Label _Label = new Label();
                        _Label.AutoSize = true;
                        _Label.Location = new Point(30, (55 + OldIndexOfNumericUpDown * 26));
                        _Label.Name = "Label" + _NumericUpDown.Value;
                        _Label.Size = new Size(22, 13);
                        _Label.TabIndex = 20;
                        _Label.Text = (OldIndexOfNumericUpDown + 1) + ".";

                        RichTextBox _RichTextBox = new RichTextBox();
                        _Controls.Add(_RichTextBox);
                        switch (_ComboBox.SelectedIndex)
                        {
                            case 2:
                                _RichTextBox.Location = new Point(90, (55 + OldIndexOfNumericUpDown * 26));
                                break;
                            case 3:
                                _RichTextBox.Location = new Point(90, (55 + OldIndexOfNumericUpDown * 26));
                                _NumericUpDown.FindForm().MinimumSize = new Size(810, _RichTextBox.Location.Y + 347);
                                break;
                            default:
                                _RichTextBox.Location = new Point(50, (55 + OldIndexOfNumericUpDown * 26));
                                _NumericUpDown.FindForm().MinimumSize = new Size(810, _RichTextBox.Location.Y + 347);
                                break;
                        }
                        _RichTextBox.Name = "RichTextBox" + _NumericUpDown.Value;
                        if (FlagReadOnly) _RichTextBox.Size = new Size(_PreviewPanel.Width - 100, 20);
                        else _RichTextBox.Size = new Size(TempPanel.Width - 100, 20);
                        _RichTextBox.TabIndex = 17;
                        _RichTextBox.Rtf = GetQuestion(Counter).Choices[(int)_NumericUpDown.Value - 1][1];
                        if (FlagReadOnly)
                        {
                            _RichTextBox.ReadOnly = true;
                            _RichTextBox.BorderStyle = BorderStyle.None;
                            _PreviewPanel.Controls.Add(_Label);
                            _PreviewPanel.Controls.Add(_RichTextBox);
                        }
                        else
                        {
                            TempPanel.Controls.Add(_Label);
                            TempPanel.Controls.Add(_RichTextBox);
                        }
                        OldIndexOfNumericUpDown = (int)_NumericUpDown.Value;
                    }
                    else
                    {
                        MessageBox.Show("Установлено максимальное число элементов.", "Внимание!");
                        FlagOfCancel = true;
                        _NumericUpDown.Value = OldIndexOfNumericUpDown;
                    }
                }
            }
            else FlagOfCancel = false;
        }
        /// <summary>
        /// Сохраняет текущий вопрос и перходит к другому.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        /// <param name="_Button"> нажатая кнопка. </param>
        /// <param name="_Question"> Сохраняемый вопрос. </param>
        /// <param name="Testing"> Флаг, определяющий режим тестировния. </param>
        public void SaveAndGo(Form InputForm, Button _Button, Question _Question, bool Testing)
        {
            SaveQuestion(InputForm, _Question, Testing);
            InputForm.Controls.Find("SetChoicePanel", false)[0].Dispose();
            _Controls.Clear();
            if (_Button.Name == "NextButton")
            {
                Counter++;
                Reconstitute(InputForm, GetQuestion(Counter), Testing);
            }
            else
            {
                Counter--;
                Reconstitute(InputForm, GetQuestion(Counter), Testing);
            }
            if (Counter == 1)
            {
                InputForm.Controls.Find("BackButton", false)[0].Enabled = false;
                InputForm.Controls.Find("NextButton", false)[0].Enabled = true;
            }
            else if (Counter == NumOfQuestions)
            {
                InputForm.Controls.Find("NextButton", false)[0].Enabled = false;
                InputForm.Controls.Find("BackButton", false)[0].Enabled = true;
            }
            else
            {
                InputForm.Controls.Find("BackButton", false)[0].Enabled = true;
                InputForm.Controls.Find("NextButton", false)[0].Enabled = true;
            }
        }
        /// <summary>
        /// Устанавливает тип начертания элементов RichTextBox.
        /// </summary>
        /// <param name="_Button"> Нажатая кнопка установки стиля. </param>
        public void SetFontStyleRichtextBox(ToolStripButton _Button)
        {
            switch (_Button.Name)
            {
                case "BoldToolStripButton":
                    foreach (RichTextBox elem in _Controls)
                    {
                        if (elem.SelectionFont != null)
                        {
                            Font CurrentFont = elem.SelectionFont;
                            FontStyle NewFontStyle;
                            if (_Button.CheckState.ToString() == "Unchecked") NewFontStyle = FontStyle.Regular;
                            else NewFontStyle = FontStyle.Bold;
                            elem.SelectionFont = new Font(CurrentFont.FontFamily, CurrentFont.Size, NewFontStyle);
                        }
                    }
                    break;
                case "ItalicToolStripButton":
                    foreach (RichTextBox elem in _Controls)
                    {
                        if (elem.SelectionFont != null)
                        {
                            Font CurrentFont = elem.SelectionFont;
                            FontStyle NewFontStyle;
                            if (_Button.CheckState.ToString() == "Unchecked") NewFontStyle = FontStyle.Regular;
                            else NewFontStyle = FontStyle.Italic;
                            elem.SelectionFont = new Font(CurrentFont.FontFamily, CurrentFont.Size, NewFontStyle);
                        }
                    }
                    break;
                case "UnderLineToolStripButton":
                    foreach (RichTextBox elem in _Controls)
                    {
                        if (elem.SelectionFont != null)
                        {
                            Font CurrentFont = elem.SelectionFont;
                            FontStyle NewFontStyle;
                            if (_Button.CheckState.ToString() == "Unchecked") NewFontStyle = FontStyle.Regular;
                            else NewFontStyle = FontStyle.Underline;
                            elem.SelectionFont = new Font(CurrentFont.FontFamily, CurrentFont.Size, NewFontStyle);
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Перемещает вопрос.
        /// </summary>
        /// <param name="TempForm"> Временная Windows.Form. </param>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        public void MoveQuestion(Form TempForm, Form InputForm)
        {
            try
            {
                int NewNumber = Int32.Parse(TempForm.Controls.Find("NewNumberTextBox", false)[0].Text);
                if (NewNumber < 1 || NewNumber > _NumOfQuestions) throw new FormatException();
                else
                {
                    Panel.FindForm().Enabled = true;
                    TempForm.Close();
                    SaveQuestion(InputForm, GetQuestion(Counter), false);
                    if (NewNumber == NumOfQuestions)
                    {
                        LinkedListNode<Question> CurrentNode = _Questions.Find(GetQuestion(Counter));
                        LinkedListNode<Question> AfterNode = _Questions.Find(GetQuestion(NewNumber));
                        LinkedListNode<Question> NewNode = new LinkedListNode<Question>(GetQuestion(Counter));
                        _Questions.Remove(CurrentNode);
                        _Questions.AddAfter(AfterNode, NewNode);
                    }
                    else
                    {
                        LinkedListNode<Question> CurrentNode = _Questions.Find(GetQuestion(Counter));
                        LinkedListNode<Question> BeforeNode = _Questions.Find(GetQuestion(NewNumber));
                        LinkedListNode<Question> NewNode = new LinkedListNode<Question>(GetQuestion(Counter));
                        _Questions.Remove(CurrentNode);
                        _Questions.AddBefore(BeforeNode, NewNode);
                    }
                    for (int i = 1; i <= NumOfQuestions; i++) GetQuestion(i).Number = i;
                    Label _Label = (Label)Panel.FindForm().Controls.Find("NumberOFQuestionLabel", true)[0];
                    ComboBox _ComboBox = (ComboBox)Panel.FindForm().Controls.Find("TypeComboBox", true)[0];
                    RichTextBox _RichTextBox = (RichTextBox)Panel.FindForm().Controls.Find("QuestionRichTextBox", true)[0];
                    _Controls.Clear();
                    _Counter = NewNumber;
                    if (_Counter == 1)
                    {
                        TempPanel.FindForm().Controls.Find("BackButton", false)[0].Enabled = false;
                        TempPanel.FindForm().Controls.Find("NextButton", false)[0].Enabled = true;
                    }
                    else if (_Counter == NumOfQuestions)
                    {
                        TempPanel.FindForm().Controls.Find("NextButton", false)[0].Enabled = false;
                        TempPanel.FindForm().Controls.Find("BackButton", false)[0].Enabled = true;
                    }
                    else
                    {
                        TempPanel.FindForm().Controls.Find("BackButton", false)[0].Enabled = true;
                        TempPanel.FindForm().Controls.Find("NextButton", false)[0].Enabled = true;
                    }
                    TempPanel.Dispose();
                    Reconstitute(InputForm, GetQuestion(Counter), false);
                }
            }
            catch (FormatException)
            {
                throw new FormatException("Некорректный номер вопроса.");
            }
        }
        /// <summary>
        /// Сохраняет текущий вопрос.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        /// <param name="_Question"> Сохраняемый вопрос. </param>
        /// <param name="Testing"> Флаг, определяющий режим тестирования. </param>
        public void SaveQuestion(Form InputForm, Question _Question, bool Testing)
        {
            ComboBox TypeComboBox = (ComboBox) InputForm.Controls.Find("TypeComboBox", true)[0];
            RichTextBox QuestionRichTextBox = (RichTextBox)InputForm.Controls.Find("QuestionRichTextBox", true)[0];
            switch (TypeComboBox.SelectedIndex)
            {
                case 0:
                    if (OldIndexOfNumericUpDown != 0)
                    {
                        int a = 0;
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            RadioButton _RadioButton = (RadioButton)TypeComboBox.FindForm().Controls.Find("RadioButton" + (i + 1), true)[0];
                            if (_RadioButton.Checked) a++;
                        }
                        if (a == 0) throw new FormatException("Не выбран ответ.");
                    }
                    if (!Testing)
                    {
                        _Question.Text = QuestionRichTextBox.Rtf;
                        _Question.Type = Type.Standart;
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            RadioButton _RadioButton = (RadioButton)TypeComboBox.FindForm().Controls.Find("RadioButton" + (i + 1), true)[0];
                            RichTextBox _RichTextBoxT = (RichTextBox)TypeComboBox.FindForm().Controls.Find("RichTextBox" + (i + 1), true)[0];
                            _Question.Choices[i][0] = _RadioButton.Checked.ToString();
                            _Question.Choices[i][1] = _RichTextBoxT.Rtf;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            RadioButton _RadioButton = (RadioButton)TypeComboBox.FindForm().Controls.Find("RadioButton" + (i + 1), true)[0];
                            if (_RadioButton.Checked) 
                            {
                                _Answers[Counter - 1] = (i + 1).ToString();
                                break;
                            }
                        }
                    } 
                    break;
                case 1:
                    int j = 0;
                    for (int i = 0; i < _Question.Choices.Count; i++)
                    {
                        CheckBox _CheckBox = (CheckBox)TypeComboBox.FindForm().Controls.Find("CheckBox" + (i + 1), true)[0];
                        if (_CheckBox.Checked) j++;
                    }
                    if (_Question.Choices.Count <= j) throw new FormatException("Число ответов должно быть меньше числа вариантов.");
                    if (!Testing)
                    {
                        _Question.Text = QuestionRichTextBox.Rtf;
                        _Question.Type = Type.StandartM;
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            CheckBox _CheckBox = (CheckBox)TypeComboBox.FindForm().Controls.Find("CheckBox" + (i + 1), true)[0];
                            RichTextBox _RichTextBoxT = (RichTextBox)TypeComboBox.FindForm().Controls.Find("RichTextBox" + (i + 1), true)[0];
                            _Question.Choices[i][0] = _CheckBox.Checked.ToString();
                            _Question.Choices[i][1] = _RichTextBoxT.Rtf;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            CheckBox _CheckBox = (CheckBox)TypeComboBox.FindForm().Controls.Find("CheckBox" + (i + 1), true)[0];
                            if (_CheckBox.Checked) _Answers[Counter - 1] += (i + 1).ToString();
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < _Question.Choices.Count; i++)
                    {
                        ComboBox _ComboBox = (ComboBox)TypeComboBox.FindForm().Controls.Find("ComboBox" + (i + 1), true)[0];
                        if (_ComboBox.SelectedItem == null) throw new FormatException("Установлены не все флаги ответов.");
                    }
                    if (!Testing)
                    {
                        _Question.Text = QuestionRichTextBox.Rtf;
                        _Question.Type = Type.Comparison;
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            ComboBox _ComboBox = (ComboBox)TypeComboBox.FindForm().Controls.Find("ComboBox" + (i + 1), true)[0];
                            RichTextBox _RichTextBoxL = (RichTextBox)TypeComboBox.FindForm().Controls.Find("RichTextBox" + (i + 1), true)[0];
                            RichTextBox _RichTextBoxR = (RichTextBox)TypeComboBox.FindForm().Controls.Find("RichTextBox" + (i + 1) + (i + 1), true)[0];
                            _Question.ExtendChoices[i] = _ComboBox.SelectedIndex + 1;
                            _Question.Choices[i][0] = _RichTextBoxR.Rtf;
                            _Question.Choices[i][1] = _RichTextBoxL.Rtf;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            ComboBox _ComboBox = (ComboBox)TypeComboBox.FindForm().Controls.Find("ComboBox" + (i + 1), true)[0];
                            _Answers[Counter - 1] += (_ComboBox.SelectedIndex + 1);
                        }
                    }
                    break;
                case 3:
                    try
                    {
                        for (int i = 0; i < _Question.Choices.Count; i++)
                        {
                            ComboBox _ComboBox = (ComboBox)TypeComboBox.FindForm().Controls.Find("ComboBox" + (i + 1), true)[0];
                            for (int k = 0; k < _Question.Choices.Count; k++)
                            {
                                if (k == i) continue;
                                ComboBox _ComboBoxT = (ComboBox)TypeComboBox.FindForm().Controls.Find("ComboBox" + (k + 1), true)[0];
                                if (_ComboBox.SelectedItem.ToString() == _ComboBoxT.SelectedItem.ToString()) throw new FormatException("В ответе не могут присутствовать одинаковые значения.");
                            }
                        }
                        if (!Testing)
                        {
                            _Question.Text = QuestionRichTextBox.Rtf;
                            _Question.Type = Type.Sequence;
                            for (int i = 0; i < _Question.Choices.Count; i++)
                            {
                                ComboBox _ComboBox = (ComboBox)TypeComboBox.FindForm().Controls.Find("ComboBox" + (i + 1), true)[0];
                                RichTextBox _RichTextBox = (RichTextBox)TypeComboBox.FindForm().Controls.Find("RichTextBox" + (i + 1), true)[0];
                                _Question.Choices[i][0] = (_ComboBox.SelectedIndex + 1).ToString();
                                _Question.Choices[i][1] = _RichTextBox.Rtf;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _Question.Choices.Count; i++)
                            {
                                ComboBox _ComboBox = (ComboBox)TypeComboBox.FindForm().Controls.Find("ComboBox" + (i + 1), true)[0];
                                _Answers[Counter - 1] += (_ComboBox.SelectedIndex + 1);
                            }
                        }
                    }
                    catch (NullReferenceException) 
                    {
                        throw new FormatException("Установлены не все флаги ответов.");
                    }
                    break;
            }
        }
        /// <summary>
        /// Сохраняет тест в виде файла *.SCTT.
        /// </summary>
        /// <param name="InputForm"> Исходная WindowsForm. </param>
        /// <param name="TestObject"> Сериализуемый объект. </param>
        /// <param name="FileName"> Путь файла. </param>
        public void SaveTest(Form InputForm, Test TestObject, string FileName)
        {
            BinaryFormatter FormatterIn = new BinaryFormatter();
            FileStream FS = null;
            try
            {
                if (FileName.Contains("\\")) FS = new FileStream(FileName, FileMode.Create);
                else
                {
                    Directory.CreateDirectory("Tests");
                    FS = new FileStream(Environment.CurrentDirectory + "\\Tests\\" + FileName + ".SCTT", FileMode.Create);
                }
                SaveQuestion(InputForm, GetQuestion(Counter), false);
                _Controls.Clear();
                FormatterIn.Serialize(FS, TestObject);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Не удалось сохранить файл, повторите попытку." , "Ошибка сохранения");
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                FS.Close();
            }
        }
        /// <summary>
        /// Сохраняет тест в файле под заданным именем в заданной директории.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        /// <param name="TestObject"> Сериализуемый объект типа Test. </param>
        /// <param name="FileName"> Заданный путь файла. </param>
        public void SaveAsTest(Form InputForm, Test TestObject, string FileName)
        {
            BinaryFormatter FormatterIn = new BinaryFormatter();
            FileStream FS = null;
            try
            {
                _FileName = FileName;
                FS = new FileStream(FileName, FileMode.Create);
                SaveQuestion(InputForm, GetQuestion(Counter), false);
                _Controls.Clear();
                FormatterIn.Serialize(FS, TestObject);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Ошибка сохранения, причина: " + e.Message, "Ошибка сериализации");
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                FS.Close();
            }
        }
        /// <summary>
        /// Осуществляет предпросмотр текущего вопроса.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        public void PreviewQuestion(Form InputForm)
        {
            FlagReadOnly = true;
            Reconstitute(InputForm, GetQuestion(Counter), true);
            FlagReadOnly = false;
        }
        /// <summary>
        /// Осуществляет предпросмотр теста.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        public void PreviewTest(Form InputForm)
        {
            DataGridView Table = (DataGridView)InputForm.Controls.Find("TableDataGridView", false)[0];
            Table.Rows.Add();
            Table.Columns[1].Width = 820;
            Table.Columns[0].Width = 20;
            for (int i = 0; i < _NumOfQuestions; i++)
            {
                RichTextBox r = new RichTextBox();
                r.Rtf = GetQuestion((i + 1)).Text;
                Table.Rows[i].Cells[0].Value = (i + 1);
                Table.Rows[i].Cells[1].Value = r.Text;
                Table.Rows.Add();
            }
        }
        /// <summary>
        /// Подготавливает исходную форму к тестированию.
        /// </summary>
        /// <param name="InputForm"> Исходная Windows.Form. </param>
        public void ToPrepareForTest(Form InputForm)
        {
            InputForm.Controls.Find("NameTestLabel", true)[0].Text = "     Ф.И.О. тестируемого:";
            InputForm.Controls.Find("ThemeLabel", true)[0].Text = "     Группа/класс:";
            InputForm.Controls.Find("ExtandPanel", true)[0].Visible = false;
            InputForm.Controls.Find("CreateQuestionPanel", false)[0].Location = new Point(3, 8);
            InputForm.Controls.Find("BackButton", false)[0].Enabled = false;
            InputForm.Controls.Find("CreateTestButton", true)[0].Location = new Point(143, 79);
            InputForm.Controls.Find("CreateTestButton", true)[0].Text = "Начать тестирование";
            InputForm.Controls.Find("ToolStrip", true)[0].Visible  = false;
            InputForm.Controls.Find("TypeOfQuestionLabel", true)[0].Visible  = false;
            InputForm.Controls.Find("TypeComboBox", true)[0].Visible  = false;
            InputForm.Controls.Find("QuestionLabel", true)[0].Visible = false;
            RichTextBox QuestionRichTextBox = (RichTextBox)InputForm.Controls.Find("QuestionRichTextBox", true)[0];
            QuestionRichTextBox.ReadOnly = true;
            QuestionRichTextBox.Location = new Point(20, 53);
            QuestionRichTextBox.BorderStyle = BorderStyle.None;
        }
        /// <summary>
        /// Вычисляет резельтаты тестирования по его завершении.
        /// </summary>
        /// <param name="Start"> Исходная Windows.Form. </param>
        /// <param name="Result"> Windows.Form вывода результата. </param>
        public void CalculateResult(Form Start, Form Result)
        {
            int Count = 0;
            for (int i = 1; i <= NumOfQuestions; i++)
            {
                Question TempQuestion = GetQuestion(i);
                switch (TempQuestion.Type)
                {
                    case Type.Standart:
                        for (int j = 0; j < TempQuestion.Choices.Count; j++)
                        {
                            if (TempQuestion.Choices[j][0] == "True")
                            {
                                if (_Answers[i - 1] == (j + 1).ToString())
                                {
                                    Count++;
                                    break;
                                }
                            }
                        }
                        break;
                    case Type.StandartM:
                        string TempS = "";
                        for (int j = 0; j < TempQuestion.Choices.Count; j++) if (TempQuestion.Choices[j][0] == "True") TempS += (j + 1);
                        if (TempS == _Answers[i - 1]) Count++;
                        break;
                    case Type.Comparison:
                        string TempC = "";
                        for (int j = 0; j < TempQuestion.Choices.Count; j++) TempC += TempQuestion.ExtendChoices[j];
                        if (TempC == _Answers[i - 1]) Count++;
                        break;
                    case Type.Sequence:
                        string TempSq = "";
                        for (int j = 0; j < TempQuestion.Choices.Count; j++) TempSq += TempQuestion.Choices[j][0];
                        if (TempSq == _Answers[i - 1]) Count++;
                        break;
                }
            }
            int Rating;
            if (_TypeOfRating == TypeOfRating.Rating)
            {
                if (Ratings[2] <= Count)
                {
                    if (Ratings[1] <= Count)
                    {
                        if (Ratings[0] <= Count) Rating = 5;
                        else Rating = 4;
                    }
                    else Rating = 3;
                }
                else Rating = 2;
            }
            else Rating = (Ratings[0] <= Count) ? 1 : 0;
            Result.Text = "Результат тестирования [" + _ParamOfPerson[0] + "]";
            Result.Controls.Find("NamePersonLabel", false)[0].Text = "Ф.И.О тестируемого: " + _ParamOfPerson[0];
            Result.Controls.Find("CastPersonLabel", false)[0].Text = "Класс/группа: " + _ParamOfPerson[1];
            Result.Controls.Find("ResultLabel", false)[0].Text = "Ваш результат: " + Count + " из " + _NumOfQuestions + ".";
            if (_TypeOfRating == TypeOfRating.Rating) Result.Controls.Find("RatingLabel", false)[0].Text = "Ваша оценка: " + Rating + ".";
            else Result.Controls.Find("RatingLabel", false)[0].Text = (Rating == 1) ? "Ваша оценка: зачет" : "Ваша оценка: не зачет";
            Result.Show();
        }
    }
}
