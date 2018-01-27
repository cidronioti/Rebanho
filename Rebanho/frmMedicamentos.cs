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
using System.IO;
using DALL;

namespace Rebanho
{
    public partial class frmMedicamentos : MetroFramework.Forms.MetroForm
    {
        MedicametoControle mc = new MedicametoControle();
        MedicamentoModelo mm = new MedicamentoModelo();
        CategoriaControle cc = new CategoriaControle();
        UnidadeControle uc = new UnidadeControle();
        public frmMedicamentos()
        {
            InitializeComponent();
        }

        private void frmMedicamentos_Load(object sender, EventArgs e)
        {
            preencheComboCategoria();
            preencheComboUnidade();
            preenchertabela();
            cbCategoria.Text = "";
            cbUnidade.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (frmCadastroCategoria fcc = new frmCadastroCategoria())
            {
                fcc.ShowDialog();
            }

            preencheComboCategoria();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (frmUnidade fu = new frmUnidade())
            {
                fu.ShowDialog();
            }

            preencheComboUnidade();
        }

        private void limpaCampos()
        {
            TextBox[] tb = {txtCod, txtCodBarras, txtNomeComercial, txtPrincipioAtivo, txtApresentacao, txtQtdPorEmbalagem, txtQtdEmbalagens, txtQtdMin, txtPrecoCompra, txtLaboratorio, txtIndicacao, txtModoUso, txtObs, txtCaminhoFoto };
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = "";
            }
            pictureBox2.Image = null;
            maskValidade.Text = "";
            cbCategoria.Text = "";
            cbUnidade.Text = "";
        }

        private void preencheComboCategoria()
        {
            cbCategoria.DisplayMember = "nome_categoria";
            cbCategoria.DataSource = mc.preencheComboCategoria();
        }

