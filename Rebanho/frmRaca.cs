using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Modelo;
using Control;
using MetroFramework.Controls;

namespace Rebanho
{
    public partial class frmRaca : MetroFramework.Forms.MetroForm
    {
        string codigo;

        RacaModelo rm = new RacaModelo();
        Racaontrole rc = new Racaontrole();
        //Racaontrole rc = new Control.Racaontrole();
        //Racaontrole rc = new Racaontrole();

        public frmRaca()
        {
            InitializeComponent();
        }

        private void frmRaca_Load(object sender, EventArgs e)
        {
            preenchertabela();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                MessageBox.Show("Preencher os campos vazios");
            } else {
                try
                {
                    rm.Cod = txtCodigo.Text;
                    rm.Nome = txtNome.Text;
                    rm.PeriodoGestacao = int.Parse(txtPeridoGestacao.Text);
                    rc.cadastroRaca(rm);
                    MessageBox.Show("Salvo com sucesso ");
                    limpaCampos();
                    preenchertabela();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ErrorBlinkStyle ao salvar " + ex);
                }
            }

        }

        private void txtPeridoGestacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)44 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        public bool verificaCampos()
        {
            MetroTextBox[] tb = { txtCodigo, txtNome, txtPeridoGestacao };

            for (int i = 0; i < tb.Length; i++)
            {
                if (tb[i].Text == "")
                    return true;
            }
            return false;
        }


        public void limpaCampos()
        {
            MetroTextBox[] tb = { txtCodigo, txtNome, txtPeridoGestacao };

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                MessageBox.Show("Selecione um registro para ser atualizado");
            }
            else
            {
                rm.Cod = txtCodigo.Text;
                rm.Nome = txtNome.Text;
                rm.PeriodoGestacao = int.Parse(txtPeridoGestacao.Text);
                rc.atualizaRaca(rm);
                MessageBox.Show("Atualizado com sucesso ");
                limpaCampos();
                preenchertabela();
            }
        }

        public void preenchertabela()
        {
            try
            {
                metroGrid1.DataSource = rc.preencheTabela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher tabela - " + ex);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigo.Text))
                {
                    rm.Cod = txtCodigo.Text;
                    rc.deleteRaca(rm);
                    MessageBox.Show("Excluido com sucesso ");
                    limpaCampos();
                    preenchertabela();
                }else
                {
                    MessageBox.Show("Campo código está vazio");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erro - "+ex);
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
               /*rm.Cod = metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
                rc.buscaRaca(rm);
                buscaRacaDataGrid();*/
                txtCodigo.Text = metroGrid1.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = metroGrid1.CurrentRow.Cells[1].Value.ToString();
                txtPeridoGestacao.Text = metroGrid1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        public void buscaRacaDataGrid()
        {
            try
            {
                txtCodigo.Text = rm.Cod;
                txtNome.Text = rm.Nome;
                txtPeridoGestacao.Text = rm.PeriodoGestacao.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro - " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
