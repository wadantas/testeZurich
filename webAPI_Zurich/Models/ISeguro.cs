using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAPI_Zurich.Models
{
    public interface ISeguro
    {
        IEnumerable<Seguro> GetAll();
        Seguro Get(string cpf);
        Seguro Add(Seguro seguro);

    }
}
