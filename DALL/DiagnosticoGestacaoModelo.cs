using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DiagnosticoGestacaoModelo
    {
        private String codAnimal;
        private String data;
        private String resultado;
        private String obs;

        public string CodAnimal
        {
            get { return codAnimal; }
            set { codAnimal = value; }
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }
    }
}
