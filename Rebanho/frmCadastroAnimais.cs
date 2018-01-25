using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;
using System.Media;

namespace Rebanho
{
    public partial class frmCadastroAnimais : MetroFramework.Forms.MetroForm
    {
        ManipulaData data12 = new ManipulaData();
        public frmCadastroAnimais()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            using (frmBuscaMatriz bm = new frmBuscaMatriz())
            {
                bm.ShowDialog();
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            using (frmRegistraParto frp = new frmRegistraParto())
            {
                frp.ShowDialog();
            }
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            using (frmDiagnosticoGestacao frmdg = new frmDiagnosticoGestacao())
            {
                frmdg.ShowDialog();
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            using (frmConsultaPartosAnteriores cpa = new frmConsultaPartosAnteriores())
            {
                cpa.ShowDialog();
            }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            using (frmRegistroCobertura rc1 = new frmRegistroCobertura())
            {
                rc1.ShowDialog();
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
           
        }

        private void txtInserePesagem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmRegistroPesagem rp1 = new frmRegistroPesagem())
            {
                rp1.ShowDialog();
            }
        }

        private void metroComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (frmRaca r1 = new frmRaca())
            {
                r1.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (frmCadastroLocais cl1 = new frmCadastroLocais())
            {
                cl1.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (frmRegistroEventosSanitarios rvs = new frmRegistroEventosSanitarios())
            {
                rvs.ShowDialog();
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            using (frmGenealogia g = new frmGenealogia())
            {
                g.ShowDialog();
            }
        }

        
        private void maskedTextBox4_Leave(object sender, EventArgs e)// evento que realiza uma ação quando o campo perde o foco
        {
            try
            { 
               lblIdade.Text= data12.calculaIdade(maskedTextBox4.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular data" + ex);
            }
            
            
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNumero.TextLength == 0)
            {
                txtNumero.Text = "";
            }
            if (txtNumero.TextLength < 2)
            {
                soLetras(e);
                txtNumero.SelectionStart = 1;//seta o cursor para a posição 1 da string
            }

            if (txtNumero.TextLength == 2)
            {
                txtNumero.Text = txtNumero.Text + "/";
                txtNumero.SelectionStart = 4;
            }

            if (txtNumero.TextLength > 2)
            {
                soNumeros(e);
                if (char.IsLetter(e.KeyChar))
                {
                    SystemSounds.Beep.Play();

                }
            }
        }

        public void soLetras(KeyPressEventArgs e)//metodo q premite digitar apenas letra nos campos de texto
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    txtNumero.Text += char.ToUpper(e.KeyChar);
                    e.Handled = true;

                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }
        }

        public void soNumeros(KeyPressEventArgs e)//metodo q premite digitar apenas Números campos de texto
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }
        }
        public void preencheCombo()//metodo que preenche a combobox situação
        {
            string[] f = { "BORREGA", "CODEIRA","OVELHA" };
            string[] m = {"BORREGO", "CAPÃO", "CARNEIRO", "CORDEIRO", "RUFIÃO" };

            if (cobSexo.Text.Equals(""))
            {

            }
            else if (cobSexo.SelectedItem.Equals("F"))
            {
                cobSituacao.Items.Clear();
                for (int i = 0; i < f.Length; i++)
                {
                    cobSituacao.Items.Add(f[i]);
                }
            }else
            {
                cobSituacao.Items.Clear();
                for (int i = 0; i < m.Length; i++)
                {
                    cobSituacao.Items.Add(m[i]);
                }
            }
        }

        private void cobSexo_Leave(object sender, EventArgs e)
        {
            preencheCombo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (frmMatriz m = new frmMatriz())
            {
                m.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (frmReprodutor r = new frmReprodutor() )
            {
                r.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmProprietarioCriador pc = new frmProprietarioCriador())
            {
                pc.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (frmProprietarioCriador pc = new frmProprietarioCriador())
            {
                pc.ShowDialog();
            }
        }
    }
}
