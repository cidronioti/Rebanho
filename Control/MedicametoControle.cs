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

    public class MedicametoControle
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        private MedicamentoModelo mm = new MedicamentoModelo();
        string caminho = "SERVER=localhost;DATABASE=berromysql;UID=root;PASSWORD=";

        public void cadastroMedicamento(MedicamentoModelo m)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string insere = "INSERT INTO medicamentos (cod_barras, nome_comercial, principio_ativo, data_validade, cod_categoria, apresentacao, quantidade_por_embalagem, quantidade_de_embalagem, cod_unidade, quantidade_min, preco_compra, laboratorio, indicacoes, modo_uso, obs, caminho_foto, foto)VALUES('" + m.CodBarras + "','" + m.NomeComercial + "','" + m.PrincipioAtivo + "','" + m.Validade + "','" + m.CodCategoria + "','" + m.Apresentacao + "','"+ m.QuantidadePorEmbalagem + "','" + m.QuantidadeDeEmbalagem + "','" + m.CodUnidade + "','" + m.QuantidadeMin+ "','" + m.PrecoCompra + "','" + m.Laboratorio + "','" + m.Indicacoes + "','" + m.ModoUso + "','" + m.Obs + "','" + m.CaminhoFoto + "','" + m.Foto + "')";
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

        public void deletarMedicamento(int parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string atualiza = "DELETE FROM medicamentos WHERE cod_medicamento='" + parametro + "'";
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

        public DataTable preencheComboCategoria()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM categoria ORDER BY nome_categoria", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(leitor);
                return dt;
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

        public DataTable preencheComboUnidade()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM unidade ORDER BY nome_unidade", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(leitor);
                return dt;
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
                comando = new MySqlCommand("SELECT  cod_medicamento, cod_barras, nome_comercial FROM medicamentos", conexao);
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
                comando = new MySqlCommand("SELECT cod_medicamento, cod_barras, nome_comercial FROM medicamentos WHERE cod_barras LIKE '%"+parametro+"%' OR nome_comercial LIKE '%" + parametro + "%'", conexao);
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

        public MedicamentoModelo buscaPorCodigo(int parametro)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                comando = new MySqlCommand("SELECT * FROM medicamentos  WHERE cod_medicamento = '" + parametro + "'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    mm.Cod = Convert.ToInt32(leitor["cod_medicamento"].ToString());
                    mm.CodBarras = leitor["cod_barras"].ToString();
                    mm.NomeComercial = leitor["nome_comercial"].ToString();
                    mm.PrincipioAtivo = leitor["principio_ativo"].ToString();
                    mm.Validade = leitor["data_validade"].ToString();
                    mm.Indicacoes = leitor["indicacoes"].ToString();
                    mm.PrecoCompra = Convert.ToDouble(leitor["preco_compra"].ToString());
                    mm.QuantidadePorEmbalagem = Convert.ToInt32(leitor["quantidade_por_embalagem"].ToString());
                    mm.QuantidadeDeEmbalagem = Convert.ToInt32(leitor["quantidade_de_embalagem"].ToString());
                    mm.QuantidadeMin = Convert.ToInt32(leitor["quantidade_min"].ToString());
                    mm.Apresentacao = leitor["apresentacao"].ToString();
                    mm.Laboratorio = leitor["laboratorio"].ToString();
                    mm.ModoUso = leitor["modo_uso"].ToString();
                    mm.Obs = leitor["obs"].ToString();
                    mm.CodCategoria = Convert.ToInt32(leitor["cod_categoria"].ToString());
                    mm.CodUnidade = Convert.ToInt32(leitor["cod_unidade"].ToString());
                    mm.CaminhoFoto = leitor["caminho_foto"].ToString();
                    mm.Foto = (byte[]) leitor["foto"];
                }
                return mm;
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
