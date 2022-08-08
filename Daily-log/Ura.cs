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
    public partial class Ura : Form
    {
        public Ura()
        {
            InitializeComponent();
        }

        public decimal uraYear
        {
            get => year.Value;
            set => year.Value = value;
        }

        public decimal uraMonth
        {
            get => month.Value;
            set => month.Value = value;
        }

        public decimal uraDay
        {
            get => day.Value;
            set => day.Value = value;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
