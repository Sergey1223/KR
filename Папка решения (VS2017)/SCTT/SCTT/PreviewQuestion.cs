using System;
using System.Windows.Forms;
using ClassLibrarySCTT;

namespace SCTT
{
    public partial class PreviewQuestion : Form
    {
        private CreateTest InputForm;

        public PreviewQuestion(CreateTest InputForm, Question _Question)
        {
            this.InputForm = InputForm;
            InitializeComponent();
        }

        private void PreviewQuestion_Load(object sender, EventArgs e)
        {
            TypeComboBox.Items.Add("стандартный вопрос с одним ответом.");
            TypeComboBox.Items.Add("стандартный вопрос с несколькими ответами.");
            TypeComboBox.Items.Add("вопрос-сопоставление.");
            TypeComboBox.Items.Add("вопрос-сортировка.");
            TypeComboBox.Items.Add("");
        }

        public void PreviewQuestion_FormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            InputForm.Enabled = true;
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputForm.TestObject.SettingType(this, InputForm.TestObject.GetQuestion(InputForm.TestObject._Counter));
        }
    }
}
