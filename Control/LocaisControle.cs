using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using MySql.Data.MySqlClient;
using System.Data;

namespace Control
{
    public class LocaisControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        LocaisModelo lm = new LocaisModelo();

        public void cadastraLocal(LocaisModelo l)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO local1 (cod_local, nome_local, area_local, graminea, data_avaliacao, suporte, pastejo, perda, consumo, descanso, obs)VALUES('" + l.Cod + "','" + l.Nome + "','" + l.Area + "','" + l.Graminea + "','" + l.DataAvaliacao + "','" + l.Suporte + "','" + l.Pastejo + "','" + l.Perda + "','" + l.Consumo + "','" + l.Descanso + "','" + l.Obs + "')";
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

        public void atualizaLocal(LocaisModelo l)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE local1 SET NOME_LOCAL='" + l.Nome + "',AREA_LOCAL='" + l.Area + "',GRAMINEA='" + l.Graminea + "',DATA_AVALIACAO='" + l.DataAvaliacao + "',SUPORTE='" + l.Suporte + "',PASTEJO='" + l.Pastejo + "',PERDA='" + l.Perda + "',CONSUMO='" + l.Consumo + "',DESCANSO='" + l.Descanso + "',OBS='" + l.Obs + "' WHERE COD_LOCAL='" + l.Cod + "'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteLocal(string parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM local1 WHERE COD_local='" + parametro + "'";
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
                comando = new MySqlCommand("SELECT * FROM local1", conexao);

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
                comando = new MySqlCommand("SELECT cod_local, nome_local FROM local1 WHERE nome_local LIKE '%" + parametro + "%'", conexao);
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

        public LocaisModelo buscaPorCodigo(string parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM local1  WHERE cod_local = '" + parametro + "'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    lm.Cod = leitor["cod_local"].ToString();
                    lm.Nome = leitor["nome_local"].ToString();
                    lm.Area = Convert.ToDouble(leitor["area_local"].ToString());
                    lm.Graminea = leitor["graminea"].ToString();
                    lm.DataAvaliacao = leitor["data_avaliacao"].ToString();
                    lm.Suporte = Convert.ToInt32(leitor["suporte"].ToString());
                    lm.Perda = Convert.ToDouble(leitor["perda"].ToString());
                    lm.Pastejo = Convert.ToDouble(leitor["pastejo"].ToString());
                    lm.Consumo = Convert.ToDouble(leitor["consumo"].ToString());
                    lm.Descanso = Convert.ToInt32(leitor["descanso"].ToString());
                    lm.Obs = leitor["obs"].ToString();
                    
                }
                return lm;
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
