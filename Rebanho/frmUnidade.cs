using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALL;
using Control;
namespace Rebanho
{
    public partial class frmUnidade : MetroFramework.Forms.MetroForm
    {
        UnidadeControle uc = new UnidadeControle();
        UnidadeModelo um = new UnidadeModelo();
        public frmUnidade()
        {
            InitializeComponent();
        }

        private void frmUnidade_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verificaCamposVazios())
            {
                try
                {
                    um.Nome = txtNome.Text;
                    um.Flag = 'M';//indicando que essa categoria tem relação com medicamentos
                    uc.cadastroCategoria(um);
                    MessageBox.Show("Salvo com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpaCampos();
                    Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro - " + ex);
                }
            }
            else
                MessageBox.Show("Preencha o campo requerido", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool verificaCamposVazios()
        {

            if (String.IsNullOrEmpty(txtNome.Text))
            {
                txtNome.BackColor = Color.Tomato;
                return true;
            }


            return false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBusca.Text))
            {
                um = uc.buscaCategoriaNome(txtBusca.Text);
                txtCod.Text = um.Cod.ToString();
                txtNome.Text = um.Nome;
                txtBusca.Text = "";
            }
            else
                MessageBox.Show("Campo de busca vazio", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCod.Text))
            {
                um.Cod = int.Parse(txtCod.Text);
                um.Nome = txtNome.Text;
                uc.atualizaCategoria(um);
                MessageBox.Show("Atualizado com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpaCampos();
            }
            else
                MessageBox.Show("Selecione uma unidade", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCod.Text))
            {
                um.Cod = int.Parse(txtCod.Text);
                uc.deleteCategoria(um);
                MessageBox.Show("Excluido com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpaCampos();
            }
            else
                MessageBox.Show("Selecione uma unidade", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void limpaCampos()
        {
            TextBox[] tb = { txtBusca, txtCod, txtNome };

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