        private void preencheComboUnidade()
        {
            cbUnidade.DisplayMember = "nome_unidade";
            cbUnidade.DataSource = mc.preencheComboUnidade();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string caminhoFoto = ofd.FileName.ToString();
                txtCaminhoFoto.Text = caminhoFoto;
                pictureBox2.ImageLocation = caminhoFoto;
            }
        }

        private void salvar()
        {
            byte[] imagem = null;
            FileStream fs = new FileStream(txtCaminhoFoto.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagem = br.ReadBytes((int) fs.Length);

            mm.CodBarras = txtCodBarras.Text;
            mm.NomeComercial = txtNomeComercial.Text;
            mm.PrincipioAtivo = txtPrincipioAtivo.Text;
            mm.Validade = maskValidade.Text;
            mm.CodCategoria = cc.retornaCodCategoria(cbCategoria.Text);
            mm.Apresentacao = txtApresentacao.Text;
            mm.QuantidadePorEmbalagem = int.Parse(txtQtdPorEmbalagem.Text);
            mm.QuantidadeDeEmbalagem = int.Parse(txtQtdEmbalagens.Text);
            mm.CodUnidade = uc.retornaCodUnidade(cbUnidade.Text);
            mm.QuantidadeMin = int.Parse(txtQtdMin.Text);
            mm.PrecoCompra = double.Parse(txtPrecoCompra.Text);
            mm.Laboratorio = txtLaboratorio.Text;
            mm.Indicacoes = txtIndicacao.Text;
            mm.ModoUso = txtModoUso.Text;
            mm.Obs = txtObs.Text;
            mm.CaminhoFoto = txtCaminhoFoto.Text;
            mm.Foto = imagem;
            mc.cadastroMedicamento(mm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verificaCamposVazios())
            {
                salvar();
                MessageBox.Show("Salvo com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpaCampos();
                preenchertabela();
            }
            else
                MessageBox.Show("Preencha os campos obrigatórios", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool verificaCamposVazios()
        {

            if (String.IsNullOrEmpty(txtNomeComercial.Text) || String.IsNullOrEmpty(txtNomeComercial.Text))
            {
                txtNomeComercial.BackColor = Color.Tomato;
                txtCodBarras.BackColor = Color.Tomato;
                maskValidade.BackColor = Color.Tomato;
                cbCategoria.BackColor = Color.Tomato;
                cbUnidade.BackColor = Color.Tomato;
                return true;
            }


            return false;
        }

        public void preenchertabela()
        {
            try
            {
                metroGrid1.DataSource = mc.preencheTabela();
                lblNumeroRegistros.Text = (metroGrid1.RowCount - 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher tabela - " + ex);
            }

        }

        public void preencherTabela2()
        {
            try
            {
                metroGrid1.DataSource = mc.preencheTabelaBuscaComParametro(txtBusca.Text);
                lblNumeroRegistros.Text = (metroGrid1.RowCount - 1).ToString();
            }
            catch (Exception ex) { MessageBox.Show("Erro - "+ex, "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)44 || e.KeyChar == (char)46 || e.KeyChar == (char)45)
            {
                e.Handled = true;
            }

            if (!String.IsNullOrEmpty(txtBusca.Text))
            {
                preencherTabela2();
            }
            else
                preenchertabela();
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                mm = mc.buscaPorCodigo((int) metroGrid1.CurrentRow.Cells[0].Value);
                txtCod.Text = mm.Cod.ToString();
                txtCodBarras.Text = mm.CodBarras.ToString();
                txtNomeComercial.Text = mm.NomeComercial;
                txtPrincipioAtivo.Text = mm.PrincipioAtivo;
                maskValidade.Text = mm.Validade;
                cbCategoria.Text = cc.retornaNomeCategoria(mm.CodCategoria);
                txtApresentacao.Text = mm.Apresentacao;
                txtQtdPorEmbalagem.Text = mm.QuantidadePorEmbalagem.ToString();
                txtQtdEmbalagens.Text = mm.QuantidadeDeEmbalagem.ToString();
                cbUnidade.Text = uc.retornaNomeUnidade(mm.CodUnidade);
                txtQtdMin.Text = mm.QuantidadeMin.ToString();
                txtPrecoCompra.Text = mm.PrecoCompra.ToString();
                txtLaboratorio.Text = mm.Laboratorio;
                txtIndicacao.Text = mm.Indicacoes;
                txtModoUso.Text = mm.ModoUso;
                txtObs.Text = mm.Obs;
                txtCaminhoFoto.Text = mm.CaminhoFoto;

                if (mm.Foto == null)
                {
                    pictureBox2.Image = null;
                }else
                {
                    MemoryStream ms = new MemoryStream(mm.Foto);
                    //pictureBox2.Image = System.Drawing.Image.FromStream(ms);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCod.Text))
            {
                var dialogResult = MessageBox.Show("Deseja excluir estes dados?", "Rebanho 1.0.0", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    mc.deletarMedicamento(int.Parse(txtCod.Text));
                    limpaCampos();
                    preenchertabela();
                }
            }else
                MessageBox.Show("Selecione o medicamento a ser excluído", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                MessageBox.Show("Selecione um registro para ser atualizado");
            }
            else
            {
                mm.Cod = int.Parse(txtCod.Text);
                mm.CodBarras = txtCodBarras.Text;
                mm.NomeComercial = txtNomeComercial.Text;
                mm.PrincipioAtivo = txtPrincipioAtivo.Text;
                mm.Validade = maskValidade.Text;
                mm.CodCategoria = cc.retornaCodCategoria(cbCategoria.Text);
                mm.Apresentacao = txtApresentacao.Text;
                mm.QuantidadePorEmbalagem = int.Parse(txtQtdPorEmbalagem.Text);
                mm.QuantidadeDeEmbalagem = int.Parse(txtQtdEmbalagens.Text);
                mm.CodUnidade = uc.retornaCodUnidade(cbUnidade.Text);
                mm.QuantidadeMin = int.Parse(txtQtdMin.Text);
                mm.PrecoCompra = double.Parse(txtPrecoCompra.Text);
                mm.Laboratorio = txtLaboratorio.Text;
                mm.Indicacoes = txtIndicacao.Text;
                mm.ModoUso = txtModoUso.Text;
                mm.Obs = txtObs.Text;
                mm.CaminhoFoto = txtCaminhoFoto.Text;

                byte[] imagem = null;
                FileStream fs = new FileStream(txtCaminhoFoto.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imagem = br.ReadBytes((int)fs.Length);
                if (imagem != null)
                {
                    mm.Foto = imagem;
                }
                mc.atualizaMedicamento(mm);
                MessageBox.Show("Atualizado com sucesso ");
                limpaCampos();
                preenchertabela();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
