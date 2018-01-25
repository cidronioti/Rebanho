using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class MedicamentoModelo
    {
        private int cod;
        private string codBarras;
        private string nomeComercial;
        private string principiaAtivo;
        private string indicacoes;
        private double precoCompra;
        private int quantidadePorEmbalagem;
        private int quantidadeDeEmbalagem;
        private int quantidadeMin;
        private string validade;
        private string apresentacao;
        private string laboratorio;
        private string modoUso;
        private string obs;
        private int codCategoria;
        private int codUnidade;
        private string caminhoFoto;
        private byte[] foto;

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        public string CodBarras
        {
            get { return codBarras; }
            set { codBarras = value; }
        }

        public string NomeComercial
        {
            get { return nomeComercial; }
            set { nomeComercial = value; }
        }

        public string PrincipioAtivo
        {
            get { return principiaAtivo; }
            set { principiaAtivo = value; }
        }

        public double PrecoCompra
        {
            get { return precoCompra; }
            set { precoCompra = value; }
        }

        public int QuantidadePorEmbalagem
        {
            get { return quantidadePorEmbalagem; }
            set { quantidadePorEmbalagem = value; }
        }
        public int QuantidadeDeEmbalagem
        {
            get { return quantidadeDeEmbalagem; }
            set { quantidadeDeEmbalagem = value; }
        }
        public int QuantidadeMin
        {
            get { return quantidadeMin; }
            set { quantidadeMin = value; }
        }

        public string Validade
        {
            get { return validade; }
            set { validade = value; }
        }

        public string Apresentacao
        {
            get { return apresentacao; }
            set { apresentacao = value; }
        }

        public string Laboratorio
        {
            get { return laboratorio; }
            set { laboratorio = value; }
        }

        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }

        public int CodUnidade
        {
            get { return codUnidade; }
            set { codUnidade = value; }
        }

        public string Indicacoes
        {
            get { return indicacoes; }
            set { indicacoes = value; }
        }

        public string ModoUso
        {
            get { return modoUso; }
            set { modoUso = value; }
        }

        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }

        public string CaminhoFoto
        {
            get { return caminhoFoto; }
            set { caminhoFoto = value; }
        }

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }
    }
}
