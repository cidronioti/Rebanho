using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class ProprietarioModelo
    {
        private string cod;
        private string nome;

        public string Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }
}
