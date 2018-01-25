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
    public partial class frmRegistroVendas1 : MetroFramework.Forms.MetroForm
    {
        public frmRegistroVendas1()
        {
            InitializeComponent();
        }

        private void frmRegistroVendas1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmRegistroVendas rv = new frmRegistroVendas())
            {
                rv.ShowDialog();
            }
        }
    }
}
