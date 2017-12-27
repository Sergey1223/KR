using System;
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
    public partial class PreviewTest : Form
    {
        private CreateTest CreateTestForm;

        public PreviewTest(CreateTest CreateTestForm)
        {
            InitializeComponent();
            this.CreateTestForm = CreateTestForm;
        }

        public void PreviewTest_FormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            CreateTestForm.Enabled = true;
        }
    }
}
