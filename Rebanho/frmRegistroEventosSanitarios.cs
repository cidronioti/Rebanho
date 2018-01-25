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
    public partial class frmRegistroEventosSanitarios : MetroFramework.Forms.MetroForm
    {
        public frmRegistroEventosSanitarios()
        {
            InitializeComponent();
        }

        private void frmRegistroEventosSanitarios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmEventosSanitarios frmes = new frmEventosSanitarios())
            {
                frmes.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmConsultaEventosSanitários ces = new frmConsultaEventosSanitários())
            {
                ces.ShowDialog();
            }
        }
    }
}
