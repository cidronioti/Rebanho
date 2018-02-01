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
    public class EventoSanitarioZooControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        EventoSanitarioZooModelo eszm = new EventoSanitarioZooModelo();

        public void cadastroEventoSaniZoo(EventoSanitarioZooModelo e)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO evento_sanitario_zootecnico (cod_sani_zoo, nome_sani_zoo)VALUES('" + e.Cod + "','" + e.Nome + "')";
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

        public void atualizaEventoSaniZoo(EventoSanitarioZooModelo e)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE evento_sanitario_zootecnico SET NOME_SANI_ZOO='" + e.Nome + "' WHERE COD_SANI_ZOO='" + e.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteEventoSaniZoo(EventoSanitarioZooModelo e)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM evento_sanitario_zootecnico WHERE COD_SANI_ZOO='" + e.Cod + "'";
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
                comando = new MySqlCommand("SELECT * FROM evento_sanitario_zootecnico order by nome_sani_zoo", conexao);
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
                comando = new MySqlCommand("SELECT * FROM evento_sanitario_zootecnico WHERE nome_sani_zoo LIKE '%" + parametro + "%'", conexao);
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

        public EventoSanitarioZooModelo buscaPorCodigo(int parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM evento_sanitario_zootecnico  WHERE cod_sani_zoo = '" + parametro + "'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    eszm.Cod = int.Parse(leitor["cod_sani_zoo"].ToString());
                    eszm.Nome = leitor["nome_sani_zoo"].ToString();

                }
                return eszm;
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
