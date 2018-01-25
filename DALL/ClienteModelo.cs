using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClienteModelo
    {
        private int cod;
        private String nome;
        private String cpf;
        private String rg;
        private string fone;
        private String propriedade;
        private int codEndereco;

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public String Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public String Rg
        {
            get { return rg; }
            set { rg = value; }
        }
        public string Fone
        {
            get { return fone; }
            set { fone = value; }
        }
        public String Propriedade
        {
            get { return propriedade; }
            set { propriedade = value; }
        }
        public int CodEndereco
        {
            get { return codEndereco; }
            set { codEndereco = value; }
        }
    }
}
