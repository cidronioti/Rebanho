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
    public partial class frmRegistroBaixaIndidual1 : MetroFramework.Forms.MetroForm
    {
        public frmRegistroBaixaIndidual1()
        {
            InitializeComponent();
        }

        private void frmRegistroBaixaIndidual1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmRegistroBaixa rb=new frmRegistroBaixa())
            {
                rb.ShowDialog();
            }
        }
    }
}
