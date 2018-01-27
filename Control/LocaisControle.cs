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
    class LocaisControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        

        public void cadastroRaca(LocaisModelo l)
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

        public void atualizaRaca(LocaisModelo l)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
               // string atualiza = "UPDATE raca SET NOME_RACA='" + r.Nome + "',PERIODO_GESTACAO='" + r.PeriodoGestacao + "' WHERE COD_RACA='" + r.Cod + "'";
                //comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteRaca(LocaisModelo l)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
               // string atualiza = "DELETE FROM raca WHERE COD_RACA='" + r.Cod + "'";
                //comando = new MySqlCommand(atualiza, conexao);
                //comando.ExecuteNonQuery();
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
