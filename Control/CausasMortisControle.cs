using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;

namespace Control
{
    public class CausasMortisControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        CausasMortisModelo cmm = new CausasMortisModelo();

        public void cadastroCausasMortis(CausasMortisModelo c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO causas_mortis (cod_causas_mortis, nome_causa)VALUES('" + c.Cod + "','" + c.Nome + "')";
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

        public void atualizaCausasMortis(CausasMortisModelo c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE causas_mortis SET NOME_CAUSA='" + c.Nome + "' WHERE COD_CAUSAS_MORTIS='" + c.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteCausasMortis(CausasMortisModelo c)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM causas_mortis WHERE COD_CAUSAS_MORTIS='" + c.Cod + "'";
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

        /*public CategoriaModelo buscaCategoriaNome(string nome)
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
        }*/

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

        public DataTable preencheTabela()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM causas_mortis order by nome_causa", conexao);
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
                comando = new MySqlCommand("SELECT * FROM causas_mortis WHERE nome_causa LIKE '%" + parametro + "%'", conexao);
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

        public CausasMortisModelo buscaPorCodigo(string parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM causas_mortis  WHERE cod_causas_mortis = '" + parametro + "'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    cmm.Cod = leitor["cod_causas_mortis"].ToString();
                    cmm.Nome = leitor["nome_causa"].ToString();

                }
                return cmm;
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
