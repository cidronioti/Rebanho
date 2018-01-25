using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class AgrupamentoModelo
    {
        private int codAgrupamento;
        private String dataBaixa;
        private String grauSangue;
        private String grupo;
        private String origem;
        private String destinacao;
        private String pelagem;
        private String dataDesmama;
        private String codPai;
        private String codMae;
        private String regimeAlimentar;
        private String obs;
        private int codCriador;
        private String codAnimal;

        public string DataBaixa
        {
            get { return dataBaixa; }
            set { dataBaixa = value; }
        }

        public string GrauSangue
        {
            get { return grauSangue; }
            set { grauSangue = value; }
        }
        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        public string Origem
        {
            get { return origem; }
            set { origem = value; }
        }

        public string Destinacao
        {
            get { return destinacao; }
            set { destinacao = value; }
        }

        public string Pelagem
        {
            get { return pelagem; }
            set { pelagem = value; }
        }
        public string DataDesmama
        {
            get { return dataDesmama; }
            set { dataDesmama = value; }
        }
        public string CodPai
        {
            get { return codPai; }
            set { codPai = value; }
        }
        public string CodMae
        {
            get { return codMae; }
            set { codMae = value; }
        }
        public string RegimeAlimentar
        {
            get { return regimeAlimentar; }
            set { regimeAlimentar = value; }
        }
        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }
        public int CodCriador
        {
            get { return codCriador; }
            set { codCriador = value; }
        }
        public string CodAnimal
        {
            get { return codAnimal; }
            set { codAnimal = value; }
        }
    }
}
