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
    public partial class frmCopiaSeguranca1 : MetroFramework.Forms.MetroForm
    {
        public frmCopiaSeguranca1()
        {
            InitializeComponent();
        }

        private void frmCopiaSeguranca1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmRealizarBackup rb = new frmRealizarBackup())
            {
                rb.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmRestaurarBackup frmrb = new frmRestaurarBackup())
            {
                frmrb.ShowDialog();
            }
        }
    }
}
