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
    public partial class frmCadastroLocais : MetroFramework.Forms.MetroForm
    {
        LocaisModelo lm = new LocaisModelo();
        LocaisControle lc = new LocaisControle();
        public frmCadastroLocais()
        {
            InitializeComponent();
        }

        private void frmCadastroLocais_Load(object sender, EventArgs e)
        {
            preenchertabela();
        }

        private bool verificaCamposVazios()
        {
            if (txtCod.Text == "" || txtNome.Text == "")
            {
                txtCod.BackColor = Color.Tomato;
                txtNome.BackColor = Color.Tomato;
                return true;
            }
            return false;
        }

        private void salvar()
        {
            lm.Cod = txtCod.Text;
            lm.Nome = txtNome.Text;
            lm.Area = double.Parse(txtArea.Text);
            lm.Graminea = txtGraminea.Text;
            lm.DataAvaliacao = maskDataAvaliacao.Text;
            lm.Suporte = int.Parse(txtSuporte.Text);
            lm.Pastejo = int.Parse(txtPastejo.Text);
            lm.Perda = double.Parse(txtPerda.Text);
            lm.Consumo = double.Parse(txtConsumo.Text);
            lm.Descanso = int.Parse(txtDescanso.Text);
            lm.Obs = txtObs.Text;
            lc.cadastraLocal(lm);
        }

        private void limpaCampos()
        {
            TextBox[] tb = { txtCod, txtArea, txtConsumo, txtDescanso, txtGraminea, txtNome, txtObs, txtPastejo, txtPerda, txtSuporte };

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = "";
            }
            maskDataAvaliacao.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!verificaCamposVazios())
            {
                salvar();
                MessageBox.Show("Salvo com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpaCampos();
                preenchertabela();
            }
        }

        public void preenchertabela()
        {
            try
            {
                metroGrid1.DataSource = lc.preencheTabela();
                lblNumRegistros.Text = (metroGrid1.RowCount - 1).ToString();
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
                metroGrid1.DataSource = lc.preencheTabelaBuscaComParametro(txtBusca.Text);
                lblNumRegistros.Text = (metroGrid1.RowCount - 1).ToString();
            }
            catch (Exception ex) { MessageBox.Show("Erro - " + ex, "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
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
                lm = lc.buscaPorCodigo(metroGrid1.CurrentRow.Cells[0].Value.ToString());
                txtCod.Text = lm.Cod;
                txtNome.Text = lm.Nome;
                txtArea.Text = lm.Area.ToString();
                txtGraminea.Text = lm.Graminea;
                maskDataAvaliacao.Text = lm.DataAvaliacao;
                txtSuporte.Text = lm.Suporte.ToString();
                txtPerda.Text = lm.Perda.ToString();
                txtPastejo.Text = lm.Pastejo.ToString();
                txtConsumo.Text = lm.Consumo.ToString();
                txtDescanso.Text = lm.Descanso.ToString();
                txtObs.Text = lm.Obs;               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCod.Text))
            {
                var dialogResult = MessageBox.Show("Deseja excluir estes dados?", "Rebanho 1.0.0", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    lc.deleteLocal(txtCod.Text);
                    limpaCampos();
                    preenchertabela();
                }
            }
            else
                MessageBox.Show("Selecione o medicamento a ser excluído", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                MessageBox.Show("Selecione um registro para ser atualizado");
            }
            else
            {
                lm.Cod = txtCod.Text;
                lm.Nome = txtNome.Text;
                lm.Area = double.Parse(txtArea.Text);
                lm.Graminea = txtGraminea.Text;
                lm.DataAvaliacao = maskDataAvaliacao.Text;
                lm.Suporte = double.Parse(txtSuporte.Text);
                lm.Perda = double.Parse(txtPerda.Text);
                lm.Pastejo = double.Parse(txtPastejo.Text);
                lm.Consumo = double.Parse(txtConsumo.Text);
                lm.Descanso = int.Parse(txtDescanso.Text);
                lm.Obs = txtObs.Text;

                lc.atualizaLocal(lm);
                MessageBox.Show("Atualizado com sucesso ");
                limpaCampos();
                preenchertabela();
            }
        }

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)44 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtSuporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)44 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtPastejo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)44 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtConsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)44 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtDescanso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)44 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
