using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace Control
{
    public class Racaontrole
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";
        RacaModelo rm = new RacaModelo();

        public void cadastroRaca(RacaModelo r)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO raca (cod_raca, nome_raca, periodo_gestacao)VALUES('"+r.Cod+"','"+r.Nome+"','"+r.PeriodoGestacao+"')";
                MySqlCommand comando = new MySqlCommand(insere, conexao);
                comando.ExecuteNonQuery();
                

            }catch(MySqlException ex)
            {
                throw new Exception("Erro - "+ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void atualizaRaca(RacaModelo r)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "UPDATE raca SET NOME_RACA='" + r.Nome + "',PERIODO_GESTACAO='" + r.PeriodoGestacao + "' WHERE COD_RACA='" + r.Cod+"'";
                comando = new MySqlCommand(atualiza, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro - " + ex);
            }
        }

        public void deleteRaca(RacaModelo r)
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
