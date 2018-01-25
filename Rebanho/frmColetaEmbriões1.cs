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
    public partial class frmColetaEmbriões1 : MetroFramework.Forms.MetroForm
    {
        public frmColetaEmbriões1()
        {
            InitializeComponent();
        }

        private void frmColetaEmbriões1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmColetaEmbrioes ce = new frmColetaEmbrioes())
            {
                ce.ShowDialog();
            }
        }
    }
}
