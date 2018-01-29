using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using System.Data;

namespace Control
{
    public class ProprietarioControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        ProprietarioModelo pm = new ProprietarioModelo();

        public void cadastroProprietario(ProprietarioModelo p)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO criador (cod_criador, nome_criador)VALUES('" + p.Cod + "','" + p.Nome + "')";
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

        public void atualizaProprietario(ProprietarioModelo p )
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE criador SET NOME_CRIADOR='" + p.Nome + "' WHERE COD_CRIADOR='" + p.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteProprietario(string parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM CRIADOR WHERE COD_CRIADOR='" + parametro + "'";
                comando = new MySqlCommand(atualiza, conexao);
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

        public ProprietarioModelo buscaProprietarioNome(string nome)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM driador  WHERE nome_criador LIKE '%" + nome + "%'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    pm.Cod = leitor["cod_unidade"].ToString();
                    pm.Nome = leitor["nome_unidade"].ToString();
                }
                return pm;
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

        public int retornaCodUnidade(string nome)
        {
            int codigoUni = 0;
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                comando = new MySqlCommand("SELECT cod_unidade FROM unidade WHERE nome_unidade = '" + nome + "'", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    codigoUni = Convert.ToInt32(leitor["cod_unidade"]);
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            conexao.Close();
            return codigoUni;
        }

        public string retornaNomeUnidade(int cod)
        {
            string nomeUni = null;
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                comando = new MySqlCommand("SELECT nome_unidade FROM unidade WHERE cod_unidade = '" + cod + "'", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    nomeUni = leitor["nome_Unidade"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            conexao.Close();
            return nomeUni;
        }

        public DataTable preencheTabela()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM criador order by nome_criador", conexao);
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
                comando = new MySqlCommand("SELECT * FROM criador WHERE cod_criador LIKE '%" + parametro + "%' OR nome_criador LIKE '%" + parametro + "%'", conexao);
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

        public ProprietarioModelo buscaPorCodigo(string parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM criador  WHERE cod_criador = '" + parametro + "'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    pm.Cod = leitor["cod_criador"].ToString();
                    pm.Nome = leitor["nome_criador"].ToString();
                    
                }
                return pm;
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

    }
}
