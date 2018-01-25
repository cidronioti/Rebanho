using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
   public class ManipulaData
    {
        public ManipulaData() { }

        public string calculaIdade(string data)// metodo calcula data
        {
            TimeSpan ts;
            double idade;
            string retornoData;

            ts = DateTime.Now.Date - Convert.ToDateTime(data);
            idade = Convert.ToDouble(ts.Days);

            if (idade < 0)
            {
                 retornoData = "0 Dia(s)";
            }

            else if (idade <= 31)//ta certo
            {
                 retornoData = idade + " Dia(s)";
            }
            else if (idade > 31 && idade < 365)
            {
                DateTime DataNascimento = Convert.ToDateTime(data);
                DateTime DataAtual = DateTime.Today;
                TimeSpan tempoCalculado = DataAtual.Subtract(DataNascimento.AddMonths(1).AddDays(1));
                DateTime dataCalculada = new DateTime(tempoCalculado.Ticks);
                string idade2 = string.Format("{1} Mes(es), {2} dia(s)", dataCalculada.Year, dataCalculada.Month, dataCalculada.Day);
                retornoData = idade2;
            }
            else
            {
                DateTime DataNascimento = Convert.ToDateTime(data);
                DateTime DataAtual = DateTime.Today;
                TimeSpan tempoCalculado = DataAtual.Subtract(DataNascimento.AddYears(1).AddMonths(1).AddDays(1));
                DateTime dataCalculada = new DateTime(tempoCalculado.Ticks);
                string idade2 = string.Format("{0} Ano(s), {1} Mes(es), {2} dia(s)", dataCalculada.Year, dataCalculada.Month, dataCalculada.Day);
                retornoData = idade2;
            }
            return retornoData;
        }

       /* public string preveDataParto(string dataCobertura, int periodoGestacao)
        {
            DateTime dataInicial = Convert.ToDateTime(dataCobertura);
            //DateTime prevParto = dataInicial.Add(Convert.ToDateTime(periodoGestacao));
            //return Convert.ToString(prevParto);
        }*/
    }
}
