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
    public partial class frmRegistroCobertura1 : MetroFramework.Forms.MetroForm
    {
        public frmRegistroCobertura1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmRegistroCobertura r = new frmRegistroCobertura())
            {
                r.ShowDialog();
            }
        }
    }
}
