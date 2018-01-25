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
    public partial class frmRegistroPesagem1 : MetroFramework.Forms.MetroForm
    {
        public frmRegistroPesagem1()
        {
            InitializeComponent();
        }

        private void frmRegistroPesagem1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            using (frmRegistroPesagem rp = new frmRegistroPesagem())
            {
                rp.ShowDialog();
            }
        }
    }
}
