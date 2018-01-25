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
    public partial class frmRegistroDesmamaIndividual1 : MetroFramework.Forms.MetroForm
    {
        public frmRegistroDesmamaIndividual1()
        {
            InitializeComponent();
        }

        private void frmRegistroDesmamaIndividual1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmRegistroDesmamaIndividual rdi = new frmRegistroDesmamaIndividual())
            {
                rdi.ShowDialog();
            }
        }
    }
}
