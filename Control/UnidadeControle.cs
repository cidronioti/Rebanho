using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using MySql.Data.MySqlClient;

namespace Control
{
    public class UnidadeControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        UnidadeModelo um = new UnidadeModelo();

        public void cadastroCategoria(UnidadeModelo u)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO unidade (cod_unidade, nome_unidade, flag)VALUES('" + u.Cod + "','" + u.Nome + "','" + u.Flag + "')";
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

        public void atualizaCategoria(UnidadeModelo u)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE unidade SET NOME_UNIDADE='" + u.Nome + "' WHERE COD_UNIDADE='" + u.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteCategoria(UnidadeModelo u)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM unidade WHERE COD_UNIDADE='" + u.Cod + "'";
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

        public UnidadeModelo buscaCategoriaNome(string nome)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM unidade  WHERE nome_unidade LIKE '%" + nome + "%'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    um.Cod = Convert.ToInt32(leitor["cod_unidade"].ToString());
                    um.Nome = leitor["nome_unidade"].ToString();
                }
                return um;
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
    }
}
