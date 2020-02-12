using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI_Zurich.Models;

namespace webAPI_Zurich.Controllers
{
    public class SeguroController : ApiController
    {
        static readonly ISeguro seguro = new SeguroRep();
        public IEnumerable<Seguro> GetAllSeguros()
        {
            return seguro.GetAll();
        }
        public Seguro GetSeguro(string cpf)
        {
            return seguro.Get(cpf);

        }
        public HttpResponseMessage PostSeguro(Seguro seg)
        {
            seg = seguro.Add(seg);
            var response = Request.CreateResponse<Seguro>(HttpStatusCode.Created, seg);
            string uri = Url.Link("DefaultApi", new { seg });
            response.Headers.Location = new Uri(uri);
            return response;
        }

    }
}
