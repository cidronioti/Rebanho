using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using MySql.Data.MySqlClient;

namespace Control
{
    public class CategoriaControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        CategoriaModelo cm = new CategoriaModelo();

        public void cadastroCategoria(CategoriaModelo c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO categoria (cod_categoria, nome_categoria, flag)VALUES('" + c.Cod + "','" + c.Nome + "','" + c.Flag + "')";
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

        public void atualizaCategoria(CategoriaModelo c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE categoria SET NOME_CATEGORIA='" + c.Nome + "' WHERE COD_CATEGORIA='" + c.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteCategoria(CategoriaModelo c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM categoria WHERE COD_CATEGORIA='" + c.Cod + "'";
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

        public CategoriaModelo buscaCategoriaNome(string nome)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM categoria  WHERE nome_categoria LIKE '%" + nome + "%'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    cm.Cod = Convert.ToInt32(leitor["cod_categoria"].ToString());
                    cm.Nome = leitor["nome_categoria"].ToString();   
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

        public int retornaCodCategoria(string nome)
        {
            int codigoCat = 0;
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                comando = new MySqlCommand("SELECT cod_categoria FROM categoria WHERE nome_categoria = '" + nome + "'", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    codigoCat = Convert.ToInt32(leitor["cod_categoria"]);
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            conexao.Close();
            return codigoCat;
        }

        public string retornaNomeCategoria(int cod)
        {
            string nomeCat = null;
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                comando = new MySqlCommand("SELECT nome_categoria FROM categoria WHERE cod_categoria = '" + cod + "'", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    nomeCat = leitor["nome_categoria"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
            conexao.Close();
            return nomeCat;
        }
    }
}
