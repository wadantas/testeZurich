using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI_Zurich.Models
{
    public class SeguroRep : ISeguro
    {
        double Margem_Seguranca = 3;
        double Lucro = 5;

        private List<Seguro> seguros = new List<Seguro>();
        public Seguro Add(Seguro seg)
        {
            double valorSeguro = CalculaSeguro(seg);
            DAO.SalvaUsuario(seg, 0);
            DAO.SalvaVeiculo(seg, 0);
            DAO.SalvaSeguro(seg,valorSeguro);
            seguros.Add(seg);
            return seg;
        }
        public double CalculaSeguro(Seguro seg)
        {
            double taxaDeRisco = (seg.Veic.Valor * 5) / (2 * seg.Veic.Valor);
            double premioRisco = taxaDeRisco * seg.Veic.Valor;
            double premioPuro = premioRisco * (1 + (Margem_Seguranca/100));
            double premioComercial = ((Lucro/100)*premioPuro)+premioPuro;

            return premioComercial;
        }
        public Seguro Get(string cpf)
        {
            return seguros.Find(p=>p.Cpf==cpf);
        }
        public IEnumerable<Seguro> GetAll()
        {
            return seguros;
        }
    }
}