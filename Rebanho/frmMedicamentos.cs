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
            TextBox[] tb = {txtCodBarras, txtNomeComercial, txtPrincipioAtivo, txtApresentacao, txtQtdPorEmbalagem, txtQtdEmbalagens, txtQtdMin, txtPrecoCompra, txtLaboratorio, txtIndicacao, txtModoUso, txtObs, txtCaminhoFoto };
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = "";
            }
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
            Console.WriteLine("CODIGO CATEGORIa: "+ cc.retornaCodCategoria(cbCategoria.Text));
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
                return true;
            }


            return false;
        }

    }
}
