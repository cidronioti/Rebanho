using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EnderecoModelo
    {
        private int cod;
        private string cep;
        private string rua;
        private string numero;
        private string bairro;
        private string cidade;
        private string obs;
        private string retorno;

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }
        public string Retorno
        {
            get { return retorno; }
            set { retorno = value; }
        }
    }
}
