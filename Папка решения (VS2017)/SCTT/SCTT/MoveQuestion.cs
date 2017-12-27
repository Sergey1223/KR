using System;
using ClassLibrarySCTT;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCTT
{
    public partial class MoveQuestion : Form
    {
        private Test TestObject;
        private CreateTest CreateTestForm;

        public MoveQuestion(Test TestObject, CreateTest CreateTestForm)
        {
            this.TestObject = TestObject;
            this.CreateTestForm = CreateTestForm;
            InitializeComponent();
            CurrentNumberLabel.Text += " " + TestObject._Counter;
        }

        private void MoveQuestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MoveQuestionButton.Enabled) CreateTestForm.Enabled = true;
        }

        private void MoveQuestionButton_Click(object sender, EventArgs e)
        {
            try
            {
                TestObject.MoveQuestion(this, CreateTestForm);
                MoveQuestionButton.Enabled = false;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
        }
    }
}
