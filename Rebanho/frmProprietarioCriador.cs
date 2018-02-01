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
    public partial class frmProprietarioCriador : MetroFramework.Forms.MetroForm
    {
        ProprietarioControle pc = new ProprietarioControle();
        ProprietarioModelo pm = new ProprietarioModelo();
        public frmProprietarioCriador()
        {
            InitializeComponent();
        }

        private void frmProprietarioCriador_Load(object sender, EventArgs e)
        {
            preenchertabela();
        }

        private void salvar()
        {
            pm.Cod = txtCod.Text;
            pm.Nome = txtNome.Text;
            pc.cadastroProprietario(pm);
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

        private void limpaCampos()
        {
            txtCod.Text = "";
            txtNome.Text = "";
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

        public void preenchertabela()
        {
            try
            {
                metroGrid1.DataSource = pc.preencheTabela();
                lblNumRegistros.Text = (metroGrid1.RowCount - 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher tabela - " + ex);
            }

        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
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

        private void preencherTabela2()
        {
            try
            {
                metroGrid1.DataSource = pc.preencheTabelaBuscaComParametro(txtBusca.Text);
                lblNumRegistros.Text = (metroGrid1.RowCount - 1).ToString();
            }
            catch (Exception ex) { MessageBox.Show("Erro - " + ex, "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                pm = pc.buscaPorCodigo(metroGrid1.CurrentRow.Cells[0].Value.ToString());
                txtCod.Text = pm.Cod.ToString();
                txtNome.Text = pm.Nome;             
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!verificaCamposVazios())
            {
                pm.Cod = txtCod.Text;
                pm.Nome = txtNome.Text;
                pc.atualizaProprietario(pm);

                MessageBox.Show("Atualizado com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpaCampos();
                preenchertabela();
            }
            else
                MessageBox.Show("Selecione um registro para atualizar", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCod.Text))
            {
                var dialogResult = MessageBox.Show("Deseja excluir este registro?", "Rebanho 1.0.0", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    pc.deleteProprietario(txtCod.Text);
                    limpaCampos();
                    preenchertabela();
                }
            }
            else
                MessageBox.Show("Selecione um registro para excluir", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpaCampos();
            txtCod.BackColor = Color.White;
            txtNome.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtBusca_Leave(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
            {
                txtBusca.Text = "BUSCA POR NOME...";
            }
        }
    }
}
