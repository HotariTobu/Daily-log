using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_log
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        public string userName
        {
            get => nameBox.Text;
            set => nameBox.Text = value;
        }

        public bool passwordEnable
        {
            get => passwordCheckBox.Checked;
        }

        public string password
        {
            get => passwordBox.Text;
            set => passwordBox.Text = value;
        }

        public bool passwordBoxFocus = false;

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordBox.Enabled = passwordCheckBox.Checked;
            passwordBox.Text = "";
        }

        private void UserForm_Shown(object sender, EventArgs e)
        {
            if (passwordBoxFocus)
            {
                passwordBox.Focus();
            }
        }
    }
}
