using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI_Zurich.Models
{
    public class Seguro
    {
        public string Cpf { get; set; }
        public Veiculo Veic { get; set; }
        public Segurado Segurado { get; set; }
        public int idSeguro { get; set; }
    }
}