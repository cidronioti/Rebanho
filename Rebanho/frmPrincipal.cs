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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registroDeDesmamaIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroDesmamaIndividual1 rdi1 = new frmRegistroDesmamaIndividual1())
            {
                rdi1.ShowDialog();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCadastroAnimais ca = new frmCadastroAnimais())
            {
                ca.ShowDialog();
            }
        }

        private void raçaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRaca raca = new frmRaca())
            {
                raca.ShowDialog();
            }
        }

        private void inseminadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmInseminadores i = new frmInseminadores())
            {
                i.ShowDialog();
            }
        }

        private void proprietáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmProprietarioCriador pc = new frmProprietarioCriador())
            {
                pc.ShowDialog();
            }
        }

        private void eventosSanitáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmEventosSanitarios es = new frmEventosSanitarios())
            {
                es.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text ="   Hora: "+ DateTime.Now.ToString("T");
        }

        private void calsasMortisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCausasMortis cm = new frmCausasMortis())
            {
                cm.ShowDialog();
            }
        }

        private void locaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCadastroLocais cl = new frmCadastroLocais())
            {
                cl.ShowDialog();
            }
        }

        private void registrarSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmResgistraSistema rs = new frmResgistraSistema())
            {
                rs.ShowDialog();
            }
        }

        private void parâmetrosDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmParametrosSistema ps = new frmParametrosSistema())
            {
                ps.ShowDialog();
            }
        }

        private void registroDeCompraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmRegistroCompras rc = new frmRegistroCompras())
            {
                rc.ShowDialog();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            using (frmRegistroCobertura1 r1 = new frmRegistroCobertura1())
            {
                r1.ShowDialog();
            }
        }

        private void registroDeCoberturasInseminaçãoIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroCobertura1 r1 = new frmRegistroCobertura1())
            {
                r1.ShowDialog();
            }
        }

        private void registroDePesagemCorporalIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroPesagem1 rp1 = new frmRegistroPesagem1())
            {
                rp1.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (frmCadastroAnimais frmca1 = new frmCadastroAnimais())
            {
                frmca1.ShowDialog();
            }
        }

        private void abrirLacaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAbrirLactacao1 al1 = new frmAbrirLactacao1())
            {
                al1.ShowDialog();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using (frmRegistroOrdenha1 frmro1 = new frmRegistroOrdenha1())
            {
                frmro1.ShowDialog();
            }
        }

        private void registroIndividualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmEventosSanitarios1 es1 = new frmEventosSanitarios1())
            {
                es1.ShowDialog();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            using (frmEventosSanitarios1 es1 = new frmEventosSanitarios1())
            {
                es1.ShowDialog();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (frmMedicamentos m = new frmMedicamentos())
            {
                m.ShowDialog();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            using (frmMedicamentos m = new frmMedicamentos())
            {
                m.ShowDialog();
            }
        }

        private void transferenciaIndividualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmTransferenciaIndividual1 ti1 = new frmTransferenciaIndividual1())
            {
                ti1.ShowDialog();
            }
        }

        private void definirNívelDeAcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmControleAcesso ca = new frmControleAcesso())
            {
                ca.ShowDialog();
            }
        }

        private void registroDeDesmamaEmGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroDesmamaGrupo rdg = new frmRegistroDesmamaGrupo())
            {
                rdg.ShowDialog();
            }
        }

        private void registroDeBaixaIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroBaixaIndidual1 rbi1 = new frmRegistroBaixaIndidual1())
            {
                rbi1.ShowDialog();
            }
        }

        private void registroDeVendaIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroVendas1 rv1 = new frmRegistroVendas1())
            {
                rv1.ShowDialog();
            }
        }

        private void registroDeOrdenhaIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroOrdenha1 ro1 = new frmRegistroOrdenha1())
            {
                ro1.ShowDialog();
            }
        }

        private void coletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmColetaEmbriões1 ce1 = new frmColetaEmbriões1())
            {
                ce1.ShowDialog();
            }
        }

        private void implanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroCobertura1 frmrc1 = new frmRegistroCobertura1())
            {
                frmrc1.ShowDialog();
            }
        }

        private void registroDeDiagnóticosIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmDiagnosticoGestação1 dg1 = new frmDiagnosticoGestação1())
            {
                dg1.ShowDialog();
            }
        }

        private void partosAntigosOuSemCoberturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmConsultaPartosAnteriores1 cpa1 = new frmConsultaPartosAnteriores1())
            {
                cpa1.ShowDialog();
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            using (frmInsumos ism = new frmInsumos())
            {
                ism.ShowDialog();
            }
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCadastroFornecedores cf = new frmCadastroFornecedores())
            {
                cf.ShowDialog();
            }
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmContasAPagar cp = new frmContasAPagar())
            {
                cp.ShowDialog();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            using (frmCadastroFerramentas cf = new frmCadastroFerramentas())
            {
                cf.ShowDialog();
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            using (frmContasAPagar cap = new frmContasAPagar())
            {
                cap.ShowDialog();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            using (frmCopiaSeguranca1 cs1 = new frmCopiaSeguranca1())
            {
                cs1.ShowDialog();
            }
        }

        private void cópiaDeSegurançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCopiaSeguranca1 cs1 = new frmCopiaSeguranca1())
            {
                cs1.ShowDialog();
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCadastraClientes cc = new frmCadastraClientes())
            {
                cc.ShowDialog();
            }
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCadastroFuncionario cf = new frmCadastroFuncionario())
            {
                cf.ShowDialog();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Deseja encerrar a aplicação?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)//evento do botão fechar do form
        {
            var dialogResult = MessageBox.Show("Deseja encerrar a aplicação?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmContasAReceber cr = new frmContasAReceber())
            {
                cr.ShowDialog();
            }
        }
    }
}
