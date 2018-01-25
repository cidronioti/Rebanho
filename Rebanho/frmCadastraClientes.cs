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

namespace Rebanho
{
    public partial class frmCadastraClientes : MetroFramework.Forms.MetroForm
    {
        EnderecoModelo em = new EnderecoModelo();
        EnderecoControle ec = new EnderecoControle();
        ClienteModelo cm = new ClienteModelo();
        ClienteControle cc = new ClienteControle();
        public frmCadastraClientes()
        {
            InitializeComponent();
        }

        private void frmCadastraClientes_Load(object sender, EventArgs e)
        {
            preenchertabela();
        }

        private void maskedTextBox3_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
                try
                {

                    string url = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml";

                    DataSet retornaEndereco = new DataSet();
                    retornaEndereco.ReadXml(url.Replace("@cep", maskedTextBox3.Text.Replace("-", "")));

                    string retorno = retornaEndereco.Tables[0].Rows[0]["resultado"].ToString();

                    if (retorno != "0")
                    {
                        txtRua.Text = retornaEndereco.Tables[0].Rows[0]["logradouro"].ToString();
                        txtBairro.Text = retornaEndereco.Tables[0].Rows[0]["bairro"].ToString();
                        txtCidade.Text = retornaEndereco.Tables[0].Rows[0]["cidade"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("CEP não emcontrado");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro - " + ex);
                }
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verificaCamposVazios())
            {
                try
                {
                    em.Cep = maskedTextBox3.Text.Replace("-", "");
                    em.Rua = txtRua.Text;
                    em.Numero = txtNumero.Text;
                    em.Bairro = txtBairro.Text;
                    em.Cidade = txtCidade.Text;
                    em.Obs = txtObs.Text;
                    ec.cadastroEndereco(em);

                    // MessageBox.Show("");

                    cm.Nome = txtNome.Text;
                    cm.Cpf = maskCpf.Text.Replace(".","").Replace("-","").Replace(",","");
                    cm.Rg = txtRg.Text;
                    cm.Fone = maskFone.Text;
                    cm.Propriedade = txtPropriedade.Text;

                    cc.cadastroCliente(cm, ec.utimoCodigoIserido);

                    MessageBox.Show("Salvo com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpaCampos();
                    preenchertabela();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro - "+ex);
                }
            }else
            {
                MessageBox.Show("Preencha os Campos obrigatórios");
            }
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

        public void limpaCampos()
        {
            TextBox[] tb = {txtCodigo, txtNome, txtBusca, txtBairro, txtCidade, txtNumero, txtRg, txtPropriedade, txtObs, txtRua};
            MaskedTextBox[] mtb = { maskCpf, maskFone, maskedTextBox3 };

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = "";
            }
            for (int j = 0; j < mtb.Length; j++)
            {
                mtb[j].Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            
            if (!String.IsNullOrEmpty(txtBusca.Text))
            {
               
                if (rbtNome.Checked)
                {
                    cm = cc.buscaClienteNome(txtBusca.Text); 
                    txtCodigo.Text = cm.Cod.ToString();
                    txtNome.Text = cm.Nome;
                    maskCpf.Text = cm.Cpf;
                    txtRg.Text = cm.Rg;
                    maskFone.Text = cm.Fone;
                    txtPropriedade.Text = cm.Propriedade;

                    em = cc.retornaEndereco();
                    txtRua.Text = em.Rua;
                    txtNumero.Text = em.Numero;
                    txtBairro.Text = em.Bairro;
                    txtCidade.Text = em.Cidade;
                    txtObs.Text = em.Obs;
                    maskedTextBox3.Text = em.Cep;
                }
                else
                {
                    cm = cc.buscaClienteCPF(txtBusca.Text);
                    txtCodigo.Text = cm.Cod.ToString();
                    txtNome.Text = cm.Nome;
                    maskCpf.Text = cm.Cpf;
                    txtRg.Text = cm.Rg;
                    maskFone.Text = cm.Fone;
                    txtPropriedade.Text = cm.Propriedade;

                    em = cc.retornaEndereco();
                    txtRua.Text = em.Rua;
                    txtNumero.Text = em.Numero;
                    txtBairro.Text = em.Bairro;
                    txtCidade.Text = em.Cidade;
                    txtObs.Text = em.Obs;
                    maskedTextBox3.Text = em.Cep;
                }           
            }
            txtBusca.Text = "";
        }

        private void maskCpf_Leave(object sender, EventArgs e)
        {
            ValidaCPFControle vcc = new ValidaCPFControle();
            if (!vcc.IsCpf(maskCpf.Text))
            {
                MessageBox.Show("CPF inválido", "Rebanho 1.0.0",MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskCpf.BackColor = Color.Tomato;
            }
        }

        public void preenchertabela()
        {
            try
            {
                metroGrid1.DataSource = cc.preencheTabela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher tabela - " + ex);
            }

        }

        public void preenchertabela2()
        {
            try
            {
                metroGrid1.DataSource = cc.preencheTabelaBuscaComParametro(txtBusca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher tabela - " + ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)44 || e.KeyChar == (char)46 || e.KeyChar == (char)45)
            {
                e.Handled = true;
            }

            if (!String.IsNullOrEmpty(txtBusca.Text))
            {
                preenchertabela2();
            }
            
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                cm = cc.buscaClienteCPF(metroGrid1.CurrentRow.Cells[0].Value.ToString());
                txtCodigo.Text = cm.Cod.ToString();
                txtNome.Text = cm.Nome;
                maskCpf.Text = cm.Cpf;
                txtRg.Text = cm.Rg;
                maskFone.Text = cm.Fone;
                txtPropriedade.Text = cm.Propriedade;

                em = cc.retornaEndereco();
                txtRua.Text = em.Rua;
                txtNumero.Text = em.Numero;
                txtBairro.Text = em.Bairro;
                txtCidade.Text = em.Cidade;
                txtObs.Text = em.Obs;
                maskedTextBox3.Text = em.Cep;
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {
                if (cc.deleteCliente(txtCodigo.Text))
                {
                    MessageBox.Show("Cliente excluido com sucesso", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }else
            {
                MessageBox.Show("Erro ao excluir cliente", "Rebanho 1.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
