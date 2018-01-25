using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RacaModelo
    {
        private String cod;
        private String nome;
        private int periodoGestacao;

        public String Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int PeriodoGestacao
        {
            get { return periodoGestacao; }
            set { periodoGestacao = value; }
        }

    }
}
