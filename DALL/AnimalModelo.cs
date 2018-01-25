using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class AnimalModelo
    {
        private String cod;
        private String nome;
        private Char sexo;
        private String situacao;
        private String brinco;
        private String codRaca;
        private String codLcal;
        private byte[] foto;

        public string Cod
        {
            get { return cod; }
            set{ cod = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public string Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }
        public string Brinco
        {
            get { return brinco; }
            set { brinco = value; }
        }

        public string CodRaca
        {
            get { return codRaca; }
            set { CodRaca = value; }
        }
        public string CodLocal
        {
            get { return codLcal; }
            set { codLcal = value; }
        }

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }
    }
}

