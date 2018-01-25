using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOdelo
{
    public class CoberturasModelo
    {
        private String codAnimal;
        private int codInseminador;
        private String dataCio;
        private String horaCio;
        private String tipoCobertura;
        private String codReprodutor;
        private String partida;
        private int numDoses;
        private float valorGasto;
        private String obs;
        
        public String CodAnimal
        {
            get { return codAnimal; }
            set { codAnimal = value; }
        }
        public int CodInseminador
        {
            get { return codInseminador; }
            set { codInseminador = value; }
        }
        public String DataCio
        {
            get { return dataCio; }
            set { dataCio = value; }
        }
        public String HoraCio
        {
            get { return horaCio; }
            set { horaCio = value; }
        }
        public String TipoCobertura
        {
            get { return tipoCobertura; }
            set { tipoCobertura = value; }
        }
        public String CodReprodutor
        {
            get { return codReprodutor; }
            set { codReprodutor = value; }
        }
        public String Partida
        {
            get { return partida; }
            set { partida = value; }
        }
        public int NumDoses
        {
            get { return numDoses; }
            set { numDoses = value; }
        }
        public float ValorGasto
        {
            get { return valorGasto; }
            set { valorGasto = value; }
        }
        public String Obs
        {
            get { return obs; }
            set { obs = value; }
        }
    }
}
