using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class CategoriaModelo
    {
        private int cod;
        private string nome;
        private char flag;//servira para diferenciar as categorias listadas no form medicamento de outras categorias como as de insumos por exemplo

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public char Flag
        {
            get { return flag; }
            set { flag = value; }
        }
    }
}
