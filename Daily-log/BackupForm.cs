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
    public partial class BackupForm : Form
    {
        public BackupForm()
        {
            InitializeComponent();
        }

        public string BoxText { set => box.Text = value.Replace("\n", "\r\n"); }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            box.SelectionStart = 0;
        }
    }
}
