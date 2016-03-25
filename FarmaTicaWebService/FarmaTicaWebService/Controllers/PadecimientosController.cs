using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmaTicaWebService.Models;
using FarmaTicaWebService.DataBase;

namespace FarmaTicaWebService.Controllers
{
    public class PadecimientosController : ApiController

    {
        public ClientsAccess DataBaseAccess = new ClientsAccess();

        public List<Padecimiento> getPadecimientos(int id)
        {
            return DataBaseAccess.getPadecimientos(id);
        }
        public Padecimiento Post(Padecimiento padecimiento)
        {
            return DataBaseAccess.addPadecimiento(padecimiento);
        }
    }
}
