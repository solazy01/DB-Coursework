using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class CleanerForm : Form
    {
        public CleanerForm()
        {
            InitializeComponent();
        }
        #region DataGrid
        public DataGridView DataGridtimetable => dataGridTimetable;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
