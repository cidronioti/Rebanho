using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using Modelo;

namespace Control
{
    public class ClienteControle
    {
        string cep, rua, numero, bairro, cidade, obs;

        ClienteModelo cm = new ClienteModelo();
        EnderecoModelo em = new EnderecoModelo();
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        public void cadastroCliente(ClienteModelo c, int codEndereco)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO cliente (nome_cliente, cpf_cliente, rg_cliente, fone_cliente, propriedade_cliente,cod_endereco)VALUES('" + c.Nome + "','" + c.Cpf + "','" + c.Rg + "','" + c.Fone + "','" + c.Propriedade + "','" + codEndereco + "')";
                MySqlCommand comando = new MySqlCommand(insere, conexao);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            finally
            {
                conexao.Close();
            }
        }
        public void atualizaCliente(ClienteModelo c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE cliente SET nome_cliente='" + c.Nome + "',cpf_cliente='" + c.Cpf + "',rg_cliente='" + c.Rg + "',fone_cliente='" + c.Fone + "',propriedade_cliente='" + c.Propriedade + "' WHERE cod_cliente ='" + c.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool deleteCliente(string c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string deletacli = "DELETE FROM cliente WHERE cod_cliente='" + c + "'";
                comando = new MySqlCommand(deletacli, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
                ////////////////////////////////////////////////////////////////////////////////
                deletaEndereco(retornaCodEndereco(int.Parse(c)));
                return true;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        public int retornaCodEndereco(int c)
        {
            int codigoEnd = 0;
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                comando = new MySqlCommand("SELECT cod_endereco FROM cliente WHERE cod_cliente = '" + c + "'", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    codigoEnd = Convert.ToInt32(leitor["cod_endereco"]);
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - "+ex);
            }
            conexao.Close();
            return codigoEnd;
        }

        public bool deletaEndereco(int cod)
        {
            conexao = new MySqlConnection(caminho);
            conexao.Open();
            string deletaend = "DELETE FROM endereco WHERE cod_endereco='" + cod + "'";
            comando = new MySqlCommand(deletaend, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
            return true;
        }

        public DataTable preencheTabela()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT cpf_cliente, nome_cliente FROM cliente", conexao);
                MySqlDataAdapter mda = new MySqlDataAdapter();
                mda.SelectCommand = comando;
                DataTable dt = new DataTable();
                mda.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public DataTable preencheTabelaBuscaComParametro(string parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT cpf_cliente, nome_cliente FROM cliente WHERE nome_cliente LIKE '%"+parametro+"%'", conexao);
                MySqlDataAdapter mda = new MySqlDataAdapter();
                mda.SelectCommand = comando;
                DataTable dt = new DataTable();
                mda.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public ClienteModelo buscaClienteNome(string nome)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM cliente INNER JOIN endereco ON (cliente.cod_endereco = endereco.cod_endereco) WHERE nome_cliente LIKE '%" + nome + "%'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();               
                while (leitor.Read())
                {
                    cm.Cod = Convert.ToInt32(leitor["cod_cliente"].ToString());
                    cm.Nome = leitor["nome_cliente"].ToString();
                    cm.Cpf = leitor["cpf_cliente"].ToString();
                    cm.Rg = leitor["rg_cliente"].ToString();
                    cm.Fone = leitor["fone_cliente"].ToString();
                    cm.Propriedade = leitor["propriedade_cliente"].ToString();

                    cep = leitor["cep_endereco"].ToString();
                    rua = leitor["rua_endereco"].ToString();
                    numero = leitor["numero_endereco"].ToString();
                    bairro = leitor["bairro_endereco"].ToString();
                    cidade = leitor["cidade_endereco"].ToString();
                    obs = leitor["obs_endereco"].ToString();
                }
                return cm;
            }
            catch(MySqlException ex)
            {
                throw new Exception("Erro - "+ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        public ClienteModelo buscaClienteCPF(string cpf)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM cliente INNER JOIN endereco ON (cliente.cod_endereco = endereco.cod_endereco) WHERE cpf_cliente LIKE '%" + cpf + "%'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    cm.Cod = Convert.ToInt32(leitor["cod_cliente"].ToString());
                    Console.WriteLine("CODIGO: " + Convert.ToInt32(leitor["cod_cliente"].ToString()));
                    Console.WriteLine("CODIGO2: " + cm.Cod);
                    cm.Nome = leitor["nome_cliente"].ToString();
                    cm.Cpf = leitor["cpf_cliente"].ToString();
                    cm.Rg = leitor["rg_cliente"].ToString();
                    cm.Fone = leitor["fone_cliente"].ToString();
                    cm.Propriedade = leitor["propriedade_cliente"].ToString();

                    cep = leitor["cep_endereco"].ToString();
                    rua = leitor["rua_endereco"].ToString();
                    numero = leitor["numero_endereco"].ToString();
                    bairro = leitor["bairro_endereco"].ToString();
                    cidade = leitor["cidade_endereco"].ToString();
                    obs = leitor["obs_endereco"].ToString();
                }
                return cm;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        public EnderecoModelo retornaEndereco()
        {
            em.Cep = cep;
            em.Rua = rua;
            em.Numero = numero;
            em.Bairro = bairro;
            em.Cidade = cidade;
            em.Obs = obs;
            return em;
        }
    }
}
