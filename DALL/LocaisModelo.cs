using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class LocaisModelo
    {
        private string cod;
        private string nome;
        private double area;
        private string graminea;
        private string dataAvaliacao;
        private double perda;
        private double suporte;
        private double pastejo;
        private double consumo;
        private int descanso;
        private string obs;

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
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
        public string Graminea
        {
            get { return graminea; }
            set { graminea = value; }
        }
        public string DataAvaliacao
        {
            get{ return dataAvaliacao; }
            set { dataAvaliacao = value; }
        }
        public double Perda
        {
            get { return perda; }
            set { perda = value; }
        }
        public double Suporte
        {
            get { return suporte; }
            set { suporte = value; }
        }
        public double Pastejo
        {
            get { return pastejo; }
            set { pastejo = value; }
        }
        public double Consumo
        {
            get { return consumo; }
            set { consumo = value; }
        }

        public int Descanso
        {
            get { return descanso; }
            set { descanso = value; }
        }
        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }
    }
}
