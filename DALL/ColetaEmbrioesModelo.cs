using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ColetaEmbrioesModelo
    {
        private String codAnimal;
        private int codFuncionario;
        private String data;
        private float valor;
        private int numEmbrioes;
        private String obs;

        public String CodAnimal
        {
            get { return codAnimal; }
            set { codAnimal = value; }
        }
        public int CodFuncionario
        {
            get { return codFuncionario; }
            set { codFuncionario = value; }
        }
        public String Data
        {
            get { return data; }
            set { data = value; }
        }
        public float Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public int NumEmbrioes
        {
            get { return numEmbrioes; }
            set { numEmbrioes = value; }
        }
        public String Obs
        {
            get { return obs; }
            set { obs = value; }
        }
    }
}
