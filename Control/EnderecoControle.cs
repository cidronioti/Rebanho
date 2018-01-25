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
    public class EnderecoControle
    {
        public int utimoCodigoIserido = 0;
        EnderecoModelo em = new EnderecoModelo();
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        public void cadastroEndereco(EnderecoModelo e)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO endereco (cep_endereco, rua_endereco, numero_endereco, bairro_endereco, cidade_endereco, obs_endereco)VALUES('" + e.Cep + "','" + e.Rua + "','" + e.Numero +"','"+e.Bairro+"','"+e.Cidade+"','"+e.Obs+ "')";
                MySqlCommand comando = new MySqlCommand(insere, conexao);
                comando.ExecuteNonQuery();

                if (comando.LastInsertedId != 0)
                    comando.Parameters.Add(new MySqlParameter("ultimoId", comando.LastInsertedId));
                // Retorna o id do novo rgistro e convert de Int64 para Int32 (int).
                utimoCodigoIserido = Convert.ToInt32(comando.Parameters["@ultimoId"].Value);
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
        public void atualizaEndereco(RacaModelo r)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE raca SET NOME_RACA='" + r.Nome + "',PERIODO_GESTACAO='" + r.PeriodoGestacao + "' WHERE COD_RACA='" + r.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteEndereo(RacaModelo r)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM raca WHERE COD_RACA='" + r.Cod + "'";
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

        public DataTable preencheTabela()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM raca", conexao);

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
    }
}
