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
    public partial class frmInsumos : MetroFramework.Forms.MetroForm
    {
        public frmInsumos()
        {
            InitializeComponent();
        }

        private void frmInsumos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMaisDetalhes_Click(object sender, EventArgs e)
        {
            using (frmInsumosMaisDetalhes imd = new frmInsumosMaisDetalhes())
            {
                imd.ShowDialog();
            }
        }
    }
}
