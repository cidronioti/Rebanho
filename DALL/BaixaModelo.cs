using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class BaixaModelo
    {
        private String codAnimal;
        private int codCausasMortis;
        private float valorAnimal;
        private String dataBaixa;
        private String obs;

        public string CodAnimal
        {
            get { return codAnimal; }
            set { codAnimal = value; }
        }
        public int CodCausasMortis
        {
            get { return codCausasMortis; }
            set { codCausasMortis = value; }
        }
        public float ValorAnimal
        {
            get { return valorAnimal; }
            set { valorAnimal = value; }
        }
        public string DataBaixa
        {
            get { return dataBaixa; }
            set { dataBaixa = value; }
        }
        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }
    }
}
