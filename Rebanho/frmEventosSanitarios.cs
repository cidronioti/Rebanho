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
    public partial class frmEventosSanitarios : MetroFramework.Forms.MetroForm
    {
        EventoSanitarioZooModelo eszm = new EventoSanitarioZooModelo();
        EventoSanitarioZooControle eszc = new EventoSanitarioZooControle();
        public frmEventosSanitarios()
        {
            InitializeComponent();
        }

        private void frmEventosSanitarios_Load(object sender, EventArgs e)
        {
            preenchertabela();
        }

        private bool verificaCamposVazios()
        {
            if (txtNome.Text == "")
            {
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
                eszm.Nome = txtNome.Text;
                eszc.cadastroEventoSaniZoo(eszm);
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
                metroGrid1.DataSource = eszc.preencheTabela();
                lblNumRegistros.Text = (metroGrid1.RowCount - 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher tabela - " + ex);
            }

        }

        private void preencherTabela2()
        {
            try
            {
                metroGrid1.DataSource = eszc.preencheTabelaBuscaComParametro(txtBusca.Text);
                lblNumRegistros.Text = (metroGrid1.RowCount - 1).ToString();
            }
            catch (Exception ex) { MessageBox.Show("Erro - " + ex, "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                eszm = eszc.buscaPorCodigo((int)metroGrid1.CurrentRow.Cells[0].Value);
                txtCod.Text = eszm.Cod.ToString();
                txtNome.Text = eszm.Nome;
                txtNome.BackColor = Color.White;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!verificaCamposVazios())
            {
                eszm.Cod = int.Parse(txtCod.Text);
                eszm.Nome = txtNome.Text;
                eszc.atualizaEventoSaniZoo(eszm);

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
                    eszm.Cod = int.Parse(txtCod.Text);
                    eszc.deleteEventoSaniZoo(eszm);
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
            txtNome.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
