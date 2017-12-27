using ClassLibrarySCTT;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SCTT
{
    public partial class Start : Form
    {
#region Поля
        private CreateTest CreateTestForm;
        private AboutBox _AboutBox;
#endregion

        /// <summary>
        /// Инициализирует новый экземпляр класса Start.
        /// </summary>
        public Start()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик события Form.Load.
        /// </summary>
        private void Start_Load(object sender, EventArgs e)
        {
            _AboutBox = new AboutBox();
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку создания теста.
        /// </summary>
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTestForm = new CreateTest(this);
            Visible = false;
            CreateTestForm.Show();
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку "О программе".
        /// </summary>
        private void _AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _AboutBox.Show();
        }
        /// <summary>
        /// Обработчик события закрытия формы.
        /// </summary>
        private void _Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitToolStripMenuItem.Enabled)
            {
                DialogResult Result = MessageBox.Show(
                        "Выйти?",
                        "Внимание!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2);
                if (Result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку редактирования теста.
        /// </summary>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTestForm = new CreateTest(this);
            CreateTestForm.Controls.Find("CreateQuestionPanel", false)[0].Visible = true;
            CreateTestForm.Controls.Find("CreateQuestionPanel", false)[0].Location = new Point(3, 8);
            CreateTestForm.Controls.Find("CreateTestPanel", false)[0].Visible = false;
            CreateTestForm.Controls.Find("BackButton", false)[0].Enabled = false;
            CreateTestForm.Controls.Find("BackButton", false)[0].Visible = true;
            CreateTestForm.Controls.Find("NextButton", false)[0].Visible = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateTestForm.Show();
                Visible = false;
                CreateTestForm.TestObject = LoadTest(OpenFileDialog.FileName);
                CreateTestForm.Text = "Редактирование теста " + "[" + CreateTestForm.TestObject.Name + "]";
                if (CreateTestForm.TestObject.NumOfQuestions == 1) CreateTestForm.Controls.Find("NextButton", false)[0].Visible = false;
                CreateTestForm.TestObject._Counter = 1;
                CreateTestForm.TestObject.Reconstitute(CreateTestForm, CreateTestForm.TestObject.GetQuestion(1), false);
            }
            else Visible = true;
        }
        /// <summary>
        /// Загружает тест из файла.
        /// </summary>
        /// <param name="FileName"> Путь к файлу. </param>
        /// <returns></returns>
        public Test LoadTest(string FileName)
        {
            BinaryFormatter FormatterOut = new BinaryFormatter();
            FileStream FS = new FileStream(FileName, FileMode.Open);
            try
            {
                return (Test)FormatterOut.Deserialize(FS);
            }
            catch (IOException)
            {
                throw new IOException();
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                MessageBox.Show("Ошибка открытия файла, возможно, он поврежден.", "Внимание!");
                return null;
            }
            finally
            {
                FS.Close();
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку ntcnbhjdfybz
        /// </summary>
        private void TestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTestForm = new CreateTest(this);
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateTestForm.FlagOfTesting = true;
                CreateTestForm.TestObject = LoadTest(OpenFileDialog.FileName);
                CreateTestForm.Show();
                CreateTestForm.Text = "Тестирование " + "[" + CreateTestForm.TestObject.Name + "]";
                Visible = false;
                CreateTestForm.TestObject.ToPrepareForTest(CreateTestForm);
            }
            else Visible = true;
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку "Выход".
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitToolStripMenuItem.Enabled = false;
            Close();
        }
    }
}
