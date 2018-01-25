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
    public partial class frmDiagnosticoGestação1 : MetroFramework.Forms.MetroForm
    {
        public frmDiagnosticoGestação1()
        {
            InitializeComponent();
        }

        private void frmDiagnosticoGestação1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmDiagnosticoGestacao dg = new frmDiagnosticoGestacao())
            {
                dg.ShowDialog();
            }
        }
    }
}
