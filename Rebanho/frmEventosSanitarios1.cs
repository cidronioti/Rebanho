using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rebanho
{
    public partial class frmEventosSanitarios1 : MetroFramework.Forms.MetroForm
    {
        public frmEventosSanitarios1()
        {
            InitializeComponent();
        }

        private void frmEventosSanitarios1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmRegistroEventosSanitarios res = new frmRegistroEventosSanitarios())
            {
                res.ShowDialog();
            }
        }
    }
}
