using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCTT
{
    public partial class Result : Form
    {
        Form StartForm;

        public Result(Form StartForm)
        {
            InitializeComponent();
            this.StartForm = StartForm;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartForm.Visible = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (RSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(RSaveFileDialog.FileName);
                SW.WriteLine(DateTime.Now.ToLocalTime().ToString());
                SW.WriteLine(NamePersonLabel.Text);
                SW.WriteLine(CastPersonLabel.Text);
                SW.WriteLine(ResultLabel.Text);
                SW.WriteLine(RatingLabel.Text);
                SW.Close();
            }
        }
    }
}
